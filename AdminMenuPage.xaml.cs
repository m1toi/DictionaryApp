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
    /// Interaction logic for AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        public AdminMenuPage()
        {
            InitializeComponent();
        }

        private void AddWordBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWordPage addWordPage = new AddWordPage();
            this.NavigationService.Navigate(addWordPage);
        }

        private void DeleteWordBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteWordPage deleteWordPage = new DeleteWordPage();
            this.NavigationService.Navigate(deleteWordPage);
        }

        private void ModifyWordBtn_Click(object sender, RoutedEventArgs e)
        {
            ModifyWordPage modifyWordPage = new ModifyWordPage();
            this.NavigationService.Navigate(modifyWordPage);
        }
    }
}
