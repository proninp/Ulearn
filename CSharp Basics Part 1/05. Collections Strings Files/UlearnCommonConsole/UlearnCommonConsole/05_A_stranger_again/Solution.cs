using System.Text;

namespace UlearnCommonConsole._05_A_stranger_again
{
    public class Solution
    {
        public static string ApplyCommands(string[] commands)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string command in commands)
            {
                if (command.Substring(0, 3) == "pop")
                {
                    var removeCount = int.Parse(command.Substring(4));
                    sb.Remove(sb.Length - removeCount, removeCount);
                }
                else
                    sb.Append(command.Substring(5));
            }
            return sb.ToString();
        }
    }
}