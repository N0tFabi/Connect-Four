using System;

class ConnectFour {
    static int[,] board = new int[6, 7];
    static int currentPlayer = 1;

    static bool playAgainstComputer = false;

    static void Main(string[] args) {
        // Clear Console
        Console.Clear();

        // Initialize the board to empty
        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < 7; j++) {
                board[i, j] = 0;
            }
        }

        // Ask if the user wants to play against a computer
        while(true) {
            Console.WriteLine("Do you want to play against the computer? (true/false)");
            try {
                playAgainstComputer = Convert.ToBoolean(Console.ReadLine());
                break;
            } catch (Exception ex) {
                Console.WriteLine(ex); // Added so that when compiling the compiler doesn't complain about it being not used
                Console.Clear();
                Console.WriteLine("Invalid answer given.");
                continue;
            }
        }

        // Play the game
        while (true) {
            // Print the board
            PrintBoard();

            // Get the player's move
            int move = GetPlayerMove();
            if (move == -1) {
                Console.Clear();
                Console.WriteLine("Invalid move. Try again.");
                continue;
            }

            // Make the move
            MakeMove(move);

            // Check for a win
            if (CheckForWin()) {
                if (currentPlayer == 2 && playAgainstComputer) {
                    Console.WriteLine("\n----------\nThe Computer wins!\n----------");
                    break;
                } else {
                    Console.WriteLine("\n----------\nPlayer {0} wins!\n----------", currentPlayer);
                    break;
                }
            }

            // Switch players
            currentPlayer = (currentPlayer == 1) ? 2 : 1;

            // Clear Console
            Console.Clear();
        }
    }

    static int GetPlayerMove() {
        int move = 0;

        if (playAgainstComputer && currentPlayer == 2) {
            Random r = new Random();
            while(!(0 < move && move < 8)) {
                move = r.Next(1, 8);
            }
            move--;
        } else {
            Console.WriteLine("Player {0}, enter column number (1-7) to drop your piece:", currentPlayer);
            move = int.Parse(Console.ReadLine()) - 1;
            if (move < 0 || move > 6) {
                return -1;
            }
            if (board[0, move] != 0) {
                return -1;
            }
        }

        return move;
        
    }

    static void MakeMove(int column) {
        for (int i = 5; i >= 0; i--) {
            if (board[i, column] == 0) {
                board[i, column] = currentPlayer;
                return;
            }
        }
    }

    static void PrintBoard() {
        for (int j = 0; j < 7; j++) {
            Console.Write("+---");
        }
        Console.WriteLine("+");
        for (int i = 0; i < 6; i++) {
            Console.Write("| ");
            for (int j = 0; j < 7; j++) {
                if (board[i, j] == 1) {
                    Console.ForegroundColor = ConsoleColor.Red;
                } else if (board[i, j] == 2) {
                    Console.ForegroundColor = ConsoleColor.Green;
                } else {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write(board[i, j]);
                Console.ResetColor();
                Console.Write(" | ");
            }
            Console.WriteLine();
            for (int j = 0; j < 7; j++) {
                Console.Write("+---");
            }
            Console.WriteLine("+");
        }
    }

    static bool CheckForWin() {
        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < 4; j++) {
                if (board[i, j] == currentPlayer &&
                    board[i, j + 1] == currentPlayer &&
                    board[i, j + 2] == currentPlayer &&
                    board[i, j + 3] == currentPlayer) {
                    return true;
                }
            }
        }

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 7; j++) {
                if (board[i, j] == currentPlayer &&
                    board[i + 1, j] == currentPlayer &&
                    board[i + 2, j] == currentPlayer &&
                    board[i + 3, j] == currentPlayer) {
                    return true;
                }
            }
        }

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 4; j++) {
                if (board[i, j] == currentPlayer &&
                    board[i + 1, j + 1] == currentPlayer &&
                    board[i + 2, j + 2] == currentPlayer &&
                    board[i + 3, j + 3] == currentPlayer) {
                        return true;
                }
            }
        }

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 4; j++) {
                if (board[i, j] == currentPlayer &&
                    board[i - 1, j + 1] == currentPlayer &&
                    board[i - 2, j + 2] == currentPlayer &&
                    board[i - 3, j + 3] == currentPlayer) {
                        return true;
                }
            }
        }

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 4; j++) {
                if (board[i, j] == currentPlayer &&
                    board[i + 1, j - 1] == currentPlayer &&
                    board[i + 2, j - 2] == currentPlayer &&
                    board[i + 3, j - 3] == currentPlayer) {
                        return true;
                }
            }
        }

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 4; j++) {
                if (board[i, j] == currentPlayer &&
                    board[i - 1, j - 1] == currentPlayer &&
                    board[i - 2, j - 2] == currentPlayer &&
                    board[i - 3, j - 3] == currentPlayer) {
                        return true;
                }
            }
        }

        return false;
    }
}