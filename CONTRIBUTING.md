# clone
This repository contains submodules and symlinks.
```PowerShell
git clone --recurse-submodules -c core.symlinks=true https://github.com/olegsych/fuzzy.git
```

# build
```PowerShell
dotnet build .\Fuzzy.sln
```

# test
```PowerShell
dotnet test .\test\Tests.csproj
```
