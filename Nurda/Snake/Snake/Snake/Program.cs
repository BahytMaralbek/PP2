using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Threading;

namespace MazeGame
{
    class Program
    {
        static GameState gameState = new GameState();
        static void Main(string[] args)
        { 
            while (true)
            {
                gameState.Draw();
                ConsoleKeyInfo ConsoleKeyInfo = Console.ReadKey();
                gameState.ProcessKey(ConsoleKeyInfo);
            }

        }

        static void DoIt()
        {
            while (true)
            {
                
            }
        }
    }
}
