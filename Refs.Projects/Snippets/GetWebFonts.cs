public partial class WebFontsForm : XtraForm
{
    public WebFontsForm()
    {
        InitializeComponent();
        GetWebFontList();
    }

    private void GetWebFontList()
    {
        WebfontsService service = Auth.AuthenticatePublic("...");

        WebfontList result = Auth.FontList(service);

        StringBuilder sb = new StringBuilder();
        if (result.Items != null)
        {
            foreach (Webfont font in result.Items)
            {
                sb.Append(font.Family + Environment.NewLine);
            }
        }

        메모.EditValue = sb.ToString();
    }
}
