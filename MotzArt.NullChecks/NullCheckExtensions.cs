using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace MotzArt.NullChecks;

public static class NullCheckExtensions
{
    /// <summary>
    /// Checks if <see cref="target"/> is not null otherwise throws <see cref="ArgumentNullException"/>.
    /// </summary>
    /// <typeparam name="T">Any reference type.</typeparam>
    /// <param name="target">Object to check.</param>
    /// <param name="name">Name of the object to include as paramName in <see cref="ArgumentNullException"/>.</param>
    /// <returns><see cref="target"/> value.</returns>
    /// <exception cref="ArgumentNullException">Throws if target is null. paramName is set to <see cref="name"/>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NotNull]
    public static T EnsureArgumentNotNull<T>([NotNull] this T? target, [CallerArgumentExpression(nameof(target))] string name = "<not specified>")
    {
        return target ?? throw new ArgumentNullException(name);
    }

    /// <summary>
    /// Checks if <see cref="value"/> has value (is not null) otherwise throws <see cref="ArgumentNullException"/>.
    /// </summary>
    /// <typeparam name="T">Any <see cref="Nullable"/> struct.</typeparam>
    /// <param name="value">Value to check.</param>
    /// <param name="name">Name of the value to include as paramName in <see cref="ArgumentNullException"/></param>
    /// <returns>Not nullable <see cref="value"/>.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static T EnsureArgumentNotNull<T>([NotNull] this T? value, [CallerArgumentExpression(nameof(value))] string name = "<not specified>") where T : struct
    {
        return value ?? throw new ArgumentNullException(name);
    }

    /// <summary>
    /// Checks if <see cref="target"/> is not null otherwise throws <see cref="ArgumentNullException"/>.
    /// </summary>
    /// <typeparam name="T">Any reference type.</typeparam>
    /// <param name="target">Object to check.</param>
    /// <param name="name">Name of the object to include as paramName in <see cref="ArgumentNullException"/>.</param>
    /// <returns><see cref="target"/> value.</returns>
    /// <exception cref="NullReferenceException">Throws if target is null.</exception>
    [return: NotNull]
    public static T EnsureNotNull<T>([NotNull] this T? target, [CallerArgumentExpression(nameof(target))] string name = "<not specified>")
    {
        return target ?? throw new NullReferenceException($"{name} should not be null.");
    }

    /// <summary>
    /// Checks if <see cref="value"/> has value (is not null) otherwise throws <see cref="NullReferenceException"/>.
    /// </summary>
    /// <typeparam name="T">Any <see cref="Nullable"/> struct.</typeparam>
    /// <param name="value">Value to check.</param>
    /// <param name="name">Name of the value to include as paramName in <see cref="NullReferenceException"/></param>
    /// <returns>Not nullable <see cref="value"/>.</returns>
    /// <exception cref="NullReferenceException">Throws if target is null.</exception>
    public static T EnsureNotNull<T>([NotNull] this T? value, [CallerArgumentExpression(nameof(value))] string name = "<not specified>") where T : struct
    {
        return value ?? throw new NullReferenceException($"{name} should not be null.");
    }

    /// <summary>
    /// Checks if <see cref="list"/> has any items. Otherwise, throws <see cref="ArgumentException"/>.
    /// </summary>
    /// <typeparam name="TItem">List items type</typeparam>
    /// <param name="list">List to check.</param>
    /// <param name="name">Name of the list. If not sett will be set to expression passed into <see cref="list"/> argument.</param>
    /// <returns>The <see cref="list"/> that was passed in.</returns>
    /// <exception cref="ArgumentException">Throws if list is <see langword="null"/> or empty.</exception>
    [return: NotNull]
    public static List<TItem> EnsureNotEmpty<TItem>([NotNull] this List<TItem>? list, [CallerArgumentExpression(nameof(list))] string name = "<not specified>")
    {
        if (list == null || list.Count == 0) throw new ArgumentException($"{name} should have at least one item.");
        return list;
    }

    /// <summary>
    /// Checks if <see cref="list"/> has any items. Otherwise, throws <see cref="ArgumentException"/>.
    /// </summary>
    /// <typeparam name="TItem">List items type</typeparam>
    /// <param name="list">List to check.</param>
    /// <param name="name">Name of the list. If not sett will be set to expression passed into <see cref="list"/> argument.</param>
    /// <returns>The <see cref="list"/> that was passed in.</returns>
    /// <exception cref="ArgumentException">Throws if list is <see langword="null"/> or empty.</exception>
    [return: NotNull]
    public static IReadOnlyList<TItem> EnsureNotEmpty<TItem>([NotNull] this IReadOnlyList<TItem>? list, [CallerArgumentExpression(nameof(list))] string name = "<not specified>")
    {
        if (list == null || list.Count == 0) throw new ArgumentException($"{name} should have at least one item.");
        return list;
    }


    /// <summary>
    /// Checks if <see cref="list"/> has any items. Otherwise, throws <see cref="ArgumentException"/>.
    /// </summary>
    /// <typeparam name="TItem">List items type</typeparam>
    /// <param name="list">List to check.</param>
    /// <param name="name">Name of the list. If not sett will be set to expression passed into <see cref="list"/> argument.</param>
    /// <returns>The <see cref="list"/> that was passed in.</returns>
    /// <exception cref="ArgumentException">Throws if list is <see langword="null"/> or empty.</exception>
    [return: NotNull]
    public static IList<TItem> EnsureNotEmpty<TItem>([NotNull] this IList<TItem>? list, [CallerArgumentExpression(nameof(list))] string name = "<not specified>")
    {
        if (list == null || list.Count == 0) throw new ArgumentException($"{name} should have at least one item.");
        return list;
    }
}