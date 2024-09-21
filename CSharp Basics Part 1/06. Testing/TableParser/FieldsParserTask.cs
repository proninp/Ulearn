using System.Collections.Generic;
using System.Text;
using System.Threading;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace TableParser;

[TestFixture]
public class FieldParserTaskTests
{
	public static void Test(string input, string[] expectedResult)
	{
		var actualResult = FieldsParserTask.ParseLine(input);
		Assert.AreEqual(expectedResult.Length, actualResult.Count);
		for (int i = 0; i < expectedResult.Length; ++i)
		{
			Assert.AreEqual(expectedResult[i], actualResult[i].Value);
		}
	}

    [TestCase("a", new[] { "a" })]
    [TestCase("a b", new[] { "a", "b" })]
    [TestCase("\"a\"", new[] { "a" })]
    [TestCase("\"a 'b' 'c' d\"", new[] { "a 'b' 'c' d" })]
    [TestCase("\"a 'b'  'c' d\"", new[] { "a 'b'  'c' d" })]
    [TestCase("'\"1\" \"2\" \"3\"'", new[] { "\"1\" \"2\" \"3\"" })]
    [TestCase("'\\'1\\' \\'2\\' \\'3\\''", new[] { "'1' '2' '3'" })]
    [TestCase("\"1\"   \"2\"", new[] { "1", "2" })]
    [TestCase("''", new[] { "" })]
    [TestCase("", new string[0])]
    [TestCase("' '", new[] { " " })]
    [TestCase("' a'", new[] { " a" })]
    [TestCase("a\"b", new[] { "a", "b" })]
    [TestCase("\"b ", new[] { "b " })]
    [TestCase("'a'b", new[] { "a", "b" })]
    [TestCase("\"b c d e\"", new[] { "b c d e" })]
    [TestCase("\"def", new[] { "def" })]
    [TestCase("\"a \\\"c\\\"", new[] { "a \"c\"" })]
    [TestCase("\"a\" \\", new[] { "a", "\\" })]
    [TestCase("\"\\\\\"", new[] { "\\" })]
    [TestCase(" \"a\" ", new[] { "a" })]
    public static void RunTests(string input, string[] expectedOutput)
    {
        Test(input, expectedOutput);
    }
}

public class FieldsParserTask
{
	private const char SingleQuote = '\'';
	private const char DoubleQuote = '"';
	public static List<Token> ParseLine(string line)
	{
		var tokens = new List<Token>();
		var startIndex = 0;
		while (startIndex < line.Length)
		{
			if (line[startIndex] == ' ')
			{
                startIndex++;
				continue;
            }
			var token = IsQuotedField(line, startIndex) ?
				ReadQuotedField(line, ref startIndex) :
				ReadField(line, startIndex);
			tokens.Add(token);
			startIndex += token.Length;
        }
		return tokens;
	}
        
	private static Token ReadField(string line, int startIndex)
	{
        StringBuilder sb = new StringBuilder(line[startIndex].ToString());
        var i = startIndex + 1;
        for (; i < line.Length; i++)
        {
            var c = line[i];
            if (c == DoubleQuote || c == SingleQuote || c == ' ')
                break;
            sb.Append(c);
        }
        return new Token(sb.ToString(), startIndex, i - startIndex);
    }

	public static bool IsQuotedField(string line, int startIndex)
	{
		if (startIndex >= line.Length)
			return false;
		var c = line[startIndex];
		return c == '\'' || c == '"';
	}

	public static Token ReadQuotedField(string line, ref int startIndex)
	{
        var token = QuotedFieldTask.ReadQuotedField(line, startIndex);
		if (IsLastQuote(line, startIndex, token.Length))
			startIndex++;
		return token;
    }

	private static bool IsLastQuote(string line, int startIndex, int tokenLength)
	{
        var position = startIndex + tokenLength;
        if (position < line.Length)
        {
            var c = line[position];
			return c == SingleQuote || c == DoubleQuote;
        }
		return false;
    }
}