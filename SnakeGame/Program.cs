using SnakeGame;
using SnakeGame.GameModels;
using System;

namespace System
{
    enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    class Program
    {
        static void Main()
        {
            SnakeModel snakeModel =
                new SnakeModel(new List<PointModel>()
                {
                    new PointModel(5, 10),
                    new PointModel(6, 10),
                    new PointModel(7, 10),
                    new PointModel(8, 10),
                    new PointModel(9, 10)
                }, 300);
            SurfaceModel surfaceModel = new SurfaceModel(20, 20);
            AppleModel appleModel = new AppleModel(surfaceModel, snakeModel, '$');

            ConsoleKey key = Console.ReadKey().Key;

            while(!surfaceModel.CheckOnCollision(snakeModel) && !snakeModel.CheckSnakeCollision())
            {
                if (Console.KeyAvailable)
                    key = Console.ReadKey().Key;

                snakeModel.TryEatApple(appleModel);

                if(snakeModel.TryEatApple(appleModel))
                {
                    appleModel = new AppleModel(surfaceModel, snakeModel, '$');
                    surfaceModel.Score++;

                    snakeModel.AddSnakePoint();
                }

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
        }
    }
}
