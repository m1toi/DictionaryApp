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
    /// Interaction logic for AddWordPage.xaml
    /// </summary>
    public partial class AddWordPage : Page
    {
        
        public AddWordPage()
        {
            InitializeComponent();
           

            string[] StringArrayCategory = GlobalUtilities.dictionaryManager.dictionary.Keys.ToArray();
            tb.ItemsSource = StringArrayCategory;


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

        private void AddWord_Click(object sender, RoutedEventArgs e)    
        {
            string wordName = txtWordName.Text;
            string description = txtDescription.Text;
            string category = tb.Text;
            string imagePath = "";

            // Validate inputs
            if (string.IsNullOrEmpty(wordName) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Get image path
            if (SelectedImage.Source != null)
            {
                imagePath = ((BitmapImage)SelectedImage.Source).UriSource.LocalPath;
            }
            else
            {                
                imagePath = "";
            }

            // Create word object
            Word newWord = new Word { Name = wordName, Description = description, Category = category, ImagePath = imagePath };

            // Add word to dictionary
            GlobalUtilities.dictionaryManager.AddWord(newWord);

            // Show success message
            MessageBox.Show("Word added successfully.");

            // Clear input fields
            txtWordName.Text = "";
            txtDescription.Text = "";
            tb.Text = "";
            SelectedImage.Source = null;

        }


    }
}
