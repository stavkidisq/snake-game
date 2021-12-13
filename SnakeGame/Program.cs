using SnakeGame;
using SnakeGame.GameLogic;
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
            AppleModel appleModel;

            do
            {
                appleModel = new AppleModel(surfaceModel, '$');
            }
            while (snakeModel.CheckAppleCollision(appleModel));

            GameDisplay.CreateSurface(surfaceModel);
            GameDisplay.SpawnApple(appleModel);
            GameDisplay.DisplayScore(surfaceModel);
            GameDisplay.SpawnSnake(snakeModel);

            ConsoleKey key = Console.ReadKey().Key;

            while (GameLogic.CheckOnCollision(snakeModel, surfaceModel) && !snakeModel.CheckSnakeCollision())
            {
                GameDisplay.DisplayScore(surfaceModel);

                if (Console.KeyAvailable)
                    key = Console.ReadKey().Key;

                snakeModel.TryEateApple(appleModel);

                if (appleModel.IsEaten)
                {
                    GameLogic.AddScore(surfaceModel);
                     
                    do
                    {
                        appleModel = new AppleModel(surfaceModel, '$');
                    }
                    while (snakeModel.CheckAppleCollision(appleModel));

                    GameDisplay.SpawnApple(appleModel);

                    snakeModel.SnakeLine.Add
                        (new PointModel(snakeModel.SnakeLine.Last().Position_X, snakeModel.SnakeLine.Last().Position_Y));
                }

                GameLogic.SnakeTurnLogic(snakeModel, key);
            }
        }
    }
}
