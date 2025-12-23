using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace P3tr0viCh.Database
{
    public static class DataGridViewExtensions
    {
        public static bool IsEmpty(this DataGridView dataGridView) => dataGridView.Rows.Count == 0;

        public static DataGridViewRow Find(this DataGridView dataGridView, BaseId value)
        {
            if (value == null) return null;

            if (dataGridView.IsEmpty()) return null;

            foreach (var row in from DataGridViewRow row in dataGridView.Rows
                                where (row.DataBoundItem as BaseId).Id == value.Id
                                select row)
            {
                return row;
            }

            return null;
        }

        public static IEnumerable<DataGridViewRow> Find(this DataGridView dataGridView, IEnumerable<BaseId> values)
        {
            if (dataGridView.IsEmpty()) return Enumerable.Empty<DataGridViewRow>();

            if (values?.Any() != true) return Enumerable.Empty<DataGridViewRow>();

            var result = Enumerable.Empty<DataGridViewRow>();

            foreach (var row in from value in values
                                from row in
                                    from DataGridViewRow row in dataGridView.Rows
                                    where (row.DataBoundItem as BaseId).Id == value.Id
                                    select row
                                select row)
            {
                result = result.Append(row);
            }

            return result;
        }

        public static void SelectAndScroll(this DataGridViewRow row)
        {
            row.Selected = true;

            if (!row.Displayed)
            {
                row.DataGridView.FirstDisplayedScrollingRowIndex = row.Index;
            }
        }

        public static void SetSelectedRows(this DataGridView dataGridView, IEnumerable<BaseId> values)
        {
            dataGridView.ClearSelection();

            var rows = dataGridView.Find(values);

            foreach (var row in rows)
            {
                row.Selected = true;
            }

            rows.FirstOrDefault()?.SelectAndScroll();
        }

        public static void SetSelectedRows(this DataGridView dataGridView, BaseId value)
        {
            dataGridView.ClearSelection();

            dataGridView.Find(value)?.SelectAndScroll();
        }
    }
}