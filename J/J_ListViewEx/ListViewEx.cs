using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace J_ListViewEx
{
    public class ListViewEx<T> : ListView
    {
        public IList<(string column, Func<T, object> value, Func<T, string> display)> ColumnInfo { get; set; }

        public int ColumnSort { get; set; }


        public ListViewEx(IList<(string column, Func<T, object> value, Func<T, string> display)> columnInfo) : base()
        {
            ColumnInfo = columnInfo;
            ColumnSort = 0;
        }
    }
}
