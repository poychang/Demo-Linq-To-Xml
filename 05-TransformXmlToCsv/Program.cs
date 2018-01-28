using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace _05_TransformXmlToCsv
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /**
             * 將 IEnumerable 資料轉成 List 後，可透過 ForEach() 取出清單中的資料並組成我們期待中的 CSV 格式
             */
            var stringBuilder = new StringBuilder();
            const string filePath = "../sample.xml";
            const string delimiter = ",";
            XDocument.Load(filePath).Descendants("Student")
                .ToList().ForEach(element =>
                {
                    Console.WriteLine(element);
                    stringBuilder.Append(
                        $@"{element.Attribute("Id")?.Value}{delimiter}" +
                        $@"{element.Element("Name")?.Value}{delimiter}" +
                        $@"{ element.Element("Gender")?.Value}{delimiter}" +
                        $@"{ element.Element("TotalMarks")?.Value}{delimiter}{"\r\n"}"
                    );
                });

            var savePath = $@"{Directory.GetCurrentDirectory()}\data.csv";
            var streamWriter = new StreamWriter(savePath);
            streamWriter.WriteLine(stringBuilder.ToString());
            streamWriter.Close();
        }
    }
}
