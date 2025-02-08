// See https://aka.ms/new-console-template for more information

using System;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        // Инициализация переменных
        string[] dungeonMap = new string[10];
        Random random = new Random();

        int playerHealth = 100;
        int playerGold = 0;
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

        static int OpenChest(int playerGold)
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
                    playerGold +=  30;
                    Console.WriteLine($"Вы открыли сундук и нашли 30 золото!" + "\nУ вас сейчас золота: " + playerGold);

                }
                else
                {
                    Console.WriteLine("Неправильный ответ, сундук закрыт.");
                }


            }
            return playerGold;

        }
        static int Merchant(int playerGold, ref int inventoryCount)
        {
            Console.WriteLine($"Торговец предлагает зелье Лечения за 30 золота. \n У вас сейчас {inventoryCount} зелий и сейчас золота: {playerGold}");
            Console.WriteLine(" 1 - Купить зелье , 2 - Отказаться");
            int weaponChoice = int.Parse(Console.ReadLine());
            if (weaponChoice == 1)
            {
                if (playerGold >= 30)
                {
                    playerGold -= 30;
                    inventoryCount += 1;
                    Console.WriteLine($"Вы купили зелье.\n У вас {inventoryCount} зелий  и {playerGold} денег");
                }
                else
                {
                    Console.WriteLine("У Вас недостаточно золота.");
                }

            }
            else if (weaponChoice == 2)
            {
                Console.WriteLine("Вы отказались");
            }

            return playerGold;
        }

        static int BattleWithMonster1(int playerHealth, ref int inventoryCount)
        {
            Random random = new Random();
            int monsterHealth = random.Next(51, 80);
            Console.WriteLine($"Вы встретили Босса с {monsterHealth} HP!");
            Console.WriteLine($"\n У вас {inventoryCount} зелий ");

            while (playerHealth > 0 && monsterHealth > 0)
            {
              
                Console.WriteLine("Выберите оружие: 1 - Меч, 2 - Лук, 3 - Использовать Зелье Лечения");
                int weaponChoice = int.Parse(Console.ReadLine());
                int damage = 0;
                int playerHealth1 = 0;
                int playerHealth2 = 0;

                if (weaponChoice == 1) // Меч
                {
                    damage = random.Next(10, 25);
                }
                else if (weaponChoice == 2) // Лук
                {
                    // Проверка наличия стрел
                    // Если стрел нет, то нельзя использовать лук
                    damage = random.Next(5, 20);
                }
                else if (weaponChoice == 3 && inventoryCount > 0) // Зелье Лечения
                {
                   
                       
                        playerHealth1 = random.Next(15, 30);
                        playerHealth2 = playerHealth + playerHealth1; 
                        Console.WriteLine($"Вы добавили себе {playerHealth1} HP. Осталось здоровье: {playerHealth2}");
                        inventoryCount--;
                    

                }
                else
                {
                    Console.WriteLine("Вы бездействовали");
                }

                monsterHealth -= damage;
                Console.WriteLine($"Вы нанесли {damage} урона Боссу. Осталось HP: {monsterHealth}");

                if (monsterHealth > 0)
                {
                    int monsterDamage = random.Next(5, 16);
                    if (weaponChoice == 3) // Зелье Лечения
                    {
                        playerHealth = playerHealth2;
                    }
                    playerHealth -= monsterDamage;
                    Console.WriteLine($"Монстр атакует! Вы потеряли {monsterDamage} HP. Осталось здоровье: {playerHealth}");
                }
            }

            return playerHealth;
            
        }


        static int BattleWithMonster(int playerHealth, ref int inventoryCount)
        {
            Random random = new Random();
            int monsterHealth = random.Next(20, 51);
            Console.WriteLine($"Вы встретили монстра с {monsterHealth} HP!");
            Console.WriteLine($"\n У вас {inventoryCount} зелий и {playerHealth} HP ");           

            while (playerHealth > 0 && monsterHealth > 0)
            {

                Console.WriteLine("Выберите оружие: 1 - Меч, 2 - Лук, 3 - Использовать Зелье Лечения");
                int weaponChoice = int.Parse(Console.ReadLine());
                int damage = 0;
                int playerHealth1 = 0;
                int playerHealth2 = 0;
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
                else if (weaponChoice == 3 && inventoryCount > 0) // Зелье Лечения
                {
                   
                       
                        playerHealth1 = random.Next(15, 30);
                        playerHealth2 = playerHealth + playerHealth1;
                        inventoryCount -= 1;
                        Console.WriteLine($"Вы добавили себе {playerHealth1} HP. Осталось здоровье: {playerHealth2} \n зелий у вас осталось {inventoryCount}" );
                        
                    
                    

                }
                else
                    {
                        Console.WriteLine("Вы бездействовали");
                    }
                monsterHealth -= damage;
                Console.WriteLine($"Вы нанесли {damage} урона монстру. Осталось HP: {monsterHealth}");

                if (monsterHealth > 0)
                {
                    int monsterDamage = random.Next(5, 16);
                    if (weaponChoice == 3) // Зелье Лечения
                    {
                        playerHealth = playerHealth2;
                    }

                    playerHealth -= monsterDamage;

                    Console.WriteLine($"Монстр атакует! Вы потеряли {monsterDamage} HP. Осталось здоровье: {playerHealth}");
                }



            }
            return playerHealth;
        }

        // Игровой цикл
        for (int room = 0; room < dungeonMap.Length; room++)
        {
            Console.WriteLine($"Вы вошли в комнату {room + 1}: {dungeonMap[room]}");

            switch (dungeonMap[room])
            {
                case "Monster":
                    playerHealth = BattleWithMonster(playerHealth, ref inventoryCount);
                    if (playerHealth <= 0) return;// Конец игры

                    playerGold +=  30; // Конец рунда
                    Console.WriteLine($"Вы победили монстра.\n Вы нашли у него 30 золота \n У вас {inventoryCount} зелий  и {playerGold} денег");
                    break;

                case "Trap":
                    playerHealth -= random.Next(10, 21);
                    Console.WriteLine($"Вы попали в ловушку! Ваше здоровье: {playerHealth}");
                    if (playerHealth <= 0) return; // Конец игры
                    break;

                case "Chest":
                    playerGold = OpenChest(playerGold);
                    break;

                case "Merchant":
                    playerGold = Merchant(playerGold, ref  inventoryCount);
                    break;

                case "Empty":
                    Console.WriteLine("Комната пустая, ничего не происходит.");
                    break;

                case "Boss":
                    Console.WriteLine("Вы встретили босса!");
                    playerHealth = BattleWithMonster1(playerHealth, ref inventoryCount);
                    if (playerHealth <= 0) return;
                    
                    Console.WriteLine($"Вы победили Босса.\n  У вас осталось {inventoryCount} зелий  и {playerGold} денег");// Конец игры // Логика боя с боссом
                    break;
            }

        }
    }
}
    

