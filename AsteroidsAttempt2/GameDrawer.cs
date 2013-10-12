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
using System.Drawing;

public class GameDrawer
{
    Canvas gameCanvas;
    PlayerShip playerShip;
    Polygon theShipShape;

    public GameDrawer(Canvas gameCanvas, PlayerShip playerShip)
    {
        this.gameCanvas = gameCanvas;
        this.playerShip = playerShip;
        this.theShipShape = playerShip.getEntityShape();
        this.centerShipOnCanvas();
    }

    public void drawShip()
    {
        theShipShape.Stroke = Brushes.White;
        theShipShape.StrokeThickness = 2;
        theShipShape.Points = playerShip.getEntityDimensions();
        gameCanvas.Children.Add(theShipShape);
    }

    public void centerShipOnCanvas()
    {
        Matrix translateMatrix = new Matrix();
        translateMatrix.Translate(gameCanvas.Width / 2, gameCanvas.Height / 2);
        playerShip.setEntityCenterX(gameCanvas.Width / 2);
        playerShip.setEntityCenterY(gameCanvas.Height / 2);
        theShipShape.RenderTransform = new MatrixTransform(translateMatrix);
    }

}

