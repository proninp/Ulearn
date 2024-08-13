namespace UlearnCommonConsole.RobotController;

public class MyController
{
    public static bool ShouldFire(bool enemyInFront, string enemyName, int robotHealth)
    {
        return enemyInFront && (enemyName != "boss" || robotHealth >= 50);
    }
}