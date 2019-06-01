using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            Console.Write("Podaj login: ");
            var login = Console.ReadLine();
            proxy.Login(login);
            Console.WriteLine(proxy.CheckLoggedPeople());
            Console.Write("Podaj odbjorce: ");

            var reciever = Console.ReadLine();


            while (true)
            {
                Console.Write("Podaj wjadomosc: ");

                var msg = Console.ReadLine();
                proxy.SendMessage(msg, login, reciever);
                Console.Write("Otrzymana wjadomosc: ");

                Console.WriteLine(proxy.GetMessage(login));


            }

            Console.ReadKey();
        }
    }
}
