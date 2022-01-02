using SnakeGame.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameModes
{
    internal class BlockGameOptions : GameOptions
    {
        public BlockGameOptions(SnakeModel snakeModel, SurfaceModel surfaceModel, AppleModel appleModel)
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

            //PlayClassicSnakeGame();
            EndGame();
        }
    }
}
