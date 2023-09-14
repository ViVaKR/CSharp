
if (this.InvokeRequired)
{
    this.Invoke(new MethodInvoker(() =>
    {
        int _행수 = layoutControlGroup1.OptionsTableLayoutGroup.RowCount - 1;
        int _열수 = layoutControlGroup1.OptionsTableLayoutGroup.ColumnCount - 1;
        LayoutControlItem 메모 = null;
        for (int i = 4; i < _행수; i++)
        {
            for (int j = 2; j < _열수; j++)
            {
                메모 = layoutControlGroup1.AddItem("Memo_" + i + "_" + j, new MemoEdit() { Name = "Memo_" + i + "_" + j });

                메모.TextVisible = false;
                메모.OptionsTableLayoutItem.RowIndex = i;
                메모.OptionsTableLayoutItem.ColumnIndex = j;

            };
        }
    }));
}
