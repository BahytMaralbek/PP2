using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace SnakeThread
{
    class Program
    {
        static GameState gameState = new GameState();
        static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {
            Thread thread = new Thread(DoIt);
            thread.Start();
            while (gameState.IsAlive == true)
            {
                gameState.Draw();
                Thread.Sleep(120);
            }

        }
        static void DoIt()
        {
            while (true)
            {
                consoleKeyInfo = Console.ReadKey();
                gameState.ProcessKey(consoleKeyInfo);
            }
        }
    }
}
