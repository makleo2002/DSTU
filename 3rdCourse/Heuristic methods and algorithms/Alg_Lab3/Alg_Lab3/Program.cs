using System.ComponentModel.Design.Serialization;
static List<List<int>> Schedule(int[] tasks, int N, int M,int select)
{

    List<List<int>> Schedule = new List<List<int>>();
    List<List<int>> oldMatrix=new();


// Первый этап

if (select == 0) 
{
    var rnd = new Random();
    for (int i = 0; i < N; i++)
    {
        Schedule.Add(new List<int>());
    }
    for (int j = 0; j < M; j++)
    {
        var pi = rnd.Next(0, N);
        Schedule[pi].Add(tasks[j]);
    }

    for (int i = 0; i < Schedule.Count; i++)
    {
        oldMatrix.Add(Schedule[i].ToList());
    }

}
 if(select==1) { Schedule = CMP(N, M, tasks); }


Console.WriteLine("Начальная матрица:");
    int maxScheduleCount = int.MinValue;
    for(int i = 0; i < N; i++)
    {
        if (Schedule[i].Count > maxScheduleCount) maxScheduleCount = Schedule[i].Count;
    }
    for (int i = 0; i < Schedule.Count; i++)
    {
        Console.Write("{0}\t", "p" + i + " |");
        int j;
        for (j = 0; j < Schedule[i].Count; j++)
        {
            Console.Write("{0}\t", Schedule[i][j]);
        }
        for (; j < maxScheduleCount; j++)
        {
            Console.Write("\t");
        }
        Console.Write("|" + Schedule[i].Sum());
        Console.WriteLine();
    }

    var loads = new int[N];
    Console.ReadLine();
    // Второй этап
    while (true)
    {
        
        // Шаг 1
        loads = new int[N];
        for (int i = 0; i < N; i++)
        {
            loads[i] = Schedule[i].Sum();
        }
        // Шаг 2
        int maxLoadIndex = 0;
        int minLoadIndex = 0;
        for (int i = 0; i < N; i++)
        {
            if (loads[i] > loads[maxLoadIndex])
            {
                maxLoadIndex = i;
            }
            if (loads[i] < loads[minLoadIndex])
            {
                minLoadIndex = i;
            }
        }
        Console.WriteLine("Промежуточная матрица:");
        int maxScheduleCount2 = int.MinValue;
        for (int i = 0; i < N; i++)
        {
            if (Schedule[i].Count > maxScheduleCount2) maxScheduleCount2 = Schedule[i].Count;
        }
        for (int i = 0; i < Schedule.Count; i++)
        {
            Console.Write("{0}\t", "p" + i + " |");
            int j;
            for (j = 0; j < Schedule[i].Count; j++)
            {
                Console.Write("{0}\t", Schedule[i][j]);
            }
            for (; j < maxScheduleCount2; j++)
            {
                Console.Write("\t");
            }
            Console.Write("|" + Schedule[i].Sum());
            Console.WriteLine();
        }

       int delta = loads[maxLoadIndex] - loads[minLoadIndex];
        Console.WriteLine("delta:"+delta);
        // Шаг 3
        bool end = true;
        for (int k = 0; k < Schedule[maxLoadIndex].Count && end; k++)
        {
            if (Schedule[maxLoadIndex][k] < delta)
            {
                // Переносим задачу на процессор с меньшей загрузкой
                Schedule[minLoadIndex].Add(Schedule[maxLoadIndex][k]);
                Schedule[maxLoadIndex].RemoveAt(k);
                end = false;
            }
        }
        if (end)
        {
            for (int k = 0; k < Schedule[maxLoadIndex].Count && end; k++)
            {
                m1:
                for (int l = 0; l < Schedule[minLoadIndex].Count; l++)
                {
                    loads = new int[N];
                    for (int i = 0; i < N; i++)
                    {
                        loads[i] = Schedule[i].Sum();
                    }
                     maxLoadIndex = 0;
                     minLoadIndex = 0;
                    for (int i = 0; i < N; i++)
                    {
                       // Console.WriteLine("loads[i]:"+ loads[i]);
                       // Console.WriteLine("loads[maxLoad]:" + loads[maxLoadIndex]);
                      //  Console.WriteLine("maxLoad:" + maxLoadIndex);
                        if (loads[i] > loads[maxLoadIndex])
                        {
                            maxLoadIndex = i;
                        }
                        if (loads[i] < loads[minLoadIndex])
                        {
                            minLoadIndex = i;
                        }
                    }
                    
                    delta = loads[maxLoadIndex] - loads[minLoadIndex];

                    if (Schedule[maxLoadIndex][k] > Schedule[minLoadIndex][l] &&
                Schedule[maxLoadIndex][k] - Schedule[minLoadIndex][l] < delta)
                    {
                      //  Console.WriteLine("дельта "+delta);
                      //  Console.WriteLine("maxElem: " + Schedule[maxLoadIndex][k]);
                     //   Console.WriteLine("minElem: "+ Schedule[minLoadIndex][l]);

                        // Меняем меcтами задачи
                        var temp = Schedule[minLoadIndex][l];
                        Schedule[minLoadIndex][l] = Schedule[maxLoadIndex][k];
                        Schedule[maxLoadIndex][k] = temp;
                        end = false;
                        goto m1;
                    }
                }

               
            }
        }

        if (end)
        {
            break;
        }
        
    }

    Console.WriteLine("Конечная матрица:");
    int maxScheduleCount1 = int.MinValue;
    for (int i = 0; i < N; i++)
    {
        if (Schedule[i].Count > maxScheduleCount1) maxScheduleCount1 = Schedule[i].Count;
    }
    for (int i = 0; i < Schedule.Count; i++)
    {
        Console.Write("{0}\t", "p" + i + " |");
        int j;
        for (j = 0; j < Schedule[i].Count; j++)
        {
            Console.Write("{0}\t", Schedule[i][j]);
        }
        for (; j < maxScheduleCount1; j++)
        {
            Console.Write("\t");
        }
        Console.Write("|" + Schedule[i].Sum());
        Console.WriteLine();
    }
    Console.WriteLine("\nМаксимальная нагрузка: {0}", loads.Max());
    
    return oldMatrix;
}
static List<List<int>> Schedule1(List<List<int>> oldMatrix, int N, int M)
{
    List<List<int>> Schedule = oldMatrix;
 
    Console.WriteLine("Начальная матрица:");
    int maxScheduleCount = int.MinValue;
    for (int i = 0; i < N; i++)
    {
        if (Schedule[i].Count > maxScheduleCount) maxScheduleCount = Schedule[i].Count;
    }
    for (int i = 0; i < Schedule.Count; i++)
    {
        Console.Write("{0}\t", "p" + i + " |");
        int j;
        for (j = 0; j < Schedule[i].Count; j++)
        {
            Console.Write("{0}\t", Schedule[i][j]);
        }
        for (; j < maxScheduleCount; j++)
        {
            Console.Write("\t");
        }
        Console.Write("|" + Schedule[i].Sum());
        Console.WriteLine();
    }
    var loads = new int[N];
    Console.ReadLine();
    // Второй этап
    while (true)
    {
        // Шаг 1
        loads = new int[N];
        for (int i = 0; i < N; i++)
        {
            loads[i] = Schedule[i].Sum();
        }
        // Шаг 2
        int maxLoadIndex = 0;
        int minLoadIndex = 0;
        for (int i = 0; i < N; i++)
        {
            if (loads[i] > loads[maxLoadIndex])
            {
                maxLoadIndex = i;
            }
            if (loads[i] < loads[minLoadIndex])
            {
                minLoadIndex = i;
            }
        }
        Console.WriteLine("Промежуточная матрица:");
        int maxScheduleCount2 = int.MinValue;
        for (int i = 0; i < N; i++)
        {
            if (Schedule[i].Count > maxScheduleCount2) maxScheduleCount2 = Schedule[i].Count;
        }
        for (int i = 0; i < Schedule.Count; i++)
        {
            Console.Write("{0}\t", "p" + i + " |");
            int j;
            for (j = 0; j < Schedule[i].Count; j++)
            {
                Console.Write("{0}\t", Schedule[i][j]);
            }
            for (; j < maxScheduleCount2; j++)
            {
                Console.Write("\t");
            }
            Console.Write("|" + Schedule[i].Sum());
            Console.WriteLine();
        }

        int delta = loads[maxLoadIndex] - loads[minLoadIndex];
        Console.WriteLine("delta:" + delta);
        // Шаг 3
        bool end = true;
        for (int k = 0; k < Schedule[maxLoadIndex].Count && end; k++)
        {
            if (Schedule[maxLoadIndex][k] < delta)
            {
                // Переносим задачу на процессор с меньшей загрузкой
                Schedule[minLoadIndex].Add(Schedule[maxLoadIndex][k]);
                Schedule[maxLoadIndex].RemoveAt(k);
                end = false;
            }
        }
        if (end)
        {
            for (int k = 0; k < Schedule[maxLoadIndex].Count && end; k++)
            {
                m1:
                for (int l = 0; l < Schedule[minLoadIndex].Count; l++)
                {
                    loads = new int[N];
                    for (int i = 0; i < N; i++)
                    {
                        loads[i] = Schedule[i].Sum();
                    }
                    maxLoadIndex = 0;
                    minLoadIndex = 0;
                    for (int i = 0; i < N; i++)
                    {
                        // Console.WriteLine("loads[i]:"+ loads[i]);
                        // Console.WriteLine("loads[maxLoad]:" + loads[maxLoadIndex]);
                        //  Console.WriteLine("maxLoad:" + maxLoadIndex);
                        if (loads[i] > loads[maxLoadIndex])
                        {
                            maxLoadIndex = i;
                        }
                        if (loads[i] < loads[minLoadIndex])
                        {
                            minLoadIndex = i;
                        }
                    }
                    if (Schedule[maxLoadIndex][k] > Schedule[minLoadIndex][l] &&
                Schedule[maxLoadIndex][k] - Schedule[minLoadIndex][l] < delta)
                    {
                        delta = loads[maxLoadIndex] - loads[minLoadIndex];
                    //    Console.WriteLine("Разница: " + (Schedule[maxLoadIndex][k] - Schedule[minLoadIndex][l]) + "при дельта " + delta);
                     //   Console.WriteLine("maxElem: " + Schedule[maxLoadIndex][k]);
                    //    Console.WriteLine("minElem: " + Schedule[minLoadIndex][l]);

                        // Меняем меcтами задачи
                        var temp = Schedule[minLoadIndex][l];
                        Schedule[minLoadIndex][l] = Schedule[maxLoadIndex][k];
                        Schedule[maxLoadIndex][k] = temp;
                        foreach (List<int> i in Schedule)
                        {
                            i.Sort();
                            i.Reverse();
                        }
                        end = false;
                        goto m1;
                    }
                }

                   
            }
        }

        if (end)
        {
            break;
        }

    }
    Console.WriteLine("Конечная матрица:");
    int maxScheduleCount1 = int.MinValue;
    for (int i = 0; i < N; i++)
    {
        if (Schedule[i].Count > maxScheduleCount1) maxScheduleCount1 = Schedule[i].Count;
    }
    for (int i = 0; i < Schedule.Count; i++)
    {
        Console.Write("{0}\t", "p" + i + " |");
        int j;
        for (j = 0; j < Schedule[i].Count; j++)
        {
            Console.Write("{0}\t", Schedule[i][j]);
        }
        for (; j < maxScheduleCount1; j++)
        {
            Console.Write("\t");
        }
        Console.Write("|" + Schedule[i].Sum());
        Console.WriteLine();
    }
    Console.WriteLine("\nМаксимальная нагрузка: {0}", loads.Max());
    return Schedule;
}
static List<List<int>> CMP(int N, int M, int[] tasks)
{
    Console.WriteLine("CMP:");
    List<List<int>> crit_matrix = new List<List<int>>(N);


    Console.WriteLine("\nНачальная матрица:");
    Console.WriteLine("====================================================");
    Console.WriteLine("| Процессор |                Задания              |");
    Console.WriteLine("====================================================");
    for (int i = 0; i < N; i++)
    {
        Console.Write("|    {0,-5}", (i));
        Console.Write("  |");
        for (int j = 0; j < M; j++)
            Console.Write(" " + tasks[j] + " ");
        Console.Write("           |");
        Console.WriteLine();
    }
    Console.WriteLine("===================================================");
  

    Array.Sort(tasks);//сортировка по убыванию
    Array.Reverse(tasks);


    Console.WriteLine("\nМатрица после сортировки:");
    Console.WriteLine("====================================================");
    Console.WriteLine("| Процессор |                Задания              |");
    Console.WriteLine("====================================================");
    for (int i = 0; i < N; i++)
    {
        Console.Write("|    {0,-5}", (i));
        Console.Write("  |");
        for (int j = 0; j < M; j++)
            Console.Write(" " + tasks[j] + " ");
        Console.Write("           |");
        Console.WriteLine();
    }
    Console.WriteLine("===================================================");


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

        crit_matrix[min_ind].Add(tasks[i]);//добавляем по мин.индексу задание
    }
  
    Console.WriteLine("\nКритическая матрица:");
    Console.WriteLine("======================================================================================");
    Console.WriteLine("| Процессор |                  Задания                   |   Оптимальная нагрузка    |");
    Console.WriteLine("======================================================================================");

    for (int i = 0; i < N; i++)
    {
        Console.Write("|     {0,-5} |", i + 1);
        for (int num=0;num<crit_matrix[i].Count; num++)
            Console.Write("{0,5}", crit_matrix[i][num]);
        int load = 0;
        for (int num = 0; num < crit_matrix[i].Count; num++)
            load += crit_matrix[i][num];
        Console.Write("{0,30}", "|");
        Console.Write("{0,-6}               |", load);
        Console.Write("\n--------------------------------------------");
        Console.WriteLine("------------------------------------------");
    }
    return crit_matrix;
}
static int[] Randomize(int M, int t1, int t2)//генерация массива с рандомными числами
{
    int[] tasks = new int[M];
    Random rnd = new Random();
    for (int i = 0; i < M; i++)
    {
        tasks[i] = rnd.Next(t1, t2 + 1);
    }
    return tasks;
}
int N = 3, M = 11, t1 = 10, t2 = 22;
int[] randMas = Randomize(M, t1, t2);
Console.WriteLine("Массив заданий: ");
foreach (var i in randMas) Console.Write(i+" ");
Console.WriteLine();
Console.WriteLine("Алгоритм Крона: ");
var oldMatrix=Schedule(randMas, N, M, 0);
Console.ReadLine();
Console.WriteLine("\n\nВторая модификация");
Schedule1(oldMatrix, N, M);