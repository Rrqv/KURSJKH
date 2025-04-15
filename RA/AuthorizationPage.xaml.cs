using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;

namespace ЖКХ
{
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(loginTextBox.Text) ||
                string.IsNullOrWhiteSpace(passwordText.Password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string passwordHash = GetHash(passwordText.Password);

            try
            {
                using (var db = new Entities1())
                {
                    var user = db.Users
                        .Include(u => u.Role) // Если нужно загрузить связанные данные
                        .FirstOrDefault(u => u.Username == loginTextBox.Text &&
                                           u.Password == passwordHash);

                    if (user == null)
                    {
                        MessageBox.Show("Неверный логин или пароль", "Ошибка",
                                      MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    Page nextPage;
                    switch (user.RoleID)
                    {
                        case 1: // Администратор
                            nextPage = new AdminPage(user);
                            break;
                        case 2: // Жилец
                            nextPage = new ResidentPage(user);
                            break;
                        case 3: // Бухгалтер
                            nextPage = new AccountantPage(user);
                            break;
                        default:
                            MessageBox.Show("Неизвестная роль пользователя", "Ошибка",
                                          MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                    }

                    NavigationService.Navigate(nextPage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}",
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationWindow());
        }

        public static string GetHash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}