public class Solution
{
    public static IEnumerable<Point> GetNeighbours(Point p)
    {
        int[] d = {-1, 0, 1}; // используйте подсказку, если не понимаете зачем тут этот массив :)
            
        return d.SelectMany(x => d.Select(y => new Point(p.X + x, p.Y + y)))
            .Where(pnt => !p.Equals(pnt));
    }
}