using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

public class Data
{
    public List<int> list { get; set; } = new() ;
    public  Mutex mut { get; set; } = new ();
    public Random rand { get; set; } = new Random(DateTime.Now.Millisecond);
}
class Task9
{
   Data SharedMemory;
   public Task9()
    {
        SharedMemory = new();
        Thread newThread1 = new Thread(new ThreadStart(MessList));
        newThread1.Name = String.Format("Thread{0}", 1);
        newThread1.Start();

        Thread newThread2 = new Thread(new ThreadStart(startSorting));
        newThread2.Name = String.Format("Thread{0}", 2);
        newThread2.Start();
    }
  
    private void startSorting()
    {
        for (; ;) {
            SharedMemory.mut.WaitOne();
            SharedMemory.list.Sort();
            Console.WriteLine("List has been sorted");
            foreach (var i in SharedMemory.list) Console.WriteLine(i);
            Console.WriteLine();
            Thread.Sleep(10000);
            SharedMemory.mut.ReleaseMutex();
        }
        
    }

    private void MessList()
    { 
        for (; ;) {
            SharedMemory.mut.WaitOne();
            SharedMemory.list.Add(SharedMemory.rand.Next(1000));
            Console.WriteLine("Element has been added to List");
            if (SharedMemory.list.Count - SharedMemory.rand.Next(100) > 0)
            {
                SharedMemory.list.RemoveAt(SharedMemory.rand.Next(SharedMemory.list.Count));
                Console.WriteLine("Element has been deleted from List");
            }
            Thread.Sleep(1);
            SharedMemory.mut.ReleaseMutex();
        }
        
    }
    private static void Main()
    {
       Task9 task9 = new Task9();

    }
}