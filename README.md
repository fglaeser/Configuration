| NuGet Version  | Downloads | Build Status |
| ------------- | ------------- | ----- |
| [![NuGet Version and Downloads count](https://img.shields.io/nuget/vpre/Extensions.Configuration.Zookeeper.svg)](http://www.nuget.org/packages/Extensions.Configuration.Zookeeper/)|[![NuGet Download count](https://img.shields.io/nuget/dt/Extensions.Configuration.Zookeeper.svg)](http://www.nuget.org/packages/Extensions.Configuration.Zookeeper/)|![CI](https://github.com/fglaeser/Extensions.Configuration.Zookeeper/workflows/CI/badge.svg)|

# Introduction

Microsoft provides class libraries that use various configuration sources in the Microsoft.Extensions.Configuration series of nuget packages, including the use of Json files such as configuration sources, XML files, environment variables, command line parameters, etc. At the same time, as a best practice for configuring application usage, Microsoft.Extensions.Configuration.Abstraction defines standardized APIs, and it is very convenient to follow these API usage settings. However, the configuration sources provided by Microsoft are always limited. For example, in a distributed environment, Zookeeper is often used as the configuration source. Therefore, the purpose of this project is to provide configuration sources other than the official package, while best practices are followed for easy use. The parties can use various configuration sources through a unified interface.

# Usage
install the nuget package  
```Install-Package Extensions.Configuration.Zookeeper```

assume you have these nodes in zookeeper  
/AccountApp/Rate/USD = 6.35  
/AccountApp/Rate/HKD = 0.87  
/AccountApp/AccountChangeNotificationMethod = Email  

```C#
IConfigurationBuilder builder = new ConfigurationBuilder();
builder.AddZookeeper(option =>
{
    option.ConnectionString = "localhost:2181";
    option.ConnectionTimeout = 10000;
    option.RootPath = "/AccountApp";
    option.SessionTimeout = 3000;
});
var configuration = builder.Build();

var usdRate = configuration["Rate:USD"];    //6.35
var hkdRate = configuration["Rate:HKD"];    //0.87
var notifyMethod = configuration["AccountChangeNotificationMethod"];    //Email
```
   
You can also add authentication information like this:

```C#
IConfigurationBuilder builder = new ConfigurationBuilder();
builder.AddZookeeper(option =>
{
    option.ConnectionString = "localhost:2181";
    option.ConnectionTimeout = 10000;
    option.RootPath = "/AccountApp";
    option.SessionTimeout = 3000;
    options.AddAuthInfo("digest", Encoding.UTF8.GetBytes("app1:app123"));
});
var configuration = builder.Build();

var usdRate = configuration["Rate:USD"];    //6.35
var hkdRate = configuration["Rate:HKD"];    //0.87
var notifyMethod = configuration["AccountChangeNotificationMethod"];    //Email
```