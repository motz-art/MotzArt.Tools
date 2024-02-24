using FluentAssertions;
using NUnit.Framework;

namespace MotzArt.NullChecks.Tests;

[TestFixture]
public class EnsureArgumentNotNullTests
{
    [Test]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("some string")]
    public void ShouldNotThrowWhenStringValueNotNull(string str)
    {
        str.EnsureArgumentNotNull().Should().BeSameAs(str);
    }

    [Test]
    public void ShouldNotThrowWhenObjectValueNotNull()
    {
        var obj = new object();

        obj.EnsureArgumentNotNull().Should().BeSameAs(obj);
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(-1)]
    [TestCase(int.MaxValue)]
    [TestCase(int.MinValue)]
    public void ShouldNotThrowIfNullableHasValue(int value)
    {
        int? nullable = value;

        nullable.EnsureArgumentNotNull().Should().Be(value);
    }

    [Test]
    public void ShouldThrowWhenObjectValueIsNull()
    {
        object? obj = null;

        var act = () => obj.EnsureArgumentNotNull();

        act.Should().Throw<ArgumentNullException>().WithMessage($"Value cannot be null. (Parameter '{nameof(obj)}')");
    }

    [Test]
    public void ShouldThrowWhenStringValueIsNull()
    {
        string? str = null;

        var act = () => str.EnsureArgumentNotNull();

        act.Should().Throw<ArgumentNullException>().WithMessage($"Value cannot be null. (Parameter '{nameof(str)}')");
    }

    [Test]
    public void ShouldThrowWhenIntValueIsNull()
    {
        int? value = null;

        var act = () => value.EnsureArgumentNotNull();

        act.Should().Throw<ArgumentNullException>().WithMessage($"Value cannot be null. (Parameter '{nameof(value)}')");
    }
}
