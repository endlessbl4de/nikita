using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FurnitureApp
{
    public partial class EditUserForm1 : Form
    {
        private int userId;
        private string role;

        public EditUserForm1(int userId, string role)
        {
            InitializeComponent();
            this.userId = userId;
            this.role = role;
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT FirstName, LastName, Phone, Email FROM Users WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtLastName.Text = reader["LastName"].ToString();
                        txtPhone.Text = reader["Phone"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                    }

                    lblRole.Text = $"Role: {role}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных пользователя: {ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE Users
                        SET FirstName = @FirstName,
                            LastName = @LastName,
                            Phone = @Phone,
                            Email = @Email
                        WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные пользователя успешно обновлены.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения данных пользователя: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
