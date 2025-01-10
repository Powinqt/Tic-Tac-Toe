using System;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class PVP : Window
    {
        private string currentPlayer = "X";
        private bool gameActive = true;

        public PVP()
        {
            InitializeComponent();
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
                    MessageBox.Show(currentPlayer + " wins!", "TicTacToe", MessageBoxButton.OK, MessageBoxImage.Information);
                    ShowResultWindow($"{currentPlayer} wins!"); // Show the winner result
                    gameActive = false;
                    this.Close();
                }
                else if (IsBoardFull())
                {
                    MessageBox.Show("It's a draw!", "TicTacToe", MessageBoxButton.OK, MessageBoxImage.Information);
                    ShowResultWindow("It's a draw!"); // Show draw result
                    gameActive = false;
                    this.Close();
                }
                else
                {
                    // Switch player
                    currentPlayer = currentPlayer == "X" ? "O" : "X";
                }
                PlayersTurn.Text = $"{currentPlayer}'s Turn";
            }
        }

        private void ShowResultWindow(string result)
        {
            Result resultWindow = new Result(result);
            resultWindow.Show();
            this.Close(); // Close the current window (PVP)
        }

        private void ShowMainMenu()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); // Close the current window (PVP)
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
            foreach (Button button in new Button[] { Button0, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8 })
            {
                if (string.IsNullOrEmpty(button.Content?.ToString()))
                    return false;
            }
            return true;
        }
    }
}
