using P3tr0viCh.Database.Properties;
using P3tr0viCh.Utils;

namespace P3tr0viCh.Database
{
    public class ConnectionSQLite : ConnectionBase
    {
        [PropertyOrder(200)]
        [LocalizedAttribute.DisplayName("Connection.FileName.DisplayName", LocalizedAttributes.ResourceName)]
        public string FileName { get; set; }

        public override string ConnectionString =>
            string.Format(Resources.ConnectionStringSQLite, FileName);
    }
}