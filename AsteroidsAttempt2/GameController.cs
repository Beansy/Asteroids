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

public class GameController
{
    public Canvas gameCanvas;
    public PlayerShip playerShip;
    public List<MovableGameEntity> asteroidCollection;
    public DateTime gameStartTime;
    public int asteroidsAdded;
    public int asteroidsKilled;
    public int playerLives;

    public GameController(Canvas gameCanvas, PlayerShip playerShip)
    {
        this.gameCanvas = gameCanvas;
        this.asteroidCollection = new List<MovableGameEntity>();
        this.gameStartTime = new DateTime();
        this.gameStartTime = DateTime.Now;
        this.asteroidsAdded = 0;
        this.asteroidsKilled = 0;
        this.playerLives = 3;
        this.playerShip = playerShip;
        this.playerShip.theGameDrawer = this;
        this.centerShipOnCanvas();
    }

    public void killAsteroid(Asteroid asteroid)
    {
        this.asteroidCollection.Remove(asteroid);
        this.gameCanvas.Children.Remove(asteroid.entityShape);
        this.asteroidsKilled += 1;
    }

    public void killPlayer(Asteroid asteroid)
    {
        asteroidCollection.Remove(asteroid);
        this.gameCanvas.Children.Remove(asteroid.entityShape);
        if (this.playerShip != null)
        {
            this.gameCanvas.Children.Remove(this.playerShip.entityShape);
            this.playerShip.setEntityCenterX(500);
            this.playerShip.setEntityCenterY(500);
            this.playerShip.setEntityHeading(0);
            this.playerLives -= 1;
        }

        if (this.playerLives > 0)
        {
            this.gameCanvas.Children.Add(this.playerShip.getEntityShape());
        }
        else { this.playerShip = null; }
    }

    public void drawBullet(Bullet theBullet)
    {
        gameCanvas.Children.Add(theBullet.getBulletShape());

        TranslateTransform initialTransform = new TranslateTransform(theBullet.getBulletX(), theBullet.getBulletY());
        theBullet.getBulletShape().RenderTransform = initialTransform;
    }

    public List<MovableGameEntity> getAsteroidCollection()
    {
        return this.asteroidCollection;
    }

    public Canvas getGameCanvas()
    {
        return this.gameCanvas;
    }

    public void drawShip()
    {
        playerShip.entityShape.Name = "playerShip";
        playerShip.entityShape.Stroke = Brushes.White;
        playerShip.entityShape.StrokeThickness = 2;
        playerShip.entityShape.Points = playerShip.getEntityDimensions();
        gameCanvas.Children.Add(playerShip.entityShape);
        
    }

    public void drawAsteroid(MovableGameEntity theAsteroid)
    {
        Polygon newPolygon = new Polygon();
        theAsteroid.setEntityShape(newPolygon);
        theAsteroid.entityShape.Name = "Asteroid" + this.asteroidsAdded;
        this.asteroidsAdded += 1;
        theAsteroid.entityShape.Stroke = Brushes.White;
        theAsteroid.entityShape.StrokeThickness = 2;
        theAsteroid.entityShape.Points = theAsteroid.getEntityDimensions();
        gameCanvas.Children.Add(theAsteroid.entityShape);
        
        TranslateTransform initialTransform = new TranslateTransform(theAsteroid.getEntityCenterX(), theAsteroid.getEntityCenterY());
        theAsteroid.entityShape.RenderTransform = initialTransform;
    }

    public void generateAsteroid()
    {
        MovableGameEntity newAsteroid = new Asteroid(playerShip, this);
        asteroidCollection.Add(newAsteroid);
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

