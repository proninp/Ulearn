namespace TicTacToe;

public class Game
{
    public static void Play()
    {
        Run("XXX OO. ...");
        Run("OXO XO. .XO");
        Run("OXO XOX OX.");
        Run("XOX OXO OXO");
        Run("... ... ...");
        Run("XXX OOO ...");
        Run("XOO XOO XX.");
        Run(".O. XO. XOX");
    }

    private static void Run(string description)
    {
        Console.WriteLine(description.Replace(" ", Environment.NewLine));
        Console.WriteLine(GetGameResult(CreateFromString(description)));
        Console.WriteLine();
    }

    private static Mark[,] CreateFromString(string str)
    {
        var field = str.Split(' ');
        var ans = new Mark[3, 3];
        for (int x = 0; x < field.Length; x++)
        for (var y = 0; y < field.Length; y++)
            ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);

        return ans;
    }

    public static GameResult GetGameResult(Mark[,] field)
    {
        var isCrossWin = false;
        var isCircleWin = false;

        for (int y = 0; y < field.GetLength(0); y++)
            (isCircleWin, isCrossWin) = GetResultTuple(isCircleWin, isCrossWin, GetRowResult(field, y));

        for (int x = 0; x < field.GetLength(1); x++)
            (isCircleWin, isCrossWin) = GetResultTuple(isCircleWin, isCrossWin, GetColumnResult(field, x));

        (isCircleWin, isCrossWin) = GetResultTuple(isCircleWin, isCrossWin, GetLDiagonalResult(field));
        (isCircleWin, isCrossWin) = GetResultTuple(isCircleWin, isCrossWin, GetRDiagonalResult(field));

        if ((isCrossWin && isCircleWin) || (!isCrossWin && !isCircleWin))
            return GameResult.Draw;
        if (isCrossWin)
            return GameResult.CrossWin;
        return GameResult.CircleWin;
    }

    private static (bool isCircleWin, bool isCrossWin) GetResultTuple(bool isCircle, bool isCross, int result)
    {
        return (IsWin(result, isCircle, (int)Mark.Circle), IsWin(result, isCross, (int)Mark.Cross));
    }

    private static int GetRowResult(Mark[,] field, int y)
    {
        int res = (int)field[y, 0];
        for (var x = 1; x < field.GetLength(1); x++)
            res &= (int)field[y, x];
        return res;
    }

    private static int GetColumnResult(Mark[,] field, int x)
    {
        var res = (int)field[0, x];
        for (var y = 1; y < field.GetLength(0); y++)
            res &= (int)field[y, x];
        return res;
    }

    private static int GetLDiagonalResult(Mark[,] field)
    {
        var res = (int)field[0, 0];
        for (int i = 1; i < field.GetLength(0); i++)
            res &= (int)field[i, i];
        return res;
    }

    private static int GetRDiagonalResult(Mark[,] field)
    {
        var res = (int)field[0, field.GetLength(0) - 1];
        for (int i = 1; i < field.GetLength(0); i++)
            res &= (int)field[i, field.GetLength(0) - 1 - i];
        return res;
    }

    private static bool IsWin(int result, bool isWin, int winValue)
    {
        return isWin || result == winValue;
    }
}