using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        { 
            GameState gameState = new GameState();

            while (gameState.IsAlive == true)
            {
                gameState.Draw();
                gameState.ProcessKey();
            }

        }
       
    }
}
