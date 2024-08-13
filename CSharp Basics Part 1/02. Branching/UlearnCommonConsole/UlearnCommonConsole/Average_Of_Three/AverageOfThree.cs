namespace UlearnCommonConsole.Average_Of_Three;

public class AverageOfThree
{
    public static int MiddleOf(int a, int b, int c)
    {
        if (a > b)
            if (b > c) return b;
            else if (a > c) return c;
            else return a;
        if (a > c) return a;
        return b > c ? c : b;
    }
}