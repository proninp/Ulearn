namespace TextAnalysis;

static class TextGeneratorTask
{
    public static string ContinuePhrase(
        Dictionary<string, string> nextWords, string phraseBeginning, int wordsCount)
    {
        if (string.IsNullOrEmpty(phraseBeginning))
            return phraseBeginning;
        var wordsList = phraseBeginning.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        while (wordsCount-- > 0)
        {
            string key = wordsList[^1];
            if (wordsList.Count > 1)
            {
                var tKey = $"{wordsList[^2]} {key}";
                if (nextWords.ContainsKey(tKey))
                    key = tKey;
            }
            if (!nextWords.ContainsKey(key))
                break;
            wordsList.Add(nextWords[key]);
        }
        return string.Join(" ", wordsList);
    }
}