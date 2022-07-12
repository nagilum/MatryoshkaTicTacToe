namespace MatryoshkaTicTacToe
{
    public class BoardCell
    {
        /// <summary>
        /// X coordinate.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Whether the cell is set.
        /// </summary>
        public bool IsSet { get; set; }

        /// <summary>
        /// Number of points set in cell.
        /// </summary>
        public int PointsSet { get; set; }

        /// <summary>
        /// Whether the cell is set for player 1.
        /// </summary>
        public bool SetForPlayer1 { get; set; }

        /// <summary>
        /// Create a new cell.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public BoardCell(
            int x,
            int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}