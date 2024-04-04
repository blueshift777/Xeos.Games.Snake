using System.Drawing;

namespace Xeos.Games.Snake.Core.Tests
{
    public class GameManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Construct_ThrowsException_WhenSnakeTooBigForBoard()
        {
            Assert.Throws<ArgumentException>(() => new GameManager(10, 1, 6, 6));
        }


        [Test]
        public void Start_ReturnsTrue_WhenEverythingWorks()
        {
            GameManager gameManager = CreateValidGameManager();

            bool didStart = gameManager.Start();

            Assert.That(didStart, Is.True);
        }


        [Test]
        public void UpdateSnake_ReturnsTrue_WhenSnakeIsValid()
        {
            GameManager gameManager = CreateValidGameManager();


            IList<Point> segments = new List<Point>(GetValidSegments());

            Snake snake = new Snake(segments);
            bool didUpdateSnake = gameManager.UpdateSnake(snake);

            Assert.That(didUpdateSnake, Is.True);
        }


        [Test]
        public void UpdateSnake_ReturnsFalse_WhenSnakeIsInvalid()
        {
            GameManager gameManager = CreateValidGameManager();

            IList<Point> segments = new List<Point>(GetInvalidSegments());

            Snake snake = new Snake(segments);
            bool didUpdateSnake = gameManager.UpdateSnake(snake);

            Assert.That(didUpdateSnake, Is.False);
        }


        private static GameManager CreateValidGameManager()
        {
            return new GameManager(5, 1, 50, 50);
        }

        private IEnumerable<Point> GetInvalidSegments()
        {
            return Enumerable.Range(0, 3).Select(n => new Point(10, 10 + n));

        }
        private static IEnumerable<Point> GetValidSegments()
        {
            return Enumerable.Range(0, 7).Select(n => new Point(10, 10 + n));
        }
    }
}