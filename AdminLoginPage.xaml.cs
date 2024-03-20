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
    /// Interaction logic for AdminLoginPage.xaml
    /// </summary>
    public partial class AdminLoginPage : Page
    {
        public AdminLoginPage()
        {
            InitializeComponent();
        }
        Admin admin = new Admin("", "");
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (admin.Username == UserTbox.Text && admin.Password == PassTbox.Password)
            {
                AdminMenuPage adminMenuPage = new AdminMenuPage();                             
                this.NavigationService.Navigate(adminMenuPage);
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }   
            
        }
        
    }
}
