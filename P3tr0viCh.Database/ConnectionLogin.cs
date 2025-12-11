using P3tr0viCh.Utils;
using System.ComponentModel;

namespace P3tr0viCh.Database
{
    [TypeConverter(typeof(PropertySortedConverter))]
    [LocalizedAttribute.DisplayName("Connection.DisplayName", LocalizedAttributes.ResourceName)]
    public abstract class ConnectionLogin : ConnectionBase
    {
        [PropertyOrder(300)]
        public Login Login { get; set; } = new Login();
    }
}