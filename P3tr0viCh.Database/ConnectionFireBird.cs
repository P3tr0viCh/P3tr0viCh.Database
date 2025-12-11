using P3tr0viCh.Database.Properties;
using P3tr0viCh.Utils;

namespace P3tr0viCh.Database
{
    public class ConnectionFireBird : ConnectionServerDatabase
    {
        public const string DefaultUser = "SYSDBA";
        public const string DefaultPassword = "masterkey";

        public const string DefaultHost = "localhost";
        public const int DefaultPort = 3050;

        public ConnectionFireBird()
        {
            Login.User = DefaultUser;
            Login.Password = DefaultPassword;

            Host = DefaultHost;
            Port = DefaultPort;
        }

        public override string ConnectionString =>
            string.Format(Resources.ConnectionFireBird,
                Host.IsEmpty() ? DefaultHost : Host,
                Port == 0 ? DefaultPort : Port,
                Database,
                Login.User, Login.Password);
    }
}