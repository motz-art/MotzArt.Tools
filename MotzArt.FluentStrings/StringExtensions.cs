using System.Buffers;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace MotzArt.FluentStrings;

/// <summary>
/// Provides a set of string extensions methods.
/// </summary>
public static class StringExtensions
{
    private static readonly SearchValues<char> WhiteSpaceCharacters = SearchValues.Create(
        "\u0020\u00A0\u1680\u2000\u2001\u2002\u2003\u2004\u2005\u2006\u2007\u2008\u2009\u200A\u202F\u205F\u3000\u2028\u2029\u0009\u000A\u000B\u000C\u000D\u0085");

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
    /// Concatenates the elements of a specified <see cref="source"/> collection, using the specified <see cref="separator"/> between each element.
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
    /// Concatenates the elements of a specified <see cref="source"/> collection, using the specified <see cref="separator"/> between each element.
    /// </summary>
    /// <param name="source">A collection that contains the strings to concatenate.</param>
    /// <param name="separator">The <see cref="string"/> to use as a separator. <see cref="separator"/> is included in the returned string only if values has more than one element.</param>
    /// <returns>A <see langword="string"/> that consists of the elements of values delimited by the separator string.</returns>
    public static string JoinString(this IEnumerable<string> source, string separator)
    {
        return string.Join(separator, source);
    }

    /// <summary>
    /// Concatenates the elements of a specified <see cref="source"/> collection, using the specified <see cref="separator"/> between each element.
    /// </summary>
    /// <param name="source">A collection that contains the strings to concatenate.</param>
    /// <param name="separator">The <see cref="char"/> to use as a separator. <see cref="separator"/> is included in the returned string only if values has more than one element.</param>
    /// <returns>A <see langword="string"/> that consists of the elements of values delimited by the separator string.</returns>
    public static string JoinString(this IEnumerable<string> source, char separator)
    {
        return string.Join(separator, source);
    }

    /// <summary>
    /// Concatenates the elements of a specified <see cref="source"/> array, using the specified <see cref="separator"/> between each element.
    /// </summary>
    /// <param name="source">A collection that contains the strings to concatenate.</param>
    /// <param name="separator">The <see cref="string"/> to use as a separator. <see cref="separator"/> is included in the returned string only if values has more than one element.</param>
    /// <returns>A <see langword="string"/> that consists of the elements of values delimited by the separator string.</returns>
    public static string JoinString(this string[] source, string separator)
    {
        return string.Join(separator, source);
    }

    /// <summary>
    /// Concatenates the elements of a specified <see cref="source"/> array, using the specified <see cref="separator"/> between each element.
    /// </summary>
    /// <param name="source">A collection that contains the strings to concatenate.</param>
    /// <param name="separator">The <see cref="char"/> to use as a separator. <see cref="separator"/> is included in the returned string only if <see cref="source"/> has more than one element.</param>
    /// <returns>A <see langword="string"/> that consists of the elements of <see cref="source"/> delimited by the separator <see langword="char"/>.</returns>
    public static string JoinString(this string[] source, char separator)
    {
        return string.Join(separator, source);
    }

    /// <summary>
    /// Concatenates non-empty and non-whitespace elements of a specified collection, using the specified separator between each element.
    /// </summary>
    /// <param name="source">A collection that contains the objects to concatenate.</param>
    /// <param name="separator">The <see cref="string"/> to use as a separator. <see cref="separator"/> is included in the returned string only if values has more than one element.</param>
    /// <returns>A <see langword="string"/> that consists of the elements of values delimited by the separator string.</returns>
    public static string JoinNonEmptyStrings(this IEnumerable<string?> source, string separator)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return source.Where(HasValue)!.JoinString(separator);
    }

    /// <summary>
    /// Removes starting, trailing and duplicate white spaces.
    /// </summary>
    /// <param name="str">Input string</param>
    /// <returns></returns>
    [return: NotNullIfNotNull("str")]
    public static string? RemoveRedundantWhiteSpaces(this string? str)
    {
        if (str == null) return null;

        if (str.Length == 0) return str;

        var span = RemoveRedundantWhiteSpaces(str.AsSpan());

        if (span.Length == str.Length) return str;

        return span.ToString();
    }

    /// <summary>
    /// Removes starting, trailing and duplicate white spaces.
    /// </summary>
    /// <param name="str">Input string</param>
    /// <returns></returns>
    public static ReadOnlySpan<char> RemoveRedundantWhiteSpaces(this ReadOnlySpan<char> str)
    {
        if (str.Length == 0) return str;

        var start = str.IndexOfAnyExcept(WhiteSpaceCharacters);

        if (start == -1) return "";

        var end = str.LastIndexOfAnyExcept(WhiteSpaceCharacters) + 1;

        Debug.Assert(start < end);

        str = str.Slice(start, end - start);

        var pos = str.IndexOfAny(WhiteSpaceCharacters);

        if (pos > 0)
        {
            while (true)
            {
                var n1 = pos + 1;
                var n = str.Slice(n1).IndexOfAny(WhiteSpaceCharacters);

                if (n < 0)
                {
                    break;
                }

                if (n == 0 && !str.Slice(pos).StartsWith("\r\n"))
                {
                    return DoRemoveRedundantWhiteSpaces(str, pos);
                }

                pos = n1 + n;
            }
        }

        return str;
    }

    private static string DoRemoveRedundantWhiteSpaces(ReadOnlySpan<char> str, int pos)
    {
        var sb = new StringBuilder(str.Length - 1);

        pos++;

        sb.Append(str.Slice(0, pos));

        var prevIsWhiteSpace = true;

        foreach (var ch in str.Slice(pos))
        {
            if (char.IsWhiteSpace(ch))
            {
                if (prevIsWhiteSpace)
                {
                    if (ch == '\n')
                    {
                        if (sb[^1] == '\r')
                        {
                            sb.Append(ch);
                        }
                        else
                        {
                            sb[^1] = ch;
                        }
                    }
                    else if (ch == '\r')
                    {
                        if (sb[^1] != '\n')
                        {
                            sb[^1] = '\r';
                        }
                    }

                    continue;
                }

                prevIsWhiteSpace = true;
            }
            else
            {
                prevIsWhiteSpace = false;
            }

            sb.Append(ch);
        }

        return sb.ToString();
    }
}