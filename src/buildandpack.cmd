@echo off

set version=2.0.0

dotnet clean
dotnet build -c Release
dotnet pack -c Release --version-suffix %version% r:\nuget