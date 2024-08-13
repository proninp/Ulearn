namespace UlearnCommonConsole.Is_Leep_Year;

public class IsLeepYearTask
{
    public static bool IsLeapYear(int year)
    {
        return (year % 400 == 0) || (year % 100 != 0 && year % 4 == 0);
    }
}