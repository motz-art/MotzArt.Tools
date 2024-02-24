using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace MotzArt.NullChecks;

public static class NullCheckExtensions
{
    [return: NotNull]
    public static T EnsureArgumentNotNull<T>([NotNull] this T? obj, [CallerArgumentExpression("obj")] string name = "<not specified>")
    {
        return obj ?? throw new ArgumentNullException(name);
    }

    public static T EnsureArgumentNotNull<T>([NotNull] this T? obj, [CallerArgumentExpression("obj")] string name = "<not specified>") where T : struct
    {
        return obj ?? throw new ArgumentNullException(name);
    }

    [return: NotNull]
    public static T EnsureNotNull<T>([NotNull] this T? obj, [CallerArgumentExpression("obj")] string name = "<not specified>")
    {
        return obj ?? throw new NullReferenceException($"{name} should not be null.");
    }

    public static T EnsureNotNull<T>([NotNull] this T? obj, [CallerArgumentExpression("obj")] string name = "<not specified>") where T : struct
    {
        return obj ?? throw new NullReferenceException($"{name} should not be null.");
    }

    [return: NotNull]
    public static List<TItem> EnsureNotEmpty<TItem>([NotNull] this List<TItem>? list, [CallerArgumentExpression("list")] string name = "<not specified>")
    {
        if (list == null || list.Count == 0) throw new ArgumentException($"{name} should have at least one item.");
        return list;
    }

    [return: NotNull]
    public static IReadOnlyList<TItem> EnsureNotEmpty<TItem>([NotNull] this IReadOnlyList<TItem>? list, [CallerArgumentExpression("list")] string name = "<not specified>")
    {
        if (list == null || list.Count == 0) throw new ArgumentException($"{name} should have at least one item.");
        return list;
    }

    [return: NotNull]
    public static IList<TItem> EnsureNotEmpty<TItem>([NotNull] this IList<TItem>? list, [CallerArgumentExpression("list")] string name = "<not specified>")
    {
        if (list == null || list.Count == 0) throw new ArgumentException($"{name} should have at least one item.");
        return list;
    }
}