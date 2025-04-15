using System.Windows;

namespace ЖКХ
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // При запуске сразу переходим на страницу авторизации
            MainFrame.Navigate(new AuthorizationPage());
        }
    }
}