using P3tr0viCh.Database.Properties;
using P3tr0viCh.Utils;
using P3tr0viCh.Utils.Attributes;

namespace P3tr0viCh.Database
{
    public class ConnectionSQLite : ConnectionBase
    {
        [PropertyOrder(200)]
        [LocalizedDisplayName("Connection.FileName.DisplayName", Const.ResourceName)]
        public string FileName { get; set; }

        public override string ConnectionString =>
            string.Format(Resources.ConnectionStringSQLite, FileName);
    }
}