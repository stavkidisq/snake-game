using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameModels
{
    internal class BarrierModel
    {
        public int Position_X { get; set; }
        public int Position_Y { get; set; }

        public BarrierModel(int pos_x, int pos_y)
        {
            Position_X = pos_x;
            Position_Y = pos_y;
        }

        public void Display()
        {
            Console.SetCursorPosition(Position_X, Position_Y);
            Console.WriteLine("+");
        }
    }
}
