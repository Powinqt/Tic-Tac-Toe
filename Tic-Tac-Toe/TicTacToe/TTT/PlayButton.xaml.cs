using System.Windows;
using TicTacToe;

namespace TTT
{
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        // Button click event handler to open the main game window
        private void PVP_Click(object sender, RoutedEventArgs e)
        {
            // Create and show the main game window
            var pvp = new PVP();
            pvp.Show();
            this.Close();
        }

        private void PVC_Click(object sender, RoutedEventArgs e)
        {
            // Create and show the main game window
            var pvc = new PVC();
            pvc.Show();
            this.Close();
        }
    }
}
