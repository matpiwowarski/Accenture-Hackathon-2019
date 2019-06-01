using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memenger
{
    // Singleton Pattern 
    class User
    {
        private string name;
        private static readonly User instance = new User();
        public string Name { get => name; set => name = value; }

        static User()
        {
        }
        private User()
        {
        }
        public static User Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
