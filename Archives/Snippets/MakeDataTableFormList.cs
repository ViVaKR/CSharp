public static DataTable CreateDataTable<T>(IEnumerable<T> list)
{
    Type type = typeof(T);
    var properties = type.GetProperties();

    DataTable dataTable = new DataTable();
    foreach (PropertyInfo info in properties)
    {
        dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
    }

    foreach (T entity in list)
    {
        object[] values = new object[properties.Length];
        for (int i = 0; i < properties.Length; i++)
        {
            values[i] = properties[i].GetValue(entity);
        }

        dataTable.Rows.Add(values);
    }

    return dataTable;
}

PowerPoint.ActionSettings aset = _TextRange.ActionSettings;
PowerPoint.ActionSetting asetmc = aset[PowerPoint.PpMouseActivation.ppMouseClick];

string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "내구_.pptm");
if (_TextRange.ActionSettings[PpMouseActivation.ppMouseClick].Action == PowerPoint.PpActionType.ppActionHyperlink)
{
    _Press.Open(path, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoTrue);
}

BulletFormat 블릿 = _TextRange.Paragraphs(1).ParagraphFormat.Bullet;
블릿.Visible = MsoTriState.msoTrue;
블릿.Character = 10063;
블릿.Font.Color.RGB = ColorTranslator.ToOle(Color.Red);
블릿.RelativeSize = 1;


_TextRange.ActionSettings[PpMouseActivation.ppMouseClick].Action = PpActionType.ppActionHyperlink;
_TextRange.ActionSettings[PpMouseActivation.ppMouseClick].Hyperlink.Address = path;
