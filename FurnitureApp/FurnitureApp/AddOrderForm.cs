using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FurnitureApp
{
    public partial class AddOrderForm : Form
    {
        private int clientId;
        private int productId;
        private string productName;
        private decimal productPrice;

        public AddOrderForm(int clientId, int productId, string productName, decimal productPrice)
        {
            InitializeComponent();
            this.clientId = clientId;
            this.productId = productId;
            this.productName = productName;
            this.productPrice = productPrice;

            lblProductName.Text = $"Название продукта: {productName}";
            lblProductPrice.Text = $"Цена за шт.: {productPrice:C}";
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            int quantity = (int)nudQuantity.Value;
            decimal totalPrice = productPrice * quantity;

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    // Вставка заказа
                    string queryOrder = @"
                        INSERT INTO Orders (ClientID, ConsultantID, OrderDate, TotalPrice, Status)
                        VALUES (@ClientID, @ConsultantID, @OrderDate, @TotalPrice, 'Новый');
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdOrder = new SqlCommand(queryOrder, conn);
                    cmdOrder.Parameters.AddWithValue("@ClientID", clientId);
                    cmdOrder.Parameters.AddWithValue("@ConsultantID", DBNull.Value); // Нет консультанта
                    cmdOrder.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    cmdOrder.Parameters.AddWithValue("@TotalPrice", totalPrice);

                    int orderId = Convert.ToInt32(cmdOrder.ExecuteScalar());

                    // Вставка деталей заказа
                    string queryOrderDetail = @"
                        INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price)
                        VALUES (@OrderID, @ProductID, @Quantity, @Price)";

                    SqlCommand cmdOrderDetail = new SqlCommand(queryOrderDetail, conn);
                    cmdOrderDetail.Parameters.AddWithValue("@OrderID", orderId);
                    cmdOrderDetail.Parameters.AddWithValue("@ProductID", productId);
                    cmdOrderDetail.Parameters.AddWithValue("@Quantity", quantity);
                    cmdOrderDetail.Parameters.AddWithValue("@Price", productPrice);

                    cmdOrderDetail.ExecuteNonQuery();

                    MessageBox.Show("Заказ успешно оформлен!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка оформления заказа: {ex.Message}");
            }
        }
    }
}
