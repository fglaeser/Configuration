using org.apache.zookeeper;
using System.Collections.Generic;
using System.Linq;

namespace DotNet.Extensions.Configuration.Zookeeper
{
  /// <summary>
  /// the default zooKeeper factory.
  /// </summary>
  internal class DefaultZooKeeperFactory : IZooKeeperFactory
  {
    /// <summary>
    /// create zooKeeper instance.
    /// </summary>
    public ZooKeeper CreateZooKeeper(string connectionString, int sessionTimeout, IEnumerable<AuthData> authData,
        out NodeWatcher watcher)
    {
      watcher = new NodeWatcher();
      var zk = new ZooKeeper(connectionString, sessionTimeout, watcher);

      if (authData != null && authData.Any())
      {
        foreach (var auth in authData)
          if (auth != null)
            zk.addAuthInfo(auth.Scheme, auth.Data);
      }

      return zk;
    }
  }
}
