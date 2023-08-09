
public class 컨트롤_폰트정보
{
    public 컨트롤_폰트정보()
    {
        BaseControlViewInfo controlViewInfo = 컨트롤.GetViewInfo();
        Font font = controlViewInfo.DefaultAppearance.Font;
    }
}
