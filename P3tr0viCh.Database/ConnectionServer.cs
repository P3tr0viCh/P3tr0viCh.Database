using P3tr0viCh.Utils;

namespace P3tr0viCh.Database
{
    public abstract class ConnectionServer : ConnectionLogin
    {
        [PropertyOrder(100)]
        [LocalizedAttribute.DisplayName("Connection.Host.DisplayName", LocalizedAttributes.ResourceName)]
        public string Host { get; set; }

        [PropertyOrder(101)]
        [LocalizedAttribute.DisplayName("Connection.Port.DisplayName", LocalizedAttributes.ResourceName)]
        public int Port { get; set; } = 0;
    }
}