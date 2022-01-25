using SnakeGame.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal abstract class GameOptions
    {
        private AppleModel? _appleModel;
        private SnakeModel? _snakeModel;
        private SurfaceModel? _surfaceModel;

        protected AppleModel Apple 
        {
            get => (_appleModel != null) 
                ? _appleModel : throw new NullReferenceException();
            set => _appleModel = value;
        }
        protected SnakeModel Snake 
        {
            get => (_snakeModel != null) 
                ? _snakeModel : throw new NullReferenceException();
            set => _snakeModel = value;
        }
        protected SurfaceModel Surface 
        {
            get => (_surfaceModel != null) 
                ? _surfaceModel : throw new NullReferenceException();
            set => _surfaceModel = value;
        }

        protected List<PointModel> GetSnakeLine 
        {
            get => (Snake.SnakeLine != null) 
                ? Snake.SnakeLine : throw new NullReferenceException();  
        }

        protected void EndGame()
        {
            Console.Clear();
            Console.WriteLine("Game over!");
            Console.WriteLine("Press any key to go to the main menu...");
            Console.ReadKey();
        }

        protected void ControlBySnake(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Snake.TurnSnakeToUp();
                    break;
                case ConsoleKey.DownArrow:
                    Snake.TurnSnakeToDown();
                    break;
                case ConsoleKey.LeftArrow:
                    Snake.TurnSnakeToLeft();
                    break;
                case ConsoleKey.RightArrow:
                    Snake.TurnSnakeToRight();
                    break;
            }
        }

        protected void ChangeApplePosition()
        {
            do
            {
                Apple.Position_X = new Random().Next(5, Surface.Width - 5);
                Apple.Position_Y = new Random().Next(5, Surface.Height - 5);
            }
            while (CheckCollisionBetweenSnakeAndApple());
        }

        protected bool CheckCollisionBetweenSnakeAndSurface()
        {
            if ((GetSnakeLine.Last().Position_X <= 0) || (GetSnakeLine.Last().Position_X >= Surface.Width)
                || (GetSnakeLine.Last().Position_Y <= 0) || (GetSnakeLine.Last().Position_Y >= Surface.Height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool CheckSnakeCollision()
        {
            for (int i = 0; i < Snake.SnakeLine.Count - 1; i++)
            {
                if (GetSnakeLine.Last().Position_X == GetSnakeLine[i].Position_X && GetSnakeLine.Last().Position_Y == GetSnakeLine[i].Position_Y)
                {
                    return true;
                }
            }

            return false;
        }

        protected bool CheckCollisionBetweenSnakeAndApple()
        {
            foreach (var point in GetSnakeLine)
            {
                if (Apple.Position_X == point.Position_X && Apple.Position_Y == point.Position_Y)
                    return true;
            }

            return false;
        }

        protected void GetSnakeHeadCoordinates()
        {
            Console.SetCursorPosition(Surface.Width + 5, 4);
            Console.WriteLine($"snake:                   ");

            Console.SetCursorPosition(Surface.Width + 5, 4);
            Console.WriteLine
                ($"snake head: {Snake.SnakeLine.Last().Position_X} {Snake.SnakeLine.Last().Position_Y}");
        }
    }
}
