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
            while (true)
            {
                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
                var login = Console.ReadLine();
                //var msg1 = proxy.GetData(int.Parse(msg));
                proxy.Login(login);
                Console.WriteLine(proxy.CheckLoggedPeople());
            }

            Console.ReadKey();
        }
    }
}
