using System;
using System.Xml.Linq;
using System.Xml.Schema;

namespace _07_ValidateWithXSD
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /**
             * XSD (XML Schema Definition) 是用來描述一個 XML 檔案必須遵守的規則，確認 XML 文件的有效性
             * 建立 Students XSD 檔，請參考 sample.xsd，規則如下：
             * 1. 根元素為 Students
             * 2. 根元素包含至少 1 個 Student 元素(minOccurs="1")，且無上限(maxOccurs="unbounded")
             * 3. Student 元素必須設定 Id 屬性
             * 4. 每個元素必須包含以下 3 個子元素
             *    (1) Name
             *    (2) Gender
             *    (3) TotalMarks
             */

            var schema = new XmlSchemaSet();
            const string xsdFilePath = "../sample.xsd";
            schema.Add("", xsdFilePath);

            const string xmlFilePath = "../sample.xml";
            var xmlDocument = XDocument.Load(xmlFilePath);
            var isInvalid = false;

            xmlDocument.Validate(schema, (s, e) =>
            {
                Console.WriteLine(e.Message);
                isInvalid = true;
            });

            Console.WriteLine(isInvalid ? "Validation failed" : "Validation succeeded");
        }
    }
}
