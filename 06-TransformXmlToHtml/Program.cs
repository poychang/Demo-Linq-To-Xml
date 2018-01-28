using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace _06_TransformXmlToHtml
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /**
             * HTML 本身符合 XML 格式，因此要將 XML 資料轉成 HTML 的 Table 來呈現資料時
             * 可以仿造 01-CreateXmlDocument 的建立 XML 檔案的方式來處理
             */
            const string filePath = "../sample.xml";
            var xmlDocument = XDocument.Load(filePath);
            var result = new XDocument(
                new XElement("table", new XAttribute("border", 1),
                new XElement("thead",
                    new XElement("tr",
                        new XElement("th", "Name"),
                        new XElement("th", "Gender"),
                        new XElement("th", "TotalMarks"))),
                new XElement("tbody",
                    from student in xmlDocument.Descendants("Student")
                    select new XElement("tr",
                        new XElement("td", student.Element("Name")?.Value),
                        new XElement("td", student.Element("Gender")?.Value),
                        new XElement("td", student.Element("TotalMarks")?.Value))))
                );

            Console.WriteLine(result.ToString());
            //var savePath = $@"{Directory.GetCurrentDirectory()}\result.html";
            //result.Save(savePath);
        }
    }
}
