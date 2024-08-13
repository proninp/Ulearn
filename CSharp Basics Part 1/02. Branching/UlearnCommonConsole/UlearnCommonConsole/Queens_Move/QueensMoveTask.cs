﻿namespace UlearnCommonConsole.Queens_Move;

public class QueensMoveTask
{
    public static bool IsCorrectMove(string from, string to)
    {
        var dx = Math.Abs(to[0] - from[0]); //смещение фигуры по горизонтали
        var dy = Math.Abs(to[1] - from[1]); //смещение фигуры по вертикали
        return !from.Equals(to) && (dx == 0 || dy == 0 || dx == dy);
    }
}