using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;

namespace AsteroidsAttempt2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PlayerShip playerShip;
        GameDrawer gameDrawer;
        Dictionary<Key, bool> keyStatus = new Dictionary<Key, bool>();
 
        public MainWindow()
        {
            InitializeComponent();
            GameCanvas.Focus();
            this.playerShip = new PlayerShip();
            this.gameDrawer = new GameDrawer(GameCanvas, playerShip);
            this.gameDrawer.drawShip();
            this.keyStatus.Add(Key.Up, false);
            this.keyStatus.Add(Key.Left, false);
            this.keyStatus.Add(Key.Right, false);
        }

        private void GameCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                playerShip.rotationOn(-10);
            }
   
            if (e.Key == Key.Right)
            {
                playerShip.rotationOn(10);
            }

            if (e.Key == Key.Up)
            {
                playerShip.gasOn();
            }

            if (e.Key == Key.Down)
            {
                playerShip.brakeOn();
            }

        }

        private void GameCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                playerShip.rotationOff();
            }

            if (e.Key == Key.Right)
            {
                playerShip.rotationOff();
            }
            
            if (e.Key == Key.Up)
            {
                playerShip.gasOff();
            }

            if (e.Key == Key.Down)
            {
                playerShip.brakeOff();
            }
     
        }

        private void GameWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Timer timer = new Timer() { Interval = 20 };
            timer.Elapsed += this.updatePlayerShip;
            timer.Start();
        }

        private void updatePlayerShip(object sender, EventArgs e)
        {
            try
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    playerShip.updateEntity();
                }));
            }
            catch(TaskCanceledException)
            {

            }
            
        }
    }
}
