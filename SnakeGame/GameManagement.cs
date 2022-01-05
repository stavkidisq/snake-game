using SnakeGame.GameModels;
using SnakeGame.GameModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    enum Modes
    {
        CLASSIC,
        BLOCK,
        SPEED,
        INCORRECT
    }

    internal class GameManagement
    {
        public GameManagement(SnakeModel snakeModel, SurfaceModel surfaceModel, AppleModel appleModel)
        {
            DisplayGameModes();
            var choice2 = InputGameModes();

            //ChoiceGameModes2
            switch (choice2)
            {
                case Modes.CLASSIC:
                    new ClassicGameOptions(snakeModel, surfaceModel, appleModel);
                    break;
                case Modes.BLOCK:
                    new BlockGameOptions(snakeModel, surfaceModel, appleModel);
                    break;
                case Modes.SPEED:
                    new SpeedGameOptions(snakeModel, surfaceModel, appleModel);
                    break;
            }
        }

        public void DisplayGameModes()
        {
            Console.Clear();
            Console.WriteLine("Choice game mode...");
            Console.WriteLine("1. Classic snake game!");
            Console.WriteLine("2. Snake game with barriers!");
            Console.WriteLine("3. Snake game for speed!");
        }

        public Modes InputGameModes()
        {
            Console.Clear();
            DisplayGameModes();

            var key = Console.ReadKey().Key;

            if (key == ConsoleKey.D1)
            {
                return Modes.CLASSIC;
            }
            else if (key == ConsoleKey.D2)
            {
                return Modes.BLOCK;
            }
            else if(key == ConsoleKey.D3)
            {
                return Modes.SPEED;
            }

            return Modes.INCORRECT;
        }
    }
}
