using FluentAssertions;
using NUnit.Framework;

namespace MotzArt.FluentStrings.Tests;

[TestFixture]
public class JoinStringTests
{
    [Test]
    public void ShouldJoinEmptyArrayWithStringSeparator()
    {
        var result = Array.Empty<object>().JoinString(", ");
        result.Should().BeEmpty();
    }

    [Test]
    public void ShouldJoinEmptyEnumerableWithStringSeparator()
    {
        var result = Enumerable.Empty<object>().JoinString(", ");
        result.Should().BeEmpty();
    }

    [Test]
    public void ShouldJoinEmptyArrayWithCharSeparator()
    {
        var result = Array.Empty<object>().JoinString(',');
        result.Should().BeEmpty();
    }

    [Test]
    public void ShouldJoinEmptyEnumerableWithCharSeparator()
    {
        var result = Enumerable.Empty<object>().JoinString(',');
        result.Should().BeEmpty();
    }

    [Test]
    public void ShouldJoinEmptyStringArrayWithStringSeparator()
    {
        var result = Array.Empty<string>().JoinString(", ");
        result.Should().BeEmpty();
    }

    [Test]
    public void ShouldJoinEmptyStringEnumerableWithStringSeparator()
    {
        var result = Enumerable.Empty<string>().JoinString(", ");
        result.Should().BeEmpty();
    }

    [Test]
    public void ShouldJoinEmptyStringArrayWithCharSeparator()
    {
        var result = Array.Empty<string>().JoinString(',');
        result.Should().BeEmpty();
    }

    [Test]
    public void ShouldJoinEmptyStringEnumerableWithCharSeparator()
    {
        var result = Enumerable.Empty<string>().JoinString(',');
        result.Should().BeEmpty();
    }

    [Test]
    public void ShouldJoinSingleItemArrayWithStringSeparator()
    {
        var result = new[] { 123 }.JoinString(", ");
        result.Should().Be("123");
    }

    [Test]
    public void ShouldJoinSingleItemEnumerableWithStringSeparator()
    {
        var result = Enumerable.Repeat(123, 1).JoinString(", ");
        result.Should().Be("123");
    }

    [Test]
    public void ShouldJoinSingleItemArrayWithCharSeparator()
    {
        var result = new[] { 123 }.JoinString(',');
        result.Should().Be("123");
    }

    [Test]
    public void ShouldJoinSingleItemEnumerableWithCharSeparator()
    {
        var result = Enumerable.Repeat(123, 1).JoinString(',');
        result.Should().Be("123");
    }

    [Test]
    public void ShouldJoinSingleItemStringArrayWithStringSeparator()
    {
        var result = new[] { "123" }.JoinString(", ");
        result.Should().Be("123");
    }

    [Test]
    public void ShouldJoinSingleItemStringEnumerableWithStringSeparator()
    {
        var result = Enumerable.Repeat("123", 1).JoinString(", ");
        result.Should().Be("123");
    }

    [Test]
    public void ShouldJoinSingleItemStringArrayWithCharSeparator()
    {
        var result = new[] { "123" }.JoinString(',');
        result.Should().Be("123");
    }

    [Test]
    public void ShouldJoinSingleItemStringEnumerableWithCharSeparator()
    {
        var result = Enumerable.Repeat("123", 1).JoinString(',');
        result.Should().Be("123");
    }

    [Test]
    public void ShouldJoinTwoItemsArrayWithStringSeparator()
    {
        var result = new[] { 123, 123 }.JoinString(", ");
        result.Should().Be("123, 123");
    }

    [Test]
    public void ShouldJoinTwoItemsEnumerableWithStringSeparator()
    {
        var result = Enumerable.Repeat(123, 2).JoinString(", ");
        result.Should().Be("123, 123");
    }

    [Test]
    public void ShouldJoinTwoItemsArrayWithCharSeparator()
    {
        var result = new[] { 123, 123 }.JoinString(',');
        result.Should().Be("123,123");
    }

    [Test]
    public void ShouldJoinTwoItemsEnumerableWithCharSeparator()
    {
        var result = Enumerable.Repeat(123, 2).JoinString(',');
        result.Should().Be("123,123");
    }

    [Test]
    public void ShouldJoinTwoItemsStringArrayWithStringSeparator()
    {
        var result = new[] { "123", "123" }.JoinString(", ");
        result.Should().Be("123, 123");
    }

    [Test]
    public void ShouldJoinTwoItemsStringEnumerableWithStringSeparator()
    {
        var result = Enumerable.Repeat("123", 2).JoinString(", ");
        result.Should().Be("123, 123");
    }

    [Test]
    public void ShouldJoinTwoItemsStringArrayWithCharSeparator()
    {
        var result = new[] { "123", "123" }.JoinString(',');
        result.Should().Be("123,123");
    }

    [Test]
    public void ShouldJoinTwoItemsStringEnumerableWithCharSeparator()
    {
        var result = Enumerable.Repeat("123", 2).JoinString(',');
        result.Should().Be("123,123");
    }
}