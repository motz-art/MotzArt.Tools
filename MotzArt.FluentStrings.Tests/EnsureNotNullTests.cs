using FluentAssertions;
using NUnit.Framework;

namespace MotzArt.FluentStrings.Tests;

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