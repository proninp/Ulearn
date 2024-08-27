namespace TextAnalysis;

static class FrequencyAnalysisTask
{
    public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
    {
        var map = new Dictionary<string, Dictionary<string, int>>();
        foreach (var sentence in text)
        {
            for (int i = 0; i < sentence.Count - 1; i++)
            { 
                var bKey = sentence[i];
                var bValue = sentence[i + 1];
                AddNewPairWithCheck(map, bKey, bValue);
                if (i + 2 < sentence.Count)
                {
                    var tKey = $"{bKey} {bValue}";
                    var tValue = sentence[i + 2];
                    AddNewPairWithCheck(map, tKey, tValue);
                }
            }
        }

        return map.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key, StringComparer.Ordinal)
                    .FirstOrDefault().Key);
    }

    private static void AddNewPairWithCheck(Dictionary<string, Dictionary<string, int>> map, string key, string value)
    {
        if (!map.ContainsKey(key))
        {
            map.Add(key, new Dictionary<string, int> { { value, 1 } });
            return;
        }
        var innerMap = map[key];
        if (!innerMap.ContainsKey(value))
        {
            innerMap.Add(value, 1);
            return;
        }
        innerMap[value]++;
    }
}