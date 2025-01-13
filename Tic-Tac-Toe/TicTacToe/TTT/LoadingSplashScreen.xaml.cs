using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TicTacToe;

namespace TTT
{
    public partial class LoadingSplashScreen : Window
    {
        public LoadingSplashScreen()
        {
            InitializeComponent();
            StartLoading();
        }

        private async void StartLoading()
        {
            // Simulate a loading process
            int progress = 0;
            while (progress <= 100)
            {
                // Update progress bar and percentage text
                ProgressBar.Value = progress;
                ProgressPercentage.Text = $"{progress}%";

              
                await Task.Delay(30); // Adjust delay for faster or slower loading

                progress++;
            }

            // Open the main window after loading is complete
            var mainWindow = new PlayButton();
            mainWindow.Show();

            // Close the splash screen
            this.Close();
        }
    }
}
