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

public class Bullet
{
    private int speed;
    private int bulletNo;
    private double bulletX;
    private double bulletY;
    private double xTotalMovement;
    private double yTotalMovement;
    private double bulletHeading;
    private DateTime fireTime;
    private Line bulletShape;
    private GameController theGameDrawer;

    public Bullet(int bulletNo, double shipX, double shipY, double shipHeading, GameController theGameDrawer)
    {
        this.bulletNo = bulletNo;
        this.bulletX = shipX;
        this.bulletY = shipY;
        this.xTotalMovement = 0;
        this.yTotalMovement = 0;
        this.speed = 30;
        this.bulletHeading = shipHeading;
        this.fireTime = new DateTime();
        this.fireTime = DateTime.Now;
        this.theGameDrawer = theGameDrawer;
        this.setBulletShape();
        this.theGameDrawer.drawBullet(this);
    }

    public void update()
    {
        Matrix moveMatrix = new Matrix();

        double radians = ConversionTools.degreesToRadians(this.bulletHeading);
        double xMovement = Math.Cos(radians) * this.speed;
        double yMovement = Math.Sin(radians) * this.speed;

        
        this.setBulletX(xMovement + bulletX);
        this.setBulletY(yMovement + bulletY);
        this.setTotalX(xMovement += this.xTotalMovement);
        this.setTotalY(yMovement += this.yTotalMovement);
        moveMatrix.Translate(xMovement, yMovement);
        //MessageBox.Show(bulletX.ToString() + " " + bulletY.ToString());
        this.bulletShape.RenderTransform = new MatrixTransform(moveMatrix);
        //this.handleWallCollisions();
        //this.checkPlayerCollision();
    }

    private void setBulletShape()
    {
        this.bulletShape = new Line();
        this.bulletShape.X1 = this.bulletX;
        this.bulletShape.Y1 = this.bulletY;
        this.bulletShape.Stroke = Brushes.Yellow;
        this.bulletShape.StrokeThickness = 2;
        double radians = ConversionTools.degreesToRadians(this.bulletHeading);
        this.bulletShape.X2 = this.bulletShape.X1 + Math.Cos(radians) * 5;
        this.bulletShape.Y2 = this.bulletShape.Y1 + Math.Sin(radians) * 5;
    }

    public Line getBulletShape() { return this.bulletShape; }
    public DateTime getFireTime() { return this.fireTime; }
    public int getBulletNo() { return this.bulletNo; }
    public void setBulletX(double newX) { this.bulletX = newX; }
    public void setBulletY(double newY) { this.bulletY = newY; }
    public double getBulletX() { return this.bulletX; }
    public double getBulletY() { return this.bulletY; }
    public void setTotalX(double newTotalX) { this.xTotalMovement = newTotalX; }
    public void setTotalY(double newTotalY) { this.yTotalMovement = newTotalY; }
}
