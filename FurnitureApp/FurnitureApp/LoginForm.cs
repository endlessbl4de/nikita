using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FurnitureApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Получение введенных данных
            string email = txtEmail?.Text.Trim();
            string password = txtPassword?.Text.Trim();

            // Проверяем, заполнены ли все обязательные поля
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Подключение к базе данных
            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Хэшируем введённый пароль перед проверкой
                    string hashedPassword = HashPassword(password);

                    // Запрос для проверки логина и пароля
                    string query = "SELECT UserID, Role FROM Users WHERE Email = @Email AND PasswordHash = @PasswordHash";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int userId = (int)reader["UserID"];
                        string role = reader["Role"].ToString();

                        // Открытие соответствующей формы
                        this.Hide();
                        OpenRoleForm(userId, role);
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OpenRoleForm(int userId, string role)
        {
            // Открываем соответствующую форму в зависимости от роли
            Form roleForm = null;

            if (role == "Admin")
            {
                roleForm = new AdminForm(userId);
            }
            else if (role == "Consultant")
            {
                roleForm = new ConsultantForm(userId);
            }
            else if (role == "Client")
            {
                roleForm = new ClientForm(userId);
            }

            if (roleForm != null)
            {
                roleForm.Show();
            }
            else
            {
                MessageBox.Show("Неизвестная роль пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show(); // Возвращаемся к форме входа
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes); // Возвращаем хэшированный пароль
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            TestDatabaseConnection();
        }

        private void TestDatabaseConnection()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    MessageBox.Show("Соединение с базой данных успешно!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Открытие формы регистрации
            this.Hide();
            RegistrationForm regForm = new RegistrationForm();
            regForm.Show();
        }
    }
}
