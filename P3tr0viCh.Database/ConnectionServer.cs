using P3tr0viCh.Database.Properties;
using P3tr0viCh.Utils;
using P3tr0viCh.Utils.Attributes;

namespace P3tr0viCh.Database
{
    public abstract class ConnectionServer : ConnectionLogin
    {
        [PropertyOrder(100)]
        [LocalizedDisplayName("Connection.Host.DisplayName", Const.ResourceName)]
        public string Host { get; set; }

        [PropertyOrder(101)]
        [LocalizedDisplayName("Connection.Port.DisplayName", Const.ResourceName)]
        public int Port { get; set; } = 0;
    }
}