using Crisp.Extensions.Configuration.Zookeeper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
      //IConfigurationBuilder builder = new ConfigurationBuilder();
      //builder.AddZookeeper(option =>
      //{
      //    option.ConnectionString = "localhost:2181";
      //    option.ConnectionTimeout = 10000;
      //    option.RootPath = "/config";
      //    option.SessionTimeout = 3000;
      //});
      //var configuration = builder.Build();
      //ChangeToken.OnChange(
      //    () => configuration.GetReloadToken(),
      //    () =>
      //    {
      //        foreach (var item in configuration.AsEnumerable())
      //        {
      //            Console.WriteLine(item);
      //        }
      //    });
      IConfigurationBuilder builder = new ConfigurationBuilder();
      builder.AddZookeeper(option =>
      {
        option.ConnectionString = "10.0.75.2:2181";
        option.ConnectionTimeout = 10000;
        option.RootPath = "/AccountApp";
        option.SessionTimeout = 3000;
      });
      var configuration = builder.Build();
      var usdRate = configuration["Rate:USD"];    //6.35
      var hkdRate = configuration["Rate:ARS"];    //0.87
      //var notifyMethod = configuration["AccountChangeNotificationMethod"];    //Email

      Console.ReadLine();
      }
    }
}
