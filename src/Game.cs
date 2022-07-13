using System.Reflection;

namespace MatryoshkaTicTacToe
{
    public static class Game
    {
        /// <summary>
        /// Whether to continue the game loop.
        /// </summary>
        public static bool Running { get; set; } = true;

        /// <summary>
        /// Whose turn it is.
        /// </summary>
        public static bool Player1Turn { get; set; } = true;

        /// <summary>
        /// Player 1.
        /// </summary>
        public static Player Player1 { get; set; }
            = new(
                "Player 1",
                ConsoleColor.Red);

        /// <summary>
        /// Player 2.
        /// </summary>
        public static Player Player2 { get; set; }
            = new(
                "Player 2",
                ConsoleColor.Blue);

        /// <summary>
        /// Current selector position.
        /// </summary>
        public static readonly Point CurrentPosition = new(2, 2);

        /// <summary>
        /// The board.
        /// </summary>
        public static readonly List<BoardCell> Board = new()
        {
            new BoardCell(1, 1),
            new BoardCell(1, 2),
            new BoardCell(1, 3),

            new BoardCell(2, 1),
            new BoardCell(2, 2),
            new BoardCell(2, 3),

            new BoardCell(3, 1),
            new BoardCell(3, 2),
            new BoardCell(3, 3),
        };

        /// <summary>
        /// Init all the things..
        /// </summary>
        private static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Clear();

            while (Running)
            {
                // Render the current scene.
                Ui.Render();

                // Capture the user input.
                Input.Capture();
            }

            Console.ResetColor();
            Console.Clear();
        }
    }
}