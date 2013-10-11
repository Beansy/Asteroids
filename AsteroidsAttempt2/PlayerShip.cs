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

public class PlayerShip
{
    private double shipCenterX;
    private double shipCenterY;
    private int shipSize;
    private double heading;
    private double speed;
    private double maxSpeed;
    private double minSpeed;
    private double rotation;
    private PointCollection shipPoints;
    private Polygon theShipShape;
    private bool gasIsOn;
    private double acceleration;
    private double decceleration;
    private DateTime gasOnTimer;
    private DateTime gasOffTimer;

    public PlayerShip()
	{
        this.shipCenterX = 0;
        this.shipCenterY = 0;
        this.shipSize = 15;
        this.speed = 0;
        this.rotation = 0;
        this.acceleration = 0.2;
        this.decceleration = 0.3;
        this.maxSpeed = 35;
        this.minSpeed = 0;
        this.gasIsOn = false;
        this.gasOnTimer = new DateTime();
        this.gasOffTimer = new DateTime();
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
        this.minSpeed = 2;
        if (this.gasIsOn == false)
        {
            gasOnTimer = DateTime.Now;
            this.gasIsOn = true;
        }
        
    }

    public void gasOff()
    {
        gasOffTimer = DateTime.Now;
        this.gasIsOn = false;
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
        double time;
        if (this.gasIsOn == true)
        {
            time = Convert.ToDouble((DateTime.Now - gasOnTimer).TotalSeconds);
            this.speed += acceleration * time;
            if (this.speed > this.maxSpeed)
            {
                this.speed = this.maxSpeed;
            }
        }
        else if (this.gasIsOn == false)
        {
            time = Convert.ToDouble((DateTime.Now - gasOffTimer).TotalSeconds);
            this.speed -= decceleration * time;
            if (this.speed < this.minSpeed)
            {
                this.speed = this.minSpeed;
            }
        }
        //MessageBox.Show(speed.ToString());
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
