using SnakeGame.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameModes
{
    internal class SpeedGameOptions : GameOptions
    {
        public SpeedGameOptions(SnakeModel snakeModel, SurfaceModel surfaceModel, AppleModel appleModel)
        {
            Snake = snakeModel;
            Surface = surfaceModel;
            Apple = appleModel;

            Console.Clear();
            ChangeApplePosition();

            Surface.DisplaySurface();
            Snake.DisplaySnake();
            Surface.GetScore();
            Apple.DisplayApple();

            PlaySpeedSnakeGame();
            EndGame();
        }

        private void PlaySpeedSnakeGame()
        {
            ConsoleKey key = Console.ReadKey().Key;

            DisplaySnakeSpeed(Snake.Speed);
            while (!CheckCollisionBetweenSnakeAndSurface() && !CheckSnakeCollision())
            {
                if (Console.KeyAvailable)
                    key = Console.ReadKey().Key;

                if (Snake.TryEatApple(Apple))
                {
                    Apple = new AppleModel('$');
                    ChangeApplePosition();
                    Apple.DisplayApple();
                    GetSnakeHeadCoordinates();

                    Surface.Score++;
                    Surface.GetScore();

                    Snake.AddSnakePoint();
                    Snake.Speed -= 10;
                    DisplaySnakeSpeed(Snake.Speed);
                }

                ControlBySnake(key);
            }
        }

        private void DisplaySnakeSpeed(int speed)
        {
            Console.SetCursorPosition(Surface.Width + 5, 1);
            Console.WriteLine(speed);
        }

    }
}
