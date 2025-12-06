using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace MotzArt.NullChecks;

/// <summary>
/// Provides extension methods for performing null and emptiness checks on objects and collections, throwing appropriate
/// exceptions when validation fails.
/// </summary>
/// <remarks>
/// <para>These methods help enforce argument validation in APIs by throwing exceptions such as
/// <see cref="ArgumentNullException"/>, <see cref="NullReferenceException"/>, or <see cref="ArgumentException"/> when
/// inputs are null or empty. All methods are static and designed for use as extension methods on reference types,
/// nullable value types, and common collection interfaces.
/// </para>
/// <para>
/// The methods do not perform deep validation beyond null or emptiness checks and are not thread-safe for concurrent
/// modifications of collections.
/// </para>
/// </remarks>
public static class NullCheckExtensions
{
    /// <summary>
    /// Checks if <paramref name="target"/> is not null otherwise throws <see cref="ArgumentNullException"/>.
    /// </summary>
    /// <typeparam name="T">Any reference type.</typeparam>
    /// <param name="target">Object to check.</param>
    /// <param name="name">Name of the object to include as paramName in <see cref="ArgumentNullException"/>.</param>
    /// <returns><paramref name="target"/> value.</returns>
    /// <exception cref="ArgumentNullException">Throws if target is null. paramName is set to <paramref name="name"/>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NotNull]
    public static T EnsureArgumentNotNull<T>([NotNull] this T? target, [CallerArgumentExpression(nameof(target))] string name = "<not specified>")
    {
        ArgumentNullException.ThrowIfNull(target, name);

        return target;
    }

    /// <summary>
    /// Checks if <paramref name="value"/> has value (is not null) otherwise throws <see cref="ArgumentNullException"/>.
    /// </summary>
    /// <typeparam name="T">Any <see cref="Nullable"/> struct.</typeparam>
    /// <param name="value">Value to check.</param>
    /// <param name="name">Name of the value to include as paramName in <see cref="ArgumentNullException"/></param>
    /// <returns>Not nullable <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static T EnsureArgumentNotNull<T>([NotNull] this T? value, [CallerArgumentExpression(nameof(value))] string name = "<not specified>") where T : struct
    {
        return value ?? throw new ArgumentNullException(name);
    }

    /// <summary>
    /// Checks if <paramref name="target"/> is not null otherwise throws <see cref="NullReferenceException"/>.
    /// </summary>
    /// <typeparam name="T">Any reference type.</typeparam>
    /// <param name="target">Object to check.</param>
    /// <param name="name">Name of the object to include in <see cref="NullReferenceException"/> message.</param>
    /// <returns><paramref name="target"/> value.</returns>
    /// <exception cref="NullReferenceException">Throws if target is null.</exception>
    [return: NotNull]
    public static T EnsureNotNull<T>([NotNull] this T? target, [CallerArgumentExpression(nameof(target))] string name = "<not specified>")
    {
        return target ?? throw new NullReferenceException($"{name} should not be null.");
    }

    /// <summary>
    /// Checks if <paramref name="value"/> has value (is not null) otherwise throws <see cref="NullReferenceException"/>.
    /// </summary>
    /// <typeparam name="T">Any <see cref="Nullable"/> struct.</typeparam>
    /// <param name="value">Value to check.</param>
    /// <param name="name">Name of the value to include as paramName in <see cref="NullReferenceException"/></param>
    /// <returns>Not nullable <paramref name="value"/>.</returns>
    /// <exception cref="NullReferenceException">Throws if target is null.</exception>
    public static T EnsureNotNull<T>([NotNull] this T? value, [CallerArgumentExpression(nameof(value))] string name = "<not specified>") where T : struct
    {
        return value ?? throw new NullReferenceException($"{name} should not be null.");
    }

    /// <summary>
    /// Checks if <paramref name="list"/> has any items. Otherwise, throws <see cref="ArgumentException"/>.
    /// </summary>
    /// <typeparam name="TItem">List items type</typeparam>
    /// <param name="list">List to check.</param>
    /// <param name="name">Name of the list. If not sett will be set to expression passed into <paramref name="list"/> argument.</param>
    /// <returns>The <paramref name="list"/> that was passed in.</returns>
    /// <exception cref="ArgumentException">Throws if list is <see langword="null"/> or empty.</exception>
    public static List<TItem> EnsureNotEmpty<TItem>([NotNull] this List<TItem>? list, [CallerArgumentExpression(nameof(list))] string name = "<not specified>")
    {
        if (list == null || list.Count == 0) throw new ArgumentException($"{name} should have at least one item.");
        return list;
    }

    /// <summary>
    /// Checks if <paramref name="list"/> has any items. Otherwise, throws <see cref="ArgumentException"/>.
    /// </summary>
    /// <typeparam name="TItem">List items type</typeparam>
    /// <param name="list">List to check.</param>
    /// <param name="name">Name of the list. If not sett will be set to expression passed into <paramref name="list"/> argument.</param>
    /// <returns>The <paramref name="list"/> that was passed in.</returns>
    /// <exception cref="ArgumentException">Throws if list is <see langword="null"/> or empty.</exception>
    public static IReadOnlyList<TItem> EnsureNotEmpty<TItem>([NotNull] this IReadOnlyList<TItem>? list, [CallerArgumentExpression(nameof(list))] string name = "<not specified>")
    {
        if (list == null || list.Count == 0) throw new ArgumentException($"{name} should have at least one item.");
        return list;
    }


    /// <summary>
    /// Checks if <paramref name="list"/> has any items. Otherwise, throws <see cref="ArgumentException"/>.
    /// </summary>
    /// <typeparam name="TItem">List items type</typeparam>
    /// <param name="list">List to check.</param>
    /// <param name="name">Name of the list. If not sett will be set to expression passed into <paramref name="list"/> argument.</param>
    /// <returns>The <paramref name="list"/> that was passed in.</returns>
    /// <exception cref="ArgumentException">Throws if list is <see langword="null"/> or empty.</exception>
    public static IList<TItem> EnsureNotEmpty<TItem>([NotNull] this IList<TItem>? list, [CallerArgumentExpression(nameof(list))] string name = "<not specified>")
    {
        if (list == null || list.Count == 0) throw new ArgumentException($"{name} should have at least one item.");
        return list;
    }
}