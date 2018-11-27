# LINQ to XML - 轉換 XML 資料

接續上篇的基本操作，這篇主要使用 LINQ to XML 來轉換 XML 資料。

目錄：

- [基本操作](https://poychang.github.io/linq-to-xml-basic-usage/)
- [建立 XML 檔案](https://poychang.github.io/linq-to-xml-create-xml-file)
- [查詢 XML 資料](https://poychang.github.io/linq-to-xml-query-xml/)
- [修改 XML 資料](https://poychang.github.io/linq-to-xml-edit-xml)
- [轉換 XML 資料](https://poychang.github.io/linq-to-xml-transfom-xml)
- [驗證 XML 資料](https://poychang.github.io/linq-to-xml-validate-xml)
- [取得 CDATA 資料](https://poychang.github.io/2018-02-05-linq-to-xml-extract-data-from-cdata)

> 系列文完整範例程式碼請參考 [poychang/Demo-Linq-To-Xml](https://github.com/poychang/Demo-Linq-To-Xml)。

## 轉換 XML 資料

### 轉換成 HTML

如果要將 XML 　資料轉換成同樣是標記式語言的 HTML 格式，玩法就可以改變一下，因為 HTML 本身符合 XML 格式，因此我們可以藉由 LINQ to XML [建立 XML 文件的方法](https://poychang.github.io/linq-to-xml-create-xml-file)，來協助我們進行轉換，請見以下範例：

```csharp
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
```

簡單來看，就是把 `table`、`thead`、`tbody` 當作 XML 的元素名稱，並在讀取完 XML 資料後，依據想要呈現的資料格式將值給塞進這些 HTML 元素中。

> 請參考 `06-TransformXmlToHtml` 專案的 [Program.cs](https://github.com/poychang/Demo-Linq-To-Xml/blob/master/06-TransformXmlToHtml/Program.cs)

---

參考資料：

- [LINQ to XML (C#)](https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/concepts/linq/linq-to-xml)
- [YouTube - LINQ to XML Tutorial](https://www.youtube.com/playlist?list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk)
- [LINQ to XML Tutorial](http://csharp-video-tutorials.blogspot.tw/2014/08/linq-to-xml-tutorial.html)
