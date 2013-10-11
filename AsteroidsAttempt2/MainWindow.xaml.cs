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

namespace AsteroidsAttempt2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PlayerShip playerShip;
        GameDrawer gameDrawer;
        InputHandler inputHandler;
        Dictionary<Key, bool> keyStatus = new Dictionary<Key, bool>();
 
        public MainWindow()
        {
            InitializeComponent();
            GameCanvas.Focus();
            this.playerShip = new PlayerShip();
            this.gameDrawer = new GameDrawer(GameCanvas, playerShip);
            this.gameDrawer.drawShip();
            this.inputHandler = new InputHandler(GameCanvas, playerShip);
            this.keyStatus.Add(Key.Up, false);
            this.keyStatus.Add(Key.Left, false);
            this.keyStatus.Add(Key.Right, false);
        }

        private void GameCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                keyStatus[Key.Left] = true;
            }
   
            if (e.Key == Key.Right)
            {
                keyStatus[Key.Right] = true;
            }

            if (e.Key == Key.Up)
            {
                keyStatus[Key.Up] = true;
            }
       

            playerShip.updateMove(keyStatus);

        }

        private void GameCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                keyStatus[Key.Left] = false;
            }

            if (e.Key == Key.Right)
            {
                keyStatus[Key.Right] = false;
            }
            
            if (e.Key == Key.Up)
            {
                keyStatus[Key.Up] = false;
            }
            playerShip.updateMove(keyStatus);
        }

    }
}
