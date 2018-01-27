using System.IO;
using System.Xml.Linq;

namespace _01_CreateXmlDocument
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /**
             * 使用 Functional Construction 的方式建立 XML 檔案
             */
            var xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Creating an XML Tree using LINQ to XML"),
                new XElement("Students",
                    new XElement("Student", new XAttribute("Id", 101),
                        new XElement("Name", "Mark"),
                        new XElement("Gender", "Male"),
                        new XElement("TotalMarks", 800)),
                    new XElement("Student", new XAttribute("Id", 102),
                        new XElement("Name", "Rosy"),
                        new XElement("Gender", "Female"),
                        new XElement("TotalMarks", 900)),
                    new XElement("Student", new XAttribute("Id", 103),
                        new XElement("Name", "Pam"),
                        new XElement("Gender", "Female"),
                        new XElement("TotalMarks", 850)),
                    new XElement("Student", new XAttribute("Id", 104),
                        new XElement("Name", "John"),
                        new XElement("Gender", "Male"),
                        new XElement("TotalMarks", 950))));

            var savePath = Directory.GetCurrentDirectory();
            const string fileName = "data.xml";
            xmlDocument.Save($@"{savePath}\{fileName}");
        }
    }
}
