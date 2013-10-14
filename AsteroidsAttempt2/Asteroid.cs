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

public class Asteroid : MovableGameEntity
{
    private Random randomPoint;
    private GameDrawer theGameDrawer;
    private PlayerShip thePlayerShip;
    private int speed;

    public Asteroid(PlayerShip thePlayerShip, GameDrawer theGameDrawer)
	{
        this.entitySize = 10;
        this.speed = 2;
        this.rotation = 5;
        this.randomPoint = new Random();
        this.thePlayerShip = thePlayerShip;
        this.theGameDrawer = theGameDrawer;
        this.entityHeading = 0;
        this.entityCenterX = 0;
        this.entityCenterY = 0;
        this.setInitialEntityPoints();
	}

    public override void updateEntity()
    {
        Matrix moveMatrix = new Matrix();

        double radians = ConversionTools.degreesToRadians(this.getEntityHeading());
        double xMovement = Math.Cos(radians) * this.speed;
        double yMovement = Math.Sin(radians) * this.speed;
        
        this.setEntityCenterX(xMovement += this.getEntityCenterX());
        this.setEntityCenterY(yMovement += this.getEntityCenterY());
        moveMatrix.Translate(xMovement, yMovement);
        moveMatrix.RotateAt(this.rotation, this.getEntityCenterX(), this.getEntityCenterY());
        this.entityShape.RenderTransform = new MatrixTransform(moveMatrix);
        
        this.rotation += 5;
        this.handleWallCollisions();
        this.checkPlayerCollision();
    }

    // needs to be improved - is placeholder
    public void checkPlayerCollision()
    {
        if (((((thePlayerShip.entityCenterX - this.entityCenterX) <= 10) && ((thePlayerShip.entityCenterX - this.entityCenterX) >= 0)) || ((thePlayerShip.entityCenterX - this.entityCenterX >= -10) && ((thePlayerShip.entityCenterX - this.entityCenterX) <= 0))) && ((((thePlayerShip.entityCenterY - this.entityCenterY) <= 10) && ((thePlayerShip.entityCenterY - this.entityCenterY) >= 0)) || ((thePlayerShip.entityCenterY - this.entityCenterY >= -10) && ((thePlayerShip.entityCenterY - this.entityCenterY) <= 0))))
        {
            theGameDrawer.getAsteroidCollection().Remove(this);
            theGameDrawer.getGameCanvas().Children.Remove(this.entityShape);
        }
    }

    private void setRandomPoints()
    {
        Random randomPoint = new Random();
        this.entityHeading = Convert.ToDouble(randomPoint.Next(1, 360));
        this.entityCenterX = 0;
        this.entityCenterY = Convert.ToDouble(randomPoint.Next(10, 990));
    }
    public override void setInitialEntityPoints()
    {
        Point point1 = new Point(this.entityCenterX, this.entityCenterY - this.entitySize);
        Point point2 = new Point(this.entityCenterX + this.entitySize, this.entityCenterY - (this.entitySize / 2));
        Point point3 = new Point(this.entityCenterX + (this.entitySize * 1.5), this.entityCenterY);
        Point point4 = new Point(this.entityCenterX + this.entitySize, this.entityCenterY + (this.entitySize / 2));
        Point point5 = new Point(this.entityCenterX, this.entityCenterY + this.entitySize);
        Point point6 = new Point(this.entityCenterX - (this.entitySize / 2), this.entityCenterY + (this.entitySize / 2));
        Point point7 = new Point(this.entityCenterX - (this.entitySize * 1.5), this.entityCenterY);
        Point point8 = new Point(this.entityCenterX - this.entitySize, this.entityCenterY - (this.entitySize / 2));
        Point point9 = new Point(this.entityCenterX, this.entityCenterY - this.entitySize);

        this.entityDimensions.Add(point1);
        this.entityDimensions.Add(point2);
        this.entityDimensions.Add(point3);
        this.entityDimensions.Add(point4);
        this.entityDimensions.Add(point5);
        this.entityDimensions.Add(point6);
        this.entityDimensions.Add(point7);
        this.entityDimensions.Add(point8);
        this.entityDimensions.Add(point9);

        this.setRandomPoints();
    }

}
