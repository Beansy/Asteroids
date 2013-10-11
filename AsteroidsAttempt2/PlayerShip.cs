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
    private PointCollection shipPoints;
    private Polygon theShipShape;

    public PlayerShip()
	{
        this.shipCenterX = 0;
        this.shipCenterY = 0;
        this.shipSize = 15;
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

    public void moveMeForward()
    {
        Matrix translateMatrix = new Matrix();
        double radians = ConversionTools.degreesToRadians(this.getHeading());
        double xMovement = Math.Cos(radians) * 10;
        double yMovement = Math.Sin(radians) * 10;
        //MessageBox.Show("Heading: " + playerShip.getHeading().ToString() + " centerx: " + playerShip.getShipCenterX().ToString() + " centery: " + playerShip.getShipCenterY().ToString());

        this.setShipCenterX(xMovement += this.getShipCenterX());
        this.setShipCenterY(yMovement += this.getShipCenterY());
        //MessageBox.Show("Heading: " + playerShip.getHeading().ToString() + " centerx: " + playerShip.getShipCenterX().ToString() + " centery: " + playerShip.getShipCenterY().ToString());

        translateMatrix.Translate(xMovement, yMovement);
        translateMatrix.RotateAt(this.getHeading(), this.getShipCenterX(), this.getShipCenterY());

        this.theShipShape.RenderTransform = new MatrixTransform(translateMatrix);

    }

    public void rotateMe(double rotation)
    {
        Matrix rotateMatrix = new Matrix();
        double newHeading = this.getHeading() + rotation;
        rotateMatrix.Translate(this.getShipCenterX(), this.getShipCenterY());
        rotateMatrix.RotateAt(newHeading, this.getShipCenterX(), this.getShipCenterY());
        //MessageBox.Show("Heading: " + newHeading.ToString() + " centerx: " + playerShip.getShipCenterX().ToString() + " centery: " + playerShip.getShipCenterY().ToString());
        theShipShape.RenderTransform = new MatrixTransform(rotateMatrix);
        this.setHeading(newHeading);
    }

    public void updateMove(Dictionary<Key, bool> keys)
    {
        if (keys[Key.Up] == true && keys[Key.Right] == true)
        {
            this.moveMeForward();
            this.rotateMe(10);
        }
        else if (keys[Key.Up] == true && keys[Key.Left] == true)
        {
            this.moveMeForward();
            this.rotateMe(-10);
        }
        else if (keys[Key.Up] == true)
        {
            this.moveMeForward();
        }
        else if (keys[Key.Left] == true)
        {
            this.rotateMe(-10);
        }
        else if (keys[Key.Right] == true)
        {
            this.rotateMe(10);
        }
    }
}
