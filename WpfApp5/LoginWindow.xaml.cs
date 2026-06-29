using System;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApp5
{
    public partial class LoginWindow : Window
    {
        public static int CurrentUserId = 0;
        public static string CurrentUserName = "";

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                txtError.Text = "❌ Введите логин и пароль!";
                txtError.Visibility = Visibility.Visible;
                return;
            }

            // ⚠️ ВСТАВЬ СВОЮ СТРОКУ ПОДКЛЮЧЕНИЯ
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BarbershopDB;Integrated Security=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "SELECT Id, FullName FROM Users WHERE Username = @login AND Password = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        CurrentUserId = Convert.ToInt32(reader["Id"]);
                        CurrentUserName = reader["FullName"].ToString();

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        txtError.Text = "❌ Неверный логин или пароль!";
                        txtError.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception ex)
            {
                txtError.Text = $"❌ Ошибка: {ex.Message}";
                txtError.Visibility = Visibility.Visible;
            }
        }
    }
}