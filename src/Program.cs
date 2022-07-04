namespace MatryoshkaTicTacToe
{
    public static class Program
    {
        /// <summary>
        /// Current cursor position.
        /// </summary>
        private static Point CursorPosition = new();

        /// <summary>
        /// Whose turn it is.
        /// </summary>
        private static bool Player1Turn = true;

        /// <summary>
        /// Color for player 1.
        /// </summary>
        private const ConsoleColor Player1Color = ConsoleColor.Red;

        /// <summary>
        /// Color for player 2.
        /// </summary>
        private const ConsoleColor Player2Color = ConsoleColor.Blue;

        /// <summary>
        /// Where all player 1 spots are.
        /// </summary>
        private static List<Point?> Player1Spots = new()
        {
            null,
            null,
            null,
            null,
            null
        };

        /// <summary>
        /// Where all player 2 spots are.
        /// </summary>
        private static List<Point?> Player2Spots = new()
        {
            null,
            null,
            null,
            null,
            null
        };

        /// <summary>
        /// Whether to continue the game loop.
        /// </summary>
        private static bool ContinueGame = true;

        /// <summary>
        /// All board cell.
        /// </summary>
        private static List<List<BoardCell>> Board = new()
        {
            new List<BoardCell>
            {
                new BoardCell(),
                new BoardCell(),
                new BoardCell()
            },
            new List<BoardCell>
            {
                new BoardCell(),
                new BoardCell(),
                new BoardCell()
            },
            new List<BoardCell>
            {
                new BoardCell(),
                new BoardCell(),
                new BoardCell()
            }
        };

        /// <summary>
        /// Init all the things..
        /// </summary>
        private static void Main()
        {
            // Disable the cursor, if possible.
            DisableCursor();

            // Clear the screen.
            ClearScreen();

            // Loop the game.
            while (ContinueGame)
            {
                // Render the board and stats.
                Render();

                // Intercept keyboard.
                InterceptKeyboard();
            }

            // Done.
            Write(0, 20, ConsoleColor.White, string.Empty);
            Console.ResetColor();
        }

        /// <summary>
        /// Clear the screen.
        /// </summary>
        private static void ClearScreen()
        {
            try
            {
                Console.Clear();
            }
            catch
            {
                //
            }
        }

        /// <summary>
        /// Disable the cursor, if possible.
        /// </summary>
        private static void DisableCursor()
        {
            try
            {
                Console.CursorVisible = false;
            }
            catch
            {
                //
            }
        }

        /// <summary>
        /// Intercept the key presses.
        /// </summary>
        private static void InterceptKeyboard()
        {
            var key = Console.ReadKey(true);

            try
            {
                switch (key.Key)
                {
                    // Exit the game.
                    case ConsoleKey.Escape:
                        ContinueGame = false;
                        break;

                    // Move up.
                    case ConsoleKey.UpArrow:
                        CursorPosition.Y = CursorPosition.Y == 0
                            ? 2
                            : CursorPosition.Y - 1;

                        break;

                    // Move down.
                    case ConsoleKey.DownArrow:
                        CursorPosition.Y = CursorPosition.Y == 2
                            ? 0
                            : CursorPosition.Y + 1;

                        break;

                    // Move left.
                    case ConsoleKey.LeftArrow:
                        CursorPosition.X = CursorPosition.X == 0
                            ? 2
                            : CursorPosition.X - 1;

                        break;

                    // Move right.
                    case ConsoleKey.RightArrow:
                        CursorPosition.X = CursorPosition.X == 2
                            ? 0
                            : CursorPosition.X + 1;

                        break;

                    // 1.
                    case ConsoleKey.D1:
                        SetSpot(1);
                        break;

                    // 2.
                    case ConsoleKey.D2:
                        SetSpot(2);
                        break;

                    // 3.
                    case ConsoleKey.D3:
                        SetSpot(3);
                        break;

                    // 4.
                    case ConsoleKey.D4:
                        SetSpot(4);
                        break;

                    // 5.
                    case ConsoleKey.D5:
                        SetSpot(5);
                        break;
                }
            }
            catch (Exception ex)
            {
                Write(
                    0,
                    18,
                    Player1Turn
                        ? Player1Color
                        : Player2Color,
                    ex.Message);
            }
        }

        /// <summary>
        /// Render the board and stats.
        /// </summary>
        private static void Render()
        {
            // Prep.
            int top;
            int left;

            // Player 1 stats.
            Write(0, 0, Player1Color, "Player 1");
            Write(1, 2, ConsoleColor.DarkGray, "Pieces:");
            Write(1, 3, ConsoleColor.DarkGray, "* 1");
            Write(1, 4, ConsoleColor.DarkGray, "* 2");
            Write(1, 5, ConsoleColor.DarkGray, "* 3");
            Write(1, 6, ConsoleColor.DarkGray, "* 4");
            Write(1, 7, ConsoleColor.DarkGray, "* 5");

            for (var i = 0; i < 5; i++)
            {
                var ps = Player1Spots[i];

                top = i + 3;

                if (ps == null)
                {
                    Write(4, top, ConsoleColor.Black, "     ");
                }
                else
                {
                    Write(3, top, ConsoleColor.White, $"{i + 1}");
                    Write(6, top, Player1Color, $"{ps.X + 1}x{ps.Y + 1}");
                }
            }

            // Player 2 stats.
            Write(0, 9, Player2Color, "Player 2");
            Write(1, 11, ConsoleColor.DarkGray, "Pieces:");
            Write(1, 12, ConsoleColor.DarkGray, "* 1");
            Write(1, 13, ConsoleColor.DarkGray, "* 2");
            Write(1, 14, ConsoleColor.DarkGray, "* 3");
            Write(1, 15, ConsoleColor.DarkGray, "* 4");
            Write(1, 16, ConsoleColor.DarkGray, "* 5");

            for (var i = 0; i < 5; i++)
            {
                var ps = Player2Spots[i];

                top = i + 12;

                if (ps == null)
                {
                    Write(4, top, ConsoleColor.Black, "     ");
                }
                else
                {
                    Write(3, top, ConsoleColor.White, $"{i + 1}");
                    Write(6, top, Player2Color, $"{ps.X + 1}x{ps.Y + 1}");
                }
            }

            // Grid.
            for (var i = 0; i < 17; i++)
            {
                Write(15, i, ConsoleColor.DarkGray, "         ##         ##         ");
            }

            Write(15, 5, ConsoleColor.DarkGray, new string('#', 31));
            Write(15, 11, ConsoleColor.DarkGray, new string('#', 31));

            // Cells.
            top = -6;

            for (var r = 0; r < 3; r++)
            {
                top += 6;
                left = 4;

                for (var c = 0; c < 3; c++)
                {
                    left += 11;

                    var bc = Board[r][c];

                    // Cell info, if set.
                    if (bc.IsSet)
                    {
                        Write(
                            left + 4,
                            top,
                            bc.SetForPlayer1
                                ? Player1Color
                                : Player2Color,
                            "#");

                        Write(
                            left + 3,
                            top + 1,
                            bc.SetForPlayer1
                                ? Player1Color
                                : Player2Color,
                            "# #");

                        Write(
                            left + 2,
                            top + 2,
                            bc.SetForPlayer1
                                ? Player1Color
                                : Player2Color,
                            $"# {bc.PointsSet} #");

                        Write(
                            left + 3,
                            top + 3,
                            bc.SetForPlayer1
                                ? Player1Color
                                : Player2Color,
                            "# #");

                        Write(
                            left + 4,
                            top + 4,
                            bc.SetForPlayer1
                                ? Player1Color
                                : Player2Color,
                            "#");
                    }

                    // Selector?
                    if (CursorPosition.Y == r &&
                        CursorPosition.X == c)
                    {
                        Write(
                            left + 2,
                            top,
                            Player1Turn
                                ? Player1Color
                                : Player2Color,
                            "#####");

                        Write(
                            left + 2,
                            top + 4,
                            Player1Turn
                                ? Player1Color
                                : Player2Color,
                            "#####");

                        for (var i = 0; i < 3; i++)
                        {
                            Write(
                                left + 1,
                                top + (i + 1),
                                Player1Turn
                                    ? Player1Color
                                    : Player2Color,
                                "#");

                            Write(
                                left + 7,
                                top + (i + 1),
                                Player1Turn
                                    ? Player1Color
                                    : Player2Color,
                                "#");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Attempt to set the points for the current player.
        /// </summary>
        /// <param name="points">Number of points to set.</param>
        private static void SetSpot(int points)
        {
            var bc = Board[CursorPosition.Y][CursorPosition.X];
            var index = points - 1;
            var ps = Player1Turn
                    ? Player1Spots[index]
                    : Player2Spots[index];

            BoardCell? prev = null;

            for (var i = 0; i < 3; i++)
            {
                prev = Board[i]
                    .Find(n => n.IsSet &&
                               n.SetForPlayer1 == Player1Turn &&
                               n.PointsSet == points);

                if (prev != null)
                {
                    break;
                }
            }

            if (prev != null &&
                ps != null)
            {
                // Player X has already placed Y points in a cell.
                throw new Exception(
                    $"Player {(Player1Turn ? "1" : "2")} has already placed {points} points in {ps.Y + 1}x{ps.X + 1}.");
            }

            if (bc.IsSet)
            {
                if (Player1Turn)
                {
                    if (bc.SetForPlayer1)
                    {
                        if (points > bc.PointsSet)
                        {
                            // Ok.
                        }
                        else
                        {
                            // Player 1 can only set a higher number on own cell.
                            throw new Exception(
                                "Player 1 can only set a higher number on own cell.");
                        }
                    }
                    else
                    {
                        if (points > bc.PointsSet)
                        {
                            // Ok.
                        }
                        else
                        {
                            // Player 1 can only set a higher number over enemy cell.
                            throw new Exception(
                                "Player 1 can only set a higher number over enemy cell.");
                        }
                    }
                }
                else
                {
                    if (!bc.SetForPlayer1)
                    {
                        if (points > bc.PointsSet)
                        {
                            // Ok.
                        }
                        else
                        {
                            // Player 2 can only set a higher number on own cell.
                            throw new Exception(
                                "Player 2 can only set a higher number on own cell.");
                        }
                    }
                    else
                    {
                        if (points > bc.PointsSet)
                        {
                            // Ok.
                        }
                        else
                        {
                            // Player 2 can only set a higher number over enemy cell.
                            throw new Exception(
                                "Player 2 can only set a higher number over enemy cell.");
                        }
                    }
                }

                bc.SetForPlayer1 = !bc.SetForPlayer1;
                bc.PointsSet = points;

                if (Player1Turn)
                {
                    for (var i = 0; i < Player2Spots.Count; i++)
                    {
                        if (Player2Spots[i]?.X == CursorPosition.X &&
                            Player2Spots[i]?.Y == CursorPosition.Y)
                        {
                            Player2Spots[i] = null;
                        }
                    }

                    Player1Spots[index] =
                        new Point(
                            CursorPosition.X,
                            CursorPosition.Y);
                }
                else
                {
                    for (var i = 0; i < Player1Spots.Count; i++)
                    {
                        if (Player1Spots[i]?.X == CursorPosition.X &&
                            Player1Spots[i]?.Y == CursorPosition.Y)
                        {
                            Player1Spots[i] = null;
                        }
                    }

                    Player2Spots[index] =
                        new Point(
                            CursorPosition.X,
                            CursorPosition.Y);
                }
            }
            else
            {
                

                bc.IsSet = true;
                bc.SetForPlayer1 = Player1Turn;
                bc.PointsSet = points;

                if (Player1Turn)
                {
                    Player1Spots[index] =
                        new Point(
                            CursorPosition.X,
                            CursorPosition.Y);
                }
                else
                {
                    Player2Spots[index] =
                        new Point(
                            CursorPosition.X,
                            CursorPosition.Y);
                }
            }

            Player1Turn = !Player1Turn;

            // Clear out the previous status.
            Write(
                0,
                18,
                ConsoleColor.Black,
                new string(' ', Console.WindowWidth));
        }

        /// <summary>
        /// Write a text entry to screen.
        /// </summary>
        /// <param name="left">Left position of text.</param>
        /// <param name="top">Top position of text.</param>
        /// <param name="color">Color of the text.</param>
        /// <param name="text">The text to write.</param>
        private static void Write(
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
    }

    public class BoardCell
    {
        /// <summary>
        /// Is the board cell set?
        /// </summary>
        public bool IsSet { get; set; }

        /// <summary>
        /// Is the cell set for player 1?
        /// </summary>
        public bool SetForPlayer1 { get; set; }

        /// <summary>
        /// How many points are set for the cell.
        /// </summary>
        public int PointsSet { get; set; }
    }

    public class Point
    {
        /// <summary>
        /// Current X position.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Current Y position.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Set a new point.
        /// </summary>
        /// <param name="x">X coord.</param>
        /// <param name="y">Y coord.</param>
        public Point(
            int x = 1,
            int y = 1)
        {
            this.X = x;
            this.Y = y;
        }
    }
}