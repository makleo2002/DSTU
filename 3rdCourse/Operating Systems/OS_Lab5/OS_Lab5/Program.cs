using System.Linq.Expressions;
using System.Text.Json;
namespace OS_Lab5;
public static class Extensions
{
    public static Random rand = new Random();
    public static void Print(this IEnumerable<byte> arr)
    {
        Console.Write($"Printing: ");
        foreach (var elem in arr)
        {
            Console.Write($"{(int)elem} ");
        }
        Console.WriteLine();
    }

    public static byte[] GenerateBytes(int count)//генерация массива байт(рандом)
    {
        var arr = new byte[count];
        rand.NextBytes(arr);
        return arr;
    }
}
internal class Program
{
    public static void Main()
    {
        const int blockSize = 8;//размер блока 8 кб
        const int blocksCount = 12;//количество блоков 12
        const string path = @"C:\Users\Максим\source\repos\OS_Lab5\OS_Lab5\transactions.txt";
        var fs = new Fs(blocksCount, blockSize, path);//создаем блочную систему
        Console.WriteLine("Начальное состояние");
        fs.PrintData();

        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("1 транзакция");
        var allocated = fs.Alloc(1);//выделяем память для одного блоков и получаем список id блоков
        var b1 = Extensions.GenerateBytes(1 * blockSize);//генерируем массив байт
        b1.Print();//выводим массив
       
        fs.Write(allocated, b1);//записываем наш массив байт в выделенные блоки
        fs.Read(allocated).Print();//считываем с них информацию
      
        fs.PrintData();
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("2 транзакция");
        var allocated2 = fs.Alloc(new List<int>() { 0, 3, 7 }); //выделяем память для трех блоков черех список и получаем список id блоков
        var b2 = Extensions.GenerateBytes(3 * blockSize);//генерируем массив байт
        b2.Print();//выводим массив
        fs.Write(allocated2, b2);//записываем наш массив байт в выделенные блоки
     
        fs.PrintData();//состояние файловой системы

        fs.Read(allocated2).Print();//считываем с блоков информацию

        fs.Flush(allocated);//освобождаем блок
        fs.Flush(allocated2);

        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("3 транзакция");
        var b3 = Extensions.GenerateBytes(6 * blockSize);//генерируем массив байт
        var allocated3 = fs.Write(b3);//записываем массив в блоки и память автоматически выделится
        fs.Read(allocated3).Print();//считываем с блоков информацию
      
        fs.PrintEmpty();//выводим свободные блоки
        fs.PrintData();
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("4 транзакция");
        var tm = fs.GetTransactionManager();
        tm.Fix();
        allocated2 = fs.Alloc(new List<int>() { 0 });
        b2 = Extensions.GenerateBytes(1 * blockSize);
        b2.Print();
        fs.Write(allocated2, b2);
        fs.PrintData();

        tm.Back();
        
        fs.PrintData();
        Console.WriteLine("---------------------------------------------");
        fs.Flush(allocated3);//освобождаем блок
    }
    internal class Fs //файловая система
    {
        private int[] _bitmap;
        private readonly TransactionManager _transactionManager;
        public TransactionManager GetTransactionManager() => _transactionManager;
        public List<Block> Blocks = new List<Block>();//список блоков
        private readonly int _blockSize;//размер блоков
        public Fs(int blocks, int blockSize, string path)
        {
            _transactionManager = new TransactionManager(path, this);
            this._blockSize = blockSize;
            _bitmap = new int[blocks];
            for (var i = 0; i < blocks; i++)
            {
                Blocks.Add(new Block(i, blockSize));
            }
        }
        public void printAllBlocks()
        {
            foreach(var i in Blocks)
            {
                Console.WriteLine("Block "+ i.Id);
                Console.WriteLine("Size: "+i.Size);
                Console.WriteLine("Data: ");
                Console.WriteLine("isAlloc: "+i.IsAlloc);
                Console.WriteLine("isFree: "+ i.IsFree);
            }
        }
        public void PrintEmpty() //свободные блоки
        {
            Console.Write("Free blocks:");
            foreach (var b in Blocks.Where(x => !x.IsAlloc))//блоки,где память не выделена
            {
                Console.Write($"{b.Id} ");
            }
            Console.WriteLine("");

        }
        public void PrintData()//состояние файловой системы
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"State:");
            Console.WriteLine($"BlockSize:{_blockSize}b");
            Console.WriteLine($"Blocks count:{Blocks.Count}");
            Console.WriteLine($"Blocks free:{Blocks.Count(x => x.IsFree)}");
            Console.WriteLine($"Data:{Blocks.Count} bits");
            Console.WriteLine($"Transaction cache:{Blocks.Count(x => x.IsFree) * _blockSize + Blocks.Count}b");
            Console.WriteLine("---------------------------------------------");
        }
        public List<int> Alloc(int number)//выделение памяти опр.кол-ву блоков
        {
            var res = new List<int>();//список блоков с выделенной памятью
            for (var i = 0; i < number; i++)
            {
                foreach (var block in Blocks)
                {
                    if (number == 0) {
                        Console.WriteLine($"Allocated {res.Count} blocks");
                        return res;
                    } //возвращаем список
                    if (block.IsAlloc) continue;//если блоку выделена память,смотрим следующий
                    block.IsAlloc = true;
                    res.Add(block.Id);
                    number--;
                }
            }
         
            throw new Exception($"Unable to allocate blocks: {number}");// id блока,которому не выделена память
        }
        public List<int> Alloc(List<int> blockIds)//выделение памяти по списку id блоков
        {
            var res = new List<int>();
            var ctrToalloc = 0;
            foreach (var id in blockIds)
            {
                if (!Blocks[id].IsAlloc)//если блоку память не выделена,то выделяем
                {
                    Blocks[id].IsAlloc = true;
                    res.Add(id);
                }
                else
                {
                    ctrToalloc++;
                }
            }
            var its = Alloc(ctrToalloc);//выделяем память для недостающих блоков
            res.AddRange(its);
            Console.WriteLine($"Allocated {res.Count} blocks");
            return res;
        }
        public List<int> Write(byte[] data)//запись данных в блок
        {
            var count = data.Length / _blockSize;//кол-во блоков
            var ids = Alloc(count);//выделяем память для блоков
            Console.WriteLine($"Writing {count} blocks");
            return Write(ids, data);
        }

        public List<int> Write(List<int> blockIds, byte[] data)//запись данных в блоки
        {
            var count = data.Length / _blockSize;//кол-во блоков
            for (var i = 0; i < count; i++)
            {
                var id = blockIds[i];
                Console.WriteLine($"Writing block {id}");
                Blocks[id].Write(data[(i * _blockSize)..(i * _blockSize + _blockSize)]);//
            }
            return blockIds;
        }
        public byte[] Read(List<int> blockIds)//чтение нескольких блоков
        {
            var len = blockIds.Count * _blockSize;
            var arr = new byte[len];
            var ptr = 0;
            foreach (var b in blockIds.SelectMany(id => Blocks[id].Data))
            {
                arr[ptr++] = b;
            }
            Console.WriteLine($"Reading {blockIds.Count} blocks");
            return arr;
        }
      
        public void Flush(IEnumerable<int> blockIds)//освобождение нескольких блоков
        {
            Console.WriteLine($"Flushing {blockIds.Count()} blocks");
            foreach (var id in blockIds)
            {
                var block = Blocks.Find(x => x.Id == id);
                block?.Flush();
            }
        }
    }
    internal class TransactionManager
    {
        private string _path;//путь к файлу
        private Fs _filesystem;//блочная система
        public TransactionManager(string path, Fs filesystem)
        {
            _path = path;
            this._filesystem = filesystem;
        }
        public void Fix()//перезаписываем файл
        {
            Console.WriteLine($"Fixed transaction");
            var json = JsonSerializer.Serialize(_filesystem.Blocks);
            File.WriteAllText(_path, json);
        }
        public void Back()//отменить изменения
        {
            Console.WriteLine($"Reverting transaction");

            var json = File.ReadAllText(_path);
            var blocks = JsonSerializer.Deserialize<List<Block>>(json);
            if (blocks != null)
            {
                _filesystem.Blocks = blocks;
                File.Delete(_path);
            }
            else
            {
                Console.WriteLine("Unable back: previous state not saved");
            }
        }
    }
    private class Additions
    {
        public static bool Degree2(int n) => n > 0 && (n & (n - 1)) == 0;
    }
    [Serializable]
    internal class Block
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public byte[] Data { get; set; }
        public bool IsAlloc { get; set; } = false; //выделена память или нет
        public bool IsFree { get; set; } = true; //свободен или нет

        public void Flush()//освобождение
        {
            IsAlloc = false;
            IsFree = true;
            Data = null;
        }

        public int Write(byte[] data)//Запись данных
        {
            if (!Additions.Degree2(data.Length)) return -1;
            this.Data = data;
            IsFree = false;//занят
            return this.Id;
        }
        public Block(int id, int size)
        {
            this.Id = id;
            this.Size = size;
        }
    }
}