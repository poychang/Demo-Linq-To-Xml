using System;
using System.Linq;
using System.Xml.Linq;

namespace _04_ModifyXmlDocument
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string filePath = "../sample.xml";
            var xmlDocument = XDocument.Load(filePath);

            /**
             * 使用 Add() 可以在既有的 XML 資料中新增一筆元素資料，這筆資料會被加在 XML 資料中的最後面
             * 另外可使用 AddFirst() 將資料加在最前面
             */
            xmlDocument.Element("Students")?.Add(
                new XElement("Student", new XAttribute("Id", 105),
                    new XElement("Name", "Todd"),
                    new XElement("Gender", "Male"),
                    new XElement("TotalMarks", 980)
                ));
            Console.WriteLine(xmlDocument.ToString());
            Console.WriteLine("----------");

            /**
             * 使用 AddBeforeSelf() 或 AddAfterSelf() 可將資料加在指定元素的前面或後面
             */
            xmlDocument.Element("Students")?.Elements("Student")
                .First(x => x.Attribute("Id")?.Value == "103")
                .AddBeforeSelf(
                    new XElement("Student", new XAttribute("Id", 106),
                        new XElement("Name", "Todd"),
                        new XElement("Gender", "Male"),
                        new XElement("TotalMarks", 980)));
            Console.WriteLine(xmlDocument.ToString());
            Console.WriteLine("----------");

            /**
             * 更新 XML 既有元素值
             * 下面程式碼中
             * .FirstOrDefault(x => x.Attribute("Id")?.Value == "106")?.SetElementValue("TotalMarks", 999);
             * 會等價於
             * .Select(x => x.Element("TotalMarks")).FirstOrDefault()?.SetValue(999);
             */
            xmlDocument.Element("Students")?.Elements("Student")
                .First(x => x.Attribute("Id")?.Value == "106")?.SetElementValue("TotalMarks", 999);
            Console.WriteLine(xmlDocument.ToString());
            Console.WriteLine("----------");

            /**
             * 刪除篩選到的 XML 元素
             */
            xmlDocument.Root?.Elements().Where(x => x.Attribute("Id")?.Value == "106").Remove();

            /**
             * 刪除根元素底下的所有 XML 元素，以範例來說，為刪除根元素下 Students 元素
             */
            xmlDocument.Root?.Elements().Remove();

            /**
             * 更新 XML Comment
             */
            xmlDocument.Nodes().OfType<XComment>().First().Value = "Comment Updated";

            /**
             * 刪除 XML Comment
             */
            xmlDocument.Nodes().OfType<XComment>().Remove();
        }
    }
}
