MemoryStream ms = new MemoryStream();
richEditControl1.SaveDocument(ms, DevExpress.XtraRichEdit.DocumentFormat.OpenDocument);
byte[] array = ms.ToArray();

MemoryStream outputStream = new MemoryStream();
richEditControl1.Document.SaveDocument(outputStream, DocumentFormat.Rtf);
byte[] array = outputStream.ToArray();

리치_컨트롤.Document.Images.Insert(리치_컨트롤.Document.CaretPosition, image);

Document.Shapes.InsertPicture
Document.Images.Insert

document.AppendText("Line One\nLine Two\nLine Three");
Shape myPicture = document.Shapes.InsertPicture(document.CreatePosition(15),
    System.Drawing.Image.FromFile("beverages.png"));
myPicture.HorizontalAlignment = ShapeHorizontalAlignment.Center;

PowerPoint.OLEFormat ole = shape.OLEFormat;
ole.Object.Activate();
Excel.Workbook workbook = ole.Object;
