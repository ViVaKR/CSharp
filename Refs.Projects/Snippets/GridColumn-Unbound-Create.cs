
public void 사용자컬럼생성()
{
    // _유 => UserControl With Banded GridView
    _유.컨트롤.ForceInitialize();

    BandedGridColumn unbColumn = _유.밴드뷰.Columns.AddField("합계");
    unbColumn.OwnerBand = _유.밴드뷰.Bands[AttrStrings.정보];
    unbColumn.ColVIndex = _유.밴드뷰.Columns["목표"].ColVIndex + 1;
    unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
    unbColumn.OptionsColumn.AllowEdit = false;
    unbColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
    unbColumn.DisplayFormat.FormatString = "n0";
    unbColumn.AppearanceCell.BackColor = Color.LemonChiffon;
    unbColumn.AppearanceCell.BackColor2 = Color.Transparent;
    unbColumn.FieldName = "합계";
    unbColumn.Caption = "실적 (km)";
}
