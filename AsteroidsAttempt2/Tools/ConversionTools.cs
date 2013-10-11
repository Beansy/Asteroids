using System;

public class ConversionTools
{
    public ConversionTools()
	{
	}

    public static double degreesToRadians(double angle)
    {
        return (Math.PI / 180) * (angle - 90);
    }
}
