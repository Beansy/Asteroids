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

public class Explosion
{
    private double epicentreX;
    private double epicentreY;

    public Explosion(double deadObjectX, double deadObjectY)
	{
        this.epicentreX = deadObjectX;
        this.epicentreY = deadObjectY;
	}
}
