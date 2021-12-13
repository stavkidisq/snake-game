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
        public bool IsEaten { get; set; } = false;

        public AppleModel(SurfaceModel surface, char skin)
        {
            Position_X = new Random().Next(5, surface.Width - 5);
            Position_Y = new Random().Next(5, surface.Height - 5);
            Skin = skin;
        }
    }
}
