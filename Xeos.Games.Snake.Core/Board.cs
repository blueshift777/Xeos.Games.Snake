namespace Xeos.Games.Snake.Core
{
    public class Board
    {
        private int boardWidth;
        private int boardHeight;

        public int Width => boardWidth;
        public int Height => boardHeight;

        public Board(int boardWidth, int boardHeight)
        {
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
        }

    }
}
