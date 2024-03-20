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
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        int count = 0;
        int i = 0;
        public GamePage()
        {
            InitializeComponent();

           
            string imagePathOrDescription = GlobalUtilities.dictionaryManager.randomWords[0].GetImagePathOrWordDescription();

            if (imagePathOrDescription == GlobalUtilities.dictionaryManager.randomWords[0].Description)
            {
                txtWordDescription.Text = GlobalUtilities.dictionaryManager.randomWords[0].Description;
            }
            else if (imagePathOrDescription.Equals(GlobalUtilities.dictionaryManager.randomWords[0].ImagePath) && !GlobalUtilities.dictionaryManager.randomWords[0].ImagePath.Equals("") 
                && !GlobalUtilities.dictionaryManager.randomWords[0].ImagePath.Equals("C://Users//alexg//Downloads//MVP_No_Image.png") )
            {
                img.Source = new BitmapImage(new Uri(GlobalUtilities.dictionaryManager.randomWords[0].ImagePath));
            }
            else
            {
                txtWordDescription.Text = GlobalUtilities.dictionaryManager.randomWords[0].Description;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (i >= GlobalUtilities.dictionaryManager.randomWords.Count)
            {
                MessageBox.Show("You have reached the end of the game!");
                return;
            }

            if (txtAnswer.Text == GlobalUtilities.dictionaryManager.randomWords[i].Name)
            {
                    count++;
                    counter.Content = count +"/5";
                    correctOrIncorrect.Content = "Correct!";
            }
            else
            {
                    correctOrIncorrect.Content = "Incorrect! Right answer: " + GlobalUtilities.dictionaryManager.randomWords[i].Name;
            }

            i++;

            if (i == 5) 
            {
                MessageBox.Show("You got " + count + " out of 5 correct!");
                GlobalUtilities.dictionaryManager.randomWords = GlobalUtilities.dictionaryManager.Get5RandomWords();
                MainMenuPage mainPage = new MainMenuPage();
                this.NavigationService.Navigate(mainPage);
            }

            string imagePathOrDescription = GlobalUtilities.dictionaryManager.randomWords[i].GetImagePathOrWordDescription();

            if (imagePathOrDescription == GlobalUtilities.dictionaryManager.randomWords[i].Description)
            {
                txtWordDescription.Text = GlobalUtilities.dictionaryManager.randomWords[i].Description;
                img.Source = null;  
            }
            else if (imagePathOrDescription.Equals(GlobalUtilities.dictionaryManager.randomWords[i].ImagePath) && !GlobalUtilities.dictionaryManager.randomWords[i].ImagePath.Equals("")
                && !GlobalUtilities.dictionaryManager.randomWords[i].ImagePath.Equals("C://Users//alexg//Downloads//MVP_No_Image.png"))
            {
                img.Source = new BitmapImage(new Uri(GlobalUtilities.dictionaryManager.randomWords[i].ImagePath));
                txtWordDescription.Text = "";
            }
            else
            {
                txtWordDescription.Text = GlobalUtilities.dictionaryManager.randomWords[i].Description;
                img.Source = null;
            }

            

          

        }
    }
}
