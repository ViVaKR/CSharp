{
    Xaxis = Chart.Axes(Ppt.XlAxisType.xlCategory);
    Yaxis = Chart.Axes(Ppt.XlAxisType.xlValue);

    Xaxis.CategoryNames = dataTable.Columns.Cast<DT.DataColumn>().Select(x => x.ColumnName).Skip(1).Take(4).ToArray();

    Yaxis.HasTitle = true;
    Yaxis.AxisTitle.Text = "비용";
    Xaxis.HasTitle = true;
    Xaxis.AxisTitle.Text = "거리";

    for (int i = 0; i < dataTable.Rows.Count; i++)
    {
        Sc.Item(i + 1).Name = dataTable.Rows[i][0].ToString();
    }

    Xaxis.CategoryNames = dataTable.Columns.Cast<DT.DataColumn>().Select(x => x.ColumnName).Skip(1).Take(4).ToArray();


    Microsoft.Office.Interop.Excel.ChartObjects chartObjs = (Microsoft.Office.Interop.Excel.ChartObjects)ws.ChartObjects(Type.Missing);
    Microsoft.Office.Interop.Excel.ChartObject chartObj = chartObjs.Add(100, 20, 300, 300);
    Microsoft.Office.Interop.Excel.Chart xlChart = chartObj.Chart;

    Range rg1 = ws.get_Range("A1", "D" + rowcount);
    rg1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

    xlChart.SetSourceData(rg1, Microsoft.Office.Interop.Excel.XlRowCol.xlColumns);
    xlChart.ChartType = XlChartType.xlLine;
    xlChart.Legend.Position = XlLegendPosition.xlLegendPositionBottom;


    //SeriesCollection seriesCollection = (SeriesCollection)xlChart.SeriesCollection();

    Series s1 = (Series)xlChart.SeriesCollection(1);
    s1.Name = "Serie1";
    s1.MarkerStyle = XlMarkerStyle.xlMarkerStyleCircle;

    //seriesCollection.NewSeries();

    Series s2 = (Series)xlChart.SeriesCollection(2);
    s2.Name = "Serie2";
    s2.MarkerStyle = XlMarkerStyle.xlMarkerStyleNone;

    //seriesCollection.NewSeries();

    Series s3 = (Series)xlChart.SeriesCollection(3);
    s3.Name = "Serie3";
    s3.MarkerStyle = XlMarkerStyle.xlMarkerStyleNone;


    ChartData.Activate();
}
