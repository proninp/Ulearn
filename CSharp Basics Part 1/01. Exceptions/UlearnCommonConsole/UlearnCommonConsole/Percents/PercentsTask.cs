namespace UlearnCommonConsole.Percents;

public class PercentsTask
{
    public static double Calculate(string userInput)
    {
        var parts = userInput.Split(' ')
            .Select(x => double.Parse(x, System.Globalization.CultureInfo.InvariantCulture)).ToList();
        if (parts[2] == 0) return parts[0];
        parts[0] += parts[0] * (parts[1] / 100.0) / 12;
        parts[2] -= 1;
        return Calculate(string.Join(" ", parts));
    }
}