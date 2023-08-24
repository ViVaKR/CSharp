namespace Intellectual;
using System.Reflection;
using System.Text;
using System.Xml;

public class DemoXml
{
    public void Run()
    {

        //-> Start
        //! [ Demo ]
        string path = "books.xml";
        var contents = File.ReadAllText(path, Encoding.UTF8);
        XmlDocument doc = new();
        doc.Load(path);

        // 태그 내부의 글 읽기
        XmlNodeList elemList = doc.GetElementsByTagName("title");
        for (int i = 0; i < elemList.Count; i++)
        {
            Console.WriteLine($"제목 = {elemList[i]?.InnerXml}");
        }
        Console.WriteLine();
        // 어트리뷰트 읽기
        elemList = doc.GetElementsByTagName("book");
        for (int i = 0; i < elemList.Count; i++)
        {
            var attribute = elemList[i]?.Attributes?["genre"];
            Console.WriteLine($"장르 = {attribute?.InnerText}");
        }
        Console.WriteLine();
        Console.WriteLine(contents);
        //-> End

        //! WPF Resource...(xml 파일을 -> 포함 리소스로 한 다음..)
        Assembly a = Assembly.GetExecutingAssembly();
        using Stream? stream = a.GetManifestResourceStream("Settings.xml");
        if (stream != null)
        {
            doc = new XmlDocument();
            using XmlReader r = XmlReader.Create(stream);
            var str = r.ReadContentAsString();

            doc.LoadXml(str);
            // TODO : 위 소스코드를 사용하시면됨 (Start ~ End 까지)

        }
    }
}
