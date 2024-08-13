using UlearnCommonConsole.RobotController;
using Xunit;

namespace UlearnCommonConsoleTests.RobotController;

public class ControllerTests
{
    [Theory]
    [InlineData(true,"noboss", 45)]
    [InlineData(true,"noboss", 55)]
    [InlineData(true,"noboss", 105)]
    [InlineData(false,"noboss", 45)]
    [InlineData(false,"noboss", 55)]
    [InlineData(false,"noboss", 105)]
    [InlineData(true,"boss", 45)]
    [InlineData(true,"boss", 55)]
    [InlineData(true,"boss", 105)]
    [InlineData(false,"boss", 45)]
    [InlineData(false,"boss", 55)]
    [InlineData(false,"boss", 105)]
    public static void ShouldFireTest(bool enemyInFront, string enemyName, int robotHealth)
    {
        // Arrange
        bool expected = OriginalController.ShouldFire(enemyInFront, enemyName, robotHealth);
        bool actual = MyController.ShouldFire(enemyInFront, enemyName, robotHealth);
        
        // Act

        // Assert
        Assert.Equal(expected, actual);
    }
}