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
        ServiceReference1.Service1Client proxy;

        public MainWindow()
        {
            Memecryptor memecryptor = Memecryptor.Instance;
            User user = User.Instance;
            Contact contact = Contact.Instance;
            proxy  = new ServiceReference1.Service1Client();
            string memeFolderPath = "../../source/";
            memecryptor.AddMemesFromFolder(memeFolderPath);

            InitializeComponent();
        }

        private void SendMeme(string resourceName)
        {
            if (UserImage1.Source == null && ContactImage1.Source == null)
            {
                UserImage1.Source = (ImageSource)FindResource(resourceName);
            }
            else if(UserImage2.Source == null && ContactImage2.Source == null)
            {
                UserImage2.Source = (ImageSource)FindResource(resourceName);
            }
            else if (UserImage3.Source == null && ContactImage3.Source == null)
            {
                UserImage3.Source = (ImageSource)FindResource(resourceName);
            }
            else
            {
                ContactImage1.Source = ContactImage2.Source;
                ContactImage2.Source = ContactImage3.Source;

                UserImage1.Source = UserImage2.Source;
                UserImage2.Source = UserImage3.Source;
                UserImage3.Source = (ImageSource)FindResource(resourceName);
            }
        }
        private void Send_Button_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox.Text.Length > 0 )
            {
                string sentText = TextBox.Text.ToString();
                TextBox.Text = "";

                Memecryptor memecryptor = Memecryptor.Instance;

                string resourceName = memecryptor.PutWordGetMeme(sentText);


     
                proxy.Login(Username_Label.Text.ToString());
                proxy.SendMessage(sentText, Username_Label.Text.ToString(), ContactNameLabel.Text.ToString());



                SendMeme(resourceName);
            }
        }


        private void ContactNameLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            Contact contact = Contact.Instance;
            contact.Name = ContactNameLabel.Text.ToString();
        }

        private void Username_Label_TextChanged(object sender, TextChangedEventArgs e)
        {
            User user = User.Instance;
            user.Name = Username_Label.Text.ToString();
        }
    }
}
