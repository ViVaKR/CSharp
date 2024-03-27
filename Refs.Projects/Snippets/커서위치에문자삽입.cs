
private void 커서위치에문자삽입(Document 문, string 글)
{
    DocumentPosition 커서위치 = 문.CaretPosition;
    SubDocument 문서 = 커서위치.BeginUpdateDocument();
    문서.InsertText(커서위치, 글 + Environment.NewLine);
    커서위치.EndUpdateDocument(문서);
}
