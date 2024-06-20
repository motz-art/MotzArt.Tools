using FluentAssertions;
using NUnit.Framework;

namespace MotzArt.FluentStrings.Tests;

[TestFixture]
public class StringExtensionsTests
{
    [Test]
    [TestCase(null, true)]
    [TestCase("", true)]
    [TestCase(" ", false)]
    [TestCase("    ", false)]
    [TestCase("\t", false)]
    [TestCase("\n", false)]
    [TestCase("\r\n", false)]
    [TestCase("Some string", false)]
    public void IsNullOrEmptyTests(string? str, bool expected)
    {
        str.IsNullOrEmpty().Should().Be(expected);
    }

    [Test]
    [TestCase(null, true)]
    [TestCase("", true)]
    [TestCase(" ", true)]
    [TestCase("    ", true)]
    [TestCase("\t", true)]
    [TestCase("\n", true)]
    [TestCase("\r\n", true)]
    [TestCase("Some string", false)]
    public void IsNullOrWhitespaceTests(string? str, bool expected)
    {
        str.IsNullOrWhitespace().Should().Be(expected);
    }

    [Test]
    [TestCase(null, false)]
    [TestCase("", false)]
    [TestCase(" ", false)]
    [TestCase("    ", false)]
    [TestCase("\t", false)]
    [TestCase("\n", false)]
    [TestCase("\r\n", false)]
    [TestCase("a", true)]
    [TestCase("Some string", true)]
    public void HasValueTests(string? str, bool expected)
    {
        str.HasValue().Should().Be(expected);
    }

    [Test]
    [TestCase(null, null)]
    [TestCase("", "")]
    [TestCase("a", "a")]
    [TestCase(" ", "")]
    [TestCase(" \r", "")]
    [TestCase(" \r\n ", "")]
    [TestCase(" \t\r\n ", "")]
    [TestCase("String", "String")]
    [TestCase(" \r\n\tString\r\n\t ", "String")]
    [TestCase("Some String", "Some String")]
    [TestCase("Some  String", "Some String")]
    [TestCase("Some\tString", "Some\tString")]
    [TestCase("Here is a String", "Here is a String")]
    [TestCase("Here  is  a  String", "Here is a String")]
    [TestCase("Here\r\nis\r\na\r\nString", "Here\r\nis\r\na\r\nString")]

    [TestCase("Some\r\nString", "Some\r\nString")]
    [TestCase("Some\r\n\r\nString", "Some\r\nString")]
    [TestCase("Some\r\n String", "Some\r\nString")]
    [TestCase("Some \r\n String", "Some\r\nString")]
    [TestCase("Some \r\nString", "Some\r\nString")]

    [TestCase("Here  is\r\n\r\nsome  String", "Here is\r\nsome String")]


    public void RemoveRedundantWhiteSpacesTests(string? str, string expected)
    {
        str.RemoveRedundantWhiteSpaces().Should().Be(expected);
    }

    [Test]
    [TestCase("", "")]
    [TestCase("a", "a")]
    [TestCase(" ", "")]
    [TestCase(" \r", "")]
    [TestCase(" \r\n ", "")]
    [TestCase(" \t\r\n ", "")]
    [TestCase("String", "String")]
    [TestCase(" \r\n\tString\r\n\t ", "String")]
    [TestCase("Some String", "Some String")]
    [TestCase("Some  String", "Some String")]
    [TestCase("Some\tString", "Some\tString")]
    [TestCase("Here is a String", "Here is a String")]
    [TestCase("Here  is  a  String", "Here is a String")]
    [TestCase("Here\r\nis\r\na\r\nString", "Here\r\nis\r\na\r\nString")]

    [TestCase("Some\r\nString", "Some\r\nString")]
    [TestCase("Some\r\n\r\nString", "Some\r\nString")]
    [TestCase("Some\r\n String", "Some\r\nString")]
    [TestCase("Some \r\n String", "Some\r\nString")]
    [TestCase("Some \r\nString", "Some\r\nString")]

    [TestCase("Here  is\r\n\r\nsome  String", "Here is\r\nsome String")]


    public void RemoveRedundantWhiteSpacesSpanTests(string str, string expected)
    {
        str.AsSpan().RemoveRedundantWhiteSpaces().ToString().Should().Be(expected);
    }
}