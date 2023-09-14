// PrintLayout - Section.Margins
// Simple - SimpleView.Padding
// Draft - DraftView.Padding

_img.wr.TextWrapping = TextWrappingType.BehindText;


foreach (Section item in _문서_문제내용.Sections)
{
    item.Margins.Left = _마진;
    item.Margins.Right = _마진;
    item.Margins.Top = _마진;
    item.Margins.Bottom = _마진;
}

DocumentPosition pos = _문서_문제내용.Range.End;
Table tbl = _문서_문제내용.Tables.Create(pos, 3, 3, AutoFitBehaviorType.AutoFitToWindow);

_문서_문제내용.BeginUpdate();

tbl.TableLayout = TableLayoutType.Fixed;
tbl.PreferredWidthType = WidthType.Fixed;
tbl.PreferredWidth = _section.Page.Width - _section.Margins.Left - _section.Margins.Right;
tbl.TableAlignment = TableRowAlignment.Center;

for (int i = 0; i < tbl.FirstRow.Cells.Count; i++)
{
    for (int j = 0; j < tbl.Rows.Count; j++)
    {
        tbl.Rows[j].Cells[0].PreferredWidth = 150;
        tbl.Rows[j].Cells[0].PreferredWidthType = WidthType.Fixed;

        tbl.Rows[j].Cells[1].PreferredWidth = tbl.PreferredWidth - 300;
        tbl.Rows[j].Cells[1].PreferredWidthType = WidthType.Fixed;

        tbl.Rows[j].Cells[2].PreferredWidth = 150;
        tbl.Rows[j].Cells[2].PreferredWidthType = WidthType.Fixed;
    }
}
