using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Score
    {
        public int score;
        public int Scores
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
        public void Draw()
        {
            Console.SetCursorPosition(0, 39);
            Console.Write("Score: {0}", score);
        }
    }
}