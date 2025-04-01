# Объединение коллекций

Вам дан список всех классов в школе. Нужно получить список всех учащихся всех классов.

Учебный класс определен так:

```csharp
public class Classroom
{
	public List<string> Students = new List<string>();
}
```

Без использования `LINQ` решение могло бы выглядеть так:

```csharp
var allStudents = new List<string>();
foreach (var classroom in classes)
{
	foreach (var student in classroom.Students)
	{
		allStudents.Add(student);
	}
}
return allStudents.ToArray();
```

Напишите решение этой задачи с помощью `LINQ` в одно выражение.

```csharp
public static void Main()
{
	Classroom[] classes =
	{
		new Classroom {Students = {"Pavel", "Ivan", "Petr"},},
		new Classroom {Students = {"Anna", "Ilya", "Vladimir"},},
		new Classroom {Students = {"Bulat", "Alex", "Galina"},}
	};
	var allStudents = GetAllStudents(classes);
	Array.Sort(allStudents);
	Console.WriteLine(string.Join(" ", allStudents));
}
```

## Решение

```csharp
public static string[] GetAllStudents(Classroom[] classes)
{
	return classes.SelectMany(c => c.Students).ToArray();
}
```