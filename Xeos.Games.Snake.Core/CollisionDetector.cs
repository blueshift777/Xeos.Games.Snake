using System.Drawing;

namespace Xeos.Games.Snake.Core
{
    public class CollisionDetector
    {

        public bool Detect(Board board, Snake snake)
        {
            //Check for collision with board or self
            Point snakeHead = snake.Segments[0]; //Head is at first position

            bool didCollide =
                DidCollideWithWall(board, snakeHead) ||
                DidCollideWithSelf(snake);

            return didCollide;
        }

        private bool DidCollideWithSelf(Snake snake)
        {
            var segments = snake.Segments;

            for (int i =0; i < segments.Count; i++)
            {
                for (int j = 0; j < segments.Count; j++)
                {
                    if (i != j)
                    {
                        if (segments[i].Equals(segments[j]))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private static bool DidCollideWithWall(Board board, Point snakeHead)
        {
            return 
                snakeHead.X.Equals(0) || 
                snakeHead.X.Equals(board.Width - 1) ||
                snakeHead.Y.Equals(0) || 
                snakeHead.Y.Equals(board.Height - 1);
        }
    }
}
