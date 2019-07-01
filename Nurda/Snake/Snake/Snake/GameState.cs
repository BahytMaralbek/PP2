using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace MazeGame
{
    class GameState
    {
        bool CollisionWithWall = false;
        Man man = new Man('O');
        Wall wall;
        Levels Level = new Levels();
        Exit exit = new Exit('X');
        public int LevelNumber { get; set; } = 1;
        public GameState()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
        }
        public void Draw()
        {
           wall = new Wall('#',LevelNumber);
           wall.exitx = exit.xx;
           wall.exity = exit.yy;
           man.Draw();
           Level.Draw();
           wall.Draw();
           exit.Draw();
        }

        public void CheckCollision()
        {
            if (man.CheckIntersection(exit.body))
            {
                Console.Clear();
                wall.LoadLevel(LevelNumber + 1);
            }
            else if (man.CheckIntersection(wall.body))
            {
                CollisionWithWall = true;
            }
          
        }

        public void ProcessKey(ConsoleKeyInfo consoleKeyInfo)
        {
            if (CollisionWithWall == false)
            {
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        man.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        man.Move(0, 1);
                        break;
                    case ConsoleKey.RightArrow:
                        man.Move(1, 0);
                        break;
                    case ConsoleKey.LeftArrow:
                        man.Move(-1, 0);
                        break;

                }
            }
            CheckCollision();
        }
    }
}
