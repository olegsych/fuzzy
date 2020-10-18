[![Build](https://img.shields.io/appveyor/ci/olegsych/fuzzy/master)](https://ci.appveyor.com/project/olegsych/fuzzy/branch/master)
[![Tests](https://img.shields.io/appveyor/tests/olegsych/fuzzy/master)](https://ci.appveyor.com/project/olegsych/fuzzy/branch/master/tests)
[![Nuget](https://img.shields.io/nuget/v/fuzzy.svg)](https://www.nuget.org/packages/fuzzy)

# what and why

Fuzzy is a simple .NET API for fuzz testing, or more specifically, for generating fuzzy inputs in unit tests.

Why use fuzz testing? To prevent system under test from making incorrect assumptions about its inputs and
make the unit tests more robust. Using `Fuzzy` for built-in and custom types in your unit tests also helps
to make them smaller and cleaner.

# install

Add the [fuzzy](https://www.nuget.org/packages/fuzzy) package to your .NET project.
```PowerShell
dotnet add package fuzzy
```

# import

Import the `Fuzzy` namespace in your .NET source file.
```C#
using Fuzzy;
```

# use

Create an `IFuzz` instance. Fuzzy is a fluent API starting with this interface.

```C#
IFuzz fuzzy = new RandomFuzz();
```

To get a fuzzy value of a type you need, look for an `IFuzz` extension method with the name of the type.

```C#
int foo = fuzzy.Int32();
double bar = fuzzy.Double();
string baz = fuzzy.String();
Uri qux = fuzzy.Uri();
TypeCode quux = fuzzy.Enum<TypeCode>();
TimeSpan quuz = fuzzy.TimeSpan();
DateTime corge = fuzzy.DateTime();
```

For supported types, you can also specify constraints, such as the minimum or the maximum value.
```C#
int foo = fuzzy.Int32().Minimum(41);
int bar = fuzzy.Int32().Maximum(42);
int baz = fuzzy.Int32().Between(41, 43);
```

`Fuzzy` can also create collections (`Array` or `List`) with fuzzy size and fuzzy elements.
```C#
int[] foo = fuzzy.Array(fuzzy.Int32);
```

If needed, you can constrain collection size
```C#
int[] foo = fuzzy.Array(fuzzy.Int32, Length.Between(41, 43));
```

and collection elements.
```C#
int[] foo = fuzzy.Array(() => Environment.TickCount);
int[] bar = fuzzy.Array(new[] { 41, 42, 43 });
```

With collections, you can also get a fuzzy element or a fuzzy index.
```C#
IEnumerable<string> elements = new[] { "foo", "bar", "baz" };
string element = fuzzy.Element(elements);
int index = fuzzy.Index(elements);
```

# extend

Suppose you have the following type in your application.
```C#
class CustomType
{
    public int Foo;
    public string Bar;
}
```

If you create an extension method like this.
```C#
static class IFuzzExtensions
{
    public static CustomType CustomType(this IFuzz fuzzy) =>
        new CustomType {
            Foo = fuzzy.Int32(),
            Bar = fuzzy.String(),
        };
}
```

Then, you can create fuzzy values of this custom types, just like the of types already supported by `Fuzzy`.
```C#
CustomType value = fuzzy.CustomType();
```

And, if you need fuzzy values of one of the .NET framework types, consider [contributing](./CONTRIBUTING.md) it to `Fuzzy`.

# debug

Sometimes fuzzy test inputs can produce test results that are hard to understand or repeat. This is a sign that either
your tests or your system aren't handling a particular input correctly. You will need to correct this by making your
tests handle this input specifically and possibly adjust your system code. In the meantime, you can replace the `RandomFuzz`
with the `SequentialFuzz` to make fuzzy values more predictable.
```C#
IFuzz fuzzy = new SequentialFuzz();
```
