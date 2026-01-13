using P3tr0viCh.Database.Properties;
using P3tr0viCh.Utils;
using P3tr0viCh.Utils.Attributes;
using System.ComponentModel;

namespace P3tr0viCh.Database
{
    [TypeConverter(typeof(PropertySortedConverter))]
    [LocalizedDisplayName("Connection.DisplayName", Const.ResourceName)]
    public abstract class ConnectionLogin : ConnectionBase
    {
        [PropertyOrder(300)]
        public Login Login { get; set; } = new Login();
    }
}