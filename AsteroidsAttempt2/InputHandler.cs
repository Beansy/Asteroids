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

public class InputHandler
{
    Canvas gameCanvas;
    PlayerShip playerShip;

    public InputHandler(Canvas gameCanvas, PlayerShip playerShip)
	{
        this.gameCanvas = gameCanvas;
        this.playerShip = playerShip;
	}

    public void handleRotate(KeyEventArgs e)
    {
        if (e.Key == Key.Left)
        {

        }
    }
}
