using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Levels
    {
        int level;
        public int Level { get { return level; } set { level = value; } }
        public Levels()
        {
            level = 1;
        }
        public void Draw()
        {
            Console.SetCursorPosition(15, 39);
            Console.Write("Level {0}", level);
        }
    }
}