using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Threading;

namespace Snake
{
    class Program
    {
        static ConsoleKeyInfo ConsoleKeyInfo;
        static GameState gameState = new GameState();
        static void Main(string[] args)
        { 
            Thread thread = new Thread(DoIt);
            thread.Start();
            while (true)
            {
                gameState.Draw();
                Thread.Sleep(120);
            }

        }

        static void DoIt()
        {
            while (true)
            {
                ConsoleKeyInfo = Console.ReadKey();
                gameState.ProcessKey(ConsoleKeyInfo);
            }
        }
    }
}
