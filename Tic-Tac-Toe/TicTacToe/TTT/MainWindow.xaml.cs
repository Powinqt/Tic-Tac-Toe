using System.Windows;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PVP_Click(object sender, RoutedEventArgs e)
        {
            // Start the game (open PVP or PVC window)
            PVP pvpWindow = new PVP();
            pvpWindow.Show();
            this.Close(); // Close the MainMenu window
        }

        private void PVC_Click(object sender, RoutedEventArgs e)
        {
            // Start the game (open PVP or PVC window)
            PVC pvcWindow = new PVC();
            pvcWindow.Show();
            this.Close(); // Close the MainMenu window
        }
    }
}