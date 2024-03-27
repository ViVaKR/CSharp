gridView1.SortInfo.ClearAndAddRange(new[] {
    new GridColumnSortInfo(colOrderDate, DevExpress.Data.ColumnSortOrder.Ascending),
    new GridColumnSortInfo(colCustomerID, DevExpress.Data.ColumnSortOrder.Descending)
});

//or

colOrderDate.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
colCustomerID.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;