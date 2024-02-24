using FluentAssertions;
using NUnit.Framework;

namespace MotzArt.NullChecks.Tests;

[TestFixture]
public class EnsureNotNullTests
{
    [Test]
    public void ShouldNotThrowWhenStringValueNotNull()
    {
        var value = "";
        value.EnsureNotNull().Should().BeSameAs(value);
    }

    [Test]
    public void ShouldNotThrowWhenObjectValueNotNull()
    {
        var obj = new object();

        obj.EnsureNotNull().Should().BeSameAs(obj);
    }
}