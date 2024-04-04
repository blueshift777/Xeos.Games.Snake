using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeos.Games.Snake.Core.Tests
{
    internal class CollisionDetectorTests
    {

        static Snake[] wallTouchingSnakes =
            new Snake[]
            {
                new Snake(Enumerable.Range(1, 7).Select(n => new Point(10, 50 - n))),
                new Snake(Enumerable.Range(1, 7).Select(n => new Point(10, n -1))),
                new Snake(Enumerable.Range(1, 7).Select(n => new Point(50- n, 10))),
                new Snake(Enumerable.Range(1, 7).Select(n => new Point(n - 1, 10))),
            };

        static Snake[] nonWallTouchingSnakes =
            new Snake[]
            {
                new Snake(Enumerable.Range(1, 7).Select(n => new Point(10, 49 - n))),
                new Snake(Enumerable.Range(1, 7).Select(n => new Point(10, n))),
                new Snake(Enumerable.Range(1, 7).Select(n => new Point(49 - n, 10))),
                new Snake(Enumerable.Range(1, 7).Select(n => new Point(n, 10))),
            };

        static Snake[] selfCollidingSnakes =
            new Snake[]
            {
                new Snake(new Point(1,1), new Point(2,1),new Point(3,1),new Point(3,2),new Point(2, 2),new Point(2, 1),new Point(1, 1)),
                new Snake(new Point(1,1), new Point(2,1),new Point(3,1),new Point(3,2),new Point(2, 2),new Point(3, 1)),
            };


        [TestCaseSource(nameof(selfCollidingSnakes))]
        public void Detect_ReturnsTrue_WhenSnakeHeadTouchesSelf(Snake snake)
        {
            //Arrange
            CollisionDetector collisionDetector = new CollisionDetector();

            Board board = new Board(50, 50);

            //Act
            bool didCollide = collisionDetector.Detect(board, snake);

            //Assert
            Assert.That(didCollide, Is.True);
        }

        [TestCaseSource(nameof(wallTouchingSnakes))]
        public void Detect_ReturnsTrue_WhenSnakeHeadTouchesBoardWall(Snake snake)
        {
            //Arrange
            CollisionDetector collisionDetector = new CollisionDetector();

            Board board = new Board(50, 50);

            //Act
            bool didCollide = collisionDetector.Detect(board, snake);

            //Assert
            Assert.That(didCollide, Is.True);
        }

        [TestCaseSource(nameof(nonWallTouchingSnakes))]
        public void Detect_ReturnsFalse_WhenSnakeHeadDoesNotTouchBoardWall(Snake snake)
        {
            //Arrange
            CollisionDetector collisionDetector = new CollisionDetector();

            Board board = new Board(50, 50);


            //Act
            bool didCollide = collisionDetector.Detect(board, snake);

            //Assert
            Assert.That(didCollide, Is.False);
        }


    }
}
