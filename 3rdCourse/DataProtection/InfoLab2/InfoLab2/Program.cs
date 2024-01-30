using System;
const int N = 5, M = 3;
string[] users = { "Ivan", "Sergey", "Boris" };

int[,] accessMatrix = new int[M, N];

Random rnd = new Random();
for (int i = 0; i < M; i++)
{
    for (int j = 0; j < N; j++)
    {
        if (i == 0) // Администратор системы имеет полный доступ ко всем объектам
        {
            accessMatrix[i, j] = 7;
        }
        else
        {
            accessMatrix[i, j] = rnd.Next(0, 8);
        }
    }
}
while (true)
{
    Console.Write("Введите идентификатор пользователя: ");
    string userInput = Console.ReadLine();

    // Поиск пользователя в списке
    int userId = Array.IndexOf(users, userInput);
    if (userId == -1)
    {
        Console.WriteLine("Пользователь не найден.");
        continue; // Перейти к следующей итерации цикла while
    }

    // Вход в систему успешен
    Console.WriteLine("Добро пожаловать, {0}!", userInput);

    // Вывод списка объектов с правами доступа
    Console.WriteLine("Объекты и права доступа:");
    Console.WriteLine("-----------------------");
    for (int i = 0; i < N; i++)
    {
        string objName = "Объект " + (i + 1);
        int userAccess = accessMatrix[userId, i];
        string accessString = Convert.ToString(userAccess, 2).PadLeft(3, '0');
        Console.WriteLine("{0}: {1}", objName, accessString);
    }
    Console.WriteLine("-----------------------");

    // Цикл выполнения действий пользователя
    while (true)
    {
        // Запрос действия пользователя
        Console.Write("Введите действие (read, write, grant, quit): ");
        string action = Console.ReadLine();

        if (action == "read")
        {
            Console.WriteLine("Над каким объектом производится операция?");
            int objIndex = int.Parse(Console.ReadLine()) - 1;
            if (((accessMatrix[userId, objIndex] >> 2) & 1) == 1) Console.WriteLine("Доступ на чтение разрешен.");
            else Console.WriteLine("У Вас нет прав для ее осуществления");
        }
        else if (action == "write")
        {
            Console.WriteLine("Над каким объектом производится операция?");
            int objIndex = int.Parse(Console.ReadLine())-1;
            if (((accessMatrix[userId, objIndex] >> 1) & 1) == 1)
                Console.WriteLine("Доступ на запись разрешен.");
            else Console.WriteLine("У Вас нет прав для ее осуществления");
        }
        else if (action == "grant")
        {
            Console.WriteLine("Введите номер объекта, для которого нужно изменить права доступа:");
            int objIndex = int.Parse(Console.ReadLine()) - 1;
            if (((accessMatrix[userId, objIndex] >> 0) & 1) == 1) {
                Console.WriteLine("Доступ на передачу прав разрешен");
                bool error = false;
                Console.WriteLine("Введите идентификатор пользователя, которому нужно выдать права доступа:");
                string grantee = Console.ReadLine();
                if (!users.Contains(grantee))
                {
                    Console.WriteLine("Ошибка: введен некорректный идентификатор пользователя!");
                    error = true;
                }
                Console.WriteLine("Введите права доступа (3-битное число):");
                int accessRights = int.Parse(Console.ReadLine());
                
                if (accessRights < 0 || accessRights > 7)
                {
                    Console.WriteLine("Ошибка: введены некорректные права доступа!");
                    error = true;
                }
                if(!error)
                {
                    //присваиваем права пользователю
                    accessMatrix[Array.IndexOf(users, grantee), objIndex] = accessRights;
                    Console.WriteLine($"Права доступа для пользователя {grantee} к объекту {objIndex + 1} изменены.");
                }

            }
            else Console.WriteLine("Доступ на передачу прав не разрешен");
        }
        // Выход из системы
        else if (action == "quit")
        {
            Console.WriteLine("Выход из системы.");
            break;
        }
        else
        {
            Console.WriteLine("Ошибка: введена некорректная команда!");
        }
    }
}