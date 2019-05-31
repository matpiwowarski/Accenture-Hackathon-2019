using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memecryptor
{
    // Singleton Pattern 
    class Memecryptor
    {
        private string text; // web page data
        private static readonly Memecryptor instance = new Memecryptor();

        public string Text { get => text; set => text = value; }
        static Memecryptor()
        {
        }
        private Memecryptor()
        {
        }
        public static Memecryptor Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
}
