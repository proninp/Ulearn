# Сортировка кортежей

Еще одно полезное свойство кортежей — они реализуют интерфейс `IComparable`,

сравнивающий кортежи по компонентам. То есть `Tuple.Create(1, 2)` будет меньше `Tuple.Create(2, 1)`. Этот интерфейс по умолчанию используется в методах сортировки и поиска минимума и максимума.

Используя этот факт, решите следующую задачу.

Дан текст, нужно составить список всех встречающихся в тексте слов, упорядоченный сначала по возрастанию длины слова, а потом лексикографически.

Запрещено использовать `ThenBy` и `ThenByDescending`.

## Решение

```csharp
public static List<string>  GetSortedWords(string text)
{
	return text.Split(new char[] {' ', ',', '\'', '.', ';'}, StringSplitOptions.RemoveEmptyEntries)
    	.Select(w => Tuple.Create(w.ToLower()))
    	.OrderBy(t => t)
		.Select(t => t.Item1)
		.Distinct()
    	.OrderBy(w => w.Length)
    	.ToList();
}
```