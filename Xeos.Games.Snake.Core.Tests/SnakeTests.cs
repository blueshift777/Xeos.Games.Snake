using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeos.Games.Snake.Core.Tests
{
    internal class SnakeTests
    {
		static object[] DirectionTestData =
		{
			new object[] { new Point(5, 1), new Point(4, 1), Direction.Right },
			new object[] { new Point(5, 1), new Point(6, 1), Direction.Left },
			new object[] { new Point(5, 1), new Point(5, 2), Direction.Up },
			new object[] { new Point(5, 1), new Point(5, 0), Direction.Down},
        };

		[TestCaseSource(nameof(DirectionTestData))]
		public void Direction_GivenSegments_ReturnsCorrectDirection(Point head, Point neck, Direction expectedDirection)
		{
			//Arrange
			Snake snake = new Snake(head, neck);

			//Act
			Direction actualDirection = snake.Direction;

			//Assert
			Assert.That(actualDirection, Is.EqualTo(expectedDirection));
		}

	}
}
