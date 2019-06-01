using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memenger
{
    // Singleton Pattern 
    class Memecryptor
    {
        private List<Meme> memeList = new List<Meme>(); // memes with file names
        private List<Meme> memesToDisplay = new List<Meme>(); // memes with file names
        private static readonly Memecryptor instance = new Memecryptor();

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
        }

        public void AddMemesFromFolder(string folderPath)
        {
            DirectoryInfo d = new DirectoryInfo(folderPath);    // ssAssuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.png");             // Getting .png files

            foreach (FileInfo file in Files)                    // Add every meme to Meme List
            {
                Meme meme = new Meme(file.Name);
                AddMeme(meme);
            }
        }

        public void FindStringInMemes(string word)
        {
            for (int i = 0; i < memeList.Count; i++)
            {
                if (memeList[i].FileName.Contains(word))
                {
                    MemesToDisplay.Add(MemeList[i]);
                }
            }
        }
        public string PutWordGetMeme(string word)
        {
            MemesToDisplay.Clear();
            FindStringInMemes(word);

            if (MemesToDisplay.Count > 0)
            {
                return MemesToDisplay[0].FileName.ToString();
            }
            else
            {
                return "z.png";
            }
        }
    }
}
