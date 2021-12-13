using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameModels
{
    internal class PointModel
    {
        public int Position_X { get; set; }
        public int Position_Y { get; set; }

        public PointModel(int x, int y)
        {
            Position_X = x;
            Position_Y = y;
        }
    }
}
