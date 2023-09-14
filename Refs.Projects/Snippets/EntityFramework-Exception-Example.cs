try
{
    //
}
catch (DbEntityValidationException dex)
{
    foreach (DbEntityValidationResult item in dex.EntityValidationErrors)
    {
        DbEntityEntry entry = item.Entry;
        string entityTypeName = entry.Entity.GetType().Name;

        StringBuilder sb = new StringBuilder();
        foreach (DbValidationError subItem in item.ValidationErrors)
        {
            string message = $"Error '{subItem.ErrorMessage}' occurred in {entityTypeName} at {subItem.PropertyName}";
            sb.Append(message + Environment.NewLine);
        }
        dex.GetMsg(this, $"{Name}의 {MethodBase.GetCurrentMethod().Name}");
    }
    if (tf)
    {
        버튼그룹.SetButtonPanel(true, true, false, false, true);
    }
    else
    {
        버튼그룹.SetButtonPanel(true, true, true, true, false);
    }
}
catch (Exception ex)
{
    ex.GetMsg(this, $"{Name}의 {MethodBase.GetCurrentMethod().Name}");
    if (tf)
    {
        버튼그룹.SetButtonPanel(true, true, false, false, true);
    }
    else
    {
        버튼그룹.SetButtonPanel(true, true, true, true, false);
    }
}

try
{
    //
}
catch (DbUpdateException eux)
{
    eux.GetMsg(this, $"{Name}의 {MethodBase.GetCurrentMethod().Name}");
    if (tf)
    {
        버튼그룹.SetButtonPanel(true, true, false, false, true);
    }
    else
    {
        버튼그룹.SetButtonPanel(true, true, true, true, false);
    }
}
catch (DbEntityValidationException dex)
{
    foreach (DbEntityValidationResult item in dex.EntityValidationErrors)
    {
        DbEntityEntry entry = item.Entry;
        string entityTypeName = entry.Entity.GetType().Name;

        StringBuilder sb = new StringBuilder();
        foreach (DbValidationError subItem in item.ValidationErrors)
        {
            string message = $"Error '{subItem.ErrorMessage}' occurred in {entityTypeName} at {subItem.PropertyName}";
            sb.Append(message + Environment.NewLine);
        }
        dex.GetMsg(this, $"{Name}의 {MethodBase.GetCurrentMethod().Name}");
    }
    if (tf)
    {
        버튼그룹.SetButtonPanel(true, true, false, false, true);
    }
    else
    {
        버튼그룹.SetButtonPanel(true, true, true, true, false);
    }
}
catch (Exception ex)
{
    ex.GetMsg(this, $"{Name}의 {MethodBase.GetCurrentMethod().Name}");
    if (tf)
    {
        버튼그룹.SetButtonPanel(true, true, false, false, true);
    }
    else
    {
        버튼그룹.SetButtonPanel(true, true, true, true, false);
    }
}
