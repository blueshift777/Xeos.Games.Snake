using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeos.Games.Snake.Core
{
    public class FoodEatenDetector
    {
        public bool Detect(Snake snake, Point foodLocation)
        {
            bool didDetect = false;

            Point snakeHead = snake.Head;
            Direction direction = snake.Direction;

            switch (direction)
            {
                case Direction.Left:
                    didDetect = foodLocation.X - snakeHead.X == -1;
                    break;
                case Direction.Right:
                    didDetect = foodLocation.X - snakeHead.X == 1;
                    break;
                case Direction.Up:
                    didDetect = foodLocation.Y - snakeHead.Y == -1;
                    break;
                case Direction.Down:
                    didDetect = foodLocation.Y - snakeHead.Y == 1;
                    break;
            }

            return didDetect;
        }
    }


}
