using System;
using System.Linq;
using System.Xml.Linq;

namespace _08_ExtractDataFromCData
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /**
             * 使用 XML 做為資料傳輸的資料格式時，常見於使用 CDATA 來標示真正要傳輸的資料內容
             * 我們可以透過 LINQ 來篩選出節點型態為 CDATA 的父元素找出來，再取得 CDATA 內容
             * 這裡要注意，使用 Value 取 CDATA 元素內容的時候，是不會包含 <![CDATA[...]]> 這個標籤
             */
            const string filePath = "../sample-cdata.xml";
            var queryCData = from element in XDocument.Load(filePath).DescendantNodes()
                             where element.NodeType == System.Xml.XmlNodeType.CDATA
                             select element.Parent?.Value.Trim();
            foreach (var data in queryCData)
            {
                Console.WriteLine(data);
            }
        }
    }
}
