
class Task3
{
    class GasStation
    {

        private Semaphore semaphore;

        public GasStation(int capacity)=> semaphore=new Semaphore(capacity,capacity);
        
        public void Refuel()
        {

            Console.WriteLine($"{Thread.CurrentThread.Name} заправляется бензином");
            Thread.Sleep(4000);
            Console.WriteLine($"{Thread.CurrentThread.Name} уехала с заправки");
            semaphore.Release();
        }
        public bool StartRefuel(string name)
        {
            //ожидаем получение свободного места в семафоре
            if (semaphore.WaitOne(0))//waitOne ждет 0 мс и возвращает true если место есть и false,если нет
            {
                Thread thread = new Thread(Refuel);//машина заезжает и начинает заправку
                thread.Name = name;
                thread.Start();

                return true;
            }
            else
            {
                Console.WriteLine($"{name} проехала мимо");
                return false;
            }
        }
    }
    private static void Main()
    {
        int stationCapacity = 4;
        int carsCount = 10;
        GasStation station = new GasStation(stationCapacity);
        int leftCount = 0;
        for (int i = 0; i < carsCount; i++)
        {
            if (!station.StartRefuel($"Машина {i + 1}")) //считаем проехавшие мимо машины
                leftCount++;
            Thread.Sleep(1000);
        }

       // Thread.Sleep(5000);
        Console.WriteLine($"Проехало мимо {leftCount} машин");
    }
}// вывод при таких параметрах не всегда будет одинаковым, так как на стыке событий,
 // когда пора запустить машину, место может успеть освободиться,
 // может не успеть, так как запуск новой машины и выезд с заправки
 // - практически одновременные события. 