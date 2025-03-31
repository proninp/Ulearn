# Чтение списка точек

В файле в каждой строке написаны две координаты точки (X, Y), разделенные пробелом. Кто-то уже вызвал метод `File.ReadLines(filename)` и теперь у вас есть массив всех строк файла.

```csharp
public static void Main()
{
	// Функция тестирования ParsePoints

	foreach (var point in ParsePoints(new[] { "1 -2", "-3 4", "0 2" }))
		Console.WriteLine(point.X + " " + point.Y);
	foreach (var point in ParsePoints(new List<string> { "+01 -0042" }))
		Console.WriteLine(point.X + " " + point.Y);
}

public class Point
{
	public Point(int x, int y)
	{
		X = x;
		Y = y;
	}
	public int X, Y;
}
```

Реализуйте метод `ParsePoints` в одно `LINQ`-выражение.

Постарайтесь не использовать функцию преобразования строки в число более одного раза.

## Решение

```csharp
public static List<Point> ParsePoints(IEnumerable<string> lines)
{
	return lines
		.Select(l => new Point(int.Parse(l.Split(' ')[0]), int.Parse(l.Split(' ')[1])))
		.ToList();
}
```