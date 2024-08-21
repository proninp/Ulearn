namespace UlearnCommonConsole.Benfords_Law
{
    public class Solution
    {
        public static int[] GetBenfordStatistics(string text)
        {
            var statistics = new int[10];
            var lines = text.Split();
            foreach (var word in lines)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (char.IsDigit(word[i]))
                    {
                        statistics[word[i] - '0']++;
                        break;
                    }
                }
            }
            return statistics;
        }
    }
}
