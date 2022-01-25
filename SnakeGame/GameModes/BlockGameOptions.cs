using SnakeGame.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameModes
{
    internal class BlockGameOptions : GameOptions
    {
        List<BarrierModel> _barriers = new List<BarrierModel>();

        public BlockGameOptions(SnakeModel snakeModel, SurfaceModel surfaceModel, AppleModel appleModel)
        {
            Snake = snakeModel;
            Surface = surfaceModel;
            Apple = appleModel;

            Console.Clear();
            ChangeApplePosition();

            Surface.DisplaySurface();
            Snake.DisplaySnake();
            Surface.GetScore();
            Apple.Display();
            SpawnBarriers(10);

            PlayBarrierSnakeGame();
            EndGame();
        }

        private void PlayBarrierSnakeGame()
        {
            ConsoleKey key = Console.ReadKey().Key;

            while (!CheckSurfaceCollision() && !CheckSnakeCollision() && !CheckSnakeToBarrierCollision())
            {
                if (Console.KeyAvailable)
                    key = Console.ReadKey().Key;

                if (Snake.TryEatApple(Apple))
                {
                    Apple = new AppleModel('$');
                    ChangeApplePosition();
                    Apple.Display();
                    GetSnakeHeadCoordinates();
                    SpawnBarrier();

                    Surface.Score++;
                    Surface.GetScore();

                    Snake.AddSnakePoint();
                }

                Control(key);
            }
        }

        private void SpawnBarriers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                SpawnBarrier();
            }
        }

        private void SpawnBarrier()
        {
            int x = 0;
            int y = 0;

            do
            {
                x = new Random().Next(1, Surface.Width - 1);
                y = new Random().Next(1, Surface.Height - 1);
            }
            while (CheckBarrierCollision(x, y));

            BarrierModel barrier = new BarrierModel(x, y);
            _barriers.Add(barrier);
            barrier.Display();
        }

        public bool CheckBarrierCollision(int x, int y)
        {
            foreach(var item in Snake.SnakeLine)
            {
                if((item.Position_X != x && item.Position_Y != y) && (Apple.Position_X != x && Apple.Position_Y != y))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckSnakeToBarrierCollision()
        {
            foreach(var snakePoint in Snake.SnakeLine)
            {
                foreach(var barrierPoint in _barriers)
                {
                    if (snakePoint.Position_X == barrierPoint.Position_X && snakePoint.Position_Y == barrierPoint.Position_Y)
                        return true;
                }
            }

            return false;
        }
    }
}
