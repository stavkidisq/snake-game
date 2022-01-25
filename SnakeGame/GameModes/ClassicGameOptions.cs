using SnakeGame.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameModes
{
    internal class ClassicGameOptions : GameOptions
    {
        public ClassicGameOptions(SnakeModel snakeModel, SurfaceModel surfaceModel, AppleModel appleModel)
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

            PlayClassicSnakeGame();
            EndGame();
        }

        private void PlayClassicSnakeGame()
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
                    GetSnakeHeadCoordinates();

                    Surface.Score++;
                    Surface.GetScore();

                    Snake.AddSnakePoint();
                }

                Control(key);
            }
        }
    }
}
