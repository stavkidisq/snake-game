using SnakeGame.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    enum GameOption
    {
        STARTGAME,
        EXITGAME,
        INCORRECT
    }
    internal class GameOptions
    {
        private AppleModel? _appleModel;
        private SnakeModel? _snakeModel;
        private SurfaceModel? _surfaceModel;

        private AppleModel Apple 
        {
            get => (_appleModel != null) ? _appleModel : throw new NullReferenceException();
            set => _appleModel = value;
        }
        private SnakeModel Snake 
        {
            get => (_snakeModel != null) ? _snakeModel : throw new NullReferenceException();
            set => _snakeModel = value;
        }
        private SurfaceModel Surface 
        {
            get => (_surfaceModel != null) ? _surfaceModel : throw new NullReferenceException();
            set => _surfaceModel = value;
        }

        private List<PointModel> GetSnakeLine 
        {
            get => (Snake.SnakeLine != null) ? Snake.SnakeLine : throw new NullReferenceException();  
        }

        public GameOptions(SnakeModel snakeModel, AppleModel appleModel,SurfaceModel surfaceModel)
        {
            Snake = snakeModel;
            Surface = surfaceModel;
            Apple = appleModel;

            Console.Clear();
            ChangeApplePosition();

            Surface.DisplaySurface();
            Snake.DisplaySnake();
            Surface.GetScore();
            Apple.Display();

            PlaySnakeGame();
            EndGame();
        }

        public void EndGame()
        {
            Console.Clear();
            Console.WriteLine("Game over!");
            Console.WriteLine("Press any key to go to the main menu...");
            Console.ReadKey();
        }

        public void PlaySnakeGame()
        {
            ConsoleKey key = Console.ReadKey().Key;

            while (!CheckSurfaceCollision() && !CheckSnakeCollision())
            {
                if (Console.KeyAvailable)
                    key = Console.ReadKey().Key;

                if (Snake.TryEatApple(Apple))
                {
                    Apple = new AppleModel('$');
                    ChangeApplePosition();
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

        private void ChangeApplePosition()
        {
            do
            {
                Apple.Position_X = new Random().Next(5, Surface.Width - 5);
                Apple.Position_Y = new Random().Next(5, Surface.Height - 5);
            }
            while (CheckAppleCollision());
        }

        public bool CheckSurfaceCollision()
        {
            if ((GetSnakeLine.Last().Position_X <= 0) || (GetSnakeLine.Last().Position_X >= Surface.Width)
                || (GetSnakeLine.Last().Position_Y <= 0) || (GetSnakeLine.Last().Position_Y >= Surface.Height))
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

        public bool CheckAppleCollision()
        {
            foreach (var point in GetSnakeLine)
            {
                if (Apple.Position_X == point.Position_X && Apple.Position_Y == point.Position_Y)
                    return true;
            }

            return false;
        }
    }
}
