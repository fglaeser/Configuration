using DotNet.Extensions.Configuration.Zookeeper;
using Microsoft.Extensions.Configuration;
using System;

namespace ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {

      IConfigurationBuilder builder = new ConfigurationBuilder();
      builder.AddZookeeper(option =>
      {
        option.ConnectionString = "localhost:2181";
        option.ConnectionTimeout = 10000;
        option.RootPath = "/AccountApp";
        option.SessionTimeout = 30000;


        //option.AddAuthInfo("digest", Encoding.UTF8.GetBytes("app4:app123"));
      
      });
      var configuration = builder.Build();
      var usdRate = configuration["Rate:USD"];    //6.35
      Console.WriteLine($"usd: {usdRate}");
      var hkdRate = configuration["Rate:ARS"];    //0.87

      //var notifyMethod = configuration["AccountChangeNotificationMethod"];    //Email

      Console.ReadLine();

      usdRate = configuration["Rate:USD"];    //6.35
      Console.WriteLine($"usd: {usdRate}");

      Console.ReadLine();
    }
  }
}
