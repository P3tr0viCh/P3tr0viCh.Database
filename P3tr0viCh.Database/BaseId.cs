using Dapper.Contrib.Extensions;
using System.ComponentModel;

namespace P3tr0viCh.Database
{
    public abstract class BaseId : IBaseId
    {
        [Key]
        [DisplayName("ID")]
        public long Id { get; set; } = Sql.NewId;

        [Write(false)]
        [Computed]
        public bool IsNew => Id == Sql.NewId;

        public void Clear()
        {
            Id = Sql.NewId;
        }

        public void Assign(BaseId source)
        {
            if (source == null)
            {
                Clear();

                return;
            }

            Id = source.Id;
        }
    }
}