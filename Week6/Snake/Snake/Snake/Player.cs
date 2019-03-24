using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Player
    {
        string name;
        public string Name {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public Score s = new Score();
    }
}