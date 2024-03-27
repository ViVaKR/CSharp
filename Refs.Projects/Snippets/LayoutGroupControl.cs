
public static void ConfigGroup(LayoutControlGroup group, XtraForm frm = null)
{
        try
        {
                if (frm == null)
                {
                        group.AppearanceItemCaption.TextOptions.HAlignment = HorzAlignment.Center;
                        group.AppearanceItemCaption.TextOptions.VAlignment = VertAlignment.Center;
                }

                group.AppearanceGroup.ForeColor = Color.SteelBlue;
                group.AppearanceGroup.Font = new Font(SafeTypes.DefaultFont, 폰트크기);
                group.ExpandOnDoubleClick = true;
                group.AppearanceItemCaption.ForeColor = Color.SteelBlue;
                group.Padding = new DevExpress.XtraLayout.Utils.Padding(1);

                foreach (object item in group.Items)
                {
                        if (item is LayoutControlGroup 그룹)
                        {
                                ConfigGroup(그룹, frm);
                        }

                        if (item is LayoutControlItem 아이템)
                        {
                                ConfigItems(아이템);
                        }
                }
        }
        catch (Exception ex)
        {
                ex.GetMsg(null, $"{group.Name}의 {MethodBase.GetCurrentMethod().Name}");
        }
}


public static void ConfigGroup(LayoutControlGroup group)
{
        try
        {
                group.AppearanceGroup.ForeColor = Color.SteelBlue;
                group.AppearanceGroup.Font = new Font(SafeTypes.DefaultFont, 폰트크기);
                group.ExpandOnDoubleClick = true;
                group.Padding = new DevExpress.XtraLayout.Utils.Padding(1);
                foreach (object item in group.Items)
                {
                        if (item is LayoutControlGroup 그룹)
                        {
                                ConfigGroup(그룹);
                        }

                        if (item is LayoutControlItem 아이템)
                        {
                                ConfigItems(아이템);
                        }
                }
        }
        catch (Exception ex)
        {
                ex.GetMsg(null, $"{group.Name}의 {MethodBase.GetCurrentMethod().Name}");
        }
}


private static void ConfigItems(LayoutControlItem item)
{
        try
        {
                item.AppearanceItemCaption.TextOptions.HAlignment = HorzAlignment.Center;
                item.AppearanceItemCaption.TextOptions.VAlignment = VertAlignment.Center;
                item.AppearanceItemCaption.Font = new Font(SafeTypes.DefaultFont, 11);
                item.Padding = new DevExpress.XtraLayout.Utils.Padding(1);
                item.AppearanceItemCaption.ForeColor = Color.SteelBlue;
        }
        catch (Exception ex)
        {
                ex.GetMsg(null, $"{MethodBase.GetCurrentMethod().Name}");
        }
}
