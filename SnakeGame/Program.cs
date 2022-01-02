using SnakeGame;
using SnakeGame.GameModels;
using System;

namespace System
{
    enum GameOption
    {
        GAMEMODES,
        EXITGAME,
        INCORRECT
    }

    class Program
    {
        public static void DisplayGameOptions()
        {
            Console.WriteLine("Welcome int the game - 'Snake'.\n");
            Console.WriteLine("1. Start game!\n");
            Console.WriteLine("2. Exit from game\n");
            Console.WriteLine("Snake v0.1.1-Alpha");
        }

        public static GameOption InputGameOptions()
        {
            Console.Clear();
            DisplayGameOptions();

            var key = Console.ReadKey().Key;

            if (key == ConsoleKey.D1)
            {
                return GameOption.GAMEMODES;
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
            while(true)
            {
                DisplayGameOptions();
                var choice1 = InputGameOptions();

                if(choice1 == GameOption.GAMEMODES)
                {
                    List<PointModel> points =
                        new List<PointModel>() { new PointModel(6, 2), new PointModel(6, 3), new PointModel(6, 4) };

                    new GameManagement(new SnakeModel(points, 300), new SurfaceModel(20, 20), new AppleModel('$'));
                }
                else
                {
                    break;
                }
            }
        }
    }
}
