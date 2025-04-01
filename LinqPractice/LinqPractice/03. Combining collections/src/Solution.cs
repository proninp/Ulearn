public class Solution
{
    public static string[] GetAllStudents(Classroom[] classes)
    {
        return classes.SelectMany(c => c.Students).ToArray();
    }
}