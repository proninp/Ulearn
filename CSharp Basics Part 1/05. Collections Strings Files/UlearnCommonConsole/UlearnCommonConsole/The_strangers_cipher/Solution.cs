namespace UlearnCommonConsole.The_strangers_cipher
{
    public class Solution
    {
        public static string DecodeMessage(string[] lines)
        {
            return string.Join(" ", lines.Select(s => string.Join(" ",
                s.Split().Where(w => char.IsUpper(w.FirstOrDefault())).Reverse()))
                .Where(s => s.Length > 0)
                .Reverse());
        }
    }
}
