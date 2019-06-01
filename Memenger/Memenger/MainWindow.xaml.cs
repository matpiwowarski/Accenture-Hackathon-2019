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

namespace Memenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Memecryptor memecryptor = Memecryptor.Instance;
            string memeFolderPath = "../../source/";
            memecryptor.AddMemesFromFolder(memeFolderPath);

            InitializeComponent();
        }
        private void Send_Button_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox.Text.Length > 0 )
            {
                string sentText = TextBox.Text.ToString();
                TextBox.Text = "";

                Memecryptor memecryptor = Memecryptor.Instance;
                memecryptor.Text = sentText;
                memecryptor.FindStringInMemes(sentText);

                for(int i = 0; i < memecryptor.MemesToDisplay.Count; i++)
                {
                    // create empty image

                    BitmapImage src = new BitmapImage();
                    src.BeginInit();
                    string memePath = "C:/Users/Mateusz/Documents/GitHub/Accenture-Hackathon-2019/Memenger/Memenger/source/" + memecryptor.MemesToDisplay[i].FileName.ToString();
                    src.UriSource = new Uri(@memePath);
                    src.EndInit();

                    Image newMeme = new Image
                    {
                        Source = src,
                        Stretch = Stretch.Uniform,
                        Height = 100
                    };


                }
            }
        }

        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            
        }

        private void Send_Button_AccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
        {

        }
    }
}
