﻿using FluentAssertions;
using NUnit.Framework;

namespace MotzArt.NullChecks.Tests;

[TestFixture]
public class EnsureNotNullTests
{
    [Test]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("some string")]
    public void ShouldNotThrowWhenStringValueNotNull(string str)
    {
        str.EnsureNotNull().Should().BeSameAs(str);
    }

    [Test]
    public void ShouldNotThrowWhenObjectValueNotNull()
    {
        var obj = new object();

        obj.EnsureNotNull().Should().BeSameAs(obj);
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

        nullable.EnsureNotNull().Should().Be(value);
    }

    [Test]
    public void ShouldThrowWhenObjectValueIsNull()
    {
        object? obj = null;

        var act = () => obj.EnsureNotNull();

        act.Should().Throw<NullReferenceException>().WithMessage($"{nameof(obj)} should not be null.");
    }

    [Test]
    public void ShouldThrowWhenStringValueIsNull()
    {
        string? str = null;

        var act = () => str.EnsureNotNull();

        act.Should().Throw<NullReferenceException>().WithMessage($"{nameof(str)} should not be null.");
    }

    [Test]
    public void ShouldThrowWhenIntValueIsNull()
    {
        int? value = null;

        var act = () => value.EnsureNotNull();

        act.Should().Throw<NullReferenceException>().WithMessage($"{nameof(value)} should not be null.");
    }
}