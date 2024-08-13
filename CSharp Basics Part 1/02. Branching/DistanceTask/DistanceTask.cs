using System;

namespace DistanceTask;

public static class DistanceTask
{
    // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
    public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
    {
        if (ax.CompareTo(bx) == 0 && ay.CompareTo(by) == 0)
        {
            if (ax.CompareTo(ay) == 0 && ax.CompareTo(x) == 0 && x.CompareTo(y) == 0) return 0;
            return Math.Sqrt((x - ax) * (x - ax) + (y - ay) * (y - ay));
        }
        var t = ((x - ax) * (bx - ax) + (y - ay) * (by - ay)) / ((bx - ax) * (bx - ax) + (by - ay) * (by - ay));
        t = t < 0 ? 0 : t > 1 ? 1 : t;
        var u = ax - x + (bx - ax) * t;
        var v = ay - y + (by - ay) * t;
        return Math.Sqrt(u * u + v * v);
    }
}