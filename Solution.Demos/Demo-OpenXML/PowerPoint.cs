using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using Picture = DocumentFormat.OpenXml.Presentation.Picture;

namespace Demo_OpenXML;

public class PowerPoint
{
	public static void GetImagesFormAllSlides(string pptFile)
	{
		try
		{
			var fi = new FileInfo(pptFile);
			if (!fi.Exists) throw new FileNotFoundException($"`{pptFile}` 에 PPT 파일이 존재하지 않습니다.");

			using var document = PresentationDocument.Open(fi.FullName, false);
			var presentation = document.PresentationPart.Presentation;

			int slideNO = 1;
			foreach (SlideId slideID in presentation.SlideIdList.Cast<SlideId>())
			{
				// 패턴매칭 채킹 및 할당
				if (document.PresentationPart.GetPartById(slideID.RelationshipId)
								is not SlidePart slidePart
								|| slidePart.Slide == null) continue;

				// 작업슬라이드
				Slide slide = slidePart.Slide;

				int picNO = 1;
				foreach (var picture in slide.Descendants<Picture>())
				{
					var id = picture.BlipFill.Blip.Embed.Value;
					ImagePart imagePart = (ImagePart)slide.SlidePart.GetPartById(id);

					// 참고 자료 출력해두기
					var orgin = imagePart.Uri.OriginalString;
					var contentType = imagePart.ContentType;
					Console.WriteLine($"\n-오리지널 파일명 : {orgin}\n-오리지널 타입명{contentType}");
					Console.WriteLine();

					// 이미지 추출
					System.Drawing.Image image = System.Drawing.Image.FromStream(imagePart.GetStream());

					// 저장할 폴더 (바탕화면 -> PPT_Slide-Images)
					var saveToFolder
					= Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PPT-Slide-Images");

					// 있으면 스킵하고 없으면 생성하므로
					// 사전에 폴더 있는지 체크할  필요 없음
					Directory.CreateDirectory(saveToFolder);

					// 최종 저장 
					image.Save(Path.Combine(saveToFolder, $@"{fi.Name}_{slideNO++}_{picNO++}.png"));
				}
			}

		}
		catch(FileNotFoundException ex)
		{
			throw new Exception(ex.Message);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{ex.Message}");
		}
	}
}
