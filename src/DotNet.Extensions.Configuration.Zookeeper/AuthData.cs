
namespace DotNet.Extensions.Configuration.Zookeeper
{
  internal class AuthData
  {
    internal AuthData(string scheme, byte[] data)
    {
      Scheme = scheme;
      Data = data;
    }

    internal readonly string Scheme;

    internal readonly byte[] Data;
  }
}
