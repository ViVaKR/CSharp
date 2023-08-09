private void 그룹_2_컨트롤추가()
{
    int _행수 = 레이아웃컨트롤그룹_2.OptionsTableLayoutGroup.RowCount - 1;
    int _열수 = 레이아웃컨트롤그룹_2.OptionsTableLayoutGroup.ColumnCount;

    LayoutControlItem _컨트롤아이템 = null;
    SimpleLabelItem _라벨 = null;
    int k = 1;
    for (int j = 1; j < _열수 - 1; j++)
    {
        if (k == 6)
        {
            k = 1;
        }
        _라벨 = new SimpleLabelItem() { Name = "라벨_" + k + "_" + j, Text = k.ToString() };

        _컨트롤아이템 = 레이아웃컨트롤그룹_2.AddItem(_라벨);
        _컨트롤아이템.TextVisible = false;
        _컨트롤아이템.OptionsTableLayoutItem.RowIndex = 1;
        _컨트롤아이템.OptionsTableLayoutItem.ColumnIndex = j;

        _라벨.AppearanceItemCaption.Font = new Font("Tahoma", 12f, FontStyle.Bold);
        _라벨.AppearanceItemCaption.ForeColor = Color.White;
        _라벨.AppearanceItemCaption.BackColor = Color.Teal;
        _라벨.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        k++;


    }

    TextEdit _글박스 = null;
    for (int i = 2; i < _행수; i++)
    {
        for (int j = 0; j < _열수; j++)
        {
            _글박스 = new TextEdit() { Name = "글_" + i + "_" + j };
            _컨트롤아이템 = 레이아웃컨트롤그룹_2.AddItem("Memo_" + i + "_" + j, _글박스);

            _컨트롤아이템.TextVisible = false;
            _컨트롤아이템.OptionsTableLayoutItem.RowIndex = i;
            _컨트롤아이템.OptionsTableLayoutItem.ColumnIndex = j;

            _글박스.Properties.Padding = new Padding(2, 2, 2, 2);
            _글박스.Font = WindowsFormsSettings.DefaultFont;
            _글박스.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }
    }
}


private void 챠트생성()
{
    int P1 = Convert.ToInt32(글_주행거리_1.Text);
    int P2 = Convert.ToInt32(글_주행거리_2.Text);
    int P3 = Convert.ToInt32(글_주행거리_3.Text);
    string[] arg = new string[] { P1.ToString(), (P1 + P2).ToString(), (P1 + P2 + P3).ToString() };

    SeriesPoint seriesPoint1 = new SeriesPoint(arg[0], Convert.ToSingle(글_평균연비_1.EditValue));
    SeriesPoint seriesPoint2 = new SeriesPoint(arg[1], Convert.ToSingle(글_평균연비_2.EditValue));
    SeriesPoint seriesPoint3 = new SeriesPoint(arg[2], Convert.ToSingle(글_평균연비_3.EditValue));
    챠트_주행연비.Series["연비"].Points.Clear();
    챠트_주행연비.Series["연비"].Points.Add(seriesPoint1);
    챠트_주행연비.Series["연비"].Points.Add(seriesPoint2);
    챠트_주행연비.Series["연비"].Points.Add(seriesPoint3);

    챠트_주행연비.ExportToImage(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Chart.png"), ImageFormat.Png);
}

private void U_Chart_Load(object sender, EventArgs e)
{
    // Create an empty chart.
    ChartControl sideBySideBarChart = new ChartControl();

    // Create the first side-by-side bar series and add points to it.
    DevExpress.XtraCharts.Series series1 = new Series("Side-by-Side Bar Series 1", ViewType.Bar);
    series1.Points.Add(new SeriesPoint("A", 10));
    series1.Points.Add(new SeriesPoint("B", 12));
    series1.Points.Add(new SeriesPoint("C", 14));
    series1.Points.Add(new SeriesPoint("D", 17));

    // Create the second side-by-side bar series and add points to it.
    DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series("Side-by-Side Bar Series 2", ViewType.Bar);
    series2.Points.Add(new SeriesPoint("A", 15));
    series2.Points.Add(new SeriesPoint("B", 18));
    series2.Points.Add(new SeriesPoint("C", 25));
    series2.Points.Add(new SeriesPoint("D", 33));

    // Add the series to the chart.
    sideBySideBarChart.Series.Add(series1);
    sideBySideBarChart.Series.Add(series2);

    // Hide the legend (if necessary).
    sideBySideBarChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

    // Rotate the diagram (if necessary).
    // ((XYDiagram)sideBySideBarChart.Diagram).Rotated = true;

    // Add a title to the chart (if necessary).
    ChartTitle chartTitle1 = new ChartTitle();
    chartTitle1.Text = "데모 챠트";
    sideBySideBarChart.Titles.Add(chartTitle1);

    // Add the chart to the form.
    sideBySideBarChart.Dock = DockStyle.Fill;
    this.Controls.Add(sideBySideBarChart);

    // SeriesLabelBase.TextOrientation.
    series1.CrosshairEmptyValueLegendText = "Hello world";
    series1.Name = "Hello";
    series2.Name = "World";
    SideBySideBarSeriesLabel label = sideBySideBarChart.Series[series1.Name].Label as SideBySideBarSeriesLabel;
    SideBySideBarSeriesLabel label2 = sideBySideBarChart.Series[series1.Name].Label as SideBySideBarSeriesLabel;
    label.Position = BarSeriesLabelPosition.Top;
    label2.Position = BarSeriesLabelPosition.Top;

    label.TextAlignment = StringAlignment.Center;
    label.BackColor = Color.Red;
    series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

}
private async void 메모컨트롤만들기()
{
    await Task.Run(() =>
    {
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
    });

}



public void Car()
{
    using (_Db = new DmsContext())
    {
        _시험차 = _Db.시험차량.FirstOrDefault(x => x.작업번호 == _작업번호);

        _Table.Cell(2, 2).Shape.TextFrame.TextRange.Text = "차종";
        _Table.Cell(2, 3).Shape.TextFrame.TextRange.Text = _시험차.차종;

        _Table.Cell(3, 2).Shape.TextFrame.TextRange.Text = "사양(호수)";
        _Table.Cell(3, 3).Shape.TextFrame.TextRange.Text = _시험차.엔진사양 + "( " + _시험차.호수 + " )";

        _Table.Cell(4, 2).Shape.TextFrame.TextRange.Text = "엔진";
        _Table.Cell(4, 3).Shape.TextFrame.TextRange.Text = _시험차.엔진.ToString();

        _Table.Cell(5, 2).Shape.TextFrame.TextRange.Text = "변속기";
        _Table.Cell(5, 3).Shape.TextFrame.TextRange.Text = _시험차.변속기.ToString();

        _Table.Cell(6, 2).Shape.TextFrame.TextRange.Text = "차량번호";
        _Table.Cell(6, 3).Shape.TextFrame.TextRange.Text = "임 " + _시험차.임시번호.ToString();
        _Table.Cell(7, 2).Shape.TextFrame.TextRange.Text = "관리번호";
        _Table.Cell(7, 3).Shape.TextFrame.TextRange.Text = _시험차.관리번호.ToString();
        _Table.Cell(8, 2).Shape.TextFrame.TextRange.Text = "시험모드";
        _Table.Cell(8, 3).Shape.TextFrame.TextRange.Text = _시험차.모드.ToString();

        _Table.Cell(9, 2).Shape.TextFrame.TextRange.Text = "실제주행거리";
        string rs = (_시험차.거리단위.ToString().Equals(거리단위.K.ToString()) ? "km" : "mile");
        int sum = _Db.주행일지.Where(x => x.임시번호 == _시험차.임시번호).Select(x => x.주행거리).Sum();
        _Table.Cell(9, 3).Shape.TextFrame.TextRange.Text = sum.ToString("#,##0") + rs;

        _Table.Cell(10, 2).Shape.TextFrame.TextRange.Text = "실제주행시간";
        double temp = (double)_Db.주행일지.Where(x => x.임시번호 == _시험차.임시번호).Select(x => x.트립운행시간).Sum();
        _Table.Cell(10, 3).Shape.TextFrame.TextRange.Text = temp.ToString("#,##0.00") + " hr";

        _Table.Cell(11, 2).Shape.TextFrame.TextRange.Text = "시험기간";
        DateTime minDate = Convert.ToDateTime(_Db.주행일지.Where(x => x.임시번호 == _시험차.임시번호).Select(x => x.날짜).Min());
        DateTime maxDate = Convert.ToDateTime(_Db.주행일지.Where(x => x.임시번호 == _시험차.임시번호).Select(x => x.날짜).Max());
        _Table.Cell(11, 3).Shape.TextFrame.TextRange.Text = "'" + minDate.ToString("%y-MM-dd") + " ~ '" + maxDate.ToString("%y-MM-dd");

        _Table.Cell(12, 2).Shape.TextFrame.TextRange.Text = "외기온";
        var minTmp = _Db.주행일지.Where(x => x.임시번호 == _시험차.임시번호).Select(x => x.외기온).Min();
        var maxTmp = _Db.주행일지.Where(x => x.임시번호 == _시험차.임시번호).Select(x => x.외기온).Max();
        온도단위 Tmp = _Db.시험차량.Where(x => x.임시번호 == _시험차.임시번호).Select(x => x.온도단위).FirstOrDefault();
        string str = (온도단위)Enum.Parse(typeof(온도단위), Tmp.ToString()) == 온도단위.C ? " ℃" : " ℉";
        _Table.Cell(12, 3).Shape.TextFrame.TextRange.Text = minTmp.ToString("#0") + str + " ~ " + maxTmp.ToString("#0.0") + str;
    }
}