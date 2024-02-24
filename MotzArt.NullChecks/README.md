MotzArt NullChecks
===

Extension methods for Fluent `null` checks.

Features:
* Fluent methods.
* All null check methods has overloads for `Nullable<T>` struct that return not nullable value.
* All methods are fully anotated with C# nullability attributes.
* All methods capture expression that is checked for `null`.

## EnsureNotNull

Use `EnsureNotNull` extension method to check any expression for `null` right inside an expression:

``` C#
	var fs = File.Open(fileName.EnsureNotNull());
```

If `fileName` is `null` a `NullReferenceExcption` will be thrown with message `"fileName should not be null."`

## EnsureArgumentNotNull

Use `EnsureArgumentNotNull` extension method to check method's arguments for null.

``` C#
	var fs = File.Open(fileName.EnsureArgumentNotNull());
```

## EnsureNotEmpty

Use `EnsureNotEmpty` to check if collection is not `null` and not empty.

``` C#
	var firstArg = args.EnsureNotEmpty()[0];
```
