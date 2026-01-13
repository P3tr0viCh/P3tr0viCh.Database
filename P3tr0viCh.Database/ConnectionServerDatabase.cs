using P3tr0viCh.Database.Properties;
using P3tr0viCh.Utils;
using P3tr0viCh.Utils.Attributes;

namespace P3tr0viCh.Database
{
    public abstract class ConnectionServerDatabase : ConnectionServer
    {
        [PropertyOrder(200)]
        [LocalizedDisplayName("Connection.Database.DisplayName", Const.ResourceName)]
        public string Database { get; set; }
    }
}