using System.Windows;

namespace TicTacToe
{
    public partial class Result : Window
    {
        public Result(string result)
        {
            InitializeComponent();
            ResultText.Text = result;
        }

        private void ReturnToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            Application.Current.Shutdown();
        }
    }
}
