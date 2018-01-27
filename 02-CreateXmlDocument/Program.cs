using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace _02_CreateXmlDocument
{
    public class Student
    {
        public string Gender { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }

        /// <summary>模擬取得資料</summary>
        /// <returns></returns>
        public static Student[] GetAllStudents()
        {
            var students = new Student[4];

            students[0] = new Student
            {
                Id = 101,
                Name = "Mark",
                Gender = "Male",
                TotalMarks = 800
            };
            students[1] = new Student
            {
                Id = 102,
                Name = "Rosy",
                Gender = "Female",
                TotalMarks = 900
            };
            students[2] = new Student
            {
                Id = 103,
                Name = "Pam",
                Gender = "Female",
                TotalMarks = 850
            };
            students[3] = new Student
            {
                Id = 104,
                Name = "John",
                Gender = "Male",
                TotalMarks = 950
            };

            return students;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            /**
             * 實務上資料會從資料庫取得，並暫存在記憶體中，此時資料型態會是 IEnumerable 的實作，例如 Array、List 等
             * 這時我們可以透過 LINQ 的方式篩選並組出我們要的 XML 資料內容，進而建立 XML 檔案
             */
            var xmlDocument = new XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XComment("Creating an XML Tree using LINQ to XML"),
               new XElement("Students",
                   from student in Student.GetAllStudents()
                   select new XElement("Student", new XAttribute("Id", student.Id),
                       new XElement("Name", student.Name),
                       new XElement("Gender", student.Gender),
                       new XElement("TotalMarks", student.TotalMarks))
               ));

            var savePath = Directory.GetCurrentDirectory();
            const string fileName = "data.xml";
            xmlDocument.Save($@"{savePath}\{fileName}");
        }
    }
}
