В воскресенье Вася пошел в кружок робототехники и увидел там такой код управления боевым роботом:

```csharp
public static bool ShouldFire(bool enemyInFront, string enemyName, int robotHealth)
{
    bool shouldFire = true;
    if (enemyInFront == true)
    {
        if (enemyName == "boss")
        {
            if (robotHealth < 50) shouldFire = false;
            if (robotHealth > 100) shouldFire = true;
        }
    }
    else
    {
        return false;
    }
    return shouldFire;
}
```

Код показался Васе слишком длинным, а к тому же еще и неряшливым. Вася поспорил с автором, что сможет написать функцию,
делающую ровно то же самое, но всего в один оператор.
Кажется, Вася погорячился... Или нет? Помогите ему не проиграть в споре!