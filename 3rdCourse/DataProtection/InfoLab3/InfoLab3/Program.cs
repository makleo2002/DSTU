using System;
const int N = 5, M = 3;
string[] users = { "Ivan", "Sergey", "Boris" };

int[] S = new int[M];
int[] O = new int[N];
string[] L = new string[3] { "Совершенно секретно", "Секретно", "Открытые данные" };

Random rnd = new Random();
for (int i = 0; i < M; i++)
{
            S[i] = rnd.Next(0, 3);
}
for (int i = 0; i < N; i++)
{
            O[i] = rnd.Next(0, 3);
}
Console.WriteLine("Уровни допуска пользователей: ");
for (int i = 0; i < M; i++)
{
    Console.WriteLine(users[i] + ": " + L[S[i]]);
}
Console.WriteLine("Уровни конфиденциальности объектов: ");
for (int i = 0; i < N; i++)
{
    Console.WriteLine("Объект_" + (i+1) + ": " + L[O[i]]);
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
    Console.WriteLine("Перечень доступных объектов:");
    for (int i = 0; i < N; i++)
    {
        if (S[userId] <= O[i])
        {
            Console.Write("Объект_" + (i+1));
            if (i != N - 1) Console.Write(",");
        }
        
    }
    Console.WriteLine();
    // Цикл выполнения действий пользователя
    while (true)
    {
        // Запрос действия пользователя
        Console.Write("Введите действие (request, quit)> ");
        string action = Console.ReadLine();

        if (action == "request")
        {
            Console.WriteLine("К какому объекту совершить доступ?");
            int num = int.Parse(Console.ReadLine())-1;
            if (num < 0 || num >= N) Console.WriteLine("Такого объекта не существует");
            else
            {
                if (S[userId] <= O[num]) Console.WriteLine("Операция прошла успешно");
                else Console.WriteLine("Недостаточно прав для выполнения операции");
            }
            
        }
        // Выход из системы
        else if (action == "quit")
        {
            Console.WriteLine("Работа пользователя "+userInput+" завершена.");
            break;
        }
        else
        {
            Console.WriteLine("Ошибка: введена некорректная команда!");
        }
    }
}