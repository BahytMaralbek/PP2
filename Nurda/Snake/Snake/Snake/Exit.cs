using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MazeGame
{
    class Exit : GameObject
    {
        public int xx, yy;
        public Exit(char sign) : base(sign)
        {
            body.Add(new Point(xx,yy));
        }
    }
}
