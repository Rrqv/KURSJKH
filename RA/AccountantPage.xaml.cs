using System.Windows;
using System.Windows.Controls;
using ЖКХ;

namespace ЖКХ
{
    public partial class AccountantPage : Page
    {
        private User currentUser;

        public AccountantPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadUserData();
        }

        private void LoadUserData()
        {
            Title = $"Бухгалтер: {currentUser.Username}";
            // Дополнительная загрузка данных для бухгалтера
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AuthorizationPage());
        }
    }
}