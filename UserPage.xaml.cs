using System;
using System.IO;

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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        
        public UserPage()
        {
            InitializeComponent();

            string[] StringArrayCategory =GlobalUtilities.dictionaryManager.dictionary.Keys.ToArray();
            CategoryBox.ItemsSource = StringArrayCategory;
            
            
            string[] StringArray = GlobalUtilities.dictionaryManager.words.Select(x => x.Name).ToArray();
            tb.ItemsSource = StringArray;
        }

        private void CategoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var typeItem = CategoryBox.SelectedItem;

            if (typeItem != null)
            {
                string selectedCategory = typeItem.ToString();
                string[] StringArray = GlobalUtilities.dictionaryManager.dictionary[selectedCategory].Select(x => x.Name).ToArray();
                tb.ItemsSource = StringArray;
            }
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
               foreach (Word word in GlobalUtilities.dictionaryManager.words)
                {
                   if (word.Name == tb.Text)
                   {
                       WordName.Content = word.Name;
                       WordDescription.Text = word.Description;
                        if (word.ImagePath != "")
                        {
                            string imagePath = System.IO.Path.Combine( word.ImagePath);
                            ImageControl.Source = new BitmapImage(new Uri(imagePath));
                        }
                        else
                        {
                            string imagePath = System.IO.Path.Combine(Environment.CurrentDirectory, "C://Users//alexg//Downloads//MVP_No_Image.png");
                            ImageControl.Source = new BitmapImage(new Uri(imagePath));
                        }
                    }
                }
               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Word word in GlobalUtilities.dictionaryManager.words)
            {
                if (word.Name == tb.Text)
                {
                    WordName.Content = word.Name;
                    WordDescription.Text = word.Description;
                    if (word.ImagePath != "")
                    {
                        string imagePath = System.IO.Path.Combine(word.ImagePath);
                        ImageControl.Source = new BitmapImage(new Uri(imagePath));
                    }
                    else
                    {
                        string imagePath = System.IO.Path.Combine(Environment.CurrentDirectory, "C://Users//alexg//Downloads//MVP_No_Image.png");
                        ImageControl.Source = new BitmapImage(new Uri(imagePath));
                    }
                }
            }

        }
    }
}