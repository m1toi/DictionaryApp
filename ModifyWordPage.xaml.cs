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
using Microsoft.Win32;

namespace DictionaryApp
{
    /// <summary>
    /// Interaction logic for ModifyWordPage.xaml
    /// </summary>
    
    
    public partial class ModifyWordPage : Page
    {
        
        public ModifyWordPage()
        {
            InitializeComponent();

            string[] StringArray = GlobalUtilities.dictionaryManager.words.Select(x => x.Name).ToArray();
            tb.ItemsSource = StringArray;


        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                foreach (Word word in GlobalUtilities.dictionaryManager.words)
                {
                    if (word.Name == tb.Text)
                    {
                        txtDescription.Text = word.Description;
                        txtCategory.Text = word.Category;
                        if (word.ImagePath != "")
                        {
                            SelectedImage.Source = new BitmapImage(new Uri(word.ImagePath));
                        }
                        else if(word.ImagePath == "")
                        {
                            SelectedImage.Source = new BitmapImage(new Uri("C:/Users/alexg/Downloads/MVP_No_Image.png"));
                        }
                    }
                }
            }
        }

        private void AddWord_Click(object sender, RoutedEventArgs e)
        {
            foreach(Word word in GlobalUtilities.dictionaryManager.words)
            {
                if (word.Name == tb.Text && txtDescription.Text!="" && txtCategory.Text!="")
                {
                    //word.Description = txtDescription.Text;
                    //word.Category = txtCategory.Text;
                    //word.ImagePath = SelectedImage.Source.ToString();
                    
                    GlobalUtilities.dictionaryManager.ModifyWord(word, txtDescription.Text, txtCategory.Text, SelectedImage.Source.ToString());
                    MessageBox.Show("Word modified successfully");
                    break;

                }
            }
        }

        private void SelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Get the selected file name and display it
                string selectedFileName = openFileDialog.FileName;

                try
                {
                    // Display the selected image in the Image control
                    BitmapImage bitmapImage = new BitmapImage(new Uri(selectedFileName));
                    SelectedImage.Source = bitmapImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }
    }
}
