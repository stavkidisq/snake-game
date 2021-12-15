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

            new GameOptions
                (new SnakeModel(points, 300), new AppleModel('$'), new SurfaceModel(20, 20));
        }
    }
}
