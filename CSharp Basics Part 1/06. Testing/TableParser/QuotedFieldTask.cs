using NUnit.Framework;
using System.Text;

namespace TableParser;

[TestFixture]
public class QuotedFieldTaskTests
{
    [TestCase("''", 0, "", 2)]
    [TestCase("'a'", 0, "a", 3)]
    [TestCase("\"abcd\"", 0, "abcd", 6)]
    [TestCase("\"abcd", 0, "abcd", 5)]
    [TestCase("abcd\"abcd\\\\a\"", 4, "abcd\\a", 9)]
    [TestCase("b \"a'\"", 2, "a'", 4)]
    [TestCase(@"'a\' b'", 0, "a' b", 7)]
    [TestCase("'a'b", 0, "a", 3)]
    [TestCase("a'b'", 1, "b", 3)]
    public void Test(string line, int startIndex, string expectedValue, int expectedLength)
    {
        var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
        Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
    }
}

class QuotedFieldTask
{
    public static Token ReadQuotedField(string line, int startIndex)
    {
        var quote = line[startIndex];
        StringBuilder sb = new StringBuilder();
        var i = startIndex + 1;
        for (; i < line.Length; i++)
        {
            if (line[i] == '\\')
            {
                sb.Append(line[++i]);
                continue;
            }
            if (line[i] == quote)
            {
                i++;
                break;
            }
            sb.Append(line[i]);
        }
        return new Token(sb.ToString(), startIndex, i - startIndex);
    }
}