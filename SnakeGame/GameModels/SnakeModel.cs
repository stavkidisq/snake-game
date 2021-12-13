using SnakeGame.GameLogic;
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
        public List<PointModel> SnakeLine = new List<PointModel>();
        public bool Health { get; set; } = true;
        public int Speed { get; set; }

        public SnakeModel(List<PointModel> snakeLine, int speed)
        {
            SnakeLine = snakeLine;
            Health = true;
            Speed = speed;
        }

        public void TryEateApple(AppleModel apple)
        {
            if (SnakeLine.Last().Position_X == apple.Position_X && SnakeLine.Last().Position_Y == apple.Position_Y)
            {
                apple.IsEaten = true;
            }
        }

        public bool CheckSnakeCollision()
        {
            for (int i = 0; i < SnakeLine.Count - 1; i++)
            {
                if (SnakeLine.Last().Position_X == SnakeLine[i].Position_X && SnakeLine.Last().Position_Y == SnakeLine[i].Position_Y)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckAppleCollision(AppleModel apple)
        {
            foreach (var point in SnakeLine)
            {
                if (apple.Position_X == point.Position_X && apple.Position_Y == point.Position_Y)
                    return true;
            }

            return false;
        }

        public void Turn(int offset_X, int offset_Y)
        {
            GameDisplay.PointDestructiuon(this);
            SnakeLine.Remove(SnakeLine.First());
            SnakeLine.Add(new PointModel(offset_X, offset_Y));
            GameDisplay.PointCreation(this);
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
