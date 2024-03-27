{
    FontFamily fontFamily = new FontFamily("Times New Roman");
    Font font = new Font(
       fontFamily,
       32,
       FontStyle.Regular,
       GraphicsUnit.Pixel);
    SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
    string string1 = "SingleBitPerPixel";
    string string2 = "AntiAlias";

    e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
    e.Graphics.DrawString(string1, font, solidBrush, new PointF(10, 10));

    e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
    e.Graphics.DrawString(string2, font, solidBrush, new PointF(10, 60));
}