@echo off

set version=2.2.0

dotnet clean -c Release
dotnet build -c Release
dotnet pack -c Release --no-build --version-suffix %version% -o r:\nuget