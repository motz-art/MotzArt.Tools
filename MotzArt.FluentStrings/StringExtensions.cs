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

}