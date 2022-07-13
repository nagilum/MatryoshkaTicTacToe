using static MatryoshkaTicTacToe.Game;
using static MatryoshkaTicTacToe.Ui;

namespace MatryoshkaTicTacToe
{
    public static class Input
    {
        /// <summary>
        /// Capture the user input and act.
        /// </summary>
        public static void Capture()
        {
            try
            {
                var key = Console.ReadKey(true);

                switch (CurrentScene)
                {
                    // Welcome scene.
                    case Scene.Welcome:
                        switch (key.Key)
                        {
                            // Start a new game.
                            case ConsoleKey.Enter:
                                Console.Clear();
                                CurrentScene = Scene.Game;
                                break;

                            // Exit the game.
                            case ConsoleKey.Escape:
                                Running = false;
                                break;
                        }

                        break;

                    // Game scene.
                    case Scene.Game:
                        switch (key.Key)
                        {
                            // Ask for confirmation.
                            case ConsoleKey.Escape:
                                CurrentScene = Scene.ConfirmExit;
                                break;

                            // Up.
                            case ConsoleKey.UpArrow:
                                CurrentPosition.Y--;
                                if (CurrentPosition.Y == 0) { CurrentPosition.Y = 3; }
                                break;

                            // Down.
                            case ConsoleKey.DownArrow:
                                CurrentPosition.Y++;
                                if (CurrentPosition.Y == 4) { CurrentPosition.Y = 1; }
                                break;

                            // Left.
                            case ConsoleKey.LeftArrow:
                                CurrentPosition.X--;
                                if (CurrentPosition.X == 0) { CurrentPosition.X = 3; }
                                break;

                            // Right.
                            case ConsoleKey.RightArrow:
                                CurrentPosition.X++;
                                if (CurrentPosition.X == 4) { CurrentPosition.X = 1; }
                                break;

                            // Set 1 point.
                            case ConsoleKey.D1:
                                SetPoints(1);
                                break;

                            // Set 2 points.
                            case ConsoleKey.D2:
                                SetPoints(2);
                                break;

                            // Set 3 points.
                            case ConsoleKey.D3:
                                SetPoints(3);
                                break;

                            // Set 4 points.
                            case ConsoleKey.D4:
                                SetPoints(4);
                                break;

                            // Set 5 points.
                            case ConsoleKey.D5:
                                SetPoints(5);
                                break;
                        }

                        break;

                    // Confirm desire to exit game.
                    case Scene.ConfirmExit:
                        switch (key.Key)
                        {
                            // Exit the game.
                            case ConsoleKey.Enter:
                                Running = false;
                                break;

                            // Continue playing.
                            case ConsoleKey.Escape:
                                Console.Clear();
                                CurrentScene = Scene.Game;
                                break;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                WriteCentered(
                    21,
                    Player1Turn
                        ? Player1.Color
                        : Player2.Color,
                    ex.Message);
            }
        }

        /// <summary>
        /// Set points for the current player.
        /// </summary>
        /// <param name="points">Number of points to set.</param>
        private static void SetPoints(int points)
        {
            // Prep.
            var bc = Board
                .First(n => n.X == CurrentPosition.X &&
                            n.Y == CurrentPosition.Y);

            var playerText = $"Player {(Player1Turn ? "1" : "2")}";
            var index = points - 1;
            var ps = Player1Turn
                ? Player1.Points[index]
                : Player2.Points[index];

            // Get previous cell.
            var prev = Board
                .Find(n => n.IsSet &&
                           n.SetForPlayer1 == Player1Turn &&
                           n.PointsSet == points);

            if (prev != null &&
                ps != null)
            {
                throw new Exception(
                    $"{playerText} has already placed {points} points on {ps.X}x{ps.Y}.");
            }

            // Is it already set?
            if (bc.IsSet)
            {
                // Check if enough points are being set.
                if (Player1Turn)
                {
                    if (bc.SetForPlayer1)
                    {
                        if (points > bc.PointsSet) { /* ok */ }
                        else
                        {
                            throw new Exception(
                                $"{playerText} can only set a higher number of points on own cell.");
                        }
                    }
                    else
                    {
                        if (points > bc.PointsSet) { /* ok */ }
                        else
                        {
                            throw new Exception(
                                $"{playerText} can only set a higher number of points over other player's cell.");
                        }
                    }
                }
                else
                {
                    if (!bc.SetForPlayer1)
                    {
                        if (points > bc.PointsSet) { /* ok */ }
                        else
                        {
                            throw new Exception(
                                $"{playerText} can only set a higher number of points on own cell.");
                        }
                    }
                    else
                    {
                        if (points > bc.PointsSet) { /* ok */ }
                        else
                        {
                            throw new Exception(
                                $"{playerText} can only set a higher number of points over other player's cell.");
                        }
                    }
                }

                bc.SetForPlayer1 = !bc.SetForPlayer1;
                bc.PointsSet = points;

                // Reset previous set value and set new.
                if (Player1Turn)
                {
                    for (var i = 0; i < Player2.Points.Count; i++)
                    {
                        var pp = Player2.Points[i];

                        if (pp != null &&
                            pp.X == CurrentPosition.X &&
                            pp.Y == CurrentPosition.Y)
                        {
                            pp.Overwritten = true;
                        }
                    }

                    Player1.Points[index] =
                        new Point(CurrentPosition);
                }
                else
                {
                    for (var i = 0; i < Player1.Points.Count; i++)
                    {
                        var pp = Player1.Points[i];

                        if (pp != null &&
                            pp.X == CurrentPosition.X &&
                            pp.Y == CurrentPosition.Y)
                        {
                            pp.Overwritten = true;
                        }
                    }

                    Player2.Points[index] =
                        new Point(CurrentPosition);
                }
            }

            // New cell!
            else
            {
                if (ps != null)
                {
                    throw new Exception(
                        $"{playerText} has already placed {points} points on {ps.X}x{ps.Y}.");
                }

                bc.IsSet = true;
                bc.SetForPlayer1 = Player1Turn;
                bc.PointsSet = points;

                if (Player1Turn)
                {
                    Player1.Points[index] =
                        new Point(CurrentPosition);
                }
                else
                {
                    Player2.Points[index] =
                        new Point(CurrentPosition);
                }
            }

            // Shift the next round to other player.
            Player1Turn = !Player1Turn;

            // Clear out the previous error/status.
            WriteCentered(
                21,
                ConsoleColor.Black,
                new string(' ', Console.WindowWidth));
        }
    }
}