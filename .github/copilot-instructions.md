# Copilot Instructions for fuzzy

## Project Overview

See [README.md](../README.md) for project description and usage examples.

The public NuGet package is `fuzzy` (targeting `netstandard2.0`). The primary entry point is the `IFuzz` interface.

## Repository Structure

```
/
├── src/                  # Library source (Fuzzy.csproj, netstandard2.0)
│   ├── IFuzz.cs          # Core interface: int Next(); T Build<T>(Fuzzy<T> spec);
│   ├── IFuzzExtensions.cs # Public extension methods on IFuzz (Boolean, Byte, Int32, String, Uri, etc.)
│   ├── IFuzzArrayExtensions.cs
│   ├── IFuzzListExtensions.cs
│   ├── IFuzzDictionaryExtensions.cs
│   ├── IComparableExtensions.cs  # Fluent constraint API: .Minimum(), .Maximum(), .Between()
│   ├── StringExtensions.cs       # .LettersOrDigits() constraint
│   ├── RandomFuzz.cs      # IFuzz implementation using System.Random
│   ├── SequentialFuzz.cs  # IFuzz implementation using sequential integers (for debugging)
│   ├── Length.cs          # Size<Length> — constrains string/collection length
│   ├── Count.cs           # Size<Count> — constrains collection count
│   ├── Size.cs            # Abstract base for Length/Count with Between/Exactly/Min/Max factory methods
│   └── Implementation/   # Internal fuzzy spec types (sealed, not part of public API)
│       ├── Fuzzy.cs       # Abstract Fuzzy<T>: holds IFuzz, implicit T conversion, calls Build()
│       ├── Fuzz.cs        # Abstract Fuzz: implements IFuzz.Build<T>, calls FuzzyContext.Set
│       ├── FuzzyContext.cs # ThreadLocal storage enabling fluent constraint chaining
│       ├── FuzzyRange.cs  # Abstract FuzzyRange<T>: base for all numeric fuzzy types
│       └── Fuzzy*.cs      # Concrete specs: FuzzyInt32, FuzzyString, FuzzyBoolean, FuzzyUri, etc.
├── test/                 # xUnit test project (Tests.csproj, net5.0)
│   ├── TestFixture.cs    # Abstract base: shared IFuzz mock + ArrangeBuildOfFuzzy* helpers
│   ├── TestEnum.cs / TestStruct.cs
│   ├── Implementation/   # Tests for internal types
│   └── *Test.cs          # Tests named exactly after the class under test + "Test"
├── examples/             # Example xUnit tests (Examples.csproj, net5.0) showing the public API
│   └── *Example.cs       # One example file per supported type
├── modules/csharp.common # Git submodule (shared C# conventions)
├── Fuzzy.sln             # Solution file
├── appveyor.yml          # CI: build + test + pack on AppVeyor
└── build.ps1 / test.ps1  # PowerShell convenience scripts
```

## Key Architecture Concepts

### IFuzz / Fuzzy<T> / FuzzyContext

- `IFuzz` exposes `int Next()` (the source of entropy) and `T Build<T>(Fuzzy<T> spec)`.
- Every fuzzy type (e.g., `FuzzyInt32`) extends `Fuzzy<T>`, which uses `implicit operator T` to auto-convert — this is how `int value = fuzzy.Int32()` works.
- `FuzzyContext` uses `ThreadLocal` storage to connect a just-built fuzzy value back to its spec, enabling fluent constraint chaining like `fuzzy.Int32().Minimum(1).Maximum(10)`.

### Adding a New Fuzzy Type

To add support for a new type `Foo`:

1. **Create `src/Implementation/FuzzyFoo.cs`** — extend `Fuzzy<Foo>` (or `FuzzyRange<Foo>` for numeric types). Implement `protected internal override Foo Build()`. Class should be `sealed`.
2. **Add extension method in `src/IFuzzExtensions.cs`** — `public static Foo Foo(this IFuzz fuzzy) => new FuzzyFoo(fuzzy);`
3. **Create `test/Implementation/FuzzyFooTest.cs`** — extend `TestFixture`. Use xUnit `[Fact]` / `[Theory]`. Use `NSubstitute` to mock `IFuzz`. Use `Inspector` library for field/property/constructor inspection in tests.
4. **Create `examples/FooExample.cs`** — demonstrate usage with `RandomFuzz` and xUnit `[Fact]`.

### Fluent Constraints

For numeric `FuzzyRange<T>` types, `IComparableExtensions` provides `.Minimum()`, `.Maximum()`, `.Between()` — these retrieve the spec from `FuzzyContext` and mutate it. Any new `FuzzyRange<T>` subtype gets these automatically.

For non-range types, add type-specific extension methods in a `*Extensions.cs` file in `src/` (see `StringExtensions.cs` as an example).

## Build & Test

See [CONTRIBUTING.md](../CONTRIBUTING.md) for clone, build, and test instructions.

**Pack (Release):**
```powershell
dotnet pack .\src\Fuzzy.csproj --configuration Release --include-symbols
```

## Testing Conventions

- Test classes live in the `Fuzzy` namespace (same as source), in `test/`.
- Each test class is named `<ClassUnderTest>Test` and inherits `TestFixture`.
- Nested classes group tests by method/scenario (e.g., `public class Constructor: FooTest { ... }`).
- `IFuzz` is always mocked with `NSubstitute`: `Substitute.For<IFuzz>()` (provided by `TestFixture`).
- Use `ArrangeBuildOfFuzzyInt32()` (and similar helpers on `TestFixture`) to configure the mock to return values from `FuzzyRange<T>` specs.
- Use the `Inspector` NuGet library to access private/internal fields, constructors, and parameters by type in assertions.
- Tests are `[Fact]` or `[Theory]` + `[InlineData(...)]`.
- The test project enables `<CheckForOverflowUnderflow>true</CheckForOverflowUnderflow>`.

## Code Style

- C# with 4-space indentation (inferred from existing code).
- `namespace Fuzzy` for public API; `namespace Fuzzy.Implementation` for internal types.
- Internal implementation types use `sealed class`.
- Extension methods are in `public static class` named after the type they extend (e.g., `IFuzzExtensions`, `StringExtensions`).
- No XML doc comments on most members; `FuzzyContext` is an exception.
- Minimal use of `var`; explicit types are preferred.

## CI / Deployment

See [CONTRIBUTING.md](../CONTRIBUTING.md) for CI and release information. Note: no GitHub Actions workflows are present; CI runs exclusively on AppVeyor.

## Known Gotchas

- The repo uses **git submodules** (`modules/csharp.common`) and **symlinks** (`.gitattributes`). Always clone with `--recurse-submodules -c core.symlinks=true`. If the submodule is empty, run `git submodule update --init`.
- `FuzzyContext` is thread-local and stateful — the fluent constraint API only works immediately after generating a fuzzy value. Don't cache fuzzy values before calling constraint methods.
- `RandomFuzz` takes an optional `seed` parameter (default `0`) — useful for reproducible sequences in tests.
- `SequentialFuzz` generates `1, 2, 3, ...` (starts at seed+1) — useful for debugging non-deterministic test failures.
