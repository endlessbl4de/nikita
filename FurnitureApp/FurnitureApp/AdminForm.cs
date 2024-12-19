using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FurnitureApp
{
    public partial class AdminForm : Form
    {
        public AdminForm(int userId)
        {
            InitializeComponent();
            LoadOrders();
            LoadProducts();
            LoadUsers();
        }

        private void LoadOrders()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT o.OrderID, c.FirstName + ' ' + c.LastName AS ClientName,
                                         o.OrderDate, o.TotalPrice, o.Status
                                     FROM Orders o
                                     JOIN Users c ON o.ClientID = c.UserID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable ordersTable = new DataTable();
                    adapter.Fill(ordersTable);
                    dgvOrders.DataSource = ordersTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}");
            }
        }

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT p.ProductID, p.ProductName, SUM(i.Quantity) AS TotalQuantity
                                     FROM Products p
                                     LEFT JOIN Inventory i ON p.ProductID = i.ProductID
                                     GROUP BY p.ProductID, p.ProductName";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable productsTable = new DataTable();
                    adapter.Fill(productsTable);
                    Products.DataSource = productsTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки товаров: {ex.Message}");
            }
        }

        private void LoadUsers()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT UserID, Role, FirstName, LastName, Phone, Email
                                     FROM Users
                                     WHERE Role IN ('Consultant', 'Client')";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable usersTable = new DataTable();
                    adapter.Fill(usersTable);
                    dgvUsers.DataSource = usersTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}");
            }
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = (int)dgvOrders.SelectedRows[0].Cells["OrderID"].Value;
                EditOrderForm editOrderForm = new EditOrderForm(orderId);
                editOrderForm.ShowDialog();
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Выберите заказ для редактирования.");
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = (int)dgvOrders.SelectedRows[0].Cells["OrderID"].Value;

                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить этот заказ?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = Database.GetConnection())
                        {
                            conn.Open();

                            // Удалить связанные записи в OrderDetails
                            string deleteDetailsQuery = "DELETE FROM OrderDetails WHERE OrderID = @OrderID";
                            SqlCommand deleteDetailsCmd = new SqlCommand(deleteDetailsQuery, conn);
                            deleteDetailsCmd.Parameters.AddWithValue("@OrderID", orderId);
                            deleteDetailsCmd.ExecuteNonQuery();

                            // Удалить сам заказ
                            string deleteOrderQuery = "DELETE FROM Orders WHERE OrderID = @OrderID";
                            SqlCommand deleteOrderCmd = new SqlCommand(deleteOrderQuery, conn);
                            deleteOrderCmd.Parameters.AddWithValue("@OrderID", orderId);
                            deleteOrderCmd.ExecuteNonQuery();

                            MessageBox.Show("Заказ и связанные детали успешно удалены.");
                            LoadOrders();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления заказа: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для удаления.");
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int userId = (int)dgvUsers.SelectedRows[0].Cells["UserID"].Value;
                string role = dgvUsers.SelectedRows[0].Cells["Role"].Value.ToString();

                EditUserForm1 editUserForm = new EditUserForm1(userId, role);
                editUserForm.ShowDialog();
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Выберите пользователя для редактирования.");
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}