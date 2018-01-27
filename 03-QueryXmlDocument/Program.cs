using System;
using System.Linq;
using System.Xml.Linq;

namespace _03_QueryXmlDocument
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /**
             * 透過 LINQ 對 XML 做資料篩選
             */
            const string filePath = "../sample.xml";
            var names = from student in XDocument.Load(filePath).Descendants("Student")
                        where (int)student.Element("TotalMarks") > 800
                        orderby (int)student.Element("TotalMarks") descending
                        select student.Element("Name")?.Value;
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            /**
             * 上述程式碼中
             * XDocument.Load(filePath).Descendants("Student")
             * 會等價於
             * XDocument.Load(filePath).Elements("Students").Elements("Student")
             * 我們可以透過串接 Elements() 來逐層剖析所需要的元素
             */

            /**
             * Descendants() 會將 XML 做遞迴拆解，會一層一層將資料拆解出來，並存成可列舉的資料型態
             * 可嘗試執行以下程式碼，會更清楚這裡想要表達的
             */
            //foreach (var elememt in XDocument.Load(filePath).Descendants())
            //{
            //    Console.WriteLine(elememt);
            //    Console.WriteLine("----------");
            //}

            /**
             * Descendants(TargetElement) 會將 XML 做遞迴拆解，並將指定的元素擷取成可列舉的資料型態
             * 可嘗試執行以下程式碼，會更清楚這裡想要表達的
             */
            //foreach (var elememt in XDocument.Load(filePath).Descendants("Student"))
            //{
            //    Console.WriteLine(elememt);
            //    Console.WriteLine("----------");
            //}
        }
    }
}
