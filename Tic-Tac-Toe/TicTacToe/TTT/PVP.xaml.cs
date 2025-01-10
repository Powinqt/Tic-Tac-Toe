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
                    MessageBox.Show(currentPlayer + " wins!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    gameActive = false;
                }
                else if (IsBoardFull())
                {
                    MessageBox.Show("It's a draw!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    gameActive = false;
                }
                else
                {
                    if (currentPlayer == "X")
                    {
                        currentPlayer = "O";
                    }
                    else
                    {
                        currentPlayer = "X";
                    }

                }
            }
        }


        private void ResetBoard()
        {
            // Loop through all buttons to clear the content (assumes buttons named Button0, Button1, ..., Button8)
            Button0.Content = null;
            Button1.Content = null;
            Button2.Content = null;
            Button3.Content = null;
            Button4.Content = null;
            Button5.Content = null;
            Button6.Content = null;
            Button7.Content = null;
            Button8.Content = null;

            // Optionally, reset other variables like gameActive if needed
        }

        //private void SetFirstPlayer()
        //{
        //    Random random = new Random();
        //    currentPlayer = random.Next(2) == 0 ? "X" : "O"; // Randomly select "X" or "O"
        //}
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button button in new Button[] { Button0, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8 })
            {
                button.Content = null;
            }

            currentPlayer = "X";
            gameActive = true;
            ResetBoard();

            // Set who starts first
            //SetFirstPlayer();

            // Enable the game to start
            gameActive = true;

            // Optionally, show a message who starts first
            MessageBox.Show(currentPlayer + " will start the game!", "Game Info", MessageBoxButton.OK, MessageBoxImage.Information);
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
