using System.Windows;
using System.Windows.Controls;
using ЖКХ;

namespace ЖКХ
{
    public partial class ResidentPage : Page
    {
        private User currentUser;

        public ResidentPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadUserData();
        }

        private void LoadUserData()
        {
            Title = $"Жилец: {currentUser.Username}";
            // Дополнительная загрузка данных жильца
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AuthorizationPage());
        }
    }
}