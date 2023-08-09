// 메세지박스
XtraMessageBox.Show("", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
XtraMessageBox.Show(ex.Message, "오류발생", MessageBoxButtons.OK, MessageBoxIcon.Error);

// 스플레쉬 스크린네니져
SplashScreenManager.ShowForm(this, typeof(대기폼), true, true, false);
SplashScreenManager.CloseForm(false);

SplashScreenManager.ShowForm(null, typeof(ProgressForm), true, true, false);
SplashScreenManager.CloseForm(false);

// 그리드뷰
GridView view = sender as GridView;
_선택한행번호 = Convert.ToInt32(view.GetRowCellValue(그리드뷰.FocusedRowHandle, view.Columns[0]));

// 라인 변경 적용 DevExpress
string _임시 = 빵.개선내역및조치결과.Replace("\r\n", Characters.LineBreak.ToString());

richEditControl1.RtfText = Encoding.UTF8.GetString(빵.문제검토);

using (MemoryStream ms = new MemoryStream(빵.문제검토))
{
    richEditControl1.LoadDocument(ms, DocumentFormat.Rtf);
}

richEditControl1.RtfText = Encoding.UTF8.GetString(빵.문제검토);
