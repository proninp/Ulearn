namespace UlearnCommonConsole._04_Split_and_Join
{
    public class Solution
    {
        public static string ReplaceIncorrectSeparators(string text)
        {
            return string.Join('\t',
                text.Split(new char[] { ' ', '-', ':', ',', ';' },
                    StringSplitOptions.RemoveEmptyEntries));
        }
    }
}