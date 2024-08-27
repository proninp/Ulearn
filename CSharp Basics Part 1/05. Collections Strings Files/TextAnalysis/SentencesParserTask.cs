namespace TextAnalysis;

static class SentencesParserTask
{
    public static List<List<string>> ParseSentences(string text)
    {
        char[] wordsSeparators = {
            '^', '#', '$', '-', '—', '+',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            '=', '\t', '\n', '\r', ',', '…', '“',
            '”', '<', '>', '‘', '*', ' ', '/', '\u00A0'};

        return text.Split(new[] { '.', '!', '?', ';', ':', '(', ')' },
            StringSplitOptions.RemoveEmptyEntries)
            .Select(w => w
            .Split(wordsSeparators, StringSplitOptions.RemoveEmptyEntries)
            .Select(w => w.Trim().ToLower())
            .Where(w => w.Length > 0)
            .ToList())
            .Where(e => e.Count > 0)
            .ToList();
    }
}