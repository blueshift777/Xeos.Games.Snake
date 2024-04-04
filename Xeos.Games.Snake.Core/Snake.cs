using System.Drawing;

namespace Xeos.Games.Snake.Core
{
    public class Snake
    {
        public int Length => Segments?.Any() == true ? Segments.Count : 0;
        public IList<Point> Segments { get; set; } = new List<Point>();
        public Point Head => Segments?.Any() == true ? Segments.First() : new Point(0, 0);

        public Direction Direction => GetDirection();


        public Snake(IEnumerable<Point> segments)
        {
            Segments = segments.ToList();
        }

        public Snake(params Point[] segments)
        {
            Segments = segments.ToList();
        }

        private Direction GetDirection()
        {
            if (Segments?.Count >= 2)
            {
                Point neck = Segments[1];
                int deltaX = Head.X - neck.X;
                int deltaY = Head.Y - neck.Y;

                if (deltaX < 0)
                {
                    return Direction.Left;
                }

                if (deltaX > 0)
                {
                    return Direction.Right;
                }

                if (deltaY < 0) 
                {
                    return Direction.Up;
                }

                if (deltaY > 0)
                {
                    return Direction.Down;
                }
            }

            return Direction.Unknown;
        }

    }
}
