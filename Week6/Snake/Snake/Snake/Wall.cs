using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Wall:GameObject
    {
        public string levelName
        {
            get;
            set;
        }
        public Wall(char sign , int levelNumber) : base(sign)
        {
            LoadLevel(levelNumber);
            
        }
      
        public void LoadLevel(int level)
        {
            string name = string.Format("Levels/Level{0}.txt", level);
            using (StreamReader sr = new StreamReader(name))
            {
                int r = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    for (int c = 0; c < line.Length; c++)
                    {
                        if (line[c] == '#')
                        {
                                body.Add(new Point(c, r));
                        }
                    }
                    r++;
                }
            }
        }
    }
}
