using P3tr0viCh.Utils;

namespace P3tr0viCh.Database
{
    public abstract class BaseText : BaseId, IBaseText
    {
        public string Text { get; set; }

        public override void Clear()
        {
            base.Clear();

            Text = string.Empty;
        }

        public void Assign(BaseText source)
        {
            if (source == null)
            {
                Clear();

                return;
            }

            base.Assign(source);
            
            Text = source.Text; 
        }
    }
}