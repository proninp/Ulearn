using System;

namespace Mazes;

public static class DiagonalMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        while (!robot.Finished) 
            MoveRobot(robot, width, height);
    }
    
    private static void MoveRobot(Robot robot, int width, int height)
    {
        int stepsDown = height > width ? (int)Math.Round(height * 1.0 / width, 0) : 1;
        int stepsRight = width > height ? (int)Math.Round(width * 1.0 / height, 0) : 1;
        if (stepsRight > stepsDown)
            MoveRightAndDown(robot, width, height, stepsDown , stepsRight);
        else
            MoveDownAndRight(robot, width, height, stepsDown, stepsRight);
    }

    private static void MoveRightAndDown(Robot robot, int width, int height, int stepsDown, int stepsRight)
    {
        MoveRight(robot, width, stepsRight);
        MoveDown(robot, height, stepsDown);
    }
    
    private static void MoveDownAndRight(Robot robot, int width, int height, int stepsDown, int stepsRight)
    {
        MoveDown(robot, height, stepsDown);
        MoveRight(robot, width, stepsRight);
    }

    private static void MoveDown(Robot robot, int height, int steps)
    {
        for (var i = 0; i < steps && (robot.Y < height - 2); i++) 
            robot.MoveTo(Direction.Down);
    }

    private static void MoveRight(Robot robot, int width, int steps)
    {
        for (var i = 0; i < steps && (robot.X < width - 2); i++)
            robot.MoveTo(Direction.Right);
    }
}