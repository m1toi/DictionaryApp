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
    /// Interaction logic for DeleteWordPage.xaml
    /// </summary>
    public partial class DeleteWordPage : Page
    {
        
        public DeleteWordPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Word word in GlobalUtilities.dictionaryManager.words)
            {
                if (word.Name == txtDeleteWord.Text)
                {
                    GlobalUtilities.dictionaryManager.DeleteWord(word);
                    MessageBox.Show("Word deleted successfully");
                    break;
                }
            }
        }
    }
}
