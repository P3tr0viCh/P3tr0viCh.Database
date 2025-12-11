using Newtonsoft.Json;
using System.ComponentModel;

namespace P3tr0viCh.Database
{
    public abstract class ConnectionBase : IConnection
    {
        [JsonIgnore]
        [Browsable(false)]
        public abstract string ConnectionString { get; }
    }
}