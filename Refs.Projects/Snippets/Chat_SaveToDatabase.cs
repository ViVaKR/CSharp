public partial class 정보교환실폼 : FluentDesignForm
{

    SqlConnection _연결 = null;
    SqlDataAdapter _DA = null;
    const string _연결문 = "Server=...;Database=...;Uid=...;Password=...";
    public 정보교환실폼() => InitializeComponent();

    void 대화저장하기()
    {
        string _저장문 = "Insert Into 대화내용 (일시, 내용) Values (@일시, @내용)";
        using (_연결 = new SqlConnection(_연결문))
        {
            _연결.Open();
            using (_DA = new SqlDataAdapter())
            {
                _DA.InsertCommand = new SqlCommand(_저장문, _연결);
                _DA.InsertCommand.Parameters.Add("@일시", SqlDbType.DateTime).Value = DateTime.Now;

                byte[] _바이트;
                using (MemoryStream ms = new MemoryStream())
                {
                    리치_읽기창.Document.SaveDocument(ms, DocumentFormat.Rtf);
                    _바이트 = ms.ToArray();
                    _DA.InsertCommand.Parameters.Add("@내용", SqlDbType.VarBinary, _바이트.Length).Value = _바이트;
                }
                int _저장결과 = _DA.InsertCommand.ExecuteNonQuery();
                if (_저장결과 > 0)
                {
                    대화불러오기();
                }
            }
        }
    }
    
    void 대화불러오기()
    {
        string _호출문 = "Select Top 1 * From 대화내용 Order by 번호 Desc";
        _DA.SelectCommand = new SqlCommand(_호출문, _연결);
        using (SqlDataReader reader = _DA.SelectCommand.ExecuteReader())
        {
            if (reader.Read())
            {
                byte[] _내용 = (byte[])reader["내용"];

                using (MemoryStream ms = new MemoryStream(_내용))
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    리치_쓰기창.LoadDocument(ms, DocumentFormat.Rtf);
                }
            }
        }
    }
    private void 버튼패널_ButtonClick(object sender, ButtonEventArgs e)
    {
        switch (e.Button.Properties.Caption)
        {
            case "전송":
                리치_읽기창.Document.AppendDocumentContent(리치_쓰기창.Document.Range);
                break;
            case "첨부":
                DialogResult result = 파일열기대화창.ShowDialog();
                if (result == DialogResult.OK)
                {
                    리치_쓰기창.Document.BeginUpdate();
                    Document document = 리치_쓰기창.Document;
                    Shape shape = document.Shapes.InsertPicture(document.Range.Start, DocumentImageSource.FromFile(파일열기대화창.FileName));
                    shape.ScaleX = (document.Sections[0].Page.Width / shape.OriginalSize.Width) / 2;
                    shape.ScaleY = shape.ScaleX;

                    // 리치_쓰기창.Document.Images.Insert(리치_쓰기창.Document.CaretPosition, Image.FromFile(파일열기대화창.FileName));
                    리치_쓰기창.Document.EndUpdate();
                }
                break;
            case "청소":
                break;
            case "끊기":
                break;
            case "접속":
                break;
            case "저장":
                대화저장하기();
                break;
            case "호출":
                대화불러오기();
                break;
            case "수평":
                분리컨테이너.Horizontal = true;
                e.Button.Properties.Caption = "수직";
                분리컨테이너_분리선초기화();
                break;
            case "수직":
                분리컨테이너.Horizontal = false;
                e.Button.Properties.Caption = "수평";
                분리컨테이너_분리선초기화();
                break;
        }
    }

}
