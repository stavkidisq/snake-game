using SnakeGame.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameLogic
{
    internal class GameDisplay
    {
        public static void DisplayScore(SurfaceModel surfaceModel)
        {
            Console.SetCursorPosition(surfaceModel.Width + 5, 2);
            Console.WriteLine($"Score: {surfaceModel.Score}");
        }

        public static void CreateSurface(SurfaceModel surfaceModel)
        {
            for (int i = 0; i < surfaceModel.Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("*");

                Console.SetCursorPosition(i, surfaceModel.Height);
                Console.WriteLine("*");
            }

            for (int i = 0; i < surfaceModel.Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("*");

                Console.SetCursorPosition(surfaceModel.Width, i);
                Console.WriteLine("*");
            }
        }
        public static void SpawnApple(AppleModel appleModel)
        {
            Console.SetCursorPosition(appleModel.Position_X, appleModel.Position_Y);
            Console.WriteLine(appleModel.Skin);
        }

        public static void SpawnSnake(SnakeModel snakeModel)
        {
            foreach (var point in snakeModel.SnakeLine.ToList())
            {
                Console.SetCursorPosition(point.Position_X, point.Position_Y);
                Console.WriteLine('*');
            }
        }

        public void DisplaySnakeTurn(SnakeModel snakeModel)
        {

            Thread.Sleep(500);
        }

        public static void PointDestructiuon(SnakeModel snakeModel)
        {
            Console.SetCursorPosition(snakeModel.SnakeLine.First().Position_X, snakeModel.SnakeLine.First().Position_Y);
            Console.WriteLine(' ');
        }

        public static void PointCreation(SnakeModel snakeModel)
        {
            Console.SetCursorPosition(snakeModel.SnakeLine.Last().Position_X, snakeModel.SnakeLine.Last().Position_Y);
            Console.WriteLine('*');
        }
    }
}
