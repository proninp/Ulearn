using System;

namespace Fractals;

internal static class DragonFractalTask
{
    public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
    {
        Random random = new Random(123);
        double x = 1, y = 0;
        double angleFirst = 45 * Math.PI / 180;
        double angleSecond = 135 * Math.PI / 180;
        pixels.SetPixel(x, y);
        for(int i = 0; i < iterationsCount; i++)
        {
            double nY;
            double nX;
            bool isFirst = random.Next(2) % 2 == 0;
            nX = CalculateX(x, y, angleFirst, angleSecond, isFirst);
            nY = CalculateY(x, y, angleFirst, angleSecond, isFirst);
            (x, y) = (nX, nY);
            pixels.SetPixel(x, y);
        }
    }

    private static double CalculateX(double x, double y, double angleFirst, double angleSecond, bool isFirst)
    {
        if (isFirst)
            return (x * Math.Cos(angleFirst) - y * Math.Sin(angleFirst)) / Math.Sqrt(2);
        return (x * Math.Cos(angleSecond) - y * Math.Sin(angleSecond)) / Math.Sqrt(2) + 1;
    }
    
    private static double CalculateY(double x, double y, double angleFirst, double angleSecond, bool isFirst)
    {
        if (isFirst)
            return (x * Math.Sin(angleFirst) + y * Math.Cos(angleFirst)) / Math.Sqrt(2);
        return (x * Math.Sin(angleSecond) + y * Math.Cos(angleSecond)) / Math.Sqrt(2);
    }
}