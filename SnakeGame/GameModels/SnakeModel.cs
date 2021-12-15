using SnakeGame.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class SnakeModel
    {
        public List<PointModel> SnakeLine { get; set; }
        public int Speed { get; set; }

        public SnakeModel(List<PointModel> snakeLine, int speed)
        {
            SnakeLine = snakeLine;
            Speed = speed;

            if (SnakeLine == null)
                SnakeLine = new List<PointModel>();

            foreach (var point in SnakeLine.ToList())
            {
                Console.SetCursorPosition(point.Position_X, point.Position_Y);
                Console.WriteLine('*');
            }
        }

        public bool TryEatApple(AppleModel apple)
        {
            if (SnakeLine.Last().Position_X == apple.Position_X && SnakeLine.Last().Position_Y == apple.Position_Y)
            {
                return true;
            }

            return false;
        }

        public void AddSnakePoint()
        {
            SnakeLine.Add
                (new PointModel(SnakeLine.Last().Position_X, SnakeLine.Last().Position_Y));
        }

        public void Turn(int offset_X, int offset_Y)
        {
            Console.SetCursorPosition(SnakeLine.First().Position_X, SnakeLine.First().Position_Y);
            Console.WriteLine(' ');

            SnakeLine.Remove(SnakeLine.First());
            SnakeLine.Add(new PointModel(offset_X, offset_Y));

            Console.SetCursorPosition(SnakeLine.Last().Position_X, SnakeLine.Last().Position_Y);
            Console.WriteLine('*');

            Thread.Sleep(Speed);
        }

        public void ToLeft()
        {
            Turn(SnakeLine.Last().Position_X - 1, SnakeLine.Last().Position_Y);
        }

        public void ToRight()
        {
            Turn(SnakeLine.Last().Position_X + 1, SnakeLine.Last().Position_Y);
        }

        public void ToUp()
        {
            Turn(SnakeLine.Last().Position_X, SnakeLine.Last().Position_Y - 1);
        }

        public void ToDown()
        {
            Turn(SnakeLine.Last().Position_X, SnakeLine.Last().Position_Y + 1);
        }
    }
}
