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
        this.theShipShape = playerShip.getShipShape();
        this.centerShipOnCanvas();
    }

    public Polygon getShipPolygon()
    {
        return this.theShipShape;
    }

    public void drawShip()
    {
        theShipShape.Stroke = Brushes.Black;
        theShipShape.StrokeThickness = 2;
        theShipShape.Points = playerShip.getShipPoints();
        gameCanvas.Children.Add(theShipShape);
    }

    public void centerShipOnCanvas()
    {
        Matrix translateMatrix = new Matrix();
        translateMatrix.Translate(gameCanvas.Width / 2, gameCanvas.Height / 2);
        playerShip.setShipCenterX(gameCanvas.Width / 2);
        playerShip.setShipCenterY(gameCanvas.Height / 2);
        theShipShape.RenderTransform = new MatrixTransform(translateMatrix);
    }

}

