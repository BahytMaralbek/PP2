using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeThread
{
    public class Player
    {
        string name;
        int score;
        public int Score
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
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public Player() { }

        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
        public void AskName()
        {
            Console.SetCursorPosition(10, 20);
            Console.Write("Enter your name:" + Name);
            Name = Console.ReadLine();
            Console.Clear();
        }
    }
}
