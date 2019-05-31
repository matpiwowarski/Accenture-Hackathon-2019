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
            var msg = Console.ReadLine();
            var msg1 = proxy.GetData(int.Parse(msg));
            Console.Write(msg1);
            Console.ReadKey();
        }
    }
}
