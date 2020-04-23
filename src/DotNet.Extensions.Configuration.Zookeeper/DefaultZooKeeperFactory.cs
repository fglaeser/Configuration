using org.apache.zookeeper;
using System.Collections.Generic;

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
    public ZooKeeper CreateZooKeeper(string connectionString, int sessionTimeout, IEnumerable<AuthData> authData, out NodeWatcher watcher)
    {
      watcher = new NodeWatcher();
      var zk = new ZooKeeper(connectionString, sessionTimeout, watcher);
      foreach(var auth in authData)
        zk.addAuthInfo(auth.Scheme, auth.Data);

      return zk;
    }
  }
}
