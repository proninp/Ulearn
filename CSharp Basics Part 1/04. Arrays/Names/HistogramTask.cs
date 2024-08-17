using System.Linq;

namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
        var xLabels = Enumerable.Range(1, 31).Select(x => x.ToString()).ToArray();
        var heat = new double[xLabels.Length];
        
        foreach (var nameData in names)
        {
            if (nameData.Name == name && nameData.BirthDate.Day != 1)
                heat[nameData.BirthDate.Day - 1]++;
        }
        
        return new HistogramData(
            $"Рождаемость людей с именем '{name}'", 
            xLabels, 
            heat);
    }
}