# Создание обратного индекса

Обратный индекс — это структура данных, часто использующаяся в задачах полнотекстового поиска нужного документа в большой базе документов.

По своей сути обратный индекс напоминает индекс в конце бумажных энциклопедий,
где для каждого ключевого слова указан список страниц, где оно встречается.

Вам требуется по списку документов построить обратный индекс.

Документ определен так:
```cs
public class Document
{
	public int Id;
	public string Text;
}
```
Обратный индекс в нашем случае — это словарь `ILookup<string, int>`, ключом в котором является слово, а значениями — идентификаторы всех документов, содержащих это слово.

```cs
public static void Main()
{
	Document[] documents =
	{
		new Document {Id = 1, Text = "Hello world!"},
		new Document {Id = 2, Text = "World, world, world... Just words..."},
		new Document {Id = 3, Text = "Words — power"},
		new Document {Id = 4, Text = ""}
	};
	var index = BuildInvertedIndex(documents);
	SearchQuery("world", index);
	SearchQuery("words", index);
	SearchQuery("power", index);
	SearchQuery("cthulhu", index);
	SearchQuery("", index);
}
```

## Решение

```cs
public static ILookup<string, int> BuildInvertedIndex(Document[] documents)
{
	return documents
		.SelectMany(d => Regex.Split(d.Text.ToLower(), @"\W+").Where(w => w != ""), (d, word) => (d.Id, word))
		.Distinct()
		.ToLookup(t => t.word, t => t.Id);
}
```