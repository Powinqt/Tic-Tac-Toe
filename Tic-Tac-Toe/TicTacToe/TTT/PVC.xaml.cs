using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class PVC : Window
    {
        private string currentPlayer = "X"; // Player is always "X", CPU is "O"
        private bool gameActive = true;

        public PVC()
        {
            InitializeComponent();
 

            gameActive = true;
            currentPlayer = "X";
        }

        private Button[] GetAllButtons()
        {
            return new Button[] { Button0, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8 };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!gameActive)
                return;

            Button button = (Button)sender;

            if (string.IsNullOrEmpty(button.Content?.ToString()))
            {
                button.Content = currentPlayer;

                if (CheckWinner())
                {
                    ShowResult($"{currentPlayer} wins!"); // Show winner result
                }
                else if (IsBoardFull())
                {
                    ShowResult("It's a draw!"); // Show draw result
                }
                else
                {
                    SwitchTurn();
                }
            }
        }
        private void ShowMainMenu()
        {
            // Close the current game window and open the MainMenu window
            MainWindow mainWindow = new MainWindow(); // Make sure you have a MainMenu.xaml window
            mainWindow.Show();
            this.Close(); // Close the current window (PVP)
        }

        //private void RestartButton_Click(object sender, RoutedEventArgs e)
        //{
        //    foreach (Button button in new Button[] { Button0, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8 })
        //    {
        //        button.Content = null;
        //    }

        //    currentPlayer = "X";
        //    gameActive = true;
        //    ResetBoard();

        //    // Enable the game to start
        //    gameActive = true;

        //    // Optionally, show a message who starts first
        //    MessageBox.Show(currentPlayer + " will start the game!", "Game Info", MessageBoxButton.OK, MessageBoxImage.Information);
        //}
        //private void ResetBoard()
        //{
        //    Button0.Content = null;
        //    Button1.Content = null;
        //    Button2.Content = null;
        //    Button3.Content = null;
        //    Button4.Content = null;
        //    Button5.Content = null;
        //    Button6.Content = null;
        //    Button7.Content = null;
        //    Button8.Content = null;
        //}
        private void SwitchTurn()
        {
            if (currentPlayer == "X")
            {
                currentPlayer = "O"; // CPU's turn
                CpuMove();
                
            }
            else
            {
                currentPlayer = "X"; // Player's turn
            }
            
        }

        private void CpuMove()
        {
            if (!gameActive)
                return;

            Random random = new Random();
            Button[] emptyButtons = GetAllButtons().Where(b => string.IsNullOrEmpty(b.Content?.ToString())).ToArray();

            if (emptyButtons.Length > 0)
            {
                Button randomButton = emptyButtons[random.Next(emptyButtons.Length)];
                randomButton.Content = "O";

                if (CheckWinner())
                {
                    MessageBox.Show(currentPlayer + " wins!", "TicTacToe", MessageBoxButton.OK, MessageBoxImage.Information);
                    ShowResult("CPU (O) wins!"); // Show CPU win result
                }
                else if (IsBoardFull())
                {
                    MessageBox.Show("It's a draw!", "TicTacToe", MessageBoxButton.OK, MessageBoxImage.Information);
                    ShowResult("It's a draw!"); // Show draw result
                }
                else
                {
                    currentPlayer = "X"; // Return turn to the player
                }
            }
        }

        private bool CheckWinner()
        {
            string[,] board = new string[3, 3]
            {
                { Button0.Content?.ToString(), Button1.Content?.ToString(), Button2.Content?.ToString() },
                { Button3.Content?.ToString(), Button4.Content?.ToString(), Button5.Content?.ToString() },
                { Button6.Content?.ToString(), Button7.Content?.ToString(), Button8.Content?.ToString() }
            };

            for (int i = 0; i < 3; i++)
            {
                // Check rows and columns
                if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                    (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                    return true;
            }

            // Check diagonals
            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
                return true;

            return false;
        }

        private bool IsBoardFull()
        {
            return GetAllButtons().All(b => !string.IsNullOrEmpty(b.Content?.ToString()));
        }
        private void ShowResult(string result)
        {
            Result resultWindow = new Result(result);
            resultWindow.Show();
            this.Close(); // Close the current window (PVC)
        }
    }
}
