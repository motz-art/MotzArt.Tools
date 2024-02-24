MotzArt FluentStrings
===

Extension methods for strings.

Features:
* Fluent methods.
* All methods are fully anotated with C# nullability attributes.

## IsNullOrEmpty

Fluent variant of `string.IsNullOrEmpty` method.

``` C#
	if (str.IsNullOrEmpty())
	{
		...
	}
```


## IsNullOrWhitespace

Fluent variant of `string.IsNullOrWhitespace` method.

``` C#
	if (str.IsNullOrWhitespace())
	{
		...
	}
```

## HasValue

Fluent variant of checking if string is not null or white-space.

``` C#
	if (str.HasValue())
	{
		...
	}
```

Same as `!string.IsNullOrWhitespace`.