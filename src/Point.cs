namespace MatryoshkaTicTacToe
{
    public class Point
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
        /// Whether the point has been overwritten.
        /// </summary>
        public bool Overwritten { get; set; }

        /// <summary>
        /// Create a new point.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Create a new point.
        /// </summary>
        /// <param name="point">Coordinates.</param>
        public Point(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }
    }
}