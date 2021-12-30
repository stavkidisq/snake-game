using SnakeGame;
using SnakeGame.GameModels;
using System;

namespace System
{
    class Program
    {
        public static void GameDisplay()
        {
            Console.WriteLine("Welcome int the game - 'Snake'.\n");
            Console.WriteLine("1. Play the game!\n");
            Console.WriteLine("2. Exit from game\n");
            Console.WriteLine("Snake Pre-Alpha v0.1.0");
        }

        public static GameOption InputGameOptions()
        {
            Console.Clear();
            GameDisplay();

            var key = Console.ReadKey().Key;

            if (key == ConsoleKey.D1)
            {
                return GameOption.STARTGAME;
            }
            else if (key == ConsoleKey.D2)
            {
                return GameOption.EXITGAME;
            }
            else
            {
                return GameOption.INCORRECT;
            }
        }

        static void Main()
        {
            while (InputGameOptions() == GameOption.STARTGAME)
            {
                List<PointModel> points = new List<PointModel>() { new PointModel(6, 2), new PointModel(6, 3), new PointModel(6, 4) };

                new GameOptions
                    (new SnakeModel(points, 300), new AppleModel('$'), new SurfaceModel(20, 20));
            }
        }
    }
}
