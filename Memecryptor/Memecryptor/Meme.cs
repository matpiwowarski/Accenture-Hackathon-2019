using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memecryptor
{
    class Meme
    {
        private string fileName;
        public string FileName { get => fileName; set => fileName = value; }

        public Meme(string fileName)
        {
            this.fileName = fileName;
        }
    }
}
