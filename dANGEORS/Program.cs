// See https://aka.ms/new-console-template for more information
static int BattleWithMonster(int playerHealth)
{
    Random random = new Random();
    int monsterHealth = random.Next(20, 51);
    Console.WriteLine($"Вы встретили монстра с {monsterHealth} HP!");

    while (playerHealth > 0 && monsterHealth > 0)
    {
        Console.WriteLine("Выберите оружие: 1 - Меч, 2 - Лук");
        int weaponChoice = int.Parse(Console.ReadLine());
        int damage = 0;

        if (weaponChoice == 1) // Меч
        {
            damage = random.Next(10, 21);
        }
        else if (weaponChoice == 2) // Лук
        {
            // Проверка наличия стрел
            // Если стрел нет, то нельзя использовать лук
            damage = random.Next(5, 16);
        }

        monsterHealth -= damage;
        Console.WriteLine($"Вы нанесли {damage} урона монстру. Осталось HP: {monsterHealth}");

        if (monsterHealth > 0)
        {
            int monsterDamage = random.Next(5, 16);
            playerHealth -= monsterDamage;
            Console.WriteLine($"Монстр атакует! Вы потеряли {monsterDamage} HP. Осталось здоровье: {playerHealth}");
        }
    }

    return playerHealth;
}

static void OpenChest()
{
    Random random = new Random();

    // Генерация двух случайных чисел
    int number1 = random.Next(0, 101);
    int number2 = random.Next(0, 101);

    // Формирование задачи
    Console.WriteLine($"{number1} + {number2} = ?");

    // Получение ответа от пользователя
    string userInput = Console.ReadLine();
    int userAnswer;

    // Проверка, является ли ввод числом
    if (int.TryParse(userInput, out userAnswer))
    {
        // Проверка правильности ответа
        if (userAnswer == number1 + number2)
        {
            Console.WriteLine("Вы открыли сундук и нашли золото!");
        }
        else
        {
            Console.WriteLine("Неправильный ответ, сундук закрыт.");
        }


    }


}
}
