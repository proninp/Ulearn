using System.Drawing;

public class Solution
{
    public static List<Point> ParsePoints(IEnumerable<string> lines)
    {
        return lines
            .Select(l => new Point(int.Parse(l.Split(' ')[0]), int.Parse(l.Split(' ')[1])))
            .ToList();
    }
}