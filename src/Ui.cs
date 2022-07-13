using static MatryoshkaTicTacToe.Game;

namespace MatryoshkaTicTacToe
{
    public static class Ui
    {
        /// <summary>
        /// All the scenes.
        /// </summary>
        public enum Scene
        {
            Welcome,
            Game,
            ConfirmExit
        }

        /// <summary>
        /// Which scene to render.
        /// </summary>
        public static Scene CurrentScene { get; set; } = Scene.Welcome;

        /// <summary>
        /// Render the current scene.
        /// </summary>
        public static void Render()
        {
            switch (CurrentScene)
            {
                case Scene.Welcome:
                    RenderWelcomeScene();
                    break;

                case Scene.Game:
                    RenderGameScene();
                    break;

                case Scene.ConfirmExit:
                    RenderConfirmExitScene();
                    break;
            }
        }

        #region Scenes

        /// <summary>
        /// Render the welcome scene.
        /// </summary>
        private static void RenderWelcomeScene()
        {
            WriteCentered(3, Player1.Color, "Matryoshka     ");
            WriteCentered(4, Player2.Color, "     Tic Tac Toe");

            WriteCentered(7, ConsoleColor.White, "Press ENTER to start");
            WriteCentered(8, ConsoleColor.White, "Press ESC to exit game");
        }

        /// <summary>
        /// Render the game scene.
        /// </summary>
        private static void RenderGameScene()
        {
            // Prep.
            var left = (Console.WindowWidth - ((9 * 3) + 2)) / 2;

            // Title
            Write(
                left + 14 - "Matryoshka".Length,
                1,
                Player1.Color,
                "Matryoshka");

            Write(
                left + 15,
                1,
                Player2.Color,
                "Tic Tac Toe");

            // Player 1 stats.
            var pl = left - 8;

            Write(
                pl + 3 - Player1.Name.Length,
                7,
                Player1.Color,
                Player1.Name);

            Write(pl, 9, Player1.Points[0] != null ? ConsoleColor.White : ConsoleColor.DarkGray, "1 *");
            Write(pl, 10, Player1.Points[1] != null ? ConsoleColor.White : ConsoleColor.DarkGray, "2 *");
            Write(pl, 11, Player1.Points[2] != null ? ConsoleColor.White : ConsoleColor.DarkGray, "3 *");
            Write(pl, 12, Player1.Points[3] != null ? ConsoleColor.White : ConsoleColor.DarkGray, "4 *");
            Write(pl, 13, Player1.Points[4] != null ? ConsoleColor.White : ConsoleColor.DarkGray, "5 *");

            for (var i = 0; i < 5; i++)
            {
                var ps = Player1.Points[i];

                Write(
                    pl - 4,
                    i + 9,
                    ps == null
                        ? ConsoleColor.Black
                        : ps.Overwritten
                            ? ConsoleColor.DarkYellow
                            : ConsoleColor.Yellow,
                    ps == null
                        ? "   "
                        : $"{ps.X}x{ps.Y}");
            }

            // Player 2 stats.
            pl = left + (9 * 3) + 7;

            Write(
                pl,
                7,
                Player2.Color,
                Player2.Name);

            Write(pl, 9, Player2.Points[0] != null ? ConsoleColor.White : ConsoleColor.DarkGray, "* 1");
            Write(pl, 10, Player2.Points[1] != null ? ConsoleColor.White : ConsoleColor.DarkGray, "* 2");
            Write(pl, 11, Player2.Points[2] != null ? ConsoleColor.White : ConsoleColor.DarkGray, "* 3");
            Write(pl, 12, Player2.Points[3] != null ? ConsoleColor.White : ConsoleColor.DarkGray, "* 4");
            Write(pl, 13, Player2.Points[4] != null ? ConsoleColor.White : ConsoleColor.DarkGray, "* 5");

            for (var i = 0; i < 5; i++)
            {
                var ps = Player2.Points[i];

                Write(
                    pl + 4,
                    i + 9,
                    ps == null
                        ? ConsoleColor.Black
                        : ps.Overwritten
                            ? ConsoleColor.DarkYellow
                            : ConsoleColor.Yellow,
                    ps == null
                        ? "   "
                        : $"{ps.X}x{ps.Y}");
            }

            // Grid.
            for (var i = 3; i < 20; i++)
            {
                Write(left, i, ConsoleColor.Black, new string(' ', 31));
            }

            for (var i = 3; i < 20; i++)
            {
                Write(left + 9, i, ConsoleColor.DarkGray, "I");
                Write(left + 19, i, ConsoleColor.DarkGray, "I");
            }

            Write(left, 8, ConsoleColor.DarkGray, new string('-', (9 * 3) + 2));
            Write(left, 14, ConsoleColor.DarkGray, new string('-', (9 * 3) + 2));

            Write(left + 9, 8, ConsoleColor.DarkGray, "+");
            Write(left + 19, 8, ConsoleColor.DarkGray, "+");

            Write(left + 9, 14, ConsoleColor.DarkGray, "+");
            Write(left + 19, 14, ConsoleColor.DarkGray, "+");

            // Cells.
            int ct;
            int cl;

            for (var y = 1; y < 4; y++)
            {
                ct = -3 + (6 * y);

                for (var x = 1; x < 4; x++)
                {
                    cl = left - 10 + (10 * x);

                    // Get cell for location.
                    var cell = Board
                        .First(n => n.X == x &&
                                    n.Y == y);

                    // Cell info, if set.
                    if (cell.IsSet)
                    {
                        Write(
                            cl + 4,
                            ct,
                            cell.SetForPlayer1
                                ? Player1.Color
                                : Player2.Color,
                            "*");

                        Write(
                            cl + 3,
                            ct + 1,
                            cell.SetForPlayer1
                                ? Player1.Color
                                : Player2.Color,
                            "* *");

                        Write(
                            cl + 2,
                            ct + 2,
                            cell.SetForPlayer1
                                ? Player1.Color
                                : Player2.Color,
                            $"* {cell.PointsSet} *");

                        Write(
                            cl + 3,
                            ct + 3,
                            cell.SetForPlayer1
                                ? Player1.Color
                                : Player2.Color,
                            "* *");

                        Write(
                            cl + 4,
                            ct + 4,
                            cell.SetForPlayer1
                                ? Player1.Color
                                : Player2.Color,
                            "*");
                    }

                    // Selector?
                    if (CurrentPosition.X == x &&
                        CurrentPosition.Y == y)
                    {
                        for (var i = 1; i < 4; i++)
                        {
                            Write(
                                cl + 1,
                                ct + i,
                                Player1Turn
                                    ? Player1.Color
                                    : Player2.Color,
                                "#");

                            Write(
                                cl + 7,
                                ct + i,
                                Player1Turn
                                    ? Player1.Color
                                    : Player2.Color,
                                "#");
                        }

                        Write(
                            cl + 2,
                            ct,
                            Player1Turn
                                ? Player1.Color
                                : Player2.Color,
                            new string('#', 5));

                        Write(
                            cl + 2,
                            ct + 4,
                            Player1Turn
                                ? Player1.Color
                                : Player2.Color,
                            new string('#', 5));
                    }
                }
            }

            // Info.
            WriteCentered(
                23,
                ConsoleColor.DarkGray,
                "Use arrow keys to navigate selected position.");

            WriteCentered(
                24,
                ConsoleColor.DarkGray,
                "Press numbers 1 through 5 to set that amount of points which must be higher than already set.");

            WriteCentered(
                25,
                ConsoleColor.DarkGray,
                "Press ESC to exit game.");
        }

        /// <summary>
        /// Render the confirm exit scene.
        /// </summary>
        private static void RenderConfirmExitScene()
        {
            WriteCentered(7, ConsoleColor.White, new string('#', 33));
            WriteCentered(8, ConsoleColor.White, "#                               #");
            WriteCentered(9, ConsoleColor.White, "#    Press ENTER to exit game   #");
            WriteCentered(10, ConsoleColor.White, "#      Press ESC to cancel      #");
            WriteCentered(11, ConsoleColor.White, "#                               #");
            WriteCentered(12, ConsoleColor.White, new string('#', 33));
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Write a text on screen, with location and color.
        /// </summary>
        /// <param name="left">Left position in console.</param>
        /// <param name="top">Top position in console.</param>
        /// <param name="color">Foreground color.</param>
        /// <param name="text">Text to write.</param>
        public static void Write(
            int left,
            int top,
            ConsoleColor color,
            string text)
        {
            Console.CursorLeft = left;
            Console.CursorTop = top;
            Console.ForegroundColor = color;
            Console.Write(text);
        }

        /// <summary>
        /// Write a text on screen, centered and with color.
        /// </summary>
        /// <param name="top">Top position in console.</param>
        /// <param name="color">Foreground color.</param>
        /// <param name="text">Text to write.</param>
        public static void WriteCentered(
            int top,
            ConsoleColor color,
            string text)
        {
            Write(
                (Console.WindowWidth - text.Length) / 2,
                top,
                color,
                text);
        }

        #endregion
    }
}