using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameModels
{
    internal class AppleModel
    {
        public int Position_X { get; set; }
        public int Position_Y { get; set; }
        public char Skin { get; set; }

        public AppleModel(char skin)
        {
            Skin = skin;
        }

        public void DisplayApple()
        {
            Console.SetCursorPosition(Position_X, Position_Y);
            Console.WriteLine(Skin);
        }
    }
}
