using P3tr0viCh.Utils;

namespace P3tr0viCh.Database
{
    public abstract class ConnectionServerDatabase : ConnectionServer
    {
        [PropertyOrder(200)]
        [LocalizedAttribute.DisplayName("Connection.Database.DisplayName", LocalizedAttributes.ResourceName)]
        public string Database { get; set; }
    }
}