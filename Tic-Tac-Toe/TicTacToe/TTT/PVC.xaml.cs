using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TTT;

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
                    SwitchTurn();
                }
            }
        }
        private void ShowMainMenu()
        {
            // Close the current game window and open the MainMenu window
            PlayButton playButton = new PlayButton();
            playButton.Show();
            this.Close(); // Close the current window (PVP)
        }
        private void ShowResultWindow(string result)
        {
            Result resultWindow = new Result(result);
            resultWindow.Show();
            this.Close(); // Close the current window (PVP)
        }

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

            // Get all empty buttons
            Button[] emptyButtons = GetAllButtons().Where(b => string.IsNullOrEmpty(b.Content?.ToString())).ToArray();

            if (emptyButtons.Length > 0)
            {
                // Shuffle the empty buttons array to randomize the choice
                emptyButtons = emptyButtons.OrderBy(b => random.Next()).ToArray();

                // Choose a random button from the shuffled list
                Button randomButton = emptyButtons.First();
                randomButton.Content = "O";

                if (CheckWinner())
                {
                    MessageBox.Show(currentPlayer + " wins!", "TicTacToe", MessageBoxButton.OK, MessageBoxImage.Information);
                    ShowResult("AI (O) Wins!"); // Show CPU win result
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

        private void ShowResult(string result)
        {
            Result resultWindow = new Result(result);
            resultWindow.Show();
            this.Close(); 
        }
    }
}
