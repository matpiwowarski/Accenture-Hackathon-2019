using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memenger
{
    // Singleton Pattern 
    class Memecryptor
    {
        private string text; // web page data
        private List<Meme> memeList = new List<Meme>(); // memes with file names
        private List<Meme> memesToDisplay = new List<Meme>(); // memes with file names
        private static readonly Memecryptor instance = new Memecryptor();

        public string Text { get => text; set => text = value; }
        public List<Meme> MemeList { get => memeList; set => memeList = value; }
        public List<Meme> MemesToDisplay { get => memesToDisplay; set => memesToDisplay = value; }

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

        public void AddMeme(Meme meme)
        {
            memeList.Add(meme);
        }

        public void AddMemes(params Meme[] memes)
        {
            for (int i = 0; i < memes.Length; i++)
            {
                MemeList.Add(memes[i]);
            }
            sortMemes();
        }

        public void sortMemes()
        {
            this.MemeList.Sort();
        }

        public void findWordInMemes(string word)
        {
            foreach (Meme m in memeList)
            {
                if (m.FileName == word)
                {
                    MemeList.Add(m);
                }
            }
        }

    }
}
