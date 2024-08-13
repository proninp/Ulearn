﻿namespace UlearnCommonConsole.RobotController;

public class OriginalController
{
    public static bool ShouldFire(bool enemyInFront, string enemyName, int robotHealth)
    {
        bool shouldFire = true;
        if (enemyInFront == true)
        {
            if (enemyName == "boss")
            {
                if (robotHealth < 50) shouldFire = false;
                if (robotHealth > 100) shouldFire = true;
            }
        }
        else
        {
            return false;
        }
        return shouldFire;
    }
}