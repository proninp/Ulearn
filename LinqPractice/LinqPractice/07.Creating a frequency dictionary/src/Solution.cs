public class Solution
{
    public static Tuple<string, int>[] GetMostFrequentWords(string text, int count)
    {
        return Regex.Split(text.ToLower(), @"\W+")
            .Where(word => word != "")
            .GroupBy(w => w)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Key)
            .Select(g => Tuple.Create(g.Key, g.Count()))
            .Take(count)
            .ToArray();
    }
}