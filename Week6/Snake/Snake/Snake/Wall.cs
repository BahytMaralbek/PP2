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
        public enum Levels
        {
            First,
            Second,
            Third 
        }
        public int l = 1;
        public int L
        {
            get
            {
                return l;
            }
            set
            {
                l = value;
            }
        }
        Levels level = Levels.First;
        public Wall(char sign) : base(sign)
        {
            LoadLevel(L);
        }
        public void NextLevel()
        {
            if(level == Levels.First)
            {
                level = Levels.Second;
                l = 2;
            }else if(level == Levels.Second)
            {
                level = Levels.Third;
                l = 3;
            }
            Clear();
            LoadLevel(L);
            Draw();
        }
        public void LoadLevel(int level)
        {
            string name = string.Format("Levels/Level{0}.txt", L);
            using (StreamReader sr = new StreamReader(name))
            {
                string[] rows = sr.ReadToEnd().Split('\n');
                for (int i = 0; i < rows.Length; i++)
                {
                    for (int j = 0; j < rows[i].Length; j++)
                    {
                        if (rows[i][j] == '#')
                        {
                            body.Add(new Point(j, i));
                        }
                    }
                }
            }
            Console.SetCursorPosition(15, 40);
            Console.Write("Level:{0}", L);
        }
    }
}
