using org.apache.zookeeper;
using System.Collections.Generic;

namespace DotNet.Extensions.Configuration.Zookeeper
{
  /// <summary>
  /// a zooKeeper factory used for create <see cref="ZooKeeper" /> instance.
  /// </summary>
  internal interface IZooKeeperFactory
  {
    /// <summary>
    /// create zooKeeper instance.
    /// </summary>
    /// <param name="connectionString">the zookeeper connection string</param>
    /// <param name="sessionTimeout"></param>
    /// <param name="authData">Authentication data</param>
    /// <param name="watcher"></param>
    /// <returns></returns>
    ZooKeeper CreateZooKeeper(string connectionString, int sessionTimeout, IEnumerable<AuthData> authData, out NodeWatcher watcher);
  }
}
