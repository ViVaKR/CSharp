public interface IXForm
{
    void 이벤트관리();
    void 폼_Load(object sender, EventArgs e);
    void 폼_Activated(object sender, EventArgs e);
    void 폼_Deactivate(object sender, EventArgs e);
    void 컨트롤초기화();
    void 입력폼_크기설정(bool tf);
    void 입력폼_전체크기();
    void 데이터_목록관리();
    void 분리형컨테이너_Resize(object sender, EventArgs e);
    void 검색창보기및숨기기(bool tf);
    void 그룹_데이터목록_DoubleClick(object sender, EventArgs e);
    void 뷰_RowCellClick(object sender, RowCellClickEventArgs e);
}
