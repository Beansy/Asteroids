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

public abstract class MovableGameEntity
{
    public double entityCenterX;
    public double entityCenterY;
    public int entitySize;
    public int entityHealth;
    public double entityHeading;
    public double rotation;
    public PointCollection entityDimensions;
    public Polygon entityShape;

    public MovableGameEntity()
	{
        this.entityDimensions = new PointCollection();
        this.entityShape = new Polygon();
        
	}
    //Abstract
    public abstract void setInitialEntityPoints();
    public abstract void updateEntity();

    //Concrete
    public double getEntityHeading()
    {
        return this.entityHeading;
    }

    public void setEntityShape(Polygon newEntityShape)
    {
        this.entityShape = newEntityShape;
    }


    public void setEntityHeading(double newHeading)
    {
        this.entityHeading = newHeading;
    }

    public double getEntityCenterX()
    {
        return this.entityCenterX;
    }

    public double getEntityCenterY()
    {
        return this.entityCenterY;
    }

    public void setEntityCenterX(double newEntityCenterX)
    {
        this.entityCenterX = newEntityCenterX;
    }

    public void setEntityCenterY(double newEntityCenterY)
    {
        this.entityCenterY = newEntityCenterY;
    }

    public int getEntitySize()
    {
        return this.entitySize;
    }

    public void setEntitySize(int newEntitySize)
    {
        this.entitySize = newEntitySize;
    }

    public void setEntityDimensions(PointCollection newEntityDimensions)
    {
        this.entityDimensions = newEntityDimensions;
    }

    public Polygon getEntityShape()
    {
        return this.entityShape;
    }

    public PointCollection getEntityDimensions()
    {
        return this.entityDimensions;
    }

    public void handleWallCollisions()
    {
        if (this.entityCenterX <= 0)
        {
            this.entityCenterX = 999;
        }

        if (this.entityCenterX >= 1000)
        {
            this.entityCenterX = 0;
        }

        if (this.entityCenterY <= 0)
        {
            this.entityCenterY = 999;
        }

        if (this.entityCenterY >= 1000)
        {
            this.entityCenterY = 0;
        }
    }
}
