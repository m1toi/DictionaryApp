using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DictionaryApp
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminLoginPage adminLoginPage = new AdminLoginPage();
            this.NavigationService.Navigate(adminLoginPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserPage userPage = new UserPage();
            this.NavigationService.Navigate(userPage);

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GamePage gamePage = new GamePage();
            this.NavigationService.Navigate(gamePage);  
        }
    }
}
