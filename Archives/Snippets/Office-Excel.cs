using System.Threading.Tasks;
using System.Threading;
// 기본적인 참조
using EXCEL = Microsoft.Office.Interop.Excel;
using CORE = Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;

// 글로발 속성 설정
public EXCEL.Application App { get; set; }
public EXCEL.Workbooks Workbooks { get; set; }
public EXCEL.Workbook Workbook { get; set; }
public EXCEL.Sheets Steets { get; set; }
public EXCEL.Worksheet Worksheet { get; set; }
public EXCEL.Range Rng { get; set; }


// (1) 초기화
private void OpenExcel()
{
  // 엑셀 열기
  App = new EXCEL.Application
  {
    Visible = true,
    DisplayAlerts = false
  };


  // 엑셀 워크북 열기
  Workbooks = App.Workbooks;
  string workbookFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Demo.xlsm");
  Workbook = Workbooks.Open(workbookFile);

  // 위 워크북에서 워크시트 모음 초기화
  Steets = Workbook.Worksheets;
}

// (버튼클릭 이벤트)  엑셀 시트에 데이터 넣기
private void Excel_Click(object sender, EventArgs e)
{
  // 엑셀 파일 열기
  OpenExcel();

  Thread.Sleep(10); //또는 async  await Task.Run(()=> OpenExcel); 해서 매듭을 짓고 하단 부를 처리해도됨
  // 워크북에서 워크 시트 1번 선택
  string sheetName = textBox1.Text;
  Worksheet = Steets[sheetName];
  Worksheet.Select();
  // 선택한 시트에서 값을 넣을 특정셀 정조준
  Rng = Worksheet.Cells[2, 1];

  // 셀에 값넣기
  Rng.Value2 = "How are you? Fine Thanks and you?";
}
