using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeos.Games.Snake.Core.Tests
{
    internal class FoodEatenDetectorTests
    {

		[Test]
		public void Detect_ReturnsTrue_WhenHeadTouchesFood()
		{
			//Arrange
			FoodEatenDetector foodEatenDetector = new FoodEatenDetector();

			//Act
			Snake snake = new Snake(new Point(10, 10), new Point(10, 11), new Point(10, 12)); //Snake direction: Up
			Point foodLocation = new Point(10, 9); //Food is one point above snake head

			bool didEat = foodEatenDetector.Detect(snake, foodLocation);

			//Assert
			Assert.That(didEat, Is.True);
		}

        [Test]
        public void Detect_ReturnsFalse_WhenHeadDoesNotTouchesFood()
        {
            //Arrange
            FoodEatenDetector foodEatenDetector = new FoodEatenDetector();

            //Act
            Snake snake = new Snake(new Point(10, 10), new Point(10, 11), new Point(10, 12));
            Point foodLocation = new Point(10, 8);

            bool didEat = foodEatenDetector.Detect(snake, foodLocation);

            //Assert
            Assert.That(didEat, Is.False);
        }
    }
}
