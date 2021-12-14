using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameModels
{
    internal class SurfaceModel
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Score { get; set; }

        public SurfaceModel(int width, int height)
        {
            Width = width;
            Height = height;

            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("*");

                Console.SetCursorPosition(i, Height);
                Console.WriteLine("*");
            }

            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("*");

                Console.SetCursorPosition(Width, i);
                Console.WriteLine("*");
            }

            Console.SetCursorPosition(Width + 5, 2);
            Console.WriteLine($"Score: {Score}");
        }

        public void GetScore()
        {
            Console.SetCursorPosition(Width + 5, 2);
            Console.WriteLine($"Score: {Score}");
        }

        public bool CheckOnCollision(SnakeModel snakeModel)
        {
            if ((snakeModel.SnakeLine.Last().Position_X < 0) && (snakeModel.SnakeLine.Last().Position_X > Width)
                && (snakeModel.SnakeLine.Last().Position_Y < 0) && (snakeModel.SnakeLine.Last().Position_Y > Height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
