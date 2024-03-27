using Demo_OpenXML;

internal class Program
{
	private static void Main()
	{
		// 작업대상 PPT
		var fileName = "Demo-OpenXML.pptm";

		// 바탕화면 폴더 경로 가져오기
		var fileFullName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

		try
		{
			// Run... (Get All images from slides)
			PowerPoint.GetImagesFormAllSlides(fileFullName);
		}
		catch (FileNotFoundException ex)
		{
			TextWriter writer = Console.Error;
			writer.WriteLine($"잘못된 파일 경로입니다`{fileFullName}`");
			writer.WriteLine($"{ex.Message}");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{ex.Message}");
		}
	}
}
