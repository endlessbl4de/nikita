using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FurnitureApp
{
    public partial class ClientForm : Form
    {
        private int clientId;

        public ClientForm(int clientId)
        {
            InitializeComponent();
            this.clientId = clientId;
            LoadOrders();
            LoadProducts();
        }

        private void LoadOrders()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT o.OrderID, o.OrderDate, o.TotalPrice, o.Status
                        FROM Orders o
                        WHERE o.ClientID = @ClientID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ClientID", clientId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
                    string query = "SELECT ProductID, ProductName, BasePrice FROM Products";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable productsTable = new DataTable();
                    adapter.Fill(productsTable);
                    dgvProducts.DataSource = productsTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки продуктов: {ex.Message}");
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int productId = (int)dgvProducts.SelectedRows[0].Cells["ProductID"].Value;
                string productName = dgvProducts.SelectedRows[0].Cells["ProductName"].Value.ToString();
                decimal productPrice = (decimal)dgvProducts.SelectedRows[0].Cells["BasePrice"].Value;

                AddOrderForm addOrderForm = new AddOrderForm(clientId, productId, productName, productPrice);
                addOrderForm.ShowDialog();
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Выберите продукт для оформления заказа.");
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
