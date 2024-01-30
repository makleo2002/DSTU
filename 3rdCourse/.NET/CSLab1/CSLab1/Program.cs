
static string Reverse(string text)
{
    char[] cArray = text.ToCharArray();
    string reverse = String.Empty;
    for (int i = cArray.Length - 1; i > -1; i--)
    {
        reverse += cArray[i];
    }
    return reverse;
}
static double getIntervalLength(double a, double b, int intervalsCount)
{
    return (b - a) / intervalsCount;
}

//Базовая стратегия распараллеливания вычислений выглядит следующим образом:
//Создание потоков (тем больше,чем больше ядер в процессоре)
//Каждый поток будет работать над диапазоном в массиве и суммировать значения
//Добавление к одной и той же переменной не будет работать из нескольких потоков,
//Понадобится механизм блокировки, иначе мы получим неверный результат.
//Нужно использовать переменную localThread,
//Чтобы сохранить значение iThread в этот момент времени.
//Иначе это будет захваченная переменная, которая изменяется по мере продвижения цикла for.
double ThreadPoolWithLock(double[] f,int n,int h)
{
    object locker = new object();//объект заглушка
    double total = 0;
    int threads = 8;
    var partSize = n / threads;
    Task[] tasks = new Task[threads];
    for (int iThread = 0; iThread < threads; iThread++)
    {
        var localThread = iThread;
       //ставим в очередь все что внутри для запуска в пуле потоков
        tasks[localThread] = Task.Run(() =>
        {
            for (int j = localThread * partSize; j < (localThread + 1) * partSize; j++)
            {
                // внутри весь код блокируется и становится недоступным
                // для других потоков до завершения работы текущего потока
                lock (locker) // объект locker блокируется
                {
                    total += f[j+h/2];
                }
            }
        });
    }

    Task.WaitAll(tasks);//ждем пока потоки завершат свою работу
    return total;
}
double Rectangle(double[] f, int a,int b)
{
    int n = f.Length-1;
    double Integral = 0;
    double h = getIntervalLength(a, b, n);
    Integral =ThreadPoolWithLock(f, n,(int)h);
    return Integral * h;
}

string[] input=Console.ReadLine().Split();

Console.WriteLine("Введите a, b и eps: ");

int a = int.Parse(input[0]);
int b = int.Parse(input[1]);

string eps = "0"+ input[2].Substring(2);
eps=Reverse(eps); 

int n = b - a + int.Parse(eps);
double length = getIntervalLength(a, b, n);
double[] f = new double[n+1];

double leftX = a;
Console.WriteLine("------------------------------");
Console.WriteLine("{1,14:c}{0,8:c}","x","y(x)");
Console.WriteLine("------------------------------");

for (int k = 0; k <= n; k++, leftX += length)
{
    Console.WriteLine("{1,20:f15}{0,10:f4}", leftX, Math.Pow(Math.E, leftX) - leftX * leftX * leftX);
    Console.WriteLine("------------------------------");
    f[k] = Math.Pow(Math.E, leftX) - leftX * leftX * leftX;
}
Console.WriteLine(Rectangle(f, a, b));
double result = Math.Pow(Math.E, 4) - 65;
Console.WriteLine("Проверка: " + result);
Console.WriteLine("Разница: " + Math.Abs(result - Rectangle(f, a, b)));
