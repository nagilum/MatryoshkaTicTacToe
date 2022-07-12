namespace MatryoshkaTicTacToe
{
    public class Player
    {
        /// <summary>
        /// Name of player.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Color to render player with.
        /// </summary>
        public ConsoleColor Color { get; set; }

        /// <summary>
        /// Set points for player.
        /// </summary>
        public List<Point?> Points = new()
        {
            null,
            null,
            null,
            null,
            null
        };

        /// <summary>
        /// Create a new player.
        /// </summary>
        /// <param name="name">Name of player.</param>
        /// <param name="color">Color to render player with.</param>
        public Player(
            string name,
            ConsoleColor color)
        {
            this.Name = name;
            this.Color = color;
        }
    }
}