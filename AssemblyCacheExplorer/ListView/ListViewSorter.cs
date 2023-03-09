using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AssemblyCacheExplorer.ListView
{
    public class ListViewSorter : System.Collections.IComparer
    {
        int _column = 0;
        int _lastSortColumn = 0;

        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }

        public int LastSortColumn
        {
            get { return _lastSortColumn; }
            set { _lastSortColumn = value; }
        }
        
        public int Compare(object o1, object o2)
        {
            if (!(o1 is ListViewItem)) return (0);
            if (!(o2 is ListViewItem)) return (0);

            ListViewItem lvi1 = (ListViewItem)o2;
            string str1 = lvi1.SubItems[Column].Text;
            ListViewItem lvi2 = (ListViewItem)o1;
            string str2 = lvi2.SubItems[Column].Text;

            int result;

            DateTime dt1;
            DateTime dt2;
            if (DateTime.TryParse(str1, out dt1) && DateTime.TryParse(str2, out dt2))
            {
                if (lvi1.ListView.Sorting == SortOrder.Ascending)
                    result = DateTime.Compare(dt1, dt2);
                else
                    result = DateTime.Compare(dt2, dt1);
            }
            else
            {
                if (lvi1.ListView.Sorting == SortOrder.Ascending)
                    result = String.Compare(str1, str2);
                else
                    result = String.Compare(str2, str1);
            }
            LastSortColumn = Column;

            return (result);
        }
    }   
}
