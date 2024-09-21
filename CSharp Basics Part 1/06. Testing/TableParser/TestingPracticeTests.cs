using NUnit.Framework;
using System;

namespace TableParser;
public class TestingPracticeTests
{
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
        FieldParserTaskTests.Test(input, expectedOutput);
    }
}
