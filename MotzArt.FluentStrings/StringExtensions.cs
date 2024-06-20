using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace MotzArt.FluentStrings;

public static class StringExtensions
{
    /// <summary>
    /// Indicates whether the <see cref="value"/> string is <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns><see langword="true"/> is <see cref="value"/> is <see langword="null"/>, empty string (""), or consists only of white-space characters, otherwise <see langword="false"/>.</returns>
    public static bool IsNullOrWhitespace([NotNullWhen(false)] this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    /// Indicates whether the <see cref="value"/> string is <see langword="null"/> or an empty string (""). 
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns><see langword="true"/> if <see cref="value"/> is <see langword="null"/> or <see cref="string.Empty"/>.</returns>
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
    {
        return string.IsNullOrEmpty(value);
    }

    /// <summary>
    /// Checks if string <see cref="value"/> is not <see langword="null"/> and has any non white-space character.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <remarks>Opposite of <see cref="IsNullOrWhitespace"/>.</remarks>
    /// <returns><see langword="true"/> if <see cref="value"/> is not <see langword="null"/> and not <see cref="string.Empty"/> and not consists exclusively of white-space character, otherwise <see langword="false"/>.</returns>
    public static bool HasValue([NotNullWhen(true)] this string? value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    /// Ensures that string <see cref="value"/> is not <see langword="null"/> and has any non white-space character.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="name">Name of variable or hint to include in <see cref="ArgumentException"/>.</param>
    /// <returns>Original <see cref="value"/> if it is not <see langword="null"/> and has non white-space character.</returns>
    /// <exception cref="ArgumentException">Throws if <see cref="value"/> is <see langword="null"/> or consists only of white-space characters.</exception>
    public static string EnsureHasValue([NotNull] this string? value, [CallerArgumentExpression(nameof(value))] string name = "<not specified>")
    {
        if (value.IsNullOrWhitespace()) throw new ArgumentException($"{name} should not be null or white-space.");
        return value;
    }

    /// <summary>
    /// Concatenates the elements of a specified collection, using the specified separator between each element.
    /// </summary>
    /// <typeparam name="T">The type of the members of <see cref="source"/>.</typeparam>
    /// <param name="source">A collection that contains the objects to concatenate.</param>
    /// <param name="separator">The string to use as a separator. <see cref="separator"/> is included in the returned string only if values has more than one element.</param>
    /// <returns>A <see langword="string"/> that consists of the elements of values delimited by the separator string.</returns>
    public static string JoinString<T>(this IEnumerable<T> source, string separator)
    {
        return string.Join(separator, source);
    }

    /// <summary>
    /// Concatenates the elements of a specified collection, using the specified separator between each element.
    /// </summary>
    /// <typeparam name="T">The type of the members of <see cref="source"/>.</typeparam>
    /// <param name="source">A collection that contains the objects to concatenate.</param>
    /// <param name="separator">The string to use as a separator. <see cref="separator"/> is included in the returned string only if values has more than one element.</param>
    /// <returns>A <see langword="string"/> that consists of the elements of values delimited by the separator string.</returns>
    public static string JoinString<T>(this IEnumerable<T> source, char separator)
    {
        return string.Join(separator, source);
    }

    /// <summary>
    /// Concatenates the elements of a specified collection, using the specified separator between each element.
    /// </summary>
    /// <typeparam name="T">The type of the members of <see cref="source"/>.</typeparam>
    /// <param name="source">A collection that contains the objects to concatenate.</param>
    /// <param name="separator">The string to use as a separator. <see cref="separator"/> is included in the returned string only if values has more than one element.</param>
    /// <returns>A <see langword="string"/> that consists of the elements of values delimited by the separator string.</returns>
    public static string JoinString<T>(this T[] source, string separator)
    {
        return string.Join(separator, source);
    }

    /// <summary>
    /// Concatenates the elements of a specified collection, using the specified separator between each element.
    /// </summary>
    /// <typeparam name="T">The type of the members of <see cref="source"/>.</typeparam>
    /// <param name="source">A collection that contains the objects to concatenate.</param>
    /// <param name="separator">The string to use as a separator. <see cref="separator"/> is included in the returned string only if values has more than one element.</param>
    /// <returns>A <see langword="string"/> that consists of the elements of values delimited by the separator string.</returns>
    public static string JoinString<T>(this T[] source, char separator)
    {
        return string.Join(separator, source);
    }

    /// <summary>
    /// Concatenates the elements of a specified collection, using the specified separator between each element.
    /// </summary>
    /// <param name="source">A collection that contains the objects to concatenate.</param>
    /// <param name="separator">The string to use as a separator. <see cref="separator"/> is included in the returned string only if values has more than one element.</param>
    /// <returns>A <see langword="string"/> that consists of the elements of values delimited by the separator string.</returns>
    public static string JoinString(this IEnumerable<string> source, string separator)
    {
        return string.Join(separator, source);
    }

    /// <summary>
    /// Concatenates the elements of a specified collection, using the specified separator between each element.
    /// </summary>
    /// <param name="source">A collection that contains the objects to concatenate.</param>
    /// <param name="separator">The string to use as a separator. <see cref="separator"/> is included in the returned string only if values has more than one element.</param>
    /// <returns>A <see langword="string"/> that consists of the elements of values delimited by the separator string.</returns>
    public static string JoinString(this IEnumerable<string> source, char separator)
    {
        return string.Join(separator, source);
    }

    /// <summary>
    /// Concatenates the elements of a specified collection, using the specified separator between each element.
    /// </summary>
    /// <param name="source">A collection that contains the objects to concatenate.</param>
    /// <param name="separator">The string to use as a separator. <see cref="separator"/> is included in the returned string only if values has more than one element.</param>
    /// <returns>A <see langword="string"/> that consists of the elements of values delimited by the separator string.</returns>
    public static string JoinString(this string[] source, string separator)
    {
        return string.Join(separator, source);
    }

    /// <summary>
    /// Concatenates the elements of a specified collection, using the specified separator between each element.
    /// </summary>
    /// <param name="source">A collection that contains the objects to concatenate.</param>
    /// <param name="separator">The string to use as a separator. <see cref="separator"/> is included in the returned string only if values has more than one element.</param>
    /// <returns>A <see langword="string"/> that consists of the elements of values delimited by the separator string.</returns>
    public static string JoinString(this string[] source, char separator)
    {
        return string.Join(separator, source);
    }
}