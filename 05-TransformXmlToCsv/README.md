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

### 轉換成 CSV

如何將 XML 資料轉換成 CSV 格式，這個轉換其實就是在玩字串組合的遊戲，將 XML 的資料內容讀取出來後，組成我們想要的格式，下面的範例將轉換成 `,` 當作分隔符號的 CSV 格式：

```csharp
const string delimiter = ",";
xmlDocument.Descendants("Student")
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
```

> 請參考 `05-TransformXmlToCsv` 專案的 [Program.cs](https://github.com/poychang/Demo-Linq-To-Xml/blob/master/05-TransformXmlToCsv/Program.cs)

---

參考資料：

- [LINQ to XML (C#)](https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/concepts/linq/linq-to-xml)
- [YouTube - LINQ to XML Tutorial](https://www.youtube.com/playlist?list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk)
- [LINQ to XML Tutorial](http://csharp-video-tutorials.blogspot.tw/2014/08/linq-to-xml-tutorial.html)
