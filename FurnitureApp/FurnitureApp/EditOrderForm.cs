using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FurnitureApp
{
    public partial class EditOrderForm : Form
    {
        private int orderId;

        public EditOrderForm(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT o.OrderID, o.TotalPrice, o.Status, c.FirstName + ' ' + c.LastName AS ClientName
                        FROM Orders o
                        JOIN Users c ON o.ClientID = c.UserID
                        WHERE o.OrderID = @OrderID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblOrderID.Text = $"ID заказа: {reader["OrderID"]}";
                        lblClientName.Text = $"Клиент: {reader["ClientName"]}";
                        txtTotalPrice.Text = reader["TotalPrice"].ToString();
                        cmbStatus.SelectedItem = reader["Status"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки деталей заказа: {ex.Message}");
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE Orders
                        SET TotalPrice = @TotalPrice, Status = @Status
                        WHERE OrderID = @OrderID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TotalPrice", decimal.Parse(txtTotalPrice.Text));
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@OrderID", orderId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Изменения успешно сохранены.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}");
            }
        }
    }
}
