# Создание частотного словаря

Дан текст, нужно вывести `count` наиболее часто встречающихся в тексте слов вместе с их частотой. Среди слов, встречающихся одинаково часто, отдавать предпочтение лексикографически меньшим словам. Слова сравнивать регистронезависимо и выводить в нижнем регистре.

Напомним сигнатуры некоторых `LINQ`-методов, которые могут понадобиться в этом упражнении:

```
IEnumerable<IGrouping<K, T>>    GroupBy(this IEnumerable<T> items, Func<T, K> keySelector)
IOrderedEnumerable<T>           OrderBy(this IEnumerable<T> items, Func<T, K> keySelector)
IOrderedEnumerable<T> OrderByDescending(this IEnumerable<T> items, Func<T, K> keySelector)
IOrderedEnumerable<T>            ThenBy(this IOrderedEnumerable<T> items, Func<T, K> keySelector)
IOrderedEnumerable<T>  ThenByDescending(this IOrderedEnumerable<T> items, Func<T, K> keySelector)
IEnumerable<T>                     Take(this IEnumerable<T> items, int count)
```

## Решение

```csharp
public static Tuple<string, int>[] GetMostFrequentWords(string text, int count)
{
	return Regex.Split(text.ToLower(), @"\W+")
		.Where(word => word != "")
		.GroupBy(w => w)
		.OrderByDescending(g => g.Count())
		.ThenBy(g => g.Key)
		.Select(g => Tuple.Create(g.Key, g.Count()))
		.Take(count)
		.ToArray();
}
```