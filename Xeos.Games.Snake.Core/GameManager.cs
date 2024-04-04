

using System.Drawing;

namespace Xeos.Games.Snake.Core
{
    public class GameManager
    {
        private Snake _snake;
        private Board _board;
        private Point _foodLocation;

        public GameManager(int snakeLength, int snakeSpeed, int boardWidth, int boardHeight)
        {
            CheckGameValidity(snakeLength, boardWidth, boardHeight);

            _board = new Board(boardWidth, boardHeight);


            IEnumerable<Point> segments = Enumerable.Range(1, snakeLength).Select(n => new Point(boardHeight + 5, n));
            _snake = new Snake(segments);
        }

        private static void CheckGameValidity(int snakeLength, int boardWidth, int boardHeight)
        {
            if (SnakeLengthIsInvalid(snakeLength, boardWidth, boardHeight))
            {
                int minimumSnakeLength = Math.Min(boardWidth + 4, boardHeight + 4);

                throw new ArgumentException($"Snake length, {snakeLength}, is invalid.  It must be greater than {minimumSnakeLength}");
            }
        }

        private static bool SnakeLengthIsInvalid(int snakeLength, int boardWidth, int boardHeight)
        {
            return snakeLength >= (boardWidth + 4) || snakeLength >= (boardHeight + 4);
        }

        public bool Start()
        {
            return true;
        }

        public bool UpdateSnake(Snake snake)
        {
            return snake.Length > 3;
        }
    }
}
