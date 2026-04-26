using System.Windows;
using System.Windows.Controls;

namespace DesktopDemo
{
    public partial class HomeScreen : Page
    {
        public HomeScreen(string userName)
        {
            InitializeComponent();
            WelcomeText.Text = GetWelcomeMessage(userName);
        }

        public static string GetWelcomeMessage(string userName)
        {
            return "Dobrodošao, " + userName;
        }

        private void CreateRequest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateRequestScreen());
        }

        private void MojiZahtjevi_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RequestsScreen());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Da li ste sigurni da se želite odjaviti?",
                "Logout",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new LoginScreen());
            }
        }
    }
}