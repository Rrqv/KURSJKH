using System.Windows;
using System.Windows.Controls;
using ЖКХ;

namespace ЖКХ
{
    public partial class AdminPage : Page
    {
        private User currentUser;

        // Конструктор с параметром User
        public AdminPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadUserData();
        }

        private void LoadUserData()
        {
            // Здесь можно загрузить данные пользователя
            Title = $"Администратор: {currentUser.Username}";
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AuthorizationPage());
        }
    }
}