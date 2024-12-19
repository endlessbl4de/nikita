using System;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FurnitureApp
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Получение данных из полей формы
            string role = cmbRole.SelectedItem?.ToString() ?? "";
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string phone = txtPhone.Text.Trim();

            // Проверка на заполненность обязательных полей
            if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Все поля обязательны для заполнения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка формата email
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Введите корректный адрес электронной почты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Хэширование пароля
            string hashedPassword = HashPassword(password);

            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Проверка существования пользователя с таким email
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@Email", email);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Пользователь с таким Email уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Добавление нового пользователя
                    string insertUserQuery = @"
                        INSERT INTO Users (Role, FirstName, LastName, Phone, Email, PasswordHash) 
                        OUTPUT INSERTED.UserID 
                        VALUES (@Role, @FirstName, @LastName, @Phone, @Email, @Password)";
                    SqlCommand userCmd = new SqlCommand(insertUserQuery, conn);
                    userCmd.Parameters.AddWithValue("@Role", role);
                    userCmd.Parameters.AddWithValue("@FirstName", firstName);
                    userCmd.Parameters.AddWithValue("@LastName", lastName);
                    userCmd.Parameters.AddWithValue("@Phone", phone);
                    userCmd.Parameters.AddWithValue("@Email", email);
                    userCmd.Parameters.AddWithValue("@Password", hashedPassword);

                    int userId = (int)userCmd.ExecuteScalar();

                    if (role == "Client")
                    {
                        string insertClientQuery = "INSERT INTO Clients (ClientID, Address) VALUES (@ClientID, @Address)";
                        SqlCommand clientCmd = new SqlCommand(insertClientQuery, conn);
                        clientCmd.Parameters.AddWithValue("@ClientID", userId);
                        clientCmd.Parameters.AddWithValue("@Address", ""); // Или пустой адрес, если не указан
                        clientCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes); // Возвращаем хэшированный пароль
            }
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Consultant");
            cmbRole.Items.Add("Client");
            cmbRole.SelectedIndex = 0;
        }
    }
}
