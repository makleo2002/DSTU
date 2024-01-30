using System;

namespace OS_Lab1
{
    class Program
    {
        byte[] BitMap = new byte[255];//битовая карта

       void allocMemory(int c) //функция выделения памяти
        {
            int count, block = 1, start = 0, end = 0;//количество нулевых байтов,номер участка памяти,начальный и конечный адрес.
            bool f = false;//показывает,выделена или не выделена память
            while (64 * block <= BitMap.Length)//проходимся по блокам
            {
                count = 0;
                start = end;
                end = 64 * block;

                for (int i = start; i < end; i++)
                {
                    if (BitMap[i] == 0) count++;
                }
                if (count > c)//если свободных байтов больше,чем указал пользователь,то выделяем память.
                {   
                    for(int i = start; i < start+c; i++)
                    {
                        BitMap[i] = 1;//заполняем часток памяти количеством байтов,которые указал пользователь
                    }
                    Console.WriteLine("Память выделена");
                    Console.WriteLine("Блок "+block);
                    Console.WriteLine("Адрес участка памяти:"+start);
                    Console.WriteLine();
                    f = true;
                    break;
                }
                block++;
            }

            if (!f) Console.WriteLine("Нехватка памяти \n");//если память не выделилась,то значит ее не хватает.
        }

       void freeMemory(int address) //функция освобождения памяти
        {
            for(int i = address; i < address + 64;i++)
            {
                BitMap[i] = 0;//обнуляем байты определенного участка памяти.
            }
        }
       void getInfo() //функции получения инф-ии
        {
            int block = 1, start = 0, end = 0;
            int free_count, filled_count;//количество свободных и занятых байтов в участке памяти
            int all_free_count = 0, all_filled_count = 0;//общее количество свободных и занятых байтов
            int free_blocks = 0,filled_blocks=0;//количество свободных и занятых блоков

            while (64 * block <= BitMap.Length)//проходимся по участкам памяти
            {
                free_count = 0;
                filled_count = 0;
                start = end;
                end = 64 * block;
                for(int i = start; i < end; i++)//проходимся по блоку
                {
                    if (BitMap[i] == 0) free_count++;//считаем свободные и занятые байты
                    else filled_count++;
                }
                all_free_count += free_count;//добавляем их общему кол-ву
                all_filled_count += filled_count;
                Console.WriteLine("Блок №" + block);
                if (filled_count == 0)//выводим тип участка
                {
                    Console.WriteLine("Тип: Свободный");
                    free_blocks++;
                }
                else {
                    Console.WriteLine("Тип: Занятый");
                    filled_blocks++;
                }
                
                Console.WriteLine("Адрес участка: " + start);
                Console.WriteLine("Размер участка: "+(end-start));

                block++;//переход на следующий участок памяти
            }
            Console.WriteLine();
            Console.WriteLine("Всего памяти: " + BitMap.Length + " байт");
            Console.WriteLine("Количество свободных участков: " + free_blocks);
            Console.WriteLine("Количество занятых участков: " + filled_blocks);
            Console.WriteLine("Свободная память: "+ all_free_count + " байт");
            Console.WriteLine("Занятая память: "+ all_filled_count + " байт");
        }
        static void Main(string[] args)
        {
            Program p1=new Program();
            p1.allocMemory(62);
            p1.allocMemory(15);
            p1.allocMemory(63);
            p1.allocMemory(63);
            p1.allocMemory(48);
            //p1.freeMemory(64);
            //p1.allocMemory(32);
            Console.WriteLine();
            p1.getInfo();

        }
    }
}
