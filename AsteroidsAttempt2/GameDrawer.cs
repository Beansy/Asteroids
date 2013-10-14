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
    List<Asteroid> asteroidCollection;
    DateTime gameStartTime;

    public GameDrawer(Canvas gameCanvas, PlayerShip playerShip)
    {
        this.gameCanvas = gameCanvas;
        this.asteroidCollection = new List<Asteroid>();
        this.gameStartTime = new DateTime();
        this.gameStartTime = DateTime.Now;
        this.playerShip = playerShip;
        this.centerShipOnCanvas();
    }

    public List<Asteroid> getAsteroidCollection()
    {
        return this.asteroidCollection;
    }

    public void drawShip()
    {
        playerShip.entityShape.Name = "playerShip";
        playerShip.entityShape.Stroke = Brushes.White;
        playerShip.entityShape.StrokeThickness = 2;
        playerShip.entityShape.Points = playerShip.getEntityDimensions();
        gameCanvas.Children.Add(playerShip.entityShape);
        
    }

    public void drawAsteroid(Asteroid theAsteroid)
    {
        Polygon newPolygon = new Polygon();
        theAsteroid.setEntityShape(newPolygon);
        theAsteroid.entityShape.Stroke = Brushes.White;
        theAsteroid.entityShape.StrokeThickness = 2;
        theAsteroid.entityShape.Points = theAsteroid.getEntityDimensions();
        gameCanvas.Children.Add(theAsteroid.entityShape);
        
        TranslateTransform initialTransform = new TranslateTransform(theAsteroid.getEntityCenterX(), theAsteroid.getEntityCenterY());
        theAsteroid.entityShape.RenderTransform = initialTransform;
    }

    public void generateAsteroid()
    {
        Asteroid newAsteroid = new Asteroid(playerShip, this);
        asteroidCollection.Add(newAsteroid);
        newAsteroid.setRandomPoints();
        drawAsteroid(newAsteroid);
    }

    public void centerShipOnCanvas()
    {
        Matrix translateMatrix = new Matrix();
        translateMatrix.Translate(gameCanvas.Width / 2, gameCanvas.Height / 2);
        playerShip.setEntityCenterX(gameCanvas.Width / 2);
        playerShip.setEntityCenterY(gameCanvas.Height / 2);
        playerShip.entityShape.RenderTransform = new MatrixTransform(translateMatrix);
    }

}

