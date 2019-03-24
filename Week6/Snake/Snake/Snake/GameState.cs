using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class GameState
    {
        Worm worm = new Worm('O');
        Food food = new Food('@');
        Wall wall = new Wall('#');
        public bool IsAlive = true;
        Player player = new Player();
        ConsoleKey consoleKeyInfo = new ConsoleKey();
        public GameState()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
        }
        public void PlayerName()
        {
            Console.SetCursorPosition(10, 20);
            Console.Write("Player name:");
            player.Name = Console.ReadLine();
            Console.Clear();
            wall.Draw();
        }
        public void Draw()
        {
            if (IsAlive)
            {
                worm.Draw();
                food.Draw();
                player.s.Draw();
            }
        }

        public void CheckCollision()
        {
            if(worm.CheckIntersection(wall.body) || worm.CheckIntersection(worm.body))
            {
                GameOver();
            }
            else if (worm.CheckIntersection(food.body))
            {
                player.s.Scores += 100;
                worm.Eat(food.body);
                if (player.s.Scores % 200 == 0)
                {
                    wall.NextLevel();
                }
                food.Generate(wall.body, worm.body);
            }
          
        }

        public void ProcessKey()
        {
            if (Console.KeyAvailable) consoleKeyInfo = Console.ReadKey(true).Key;
            switch (consoleKeyInfo)
            {
                case ConsoleKey.UpArrow:
                    if (worm.direction != Worm.Direction.DOWN)
                    {
                        worm.Move(0, -1);
                        worm.direction = Worm.Direction.UP;
                    }
                    else
                    {
                        worm.Move(0, 1);
                        worm.direction = Worm.Direction.DOWN;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (worm.direction != Worm.Direction.UP)
                    {
                        worm.Move(0, 1);
                        worm.direction = Worm.Direction.DOWN;
                    }
                    else
                    {
                        worm.direction = Worm.Direction.UP;
                        worm.Move(0, -1);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (worm.direction != Worm.Direction.LEFT)
                    {
                        worm.Move(1, 0);
                        worm.direction = Worm.Direction.RIGHT;
                    }
                    else
                    {
                        worm.direction = Worm.Direction.LEFT;
                        worm.Move(-1, 0);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (worm.direction != Worm.Direction.RIGHT)
                    {
                        worm.Move(-1, 0);
                        worm.direction = Worm.Direction.LEFT;
                    }
                    else
                    {
                        worm.direction = Worm.Direction.RIGHT;
                        worm.Move(1, 0);
                    }
                    break;
                case ConsoleKey.Escape:
                    GameOver();
                    break;

            }
            CheckCollision();
        }
        public void GameOver()
        {
            IsAlive = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(10, 20);
            Console.Write("GAME OVER!!!");
        }
    }
}
