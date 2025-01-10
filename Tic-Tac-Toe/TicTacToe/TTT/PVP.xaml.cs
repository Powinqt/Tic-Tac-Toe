using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TTT
{
    public partial class PVP : Window
    {
        private string currentPlayer = "X";
        private bool gameActive = true;
        private List<Button> buttons;

        public PVP()
        {
            InitializeComponent();
            buttons = new List<Button> { Button0, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8 };
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
                    ShowGameOverMessage($"{currentPlayer} wins!");
                }
                else if (IsBoardFull())
                {
                    ShowGameOverMessage("It's a draw!");
                }
                else
                {
                    SwitchPlayer();
                }
            }
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var button in buttons)
            {
                button.Content = null;
                button.IsEnabled = true;
            }

            currentPlayer = "X";
            gameActive = true;

            MessageBox.Show($"{currentPlayer} will start the game!", "Game Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SwitchPlayer()
        {
            currentPlayer = currentPlayer == "X" ? "O" : "X";
        }

        private void ShowGameOverMessage(string message)
        {
            MessageBox.Show(message, "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
            gameActive = false;
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
            return buttons.All(button => !string.IsNullOrEmpty(button.Content?.ToString()));
        }
    }
}
