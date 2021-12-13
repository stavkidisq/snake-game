using SnakeGame.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameLogic
{
    internal class GameLogic
    {
        public int GetScore(SurfaceModel surfaceModel)
        {
            return surfaceModel.Score;
        }

        public static bool CheckOnCollision(SnakeModel snakeModel, SurfaceModel surfaceModel)
        {
            if ((snakeModel.SnakeLine.Last().Position_X > 0) && (snakeModel.SnakeLine.Last().Position_X < surfaceModel.Width)
                && (snakeModel.SnakeLine.Last().Position_Y > 0) && (snakeModel.SnakeLine.Last().Position_Y < surfaceModel.Height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SnakeTurnLogic(SnakeModel snakeModel, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    snakeModel.ToUp();
                    break;
                case ConsoleKey.DownArrow:
                    snakeModel.ToDown();
                    break;
                case ConsoleKey.LeftArrow:
                    snakeModel.ToLeft();
                    break;
                case ConsoleKey.RightArrow:
                    snakeModel.ToRight();
                    break;
            }
        }

        public static void AddScore(SurfaceModel surfaceModel)
        {
            surfaceModel.Score++;
        }
    }
}
