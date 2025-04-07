public class Solution
{
    public static ILookup<string, int> BuildInvertedIndex(Document[] documents)
    {
        return documents
            .SelectMany(d => Regex.Split(d.Text.ToLower(), @"\W+").Where(w => w != ""), (d, word) => (d.Id, word))
            .Distinct()s
            .ToLookup(t => t.word, t => t.Id);
    }
}