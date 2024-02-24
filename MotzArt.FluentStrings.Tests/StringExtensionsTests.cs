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

[TestFixture]
public class EnsureNotNullTests
{
    [Test]
    [TestCase("a")]
    [TestCase(" value")]
    [TestCase("value ")]
    [TestCase("some string")]
    public void ShouldNotThrowIfNotNullOrWhitespace(string value)
    {
        value.EnsureHasValue().Should().BeSameAs(value);
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("    ")]
    [TestCase("\t")]
    [TestCase("\n")]
    [TestCase("\r\n")]
    public void ShouldThrowIfNullOrWhitespace(string? value)
    {
        var act = () => value.EnsureHasValue();
        act.Should().Throw<ArgumentException>().WithMessage($"{nameof(value)} should not be null or white-space.");
    }
}