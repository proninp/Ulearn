namespace Mazes;

public static class SnakeMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        while (!robot.Finished) 
            MoveRobot(robot, width, height);
    }
    
    private static void MoveRobot(Robot robot, int width, int height)
    {
        MoveRight(robot, width);
        DoubleMoveDown(robot, height);
        MoveLeft(robot);
        DoubleMoveDown(robot, height);
    }

    private static void DoubleMoveDown(Robot robot, int height)
    {
        for (var i = 0; i < 2 && (robot.Y < height - 2); i++) 
            robot.MoveTo(Direction.Down);
    }

    private static void MoveRight(Robot robot, int width)
    {
        while (robot.X < width - 2)
            robot.MoveTo(Direction.Right);
    }
    
    private static void MoveLeft(Robot robot)
    {
        while (robot.X > 1)
            robot.MoveTo(Direction.Left);
    }
}