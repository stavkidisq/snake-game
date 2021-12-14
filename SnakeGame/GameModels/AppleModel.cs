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

        public AppleModel(SurfaceModel surface, SnakeModel snakeModel, char skin)
        {
            Skin = skin;

            if(surface != null && snakeModel != null) // not spawn apple when surface or snakemodel is null
            {
                do
                {
                    Position_X = new Random().Next(5, surface.Width - 5);
                    Position_Y = new Random().Next(5, surface.Height - 5);
                }
                while(snakeModel.CheckAppleCollision(this));

                Console.SetCursorPosition(Position_X, Position_Y);
                Console.WriteLine(Skin);
            }
        }
    }
}
