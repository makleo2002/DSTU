using System.Linq.Expressions;

static int[] СheckSum(int[,] matrix)//проверяем сумму для строки
{
    int[] rowSums = new int[matrix.GetLength(1)];//matrix.GetLength(1)=M
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)//matrix.GetLength(0)=N
        {
            rowSums[i] += matrix[j, i];
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
    Format(matrix.GetLength(0));
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
    Format(matrix.GetLength(0));
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
static void Format(int N)
{
    Console.Write("{0}\t", " ");
    for (int j = 0; j < N; j++)
        Console.Write("{0}\t", "p" + j);
    Console.Write("{0}\t", " Sum");
    Console.WriteLine();
}
static int CheckMin(List<int> mas)
{
    int min = int.MaxValue, index = 0;
    for (int i = 0;i < mas.Count;i++)
        if (mas[i] < min)
        {
            min = mas[i];
            index = i;
        }
    return index;
}
static List<int> SetOrdinary(int[,] matrix, int mode)
{
    int N = matrix.GetLength(0);
    int M = matrix.GetLength(1);
  
    // Создаем массив для хранения сумм элементов каждой строки
    List<int> procMas = new(N);
    for (int i = 0; i < N; i++)
    {
        procMas.Add(0);
    }
    // Проходимся по всем строкам матрицы
    for (int i = 0; i < M; i++)
    {
        List<int> sums = new();
        // Проходимся по всем столбцам матрицы
        for (int j = 0; j < N; j++)
        {
            int sum = 0;
            sum += (int)Math.Pow(matrix[j,i] + procMas[j], mode);
         //   Console.WriteLine("sum "+sum);
            for (int m = 0; m < N; m++)
            {
                if(m!=j) sum += (int)Math.Pow(procMas[m], mode);
            }
            sums.Add(sum);
          
        }
       //  foreach (var s in sums) Console.Write(s + " ");
       //  Console.WriteLine();
        procMas[CheckMin(sums)] = matrix[CheckMin(sums),i] + procMas[CheckMin(sums)];
       // foreach (var m in procMas) Console.Write(m+" ");
       // Console.WriteLine();
    }
    return procMas;
}
static List<int> Square(int N, int M, int[,] matrix1, int select, int mode)//функция для вызова всех алгоритмов в правильной последовательности и вывод данных
{
    int[,] matrix = matrix1;
    int[] rowSums = СheckSum(matrix);
    if (select == 0)
    {
        Console.WriteLine("Начальная матрица");
        Format(N);
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
 
    List<int> ordinary = SetOrdinary(matrix,mode);
    return ordinary;
}
static int[,] Randomize(int N, int M, int t1, int t2)//генерация массива с рандомными числами
{
    int[,] tasks = new int[N, M];
    Random rnd = new Random();
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            tasks[i, j] = rnd.Next(t1, t2 + 1);
        }
    }
    return tasks;
}
int N = 4, M = 11, t1 = 10, t2 = 20;
int[,] tasks = Randomize(N, M, t1, t2);
//tasks = new int[,] { { 15, 15, 19, 12, 11, 18, 18, 16, 14 }, { 14, 15, 16, 11, 13, 16, 14, 18, 15 }, { 14, 15, 16, 11, 10, 10, 12, 19, 16 } };
var ord1 = Square(N, M, tasks, 0, 2);//Без сортировки(2)
Console.WriteLine("\n");
var ord2 = Square(N, M, tasks, 2, 3);//Сортировка по возрастанию(3)

Console.ReadLine();


for (int j = 0; j < N; j++)
    Console.Write("{0}\t", "p" + j);
Console.WriteLine();

for (int j = 0; j < N; j++)
    {
        try
        {
            Console.Write("{0}\t", ord1[j]);
        }
        catch
        {
            Console.Write("{0}\t", "");
        }

    }

Console.WriteLine("\n\nmax = " +ord1.Max());

Console.ReadLine();


for (int j = 0; j < N; j++)
    Console.Write("{0}\t", "p" + j);
Console.WriteLine();

for (int j = 0; j < N; j++)
{
    try
    {
        Console.Write("{0}\t", ord2[j]);
    }
    catch
    {
        Console.Write("{0}\t", "");
    }

}
Console.WriteLine("\n\nmax = " + ord2.Max());
