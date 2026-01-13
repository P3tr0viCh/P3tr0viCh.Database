using P3tr0viCh.Database.Properties;
using P3tr0viCh.Utils;
using P3tr0viCh.Utils.Attributes;
using P3tr0viCh.Utils.Extensions;
using System.ComponentModel;
using P3tr0viCh.Utils.Converters;

namespace P3tr0viCh.Database
{
    public class ConnectionMySql : ConnectionServerDatabase
    {
        public const string DefaultHost = "localhost";
        public const int DefaultPort = 3306;

        public const bool DefaultUseSsl = true;

        [PropertyOrder(300)]
        [TypeConverter(typeof(BooleanTypeOnOffConverter))]
        [LocalizedDisplayName("Connection.UseSsl.DisplayName", Const.ResourceName)]
        public bool UseSsl { get; set; }

        public ConnectionMySql()
        {
            Host = DefaultHost;
            Port = DefaultPort;

            UseSsl = DefaultUseSsl;
        }

        public override string ConnectionString =>
            string.Format(Resources.ConnectionStringMySql,
                Host.IsEmpty() ? DefaultHost : Host,
                Port == 0 ? DefaultPort : Port,
                Database,
                Login.User, Login.Password,
                UseSsl ? Resources.ConnectionStringMySqlSslPreferred : Resources.ConnectionStringMySqlSslNone);
    }
}