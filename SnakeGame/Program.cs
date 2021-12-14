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
            List<PointModel> points = new List<PointModel>() { new PointModel(6, 2), new PointModel(6, 3), new PointModel(6, 4) };

            SnakeModel snakeModel = new SnakeModel(points, 300);
            SurfaceModel surfaceModel = new SurfaceModel(20, 20);
            AppleModel appleModel = new AppleModel(surfaceModel, snakeModel, '$');

            ConsoleKey key = Console.ReadKey().Key;

            if (snakeModel != null && surfaceModel != null)
            {
                if(snakeModel.SnakeLine.Count > 2)
                {
                    while (!surfaceModel.CheckOnCollision(snakeModel) && !snakeModel.CheckSnakeCollision())
                    {
                        if (Console.KeyAvailable)
                            key = Console.ReadKey().Key;

                        if (snakeModel.TryEatApple(appleModel))
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
    }
}
