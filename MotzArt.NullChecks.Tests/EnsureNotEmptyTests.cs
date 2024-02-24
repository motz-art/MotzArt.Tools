using FluentAssertions;
using NUnit.Framework;

namespace MotzArt.NullChecks.Tests;

[TestFixture]
public class EnsureNotEmptyTests
{
    [Test]
    public void ShouldNotThrowForNonEmptyList()
    {
        var list = new List<string?> { null };

        list.EnsureNotEmpty().Should().BeSameAs(list);
    }

    [Test]
    public void ShouldNotThrowForNonEmptyIList()
    {
        IList<string?> list = new List<string> { null };

        list.EnsureNotEmpty().Should().BeSameAs(list);
    }

    [Test]
    public void ShouldNotThrowForNonEmptyIReadOnlyList()
    {
        IReadOnlyList<string?> list = new string?[] { null };

        list.EnsureNotEmpty().Should().BeSameAs(list);
    }

    [Test]
    public void ShouldThrowWhenListIsNull()
    {
        List<string>? list = null;

        var act = () => list.EnsureNotEmpty();

        act.Should().Throw<ArgumentException>().WithMessage($"{nameof(list)} should have at least one item.");
    }

    [Test]
    public void ShouldThrowWhenListIsEmpty()
    {
        List<string> list = new();

        var act = () => list.EnsureNotEmpty();

        act.Should().Throw<ArgumentException>().WithMessage($"{nameof(list)} should have at least one item.");
    }

    [Test]
    public void ShouldThrowWhenIListIsNull()
    {
        IList<string>? list = null;

        var act = () => list.EnsureNotEmpty();

        act.Should().Throw<ArgumentException>().WithMessage($"{nameof(list)} should have at least one item.");
    }

    [Test]
    public void ShouldThrowWhenIListEmpty()
    {
        IList<string> list = new List<string>();

        var act = () => list.EnsureNotEmpty();

        act.Should().Throw<ArgumentException>().WithMessage($"{nameof(list)} should have at least one item.");
    }

    [Test]
    public void ShouldThrowWhenIReadOnlyListIsNull()
    {
        IReadOnlyList<string>? list = null;

        var act = () => list.EnsureNotEmpty();

        act.Should().Throw<ArgumentException>().WithMessage($"{nameof(list)} should have at least one item.");
    }

    [Test]
    public void ShouldThrowWhenIReadOnlyListEmpty()
    {
        IReadOnlyList<string> list = Array.Empty<string>();

        var act = () => list.EnsureNotEmpty();

        act.Should().Throw<ArgumentException>().WithMessage($"{nameof(list)} should have at least one item.");
    }
}