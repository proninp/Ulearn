namespace Mazes;

public static class EmptyMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        while (!robot.Finished) 
            MoveRobot(robot, width, height);
    }

    private static void MoveRobot(Robot robot, int width, int height)
    {
        MoveDown(robot, height);
        MoveRight(robot, width);
    }

    private static void MoveDown(Robot robot, int height)
    {
        if (robot.Y < height - 2)
            robot.MoveTo(Direction.Down);
    }

    private static void MoveRight(Robot robot, int width)
    {
        if (robot.X < width - 2)
            robot.MoveTo(Direction.Right);
    }
}