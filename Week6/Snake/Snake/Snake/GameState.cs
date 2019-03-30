using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace Snake
{
    class GameState
    {
        Worm worm = new Worm('O');
        Food food = new Food('@');
        Wall wall;
        public bool IsAlive = true;
        Player player = new Player();
        ScoreLevel ScoreLevel = new ScoreLevel();
        ConsoleKey consoleKeyInfo = new ConsoleKey();
        public int LevelNumber { get; set; } = 0;
        public GameState()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
            player.AskName();
        }
        public void Draw()
        {
            if (IsAlive)
            {
                wall = new Wall('#', ScoreLevel.Level);
                worm.Draw();
                ScoreLevel.Draw();
                food.Draw();
                wall.Draw();
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
             
                ScoreLevel.Score += 100;
                player.Score = ScoreLevel.Score;
                food.Generate(wall.body, worm.body);
                if (ScoreLevel.Score == 300)
                {
                    wall.Clear();
                    ScoreLevel.Level = 2;
                    wall = new Wall('#', ScoreLevel.Level);
                    wall.Draw();
                }
                else if (ScoreLevel.Score == 600)
                {
                    wall.Clear();
                    ScoreLevel.Level = 3;
                    wall = new Wall('#', ScoreLevel.Level);
                    wall.Draw();
                }
                worm.Eat(food.body);
            }
          
        }

        public void ProcessKey()
        {
            if (Console.KeyAvailable)
                consoleKeyInfo = Console.ReadKey(true).Key;
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
                    Save(player);
                    GameOver();
                    break;

            }
            CheckCollision();
        }
        public void Save(Player player)
        { 
            string path = "C:/Users/User/PP2/Week6/Table";
            string s = string.Format("{0}.xml", player.Name);
            string directory = Path.Combine(path, s);
            XmlSerializer xs = new XmlSerializer(typeof(Player));
            using (FileStream fs = new FileStream(directory, FileMode.Create, FileAccess.Write))
            { 
                xs.Serialize(fs, player);
            }
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
