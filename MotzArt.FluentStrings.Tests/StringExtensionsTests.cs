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
}