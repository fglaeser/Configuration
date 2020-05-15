
using System.Text;

namespace DotNet.Extensions.Configuration.Zookeeper
{
    public class AuthData
    {
        public AuthData(string scheme, byte[] data)
        {
            Scheme = scheme;
            Data = data;
        }

        public AuthData(string scheme, string data)
        {
            Scheme = scheme;
            Data = Encoding.ASCII.GetBytes(data);
        }


        internal readonly string Scheme;

        internal readonly byte[] Data;
    }
}
