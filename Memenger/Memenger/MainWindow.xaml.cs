using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
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
using System.Windows.Threading;

namespace Memenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static DispatcherTimer _timer = new DispatcherTimer();
        ServiceReference1.Service1Client proxy;
        public static DispatcherTimer Timer { get => _timer; set => _timer = value; }

        public MainWindow()
        {
            Timer.Tick += new EventHandler(update);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();

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
            try
            {
                string oneNumberHour = "";
                if (DateTime.Now.Hour.ToString().Count() < 2)
                    oneNumberHour = "0";

                string oneNumberMinute = "";
                if (DateTime.Now.Minute.ToString().Count() < 2)
                    oneNumberMinute = "0";
                string time = oneNumberHour + DateTime.Now.Hour.ToString() + ":" + oneNumberMinute + DateTime.Now.Minute.ToString();

                if (UserImage1.Source == null && ContactImage1.Source == null)
                {
                    UserImage1.Source = (ImageSource)FindResource(resourceName);
                    UserDate1.Content = time; 
                }
                else if (UserImage2.Source == null && ContactImage2.Source == null)
                {
                    UserImage2.Source = (ImageSource)FindResource(resourceName);
                    UserDate2.Content = time; 
                }
                else if (UserImage3.Source == null && ContactImage3.Source == null)
                {
                    UserImage3.Source = (ImageSource)FindResource(resourceName);
                    UserDate3.Content = time; 
                }
                else
                {
                    ContactImage1.Source = ContactImage2.Source;
                    ContactDate1.Content = ContactDate2.Content;
                    ContactImage2.Source = ContactImage3.Source;
                    ContactDate2.Content = ContactDate3.Content;
                    if (ContactImage3 != null)
                        ContactImage3.Source = null;
                    if (ContactDate3 != null)
                        ContactDate3.Content = null; 

                    UserImage1.Source = UserImage2.Source;
                    UserDate1.Content = UserDate2.Content;
                    UserImage2.Source = UserImage3.Source;
                    UserDate2.Content = UserDate3.Content;
                    UserImage3.Source = (ImageSource)FindResource(resourceName);
                    UserDate3.Content = time;
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void Send_Button_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox.Text.Length > 0 )
            {
                string sentText = TextBox.Text.ToString();
                sentText=sentText.Replace(' ', '_');
                TextBox.Text = "";

                Memecryptor memecryptor = Memecryptor.Instance;

                string resourceName = memecryptor.PutWordGetMeme(sentText);


     
                proxy.Login(Contact_Label.Text.ToString());
                proxy.SendMessage(sentText, Contact_Label.Text.ToString(), Contact_Label.Text.ToString());



                SendMeme(resourceName);
            }
        }

        void update(object sender, EventArgs e)
        {
            string fileName = proxy.GetMessage(Username_Label.Text.ToString());

            Memecryptor memecryptor = Memecryptor.Instance;
            string oneNumberHour = "";
            if (DateTime.Now.Hour.ToString().Count() < 2)
                oneNumberHour = "0";

            string oneNumberMinute = "";
            if (DateTime.Now.Minute.ToString().Count() < 2)
                oneNumberMinute = "0";

            string time = oneNumberHour + DateTime.Now.Hour.ToString() + ":" + oneNumberMinute  + DateTime.Now.Minute.ToString();

            //fileName = memecryptor.PutWordGetMeme(fileName);

            //string fileName = "";
            if (fileName != "")
            {
                fileName = memecryptor.PutWordGetMeme(fileName);
                try
                { 
                    if (UserImage1.Source == null && ContactImage1.Source == null)
                    {
                        ContactImage1.Source = (ImageSource)FindResource(fileName);
                        ContactDate1.Content = time; 
                    }
                    else if (UserImage2.Source == null && ContactImage2.Source == null)
                    {
                        ContactImage2.Source = (ImageSource)FindResource(fileName);
                        ContactDate2.Content = time; 
                    }
                    else if (UserImage3.Source == null && ContactImage3.Source == null)
                    {
                        ContactImage3.Source = (ImageSource)FindResource(fileName);
                        ContactDate3.Content = time; 
                    }
                    else
                    {
                        UserImage1.Source = UserImage2.Source;
                        UserDate1.Content = UserDate2.Content; 
                        UserImage2.Source = UserImage3.Source;
                        UserDate2.Content = UserDate3.Content; 
                        if (UserImage3 != null)
                            UserImage3.Source = null;
                        if (UserDate3 != null)
                            UserDate3.Content = null;

                        ContactImage1.Source = ContactImage2.Source;
                        ContactDate1.Content = ContactDate2.Content;
                        ContactImage2.Source = ContactImage3.Source;
                        ContactDate2.Content = ContactDate3.Content;
                        ContactImage3.Source = (ImageSource)FindResource(fileName);
                        ContactDate3.Content = time; 
                    }
                }
                catch(Exception)
                {

                }
                fileName = "";
            }
        }

        private void ContactNameLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            clearChat();
            Contact contact = Contact.Instance;
            contact.Name = Contact_Label.Text.ToString();
        }

        private void Username_Label_TextChanged(object sender, TextChangedEventArgs e)
        {
            clearChat();
            User user = User.Instance;
            user.Name = Contact_Label.Text.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        void clearChat()
        {
            if(ContactImage1 != null)
                ContactImage1.Source = null;
            if (ContactImage2 != null)
                ContactImage2.Source = null;
            if (ContactImage3 != null)
                ContactImage3.Source = null;

            if(UserImage1 != null)
                UserImage1.Source = null;
            if (UserImage2 != null)
                UserImage2.Source = null;
            if (UserImage3 != null)
                UserImage3.Source = null;
        }

        private void RomekButton_Click(object sender, RoutedEventArgs e)
        {
            Contact_Label.Text = "Romek";
        }

        private void MichalButton_Click(object sender, RoutedEventArgs e)
        {
            Contact_Label.Text = "Michal";
        }

        private void MateuszButton_Click(object sender, RoutedEventArgs e)
        {
            Contact_Label.Text = "Mateusz";
        }

        private void PawelButton_Click(object sender, RoutedEventArgs e)
        {
            Contact_Label.Text = "Pawel";
        }
    }
}
