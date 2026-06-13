# clone
This repository contains submodules and symlinks.
```PowerShell
git clone --recurse-submodules -c core.symlinks=true https://github.com/olegsych/fuzzy.git
```

# build
```PowerShell
dotnet build ./Fuzzy.slnx
```

# test
```PowerShell
dotnet test --project ./test/Tests.csproj
wsl -e dotnet test --project ./test/Tests.csproj
```
