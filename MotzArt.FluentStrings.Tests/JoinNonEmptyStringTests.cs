using FluentAssertions;
using NUnit.Framework;

namespace MotzArt.FluentStrings.Tests;

[TestFixture]
public class JoinNonEmptyStringTests
{
    [Test]
    [TestCase("", "", ExpectedResult = "")]
    [TestCase(null, "", ExpectedResult = "")]
    [TestCase("", null, ExpectedResult = "")]
    [TestCase("str", "", ExpectedResult = "str")]
    [TestCase("", "str", ExpectedResult = "str")]
    [TestCase("str", null, ExpectedResult = "str")]
    [TestCase(null, "str", ExpectedResult = "str")]
    [TestCase("foo", "", "bar", ExpectedResult = "foo, bar")]
    [TestCase("", "foo", "bar", ExpectedResult = "foo, bar")]
    [TestCase("foo", "bar", "", ExpectedResult = "foo, bar")]
    [TestCase("foo", "", null, "bar", ExpectedResult = "foo, bar")]
    [TestCase(null, "foo", "bar", ExpectedResult = "foo, bar")]
    [TestCase("foo", "bar", null, ExpectedResult = "foo, bar")]
    public string JoinNonEmptyStringsTests(params string?[] values)
    {
        return values.JoinNonEmptyStrings(", ");
    }

    [Test]
    [TestCase(null, 0)]
    [TestCase("", 0)]
    [TestCase(" ", 0)]
    [TestCase("  ", 0)]
    [TestCase("\t", 0)]
    [TestCase("\r\n", 0)]

    [TestCase(null, 1)]
    [TestCase("", 1)]
    [TestCase(" ", 1)]
    [TestCase("  ", 1)]
    [TestCase("\t", 1)]
    [TestCase("\r\n", 1)]

    [TestCase(null, 2)]
    [TestCase("", 2)]
    [TestCase(" ", 2)]
    [TestCase("  ", 2)]
    [TestCase("\t", 2)]
    [TestCase("\r\n", 2)]

    [TestCase(null, 10)]
    [TestCase("", 10)]
    [TestCase(" ", 10)]
    [TestCase("  ", 10)]
    [TestCase("\t", 10)]
    [TestCase("\r\n", 10)]
    public void ShouldIgnoreNullOrWhitespaceStringsTest(string? value, int n)
    {
        var result = Enumerable.Repeat("", n).JoinNonEmptyStrings(", ");
        result.Should().BeEmpty();
    }

    [Test]
    public void ShouldThrowIfValuesIsNull()
    {
        IEnumerable<string>? values = null;
        var act = () => values.JoinNonEmptyStrings(",");
        act.Should().Throw<ArgumentNullException>();
    }
}