public class Solution
{
    public static List<string>  GetSortedWords(string text)
    {
        return text.Split(new char[] {' ', ',', '\'', '.', ';'}, StringSplitOptions.RemoveEmptyEntries)
            .Select(w => Tuple.Create(w.ToLower()))
            .OrderBy(t => t)
            .Select(t => t.Item1)
            .Distinct()
            .OrderBy(w => w.Length)
            .ToList();
    }
}