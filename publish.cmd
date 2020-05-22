rem dotnet build -c Release
dotnet nuget push .\src\DotNet.Extensions.Configuration.Zookeeper\bin\Release\Extensions.Configuration.Zookeeper.*.nupkg -s https://www.nuget.org -k %1