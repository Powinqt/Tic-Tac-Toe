using System.Windows;
using TTT;

namespace TicTacToe
{
    public partial class Result : Window
    {
        public Result(string result) //textblock shows result
        {
            InitializeComponent();
            ResultText.Text = result;
        }

        private void ReturnToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            PlayButton playButton = new PlayButton();
            playButton.Show();
            this.Close();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            Application.Current.Shutdown();
        }
    }
}
