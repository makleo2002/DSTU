using System.Linq.Expressions;

static int[] СheckSum(int[,] matrix)//проверяем сумму для строки
{
    int[] rowSums = new int[matrix.GetLength(1)];//matrix.GetLength(1)=M
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)//matrix.GetLength(0)=N
        {
            rowSums[i] += matrix[j,i];
        }
    }
    return rowSums;//массив сумм строк
}
static int[,] SwapDescending(int[] rowSums, int[,] matrix)//сортировка по убыванию
{
    // Выполняем перестановку строк матрицы в порядке убывания сумм их строк
    for (int i = 0; i < rowSums.Length - 1; i++)
    {
        for (int j = i + 1; j < rowSums.Length; j++)
        {
            if (rowSums[j] > rowSums[i])
            {
                // Обмениваем строки матрицы
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    int temp = matrix[k, i];
                    matrix[k, i] = matrix[k, j];
                    matrix[k, j] = temp;
                }
                // Обмениваем значения сумм строк
                int tempSum = rowSums[i];
                rowSums[i] = rowSums[j];
                rowSums[j] = tempSum;
            }
        }
    }
    Console.Write("Сортировка ");
    Console.WriteLine("по убыванию:");
    format(matrix.GetLength(0));
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        Console.Write("{0}\t", i + " |");
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            Console.Write("{0}\t", matrix[j, i]);
        }
        Console.WriteLine("|" + rowSums[i] + " ");
    }
    Console.ReadLine();
    return matrix;
}
static int[,] SwapAscending(int[] rowSums, int[,] matrix)//сортировка по возрастанию
{
    // Выполняем перестановку строк матрицы в порядке возрастания сумм их строк
    for (int i = 0; i < rowSums.Length - 1; i++)
    {
        for (int j = i + 1; j < rowSums.Length; j++)
        {
            if (rowSums[j] < rowSums[i])
            {
                // Обмениваем строки матрицы
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    int temp = matrix[k, i];
                    matrix[k, i] = matrix[k, j];
                    matrix[k, j] = temp;
                }
            // Обмениваем значения сумм строк
            int tempSum = rowSums[i];
                rowSums[i] = rowSums[j];
                rowSums[j] = tempSum;
            }
        }
    }
    Console.Write("Сортировка ");
    Console.WriteLine("по возрастанию:");
    format(matrix.GetLength(0));
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        Console.Write("{0}\t", i + " |");
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            Console.Write("{0}\t", matrix[j, i]);
        }
        Console.WriteLine("|" + rowSums[i] + " ");
    }
    Console.ReadLine();
    return matrix;
}
static void format(int N)
{
    Console.Write("{0}\t", " ");
    for (int j = 0; j < N; j++)
        Console.Write("{0}\t", "p" + j);
    Console.Write("{0}\t", " Sum");
    Console.WriteLine();
}
static List<List<int>> SetOrdinary(int[,] matrix1)
{
    int N = matrix1.GetLength(0);
    int M = matrix1.GetLength(1);
    // Создаем новую матрицу и копируем в нее все значения из исходной матрицы
    int[][] matrix = new int[N][];
    for (int i = 0; i < N; i++)
    {
        matrix[i] = new int[M];
        for (int j = 0; j < M; j++)
        {
            matrix[i][j] = matrix1[i, j];
        }
    }
   
    // Создаем массив для хранения сумм элементов каждой строки
    List<List<int>> procMas = new(N);
    for (int i = 0; i < N; i++)
    {
        procMas.Add(new List<int>(0));
    }
    // Проходимся по всем столбцам матрицы
    for (int i = 0; i < M; i++)
    {
        // Находим минимальный элемент в столбце и запоминаем его индекс
        int min = int.MaxValue;
        int minIndex = -1;
        for (int j = 0; j < N; j++)
        {
            int procSum = 0;
            for(int k = 0; k < procMas[j].Count; k++)
                procSum += procMas[j][k];

            if (matrix[j][i] + procSum < min) 
            {
                min = matrix[j][i] + procSum;
                minIndex = j;
            }
        }
        
        procMas[minIndex].Add(matrix[minIndex][i]);
      
    }
    return procMas;
}
static List<List<int>> SetOrdinary1(int[,] matrix)//алгоритм абсолютного минимума
{
    List<List<int>> ordinary = new(matrix.GetLength(0));
for (int i = 0; i < matrix.GetLength(0); i++)
{
    ordinary.Add(new List<int>());
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        ordinary[i].Add(0);
    }
}
for (int i = 0; i < matrix.GetLength(1); i++)
{
    int min = int.MaxValue;
    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        if (matrix[j, i] < min)
        {
            min = matrix[j, i];
        }
    }
    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        if (matrix[j, i] == min && ordinary[j][i] == 0)
        {
            ordinary[j][i] = min;
            break;
        }
    }
}
return ordinary;
}
static List<List<int>> Alg3(int N, int M, int[,] matrix1,int select,int select1)//функция для вызова всех алгоритмов в правильной последовательности и вывод данных
{
    int[,] matrix = matrix1;
    int[] rowSums=СheckSum(matrix);
    if (select == 1||select==0)
    {
        Console.WriteLine("Начальная матрица");
        format(N);
        for (int i = 0; i < M; i++)
        {
            Console.Write("{0}\t", i + " |");
            for (int j = 0; j < N; j++)
            {
                Console.Write("{0}\t", matrix[j, i]);
            }
            Console.WriteLine("|" + rowSums[i] + " ");
        }
        Console.WriteLine();
        Console.ReadLine();
    }
   
    if (select == 1) SwapDescending(rowSums, matrix);
    else if (select == 2) SwapAscending(rowSums, matrix);
    
 
    List<List<int>> ordinary=new List<List<int>>();
    if (select1 == 1)
    {
        ordinary = SetOrdinary(matrix);
    }
    else if (select1 == 2) {
        Console.WriteLine("Абсолютный минимум:");
      ordinary = SetOrdinary1(matrix);
    }
    return ordinary;
}
static int[,] Randomize(int N,int M, int t1, int t2)//генерация массива с рандомными числами
{
    int[,] tasks = new int[N,M];
    Random rnd = new Random();
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            tasks[i,j] = rnd.Next(t1, t2 + 1);
        }
    }
    return tasks;
}
int N = 4, M = 11, t1 = 10, t2 = 20;
int[,] tasks = Randomize(N, M, t1, t2);

var ord1 = Alg3(N, M, tasks, 0, 1);//Случайный
Console.WriteLine("\n");
var ord2 = Alg3(N, M, tasks, 2, 1);//Сортировка по возрастанию
Console.WriteLine("Матрица расписания(убывание):");

for (int j = 0; j < N; j++)
    Console.Write("{0}\t", "p" + j);
Console.WriteLine();

for (int i = 0; i < M; i++)
{
    for (int j = 0; j < N; j++)
    {
        try
        {
            Console.Write("{0}\t", ord1[j][i]);
        }
        catch
        {
            Console.Write("{0}\t", "");
        }

    }
    Console.WriteLine();
}

int max = int.MinValue;
for (int i = 0; i < ord1.Count; i++)
{
    if (ord1[i].Sum() > max) max = ord1[i].Sum();
    Console.Write("{0}\t", ord1[i].Sum());
}
Console.WriteLine("\n\nmax = " + max);
Console.WriteLine("Матрица расписания(возрастание):");

for (int j = 0; j < N; j++)
    Console.Write("{0}\t", "p" + j);
Console.WriteLine();

for (int i = 0; i < M; i++)
{
    for (int j = 0; j < N; j++)
    {
        try
        {
            Console.Write("{0}\t", ord2[j][i]);
        }
        catch
        {
            Console.Write("{0}\t", "");
        }

    }
    Console.WriteLine();
}

int max1 = int.MinValue;
for (int i = 0; i < ord2.Count; i++)
{
    if (ord2[i].Sum() > max1) max1 = ord2[i].Sum();
    Console.Write("{0}\t", ord2[i].Sum());
}
Console.WriteLine("\n\nmax = " + max1);
