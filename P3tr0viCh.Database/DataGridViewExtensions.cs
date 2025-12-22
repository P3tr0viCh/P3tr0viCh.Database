using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace P3tr0viCh.Database
{
    public static class DataGridViewExtensions
    {
        public static void SetSelectedRows(this DataGridView dataGridView, IEnumerable<BaseId> values)
        {
            dataGridView.ClearSelection();

            foreach (var value in values)
            {
                foreach (var row in from DataGridViewRow row in dataGridView.Rows
                                    where (row.DataBoundItem as BaseId).Id == value.Id
                                    select row)
                {
                    row.Selected = true;

                    dataGridView.FirstDisplayedScrollingRowIndex = row.Index;

                    break;
                }
            }
        }

        public static void SetSelectedRows(this DataGridView dataGridView, BaseId value)
        {
            dataGridView.ClearSelection();

            foreach (var row in from DataGridViewRow row in dataGridView.Rows
                                where (row.DataBoundItem as BaseId).Id == value.Id
                                select row)
            {
                row.Selected = true;

                dataGridView.FirstDisplayedScrollingRowIndex = row.Index;

                break;
            }
        }
    }
}