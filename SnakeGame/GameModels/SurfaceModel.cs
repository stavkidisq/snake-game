using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameModels
{
    internal class SurfaceModel
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Score { get; set; }

        public SurfaceModel(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
