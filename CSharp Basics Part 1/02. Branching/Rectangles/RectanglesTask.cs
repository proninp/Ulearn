using System;

namespace Rectangles;

public static class RectanglesTask
{
    // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
    public static bool AreIntersected(Rectangle r1, Rectangle r2)
    {
        return r1.Left <= r2.Right && r1.Right >= r2.Left &&
               r1.Top <= r2.Bottom && r1.Bottom >= r2.Top;
    }

    // Площадь пересечения прямоугольников
    public static int IntersectionSquare(Rectangle r1, Rectangle r2)
    {
        if (!AreIntersected(r1, r2)) return 0;
        var left = Math.Max(r1.Left, r2.Left);
        var right = Math.Min(r1.Right, r2.Right);
        var bottom = Math.Min(r1.Bottom, r2.Bottom);
        var top = Math.Max(r1.Top, r2.Top);
        return (right - left) * (bottom - top);
    }

    // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
    // Иначе вернуть -1
    // Если прямоугольники совпадают, можно вернуть номер любого из них.
    public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
    {
        var isFirst = CheckIfInnerRectangle(r1, r2); 
        if (!isFirst && !CheckIfInnerRectangle(r2, r1))
            return -1;
        return isFirst ? 0 : 1;
    }
    
    private static bool CheckIfInnerRectangle(Rectangle r1, Rectangle r2)
    {
        return r1.Left >= r2.Left && r1.Right <= r2.Right && r1.Top >= r2.Top && r1.Bottom <= r2.Bottom;
    }
}