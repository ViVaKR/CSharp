
private void 튜플()
{
    XtraForm form = new XtraForm
    {
        MdiParent = this,
        Dock = DockStyle.Fill,
        WindowState = FormWindowState.Maximized
    };
    form.Show();


    LabelControl label = new LabelControl();
    label.Text = "Hello world";

    label.Font = new Font(DefaultFont.FontFamily, 20, FontStyle.Bold);

    form.Controls.Add(label);

    MessageBox.Show((값반환().a + 값반환().b + 값반환().c).ToString());
}

private (int a, int b, int c) 값반환()
{
    (int a, int b, int c) temp = (a: 5, b: 7, c: 99);
    return temp;
}

Document document = 문서_문제내용.Document;
DocumentPosition pos1 = document.CreatePosition(2);
document.InsertText(pos1, "The Word Processing Document API is a non-visual .NET library.\r It allows you to automate frequent word processing tasks.\n");

PictureEdit edit = new PictureEdit();
