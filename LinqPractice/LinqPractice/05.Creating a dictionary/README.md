# Составление словаря

Текст задан массивом строк. Вам нужно составить лексикографически упорядоченный список всех встречающихся в этом тексте слов.

Слова нужно сравнивать регистронезависимо, а выводить в нижнем регистре.

```csharp
public static void Main()
{
	var vocabulary = GetSortedWords(
		"Hello, hello, hello, how low",
		"",
		"With the lights out, it's less dangerous",
		"Here we are now; entertain us",
		"I feel stupid and contagious",
		"Here we are now; entertain us",
		"A mulatto, an albino, a mosquito, my libido...",
		"Yeah, hey"
	);
	foreach (var word in vocabulary)
		Console.WriteLine(word);
}
```

## Решение

```csharp
public static string[] GetSortedWords(params string[] textLines)
{
	return textLines
		.SelectMany(s => s.Split(new char[] { ' ', ',', '\'', '.', ';' }, StringSplitOptions.RemoveEmptyEntries))
		.Select(w => w.ToLower())
    	.OrderBy(w => w)
    	.Distinct()
    	.ToArray();
}
```