# Clone

- _Include submodules and symlinks_.
```PowerShell
git clone --recurse-submodules -c core.symlinks=true https://github.com/olegsych/fuzzy.git
```

If you already cloned without `--recurse-submodules`, initialize them manually:
```PowerShell
git submodule update --init --recursive
```

The build depends on symlinked files from the `modules/csharp.common` submodule. Without it the build will fail.

# Build

_Build the `Release` configuration for full build-time validation_.
```PowerShell
dotnet build -c Release
```

# Test

- _Run tests in the default `Debug` configuration on all frameworks and platforms_.
  Tests may require `#if DEBUG` hooks and fail with `-c Release`.
  ```PowerShell
  dotnet test
  wsl -e dotnet test
  ```

- _Troubleshoot specific projects, target frameworks, tests, including explicit tests_
  ```PowerShell
  dotnet run --project ./examples/Examples.csproj -f net10.0 -- -reporter verbose -namespace * -class * -method * -explicit on
  ```

# Pack

```PowerShell
dotnet pack
```

This builds the `Release` configuration by default and creates NuGet packages in the `out/packages/` directory.
