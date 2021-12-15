using SnakeGame.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class GameOptions
    {
        AppleModel Apple { get; set; }
        SnakeModel Snake { get; set; }
        SurfaceModel Surface { get; set; }
        public bool TryRules() => true;
        public List<PointModel> GetSnakeLine
        {
            get
            {
                if (Snake != null)
                    return Snake.SnakeLine;
                else
                    throw new NullReferenceException();
            }
        }

        public GameOptions(SnakeModel snakeModel, AppleModel appleModel,SurfaceModel surfaceModel)
        {
            Snake = snakeModel;
            Surface = surfaceModel;
            Apple = appleModel;

            ChangeApplePosition(Surface, Snake);
            Apple.Display();

            PlaySnakeGame();
        }

        public void PlaySnakeGame()
        {
            ConsoleKey key = Console.ReadKey().Key;

            while (!CheckOnCollision(Snake) && !CheckSnakeCollision())
            {
                if (Console.KeyAvailable)
                    key = Console.ReadKey().Key;

                if (Snake.TryEatApple(Apple))
                {
                    Apple = new AppleModel('$');
                    ChangeApplePosition(Surface, Snake);
                    Apple.Display();

                    Surface.Score++;
                    Surface.GetScore();

                    Snake.AddSnakePoint();
                }

                Control(key);
            }
        }

        public void Control(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Snake.ToUp();
                    break;
                case ConsoleKey.DownArrow:
                    Snake.ToDown();
                    break;
                case ConsoleKey.LeftArrow:
                    Snake.ToLeft();
                    break;
                case ConsoleKey.RightArrow:
                    Snake.ToRight();
                    break;
            }
        }

        private void ChangeApplePosition(SurfaceModel surface, SnakeModel snakeModel)
        {
            do
            {
                Apple.Position_X = new Random().Next(5, surface.Width - 5);
                Apple.Position_Y = new Random().Next(5, surface.Height - 5);
            }
            while (CheckAppleCollision(Apple));
        }

        public bool CheckOnCollision(SnakeModel snakeModel)
        {
            if ((GetSnakeLine.Last().Position_X < 0) && (GetSnakeLine.Last().Position_X > Surface.Width)
                && (GetSnakeLine.Last().Position_Y < 0) && (GetSnakeLine.Last().Position_Y > Surface.Height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckSnakeCollision()
        {
            for (int i = 0; i < Snake.SnakeLine.Count - 1; i++)
            {
                if (GetSnakeLine.Last().Position_X == GetSnakeLine[i].Position_X && GetSnakeLine.Last().Position_Y == GetSnakeLine[i].Position_Y)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckAppleCollision(AppleModel apple)
        {
            foreach (var point in GetSnakeLine)
            {
                if (apple.Position_X == point.Position_X && apple.Position_Y == point.Position_Y)
                    return true;
            }

            return false;
        }
    }
}
