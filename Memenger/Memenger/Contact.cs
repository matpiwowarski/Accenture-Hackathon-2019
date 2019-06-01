using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memenger
{
    class Contact
    {
        private string name;
        private static readonly Contact instance = new Contact();
        public string Name { get => name; set => name = value; }

        static Contact()
        {
        }
        private Contact()
        {
        }
        public static Contact Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
