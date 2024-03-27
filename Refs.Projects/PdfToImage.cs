using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("gdi32.dll")]
    private static extern int DeleteObject(IntPtr o);

    static void Main(string[] args)
    {
        string pdfFilePath = "path/to/pdf/file.pdf";
        string jpgFilePath = "path/to/image/file.jpg";

        using (var pdfStream = new FileStream(pdfFilePath, FileMode.Open, FileAccess.Read))
        {
            var pdfDoc = new System.Drawing.Printing.PrintDocument();
            pdfDoc.DocumentName = pdfFilePath;
            pdfDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            pdfDoc.PrinterSettings.PrintToFile = true;
            pdfDoc.PrinterSettings.PrintFileName = jpgFilePath;
            pdfDoc.PrintPage += (s, e) =>
            {
                using (var img = new Bitmap(e.PageBounds.Width, e.PageBounds.Height))
                {
                    e.Graphics.DrawImage(img, e.PageBounds);

                    var g = Graphics.FromImage(img);
                    IntPtr hdc = g.GetHdc();
                    try
                    {
                        var rect = new Rect(e.PageBounds.Left, e.PageBounds.Top, e.PageBounds.Width, e.PageBounds.Height);
                        int res = NativeMethods.DrawPDFToDC(pdfStream.SafeFileHandle, hdc, rect);
                        if (res == 0)
                        {
                            throw new Exception("Failed to draw PDF to DC");
                        }

                        var jpgEncoder = ImageCodecInfo.GetImageEncoders().First(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
                        var encoderParams = new EncoderParameters(1);
                        encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 90L);

                        img.Save(jpgFilePath, jpgEncoder, encoderParams);
                    }
                    finally
                    {
                        g.ReleaseHdc(hdc);
                    }
                }
            };
            pdfDoc.Print();
        }
    }
}

internal static class NativeMethods
{
    [DllImport("PdfiumViewer.dll", EntryPoint = "DrawPDFToDC", CharSet = CharSet.Unicode)]
    public static extern int DrawPDFToDC(IntPtr hPdf, IntPtr hdc, Rect rect);
}

[StructLayout(LayoutKind.Sequential)]
internal struct Rect
{
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;

    public Rect(int left, int top, int width, int height)
    {
        Left = left;
        Top = top;
        Right = left + width;
        Bottom = top + height;
    }
}
