private void 밴드뷰_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
{
    try
    {
        BandedGridView view = sender as BandedGridView;
        string value = view.GetListSourceRowCellValue(e.ListSourceRowIndex, view.Columns["날짜"])?.ToString() ?? string.Empty;

        if (value == string.Empty)
        {
            return;
        }

        bool tf = DateTime.TryParse(value, out DateTime dt);
        if (tf)
        {
            if (e.Column.Caption != "요일")
            {
                return;
            }

            e.Value = dt.GetWeekDay();
        }
    }
    catch
    {
        //
    }
}

