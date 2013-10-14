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

public class PlayerShip : MovableGameEntity
{
    private double velocity;
    private double maxSpeed;
    private double minSpeed;
    private double brakePower;
    private bool gasIsOn;
    private double acceleration;
    private double decceleration;
    private DateTime gasOnTimer;
    private DateTime gasOffTimer;

    public PlayerShip()
	{
        this.entityCenterX = 0;
        this.entityCenterY = 0;
        this.entitySize = 15;
        this.entityHealth = 100;
        this.velocity = 0;
        this.rotation = 0;
        this.acceleration = 0.2;
        this.decceleration = 0.3;
        this.brakePower = 0;
        this.maxSpeed = 35;
        this.minSpeed = 0;
        this.gasIsOn = false;
        this.gasOnTimer = new DateTime();
        this.gasOffTimer = new DateTime();
        this.setInitialEntityPoints();
        
	}

    public override void setInitialEntityPoints()
    {
        Polygon newPolygon = new Polygon();
        this.setEntityShape(newPolygon);
        Point shipTop = new Point(this.entityCenterX, this.entityCenterY - this.entitySize);
        Point shipRight = new Point(this.entityCenterX + this.entitySize, this.entityCenterY + this.entitySize);
        Point shipMiddle = new Point(this.entityCenterX, this.entityCenterY + 3);
        Point shipLeft = new Point(this.entityCenterX - this.entitySize, this.entityCenterY + this.entitySize);

        this.entityDimensions.Add(shipTop);
        this.entityDimensions.Add(shipRight);
        this.entityDimensions.Add(shipMiddle);
        this.entityDimensions.Add(shipLeft);
        this.entityDimensions.Add(shipTop);
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

    public void brakeOn()
    {
        this.brakePower = 3.2;
        this.minSpeed = 0;
    }

    public void brakeOff()
    {
        this.brakePower = 0;
    }

    public void rotationOn(double rotation)
    {
        this.rotation = rotation;
    }

    public void rotationOff()
    {
        this.rotation = 0;
    }

    private void setVelocity()
    {
        double time;
        if (this.gasIsOn == true)
        {
            time = Convert.ToDouble((DateTime.Now - gasOnTimer).TotalSeconds);
            this.velocity += this.acceleration * time;
            if (this.velocity > this.maxSpeed)
            {
                this.velocity = this.maxSpeed;
            }
        }
        else if (this.gasIsOn == false)
        {
            time = Convert.ToDouble((DateTime.Now - gasOffTimer).TotalSeconds);
            this.velocity -= (this.decceleration + this.brakePower) * time;
            if (this.velocity < this.minSpeed)
            {
                this.velocity = this.minSpeed;
            }
        }
    }

    public override void updateEntity()
    {
        this.setVelocity();
        
        Matrix moveMatrix = new Matrix();
        double radians = ConversionTools.degreesToRadians(this.getEntityHeading());
        double xMovement = Math.Cos(radians) * this.velocity;
        double yMovement = Math.Sin(radians) * this.velocity;

        this.setEntityCenterX(xMovement += this.getEntityCenterX());
        this.setEntityCenterY(yMovement += this.getEntityCenterY());
        double newHeading = this.getEntityHeading() + this.rotation;

        moveMatrix.Translate(xMovement, yMovement);
        moveMatrix.RotateAt(newHeading, this.getEntityCenterX(), this.getEntityCenterY());
        this.setEntityHeading(newHeading);
        this.entityShape.RenderTransform = new MatrixTransform(moveMatrix);

        this.handleWallCollisions();
        
    }
}
