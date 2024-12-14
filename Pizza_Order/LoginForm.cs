using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace Pizza_Order
{
    public partial class LoginForm : Form
    {
        // Строка подключения к базе данных MySQL
        private string connectionString = "Server=localhost;Database=pizza;Uid=root;Pwd=;";

        public LoginForm()
        {
            InitializeComponent();
        }

        // Обработчик кнопки входа
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsernameLogin.Text;
            string password = txtPasswordLogin.Text;

            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Вход выполнен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Открыть основное окно приложения
                PizzaOrderForm orderForm = new PizzaOrderForm();
                orderForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик кнопки регистрации
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsernameRegister.Text;
            string password = txtPasswordRegister.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Имя пользователя и пароль не должны быть пустыми.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsUsernameExists(username))
            {
                MessageBox.Show("Пользователь с таким именем уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Добавляем пользователя в базу данных
            RegisterUser(username, password);
            MessageBox.Show("Регистрация успешно выполнена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Переключаемся на вкладку авторизации
            tabControl.SelectedTab = tabPageLogin;
        }

        // Проверка на существование имени пользователя в базе данных
        private bool IsUsernameExists(string username)
        {
            bool exists = false;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                exists = count > 0;
            }
            return exists;
        }

        // Регистрация пользователя в базе данных
        private void RegisterUser(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO users (username, password) VALUES (@username, @password)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // В реальном приложении, пароль должен быть зашифрован
                cmd.ExecuteNonQuery();
            }
        }

        // Аутентификация пользователя
        private bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // В реальном приложении, пароль должен быть зашифрован
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                isAuthenticated = count > 0;
            }
            return isAuthenticated;
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
