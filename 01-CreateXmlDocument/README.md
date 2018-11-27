# LINQ to XML - 基本操作

XML(eXtensible Markup Language) 可擴展標記語言常作為各種資訊交換用的通訊格式，例如用於 SOAP 通訊協定，其豐富的描述讓資料資訊表達得更完整（當然資料本身也變得比較複雜些），.Net Team 提供了方便操作 XML 的工具 [System.Xml.Linq](https://docs.microsoft.com/zh-tw/dotnet/api/system.xml.linq) 也就是 LINQ to XML，這篇介紹 LINQ to XML 的基本操作。

目錄：

- [基本操作](https://poychang.github.io/linq-to-xml-basic-usage/)
- [建立 XML 檔案](https://poychang.github.io/linq-to-xml-create-xml-file)
- [查詢 XML 資料](https://poychang.github.io/linq-to-xml-query-xml/)
- [修改 XML 資料](https://poychang.github.io/linq-to-xml-edit-xml)
- [轉換 XML 資料](https://poychang.github.io/linq-to-xml-transfom-xml)
- [驗證 XML 資料](https://poychang.github.io/linq-to-xml-validate-xml)
- [取得 CDATA 資料](https://poychang.github.io/2018-02-05-linq-to-xml-extract-data-from-cdata)

> 系列文完整範例程式碼請參考 [poychang/Demo-Linq-To-Xml](https://github.com/poychang/Demo-Linq-To-Xml)。

## LINQ to XML 類別

常見的 LINQ to XML 類別如下圖：

![常見的 LINQ to XML 類別](https://i.imgur.com/ib68hkU.png)

- `XDocument` 代表整份 XML 文件
- `XDeclaration` 代表 XML 宣告，告用於宣告 XML 版本與文件的編碼
- `XComment` 代表 XML 註解
- `XElement` 代表 XML 元素，內容可為資料或另一個 XML 元素
- `XAttribute` 代表 XML 屬性

更多 LINQ to XML 類別請參考[這份文件](https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/concepts/linq/linq-to-xml-classes-overview)

## 基本操作

LINQ to XML 屬於記憶體內操作 XML 資料，因此在做任何操作前，都必須先載入 XML 資料至記憶體中，使用 `XDocuments.Load()` 進行載入：

```csharp
// 載入 sample.xml 檔
XDocument xmlDocument = XDocuments.Load("sample.xml");
```

取得節點內特定單一元素，可使用 `Element()`，若要取得節點內多元素，則使用 `Elements()`，這裡會取得 `IEnumerable<XElement>` 資料型別的列舉資料：

```csharp
// 取得單一元素
XElement element = xmlDocument.Element("Node");
// 取得多元素
IEnumerable<XElement> elements = xmlDocument.Elements("Nodes");
```

有時候 XML 元素會設定屬性值，可使用 `Attribute()` 來取得屬性值：

```csharp
// 取得指定屬性值
XAttribute att = element.Attribute("AttributeName");
```

取得元素後，若要調用元素內所包含的值，可使用 `Value` 來取得：

```csharp
XElement element = xmlDocument.Element("Node");
string value = element.Value;
```

## 注意事項

在使用 LINQ to XML 進行資料操作的時候，請隨時注意會不會因為 XML 資料中沒有該元素，造成 NullException。因此在此系列文的範例程式碼 [poychang/Demo-Linq-To-Xml](https://github.com/poychang/Demo-Linq-To-Xml) 中，會用到很多 [Null 條件運算子](https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/operators/null-conditional-operators)，用來測試是否為 Null，若為 Null 就不繼續往下操作。

---

參考資料：

- [LINQ to XML (C#)](https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/concepts/linq/linq-to-xml)
- [Wiki - XML](https://zh.wikipedia.org/wiki/XML)
- [Linq to XML 讀取 XML 檔](http://bennett.logdown.com/posts/241690-c-linq-for-xml)
