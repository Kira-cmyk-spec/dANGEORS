// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main(string[] args)
    {
        // Инициализация переменных
        string[] dungeonMap = new string[10];
        Random random = new Random();

        int playerHealth = 100;
        int playerGold = 50;
        string[] inventory = new string[5];
        int inventoryCount = 0;

        // Заполнение карты подземелья
        for (int i = 0; i < dungeonMap.Length - 1; i++)
        {
            int eventType = random.Next(0, 5); // 0-4 для различных событий
            switch (eventType)
            {
                case 0: dungeonMap[i] = "Monster"; break; // Монстр
                case 1: dungeonMap[i] = "Trap"; break; // Ловушка
                case 2: dungeonMap[i] = "Chest"; break;// Сундук
                case 3: dungeonMap[i] = "Merchant"; break;// Торговец
                case 4: dungeonMap[i] = "Empty"; break;// Пусто
            }
        }
        dungeonMap[9] = "Boss"; // Босс в 10-й комнате
        static int Merchant(int playerGold)
        {
            Console.WriteLine("Торговец предлагает зелье за 30 золота.");
            if (playerGold >= 30)
            {
                playerGold -= 30;
                Console.WriteLine("Вы купили зелье.");
            }
            else
            {
                Console.WriteLine("У Вас недостаточно золота.");
            }
            return playerGold;
        }
        // Игровой цикл
        for (int room = 0; room < dungeonMap.Length; room++)
        {
            Console.WriteLine($"Вы вошли в комнату {room + 1}: {dungeonMap[room]}");

            switch (dungeonMap[room])
            {
                case "Monster":
                    playerHealth = BattleWithMonster(playerHealth);
                    if (playerHealth <= 0) return; // Конец игры
                    break;

                case "Trap":
                    playerHealth -= random.Next(10, 21);
                    Console.WriteLine($"Вы попали в ловушку! Ваше здоровье: {playerHealth}");
                    if (playerHealth <= 0) return; // Конец игры
                    break;

                case "Chest":
                    OpenChest();
                    break;

                case "Merchant":
                    playerGold = Merchant(playerGold);
                    break;

                case "Empty":
                    Console.WriteLine("Комната пустая, ничего не происходит.");
                    break;

                case "Boss":
                    Console.WriteLine("Вы встретили босса!");
                    playerHealth = BattleWithMonster1(playerHealth);
                    if (playerHealth <= 0) return; // Конец игры // Логика боя с боссом
                    break;
            }
        }
    }
    static int BattleWithMonster1(int playerHealth)
    {
        Random random = new Random();
        int monsterHealth = random.Next(51, 80);
        Console.WriteLine($"Вы встретили Босса с {monsterHealth} HP!");

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
            Console.WriteLine($"Вы нанесли {damage} урона Боссу. Осталось HP: {monsterHealth}");

            if (monsterHealth > 0)
            {
                int monsterDamage = random.Next(5, 16);
                playerHealth -= monsterDamage;
                Console.WriteLine($"Монстр атакует! Вы потеряли {monsterDamage} HP. Осталось здоровье: {playerHealth}");
            }
        }

        return playerHealth;
    }

   
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

