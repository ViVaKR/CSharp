public void CreateChart(PPT.Slide slide)
{
    slide.Layout = PPT.PpSlideLayout.ppLayoutBlank;

    var chart = slide.Shapes.AddChart(XlChartType.xlLine, 10f, 10f, 900f, 400f).Chart;

    var workbook = (EXCEL.Workbook)chart.ChartData.Workbook;
    workbook.Windows.Application.Visible = true;

    var dataSheet = (EXCEL.Worksheet)workbook.Worksheets[1];
    dataSheet.Cells.ClearContents();


    dataSheet.Cells.Range["A1"].Value2 = "Bananas";
    dataSheet.Cells.Range["A2"].Value2 = "Apples";
    dataSheet.Cells.Range["A3"].Value2 = "Pears";
    dataSheet.Cells.Range["A4"].Value2 = "Oranges";
    dataSheet.Cells.Range["B1"].Value2 = "1000";
    dataSheet.Cells.Range["B2"].Value2 = "2500";
    dataSheet.Cells.Range["B3"].Value2 = "4000";
    dataSheet.Cells.Range["B4"].Value2 = "3000";

    var sc = (PPT.SeriesCollection)chart.SeriesCollection();

    do
    {
        var seriesToDelete = sc.Item(1);
        seriesToDelete.Delete();
    }
    while (sc.Count != 0);

    var series1 = sc.NewSeries();
    series1.Name = "Pauls Series";
    series1.XValues = "'Sheet1'!$A$1:$A$2";
    series1.Values = "'Sheet1'!$B$1:$B$2";
    series1.ChartType = XlChartType.xlLine;

    var series2 = sc.NewSeries();
    series2.Name = "Seans Series";
    series2.XValues = "'Sheet1'!$A$1:$A$2";
    series2.Values = "'Sheet1'!$B$3:$B$4";
    series2.ChartType = XlChartType.xlLine;

    chart.HasTitle = true;
    chart.ChartTitle.Font.Italic = true;
    chart.ChartTitle.Text = "My First Chart!";
    chart.ChartTitle.Font.Size = 12;
    chart.ChartTitle.Font.Color = Color.Black.ToArgb();
    chart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
    chart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

    chart.HasLegend = true;
    chart.Legend.Font.Italic = true;
    chart.Legend.Font.Size = 10;

    chart.Refresh();


    cell.NumberFormat = "m/d/yy h:mm;@";
    Axis xAxis = (Excel.Axis)chart.Axes(Excel.XlAxisType.xlCategory);
    TickLabels ticks = xAxis.TickLabels;
    xAxis.MinimumScale = timeSeriesRange.Value2[1, 1];
    xAxis.MaximumScale = timeSeriesRange.Value2[timeSeriesRange.Count, 1];
    xAxis.MajorTickMark = XlTickMark.xlTickMarkCross;
    xAxis.MinorTickMark = XlTickMark.xlTickMarkInside;
    xAxis.MajorUnit = 0.005;
    xAxis.HasMinorGridlines = true;
    xAxis.HasMajorGridlines = true;
    ticks.Orientation = XlTickLabelOrientation.xlTickLabelOrientationUpward;
    chart.PlotArea.Select();
    chart.PlotArea.Height = 300;


    chart.ChartWizard(Type.Missing,
       Microsoft.Office.Interop.Excel.XlChartType.xlXYScatterLines,
       Type.Missing,
       XlRowCol.xlColumns,
       Type.Missing,
       Type.Missing,
       true,
       "Trend",
       "Time stamp",
       Type.Missing,
       Type.Missing);

    Microsoft.Office.Tools.Excel.Chart chart = worksheet.Controls.AddChart(0, 0, xx, yy, "Trend");
    chart.ChartWizard(Type.Missing,
   Microsoft.Office.Interop.Excel.XlChartType.xlXYScatterLines,
   Type.Missing,
   XlRowCol.xlColumns,
   Type.Missing,
   Type.Missing,
   true,
   "Trend",
   "Time stamp",
   Type.Missing,
   Type.Missing);
    chart.AutoScaling = false;
    chart.ChartStyle = 34
            chart.Legend.Position = XlLegendPosition.xlLegendPositionBottom;
    chart.HasTitle = true;
    chart.ChartType = XlChartType.xlXYScatterLines;
    chart.ChartTitle.Text = ""Trend";


foreach (series)
    {
        Excel.Series xlSeries = (Excel.Series)((Excel.SeriesCollection)chart.SeriesCollection()).NewSeries();
        Microsoft.Office.Interop.Excel.Range seriesRange = worksheet.get_Range(series.seriesBeginRange,
                                                            worksheet.get_Range(series.seriesBeginRange).get_End(XlDirection.xlDown));
        xlSeries.Name = series.seriesName;
        xlSeries.XValues = timeSeriesRange; //This has datetime
        xlSeries.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlXYScatterLines;
        xlSeries.Values = seriesRange;
    }

    cell.NumberFormat = "MM/dd/yy HH:mm";
    cell.Value = ts;

    //범위 = 워크시트.UsedRange.Columns[1, Type.Missing];
    //범위.Select();
    //계열.XValues = 범위;

    //범위 = 워크시트.UsedRange.Columns[2, Type.Missing];
    //범위.Select();
    //계열.Values = 범위;

}
