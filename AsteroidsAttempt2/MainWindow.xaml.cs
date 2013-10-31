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
        private PlayerShip playerShip; 
        private GameController gameDrawer;
        private Dictionary<Key, bool> keyStatus = new Dictionary<Key, bool>();
        private List<MovableGameEntity> currentAsteroidCollection = new List<MovableGameEntity>();
 
        public MainWindow()
        {
            InitializeComponent();
            GameCanvas.Focus();
            this.playerShip = new PlayerShip();
            this.gameDrawer = new GameController(GameCanvas, playerShip);
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

            if (e.Key == Key.Space)
            {
                playerShip.fire();
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
            Timer fastGameUpdater = new Timer() { Interval = 20 };
            Timer asteroidAddTimer = new Timer() { Interval = 1000 };
            fastGameUpdater.Elapsed += this.updateGameObjects;
            fastGameUpdater.Start();
            asteroidAddTimer.Elapsed += this.handleAsteroidAdd;
            asteroidAddTimer.Start();

        }

        private void handleAsteroidAdd(object sender, EventArgs e)
        {

            try
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    gameDrawer.generateAsteroid();
                   
                }));
            }
            catch (TaskCanceledException)
            {

            }

        }

        private void updateGameObjects(object sender, EventArgs e)
        {
            try
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    playerShip.updateEntity();
                    tbxScore.Content = (this.gameDrawer.asteroidsKilled * 10).ToString();
                    tbxLives.Content = this.gameDrawer.playerLives.ToString();
                    if (this.gameDrawer.playerLives <= 0)
                    {
                        lblYouLose.Visibility = System.Windows.Visibility.Visible;
                        
                    }
                    this.currentAsteroidCollection = gameDrawer.getAsteroidCollection();
                    try
                    {
                        foreach (MovableGameEntity asteroid in this.currentAsteroidCollection) { asteroid.updateEntity(); }
                    }
                    catch (InvalidOperationException) { }
                }));
            }
            catch(TaskCanceledException)
            {

            }
            
        }
    }
}
