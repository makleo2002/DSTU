using System;
using System.Collections.Generic;

static List<List<int>> CMP(int N,int M, int[] tasks)
{
    Console.WriteLine("CMP:");
    List<List<int>> crit_matrix = new List<List<int>>(N);


    Console.WriteLine("\nНачальная матрица:");
    Console.WriteLine("====================================================");
    Console.WriteLine("| Процессор |                Задания              |");
    Console.WriteLine("====================================================");
    for (int i = 0; i < N; i++)
    {
        Console.Write("|    {0,-5}", (i + 1));
        Console.Write("  |");
        for (int j = 0; j < M; j++)
            Console.Write(" " + tasks[j] + " ");
        Console.Write("           |");
        Console.WriteLine();
    }
    Console.WriteLine("===================================================");
    Console.ReadLine();

    Array.Sort(tasks);//сортировка по убыванию
    Array.Reverse(tasks);


    Console.WriteLine("\nМатрица после сортировки:");
    Console.WriteLine("====================================================");
    Console.WriteLine("| Процессор |                Задания              |");
    Console.WriteLine("====================================================");
    for (int i = 0; i < N; i++)
    {
        Console.Write("|    {0,-5}", (i + 1));
        Console.Write("  |");
        for (int j = 0; j < M; j++)
            Console.Write(" " + tasks[j] + " ");
        Console.Write("           |");
        Console.WriteLine();
    }
    Console.WriteLine("===================================================");
    Console.ReadLine();

    for (int i = 0; i < N; i++)//добавляем пустые списки
        crit_matrix.Add(new List<int>());

    crit_matrix[0].Add(tasks[0]);//добавляем первое задание

    for (int i = 1; i < M; i++)
    {
        int min_sum = int.MaxValue;
        int min_ind = 0;

        for (int j = 0; j < N; j++)
        {
            for (int k = 0; k < crit_matrix[j].Count + 1; k++)
            {
                List<int> temp = new List<int>(crit_matrix[j]);//сохраняем наш текущий список в переменную temp
                temp.Insert(k, tasks[i]);

                int sum = 0;
                foreach (int num in temp)// вычисляем нагрузку
                    sum += num;

                if (sum < min_sum)//смотрим меньше ли она, чем min_sum, если да, то запоминаем индекс и сумму
                {
                    min_sum = sum;
                    min_ind = j;
                }
            }
        }

        crit_matrix[min_ind].Insert(min_ind == 0 ? crit_matrix[min_ind].Count : 0, tasks[i]);//добавляем по мин.индексу задание
    }

    
   



Console.WriteLine("\nКритическая матрица:");
Console.WriteLine("======================================================================================");
Console.WriteLine("| Процессор |                  Задания                   |   Оптимальная нагрузка    |");
Console.WriteLine("======================================================================================");

int max_load = 0;
for (int i = 0; i < N; i++)
{
    Console.Write("|     {0,-5} |", i + 1);
    foreach (int num in crit_matrix[i])
        Console.Write("{0,5}", num);
    int load = 0;
    foreach (int num in crit_matrix[i])
        load += num;
    if (load > max_load)
        max_load = load;
        Console.Write("{0,30}", "|");
    Console.Write("{0,-6}               |", load);
    Console.Write("\n--------------------------------------------");
    Console.WriteLine("------------------------------------------");
}

Console.WriteLine("\nМаксимальная нагрузка на процессоре: {0}", max_load);
    return crit_matrix;
}

static int FindMinProc(List<List<int>> matrix)
{
    int min = int.MaxValue;
    int index = 0;
    for (int i = 0; i < matrix.Count; i++)
    {
        int sum = matrix[i].Sum();
        if (sum < min) {
            min = sum;
            index= i;
        } 
    }
    return index;
}
static void HDMT(int N,int M, int[] tasks)
{
    if (N % 2 != 0) return;

    Console.WriteLine("HDMT:");
    Console.WriteLine("\nНачальная матрица:");
    Console.WriteLine("====================================================");
    Console.WriteLine("| Процессор |                Задания              |");
    Console.WriteLine("====================================================");

    for (int i = 0; i < N; i++)
    {
        Console.Write("|    {0,-5}", (i + 1));
        Console.Write("  |");
        for (int j = 0; j < M; j++)
            Console.Write(" " + tasks[j] + " ");
        Console.Write("           |");
        Console.WriteLine();
    }

    Array.Sort(tasks);//сортировка по убыванию
    Array.Reverse(tasks);

    Console.WriteLine("\nМатрица после сортировки:");
    Console.WriteLine("====================================================");
    Console.WriteLine("| Процессор |                Задания              |");
    Console.WriteLine("====================================================");
    for (int i = 0; i < N; i++)
    {
        Console.Write("|    {0,-5}", (i + 1));
        Console.Write("  |");
        for (int j = 0; j < M; j++)
            Console.Write(" " + tasks[j] + " ");
        Console.Write("           |");
        Console.WriteLine();
    }
    Console.WriteLine("===================================================");
    Console.ReadLine();


    List<List<int>> matrix=new(N/2);

    for (int i = 0; i < N/2; i++)//добавляем пустые списки
        matrix.Add(new List<int>());

    foreach (var task in tasks)
    {
        int index = FindMinProc(matrix);
        matrix[index].Add(task);
    }
    for(int i = 0; i < matrix.Count; i++)
        Console.WriteLine("Нагрузка на процессор " + i + " - " + matrix[i].Sum());

    Console.WriteLine("Второй уровень");
    List<List<int>> matrix1 = new(N);
    foreach (var proc in matrix)
    {
        List<List<int>> group = new(2);

        for (int i = 0; i < 2; i++)//добавляем пустые списки
            group.Add(new List<int>());
       
        for (int t=0;t<proc.Count;t++)
        {
            int index = FindMinProc(group);
            group[index].Add(proc[t]);
        }
        matrix1.Add(group[0]);
        matrix1.Add(group[1]);
    }
    Console.WriteLine("\n Конечная матрица:");
    Console.WriteLine("======================================================================================");
    Console.WriteLine("| Процессор |                  Задания                   |   Оптимальная нагрузка    |");
    Console.WriteLine("======================================================================================");
    for (int i = 0; i < N; i++)
    {
        Console.Write("|     {0,-5} |", i + 1);
        foreach (int num in matrix1[i])
            Console.Write("{0,5}", num);
        Console.Write("{0,30}", "|");
        Console.Write("{0,-6}               |", matrix1[i].Sum());
        Console.Write("\n--------------------------------------------");
        Console.WriteLine("------------------------------------------");
    }

    int max_load = int.MinValue;
    for(int i = 0; i < matrix1.Count; i++)
    {
        if (matrix1[i].Sum() > max_load) max_load = matrix1[i].Sum();
    }
    Console.WriteLine("Максимальная нагрузка "+max_load);

}
static int[] Randomize(int M,int t1,int t2)
{
    int[] tasks = new int[M];
    Random rnd = new Random();

    for (int i = 0; i < M; i++)
    {
        tasks[i] = rnd.Next(t1, t2 + 1);
    }
    return tasks;
}

int[] tasks = Randomize(14, 10, 20);
CMP(4, 14, tasks);
//HDMT(4, 14, tasks);
