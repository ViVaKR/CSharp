
using System.Text;
using System.Text.Json;
using System.Xml;

var array = new byte[] { 0x00, 0x00, 0x12, 0x12, 0xAB, 0xAB };

// (방법 1) 그대로 출력, 가장 간단
array.ToList()
.ForEach(b => File.AppendAllText("방법1", $"{b:X2} "));

// (방법 2) 그대로 출력, 고전적인 방전
StringBuilder sb = new();
array.ToList().ForEach(b => sb.Append($"{b:X2} "));
File.WriteAllText("방법2", sb.ToString());

// (방법 3) XmlWriter 사용, 각 잡아 저장
using XmlWriter writer = XmlWriter.Create("방법3.xml");
writer.WriteStartElement("root");
array.ToList().ForEach(b => writer.WriteElementString("byte", $"{b:X2}"));
writer.WriteEndElement();

// (방법 4) binary 파일로 저장
File.WriteAllBytes("방법4.bin", array);

// (방법 5) json 파일로 저장
File.WriteAllText("방법5.json", JsonSerializer.Serialize(array.Select(b => b.ToString("X2"))));
