using System;
using System.Windows;
using System.Windows.Controls;
using TTT;

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
        private Button[] GetAllButtons() //Group all 9 buttons into an array
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
                    if (currentPlayer == "X")
                    {
                        currentPlayer = "O";
                    }
                    else
                    {
                        currentPlayer = "X";
                    }

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
            PlayButton playButton = new PlayButton();
            playButton.Show();
            this.Close(); // Close the current window (PVP)
        }

        private bool CheckWinner()
        {
            // Check rows
            // Button0.Content != null && Button0.Content.ToString()
            if ((Button0.Content?.ToString() == currentPlayer && Button1.Content?.ToString() == currentPlayer && Button2.Content?.ToString() == currentPlayer) ||
                (Button3.Content?.ToString() == currentPlayer && Button4.Content?.ToString() == currentPlayer && Button5.Content?.ToString() == currentPlayer) ||
                (Button6.Content?.ToString() == currentPlayer && Button7.Content?.ToString() == currentPlayer && Button8.Content?.ToString() == currentPlayer))
                return true;

            // Check columns
            if ((Button0.Content?.ToString() == currentPlayer && Button3.Content?.ToString() == currentPlayer && Button6.Content?.ToString() == currentPlayer) ||
                (Button1.Content?.ToString() == currentPlayer && Button4.Content?.ToString() == currentPlayer && Button7.Content?.ToString() == currentPlayer) ||
                (Button2.Content?.ToString() == currentPlayer && Button5.Content?.ToString() == currentPlayer && Button8.Content?.ToString() == currentPlayer))
                return true;

            // Check diagonals
            if ((Button0.Content?.ToString() == currentPlayer && Button4.Content?.ToString() == currentPlayer && Button8.Content?.ToString() == currentPlayer) ||
                (Button2.Content?.ToString() == currentPlayer && Button4.Content?.ToString() == currentPlayer && Button6.Content?.ToString() == currentPlayer))
                return true;

            return false;
        }

        private bool IsBoardFull()
        {
            foreach (Button button in GetAllButtons())
            {
                if (string.IsNullOrEmpty(button.Content?.ToString()))
                {
                    return false; // Return false as soon as we find an empty button
                }
            }
            return true; // If no empty buttons are found, return true
        }
    }
}
