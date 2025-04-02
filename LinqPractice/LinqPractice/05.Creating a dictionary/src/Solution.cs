public class Solution
{
    public static string[] GetSortedWords(params string[] textLines)
    {
        return textLines
            .SelectMany(s => s.Split(new char[] { ' ', ',', '\'', '.', ';' }, StringSplitOptions.RemoveEmptyEntries))
            .Select(w => w.ToLower())
            .OrderBy(w => w)
            .Distinct()
            .ToArray();
    }
}