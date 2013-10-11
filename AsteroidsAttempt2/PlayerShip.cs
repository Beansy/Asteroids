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

public class PlayerShip
{
    private double shipCenterX;
    private double shipCenterY;
    private int shipSize;
    private double heading;
    private int speed;
    private double rotation;
    private PointCollection shipPoints;
    private Polygon theShipShape;

    public PlayerShip()
	{
        this.shipCenterX = 0;
        this.shipCenterY = 0;
        this.shipSize = 15;
        this.speed = 0;
        this.rotation = 0;
        this.shipPoints = new PointCollection();
        this.theShipShape = new Polygon();
        this.setInitialShipPoints();
	}
 
    public double getHeading()
    {
        return this.heading;
    }

    public void setHeading(double newHeading)
    {
        this.heading = newHeading;
    }

    public double getShipCenterX()
    {
        return this.shipCenterX;
    }

    public double getShipCenterY()
    {
        return this.shipCenterY;
    }

    public void setShipCenterX(double newShipCenterX)
    {
        this.shipCenterX = newShipCenterX;
    }

    public void setShipCenterY(double newShipCenterY)
    {
        this.shipCenterY = newShipCenterY;
    }

    public int getShipSize()
    {
        return this.shipSize;
    }

    public void setShipSize(int newShipSize)
    {
        this.shipSize = newShipSize;
    }

    public void setShipPoints(PointCollection newShipPoints)
    {
        this.shipPoints = newShipPoints;
    }

    public Polygon getShipShape()
    {
        return this.theShipShape;
    }

    public void setInitialShipPoints()
    {
        Point shipTop = new Point(this.shipCenterX,this.shipCenterY - this.shipSize);
        Point shipRight = new Point(this.shipCenterX + this.shipSize, this.shipCenterY + this.shipSize);
        Point shipLeft = new Point(this.shipCenterX - this.shipSize, this.shipCenterY + this.shipSize);

        this.shipPoints.Add(shipTop);
        this.shipPoints.Add(shipRight);
        this.shipPoints.Add(shipLeft);
        this.shipPoints.Add(shipTop);
    }

    public PointCollection getShipPoints()
    {
        return this.shipPoints;
    }

    public void gasOn()
    {
        if (this.speed <= 15)
        {
            if (this.speed + 3 >= this.speed)
            {
                this.speed = 15;
            }
            else
            {
                this.speed += 3;
            }
        }
    }

    public void gasOff()
    {
        
        if (this.speed >= 0)
        {
            if (this.speed - 3 <= this.speed)
            {
                this.speed = 0;
            }
            else
            {
                this.speed -= 3;
            }
        }
    }

    public void rotationOn(double rotation)
    {
        this.rotation = rotation;
    }

    public void rotationOff()
    {
        this.rotation = 0;
    }

    private void handleWallCollisions()
    {
        if (this.shipCenterX <= 0)
        {
            this.shipCenterX = 999;
        }

        if (this.shipCenterX >= 1000)
        {
            this.shipCenterX = 0;
        }

        if (this.shipCenterY <= 0)
        {
            this.shipCenterY = 999;
        }

        if (this.shipCenterY >= 1000)
        {
            this.shipCenterY = 0;
        }
    }

    public void updatePlayerShip()
    {
        
        Matrix moveMatrix = new Matrix();
        double radians = ConversionTools.degreesToRadians(this.getHeading());
        double xMovement = Math.Cos(radians) * this.speed;
        double yMovement = Math.Sin(radians) * this.speed;

        this.setShipCenterX(xMovement += this.getShipCenterX());
        this.setShipCenterY(yMovement += this.getShipCenterY());
        double newHeading = this.getHeading() + this.rotation;

        moveMatrix.Translate(xMovement, yMovement);
        moveMatrix.RotateAt(newHeading, this.getShipCenterX(), this.getShipCenterY());
        this.setHeading(newHeading);
        theShipShape.RenderTransform = new MatrixTransform(moveMatrix);

        this.handleWallCollisions();
        
    }
}
