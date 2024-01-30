using System;
using System.Diagnostics;
using System.Threading;

class Task1
{
    // Создаем новый мьютекс. Созданный поток не владеет мьютексом.
    private static Mutex mut = new Mutex();
    private const int numThreads = 3;

    // Этот метод представляет ресурс, который необходимо синхронизировать
    // так что только один поток за раз может войти.
    private static void useResource() //1
    {
       
            //Ждем, пока вход станет безопасным
            Console.WriteLine("{0} is requesting the mutex",
                              Thread.CurrentThread.Name);
            mut.WaitOne();

            Console.WriteLine("{0} has entered the protected area",
                              Thread.CurrentThread.Name);


            // Работа процесса
            readFile("C:\\Users\\Максим\\Desktop\\myDir\\input\\css1.txt");
            Console.WriteLine();

            Console.WriteLine("{0} is leaving the protected area",
                Thread.CurrentThread.Name);

            // Освобождаем мьютекс
            mut.ReleaseMutex();
            Console.WriteLine("{0} has released the mutex",
                Thread.CurrentThread.Name);
        
    }
    private static void readFile(string path)//1
    {
        TextReader sr = new StreamReader(path);
        Console.WriteLine(sr.ReadToEnd());
    }


  private static void Main()
    {
        // Создаем потоки, которые будут использовать защищенный ресурс.
       
        for (int i = 0; i < numThreads; i++)
        {
            Thread newThread = new Thread(useResource);
            newThread.Name = String.Format("Thread{0}", i + 1);
            newThread.Start();
        }

    }

}
