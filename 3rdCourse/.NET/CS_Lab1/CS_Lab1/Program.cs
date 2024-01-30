
using System.Text;

namespace CS_Lab1
{
    class Program
    {
        void find(int[] mas) //самая длинная последовательность одинаковых элементов
        {
            int cur = mas[0], count = 1, res = -1;
            for (int i = 1; i < mas.Length; ++i)
            {
                if (mas[i] == cur)//если следующий элемент равен текущему
                    count++;
                else
                {
                    if (count > res)//если текущее количество одинаковых элементов больше,чем res
                        res = count;//записываем количество повторений в res
                    count = 1;//сбрасываем счетчик до единицы
                    cur = mas[i];//двигаемся на один элемент
                }
            }
            if (count > res)//если текущее количество одинаковых элементов больше,чем res
                res = count;//записываем количество повторений в res
            Console.WriteLine(res);
        }
        private bool ContainsMatrix(int[,] big, int[,] small)
        {
            int smallWidth = small.GetLength(1);
            int smallHeight = small.GetLength(0);
            int bigWidth = big.GetLength(1);
            int bigHeight = big.GetLength(0);

            if (smallHeight > bigHeight || smallWidth > bigWidth)//если ввели неправильно
                return false;

            for (int i = 0; i < bigHeight - smallHeight + 1; i++)
            {
                for (int j = 0; j < bigWidth - smallWidth + 1; j++)
                {
                    if (Compare(big, small, i, j))
                        return true;
                }
            }
            return false;
        }
        private bool Compare(int[,] big, int[,] small, int rowOffset, int colOffset)
        {
            for (int i = 0; i < small.GetLength(0); i++)
            {
                for (int j = 0; j < small.GetLength(1); j++)
                {
                    //  Console.WriteLine(small[i, j] + " " + big[i + rowOffset, j + colOffset] + "\n");
                    if (small[i, j] != big[i + rowOffset, j + colOffset])
                        return false;
                }
            }
            return true;
        }
        void sum(int[,] mas)
        {
            int str_sum = 0;//сумма элементов строк
            int col_sum = 0;//сумма элементов столбцов
            int main_sum = 0;//сумма элементов главной диагонали
            int sec_sum = 0;//сумма элементов побочной диагонали
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                Console.WriteLine("Сумма элементов " + i + " строки: ");

                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    str_sum += mas[i, j];
                }
                Console.Write(str_sum + "\n\n");
                str_sum = 0;
            }
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                Console.WriteLine("Сумма элементов " + i + " столбца: ");

                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    col_sum += mas[j, i];
                }
                Console.Write(col_sum + "\n\n");
                col_sum = 0;
            }

            Console.WriteLine("Сумма элементов главной диагонали: ");

            for (int i = 0; i < mas.GetLength(0); i++)
            {

                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (i == j) main_sum += mas[i, j];
                }

            }
            Console.Write(main_sum + "\n\n");

            Console.WriteLine("Сумма элементов побочной диагонали: ");

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (i + j == mas.GetLength(0) - 1) sec_sum += mas[i, j];
                }

            }
            Console.Write(sec_sum + "\n\n");
        }
        void DirectInclusion(int[] a, int n)
        {
            for (int i = 1; i < n; ++i)
            {

                if (a[i] >= a[i - 1])
                {
                    Console.WriteLine("Сортировка массива на итерации " + i + " ");
                    for (int k = 0; k < a.Length; k++)
                    {
                        Console.WriteLine(a[k]);
                    }
                    continue;
                }

                int x = a[i], j = i;
                do
                {
                    a[j] = a[j - 1];
                } while (--j > 0 && a[j - 1] > x);
                a[j] = x;

                Console.WriteLine("Сортировка массива на итерации " + i + " ");
                for (int k = 0; k < a.Length; k++)
                {
                    Console.WriteLine(a[k]);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            int size1 = 0, size21 = 0, size22 = 0, size31 = 0, size32 = 0;

            int[] mas1 = { }; int[,] mas2 = { }; int[,] mas3 = { };

            Program A = new Program();

            try
            {
                string[] str;
                string str1;
                int cnt = 0;


                Console.WriteLine("Введите размер для 3 массивов");

                str = Console.ReadLine().Split();

                size1 = int.Parse(str[0]);

                size21 = int.Parse(str[1]);

                size22 = int.Parse(str[2]);

                size31 = int.Parse(str[3]);

                size32 = int.Parse(str[4]);

                mas1 = new int[size1];

                mas2 = new int[size21, size22];

                mas3 = new int[size31, size32];


                Console.WriteLine("Введите элементы 1 массива\n");
                str1 = Console.ReadLine();
              
                Console.WriteLine();

                for (int k = 0; k < mas1.Length; k++)//вносим в массив строку из консоли
                {
                    mas1[k] = int.Parse(str1.Split()[k]);
                }

                Console.WriteLine("Самая длинная последовательность одинаковых чисел в массиве");
                A.find(mas1);

                A.DirectInclusion(mas1, size1);
                Console.WriteLine("Введите элементы 2 массива\n");

                str = Console.ReadLine().Split();

                for (int i = 0; i < size21; i++)
                {
                    for (int j = 0; j < size22; j++)
                    {
                        mas2[i, j] = int.Parse(str[cnt]);
                        cnt++;
                    }

                }



                cnt = 0;

                Console.WriteLine("Введите элементы 3 массива\n");


                str = Console.ReadLine().Split();

                for (int i = 0; i < size31; i++)
                {
                    for (int j = 0; j < size32; j++)
                    {
                        mas3[i, j] = int.Parse(str[cnt]);
                        cnt++;
                    }
                }

                A.sum(mas3);


                //  1 2 3 4 5
                //  2 3 4 5 6
                //  7 8 9 1 2
                //  2 3 4
                //  3 4 5
                //  8 9 1

                Console.WriteLine("Проверка на вхождение второго массива в первый массив: " + A.ContainsMatrix(mas2, mas3) + "\n");
            }

            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Количество введенных чисел не соответствует размеру массива(ов)\n");
            }
            finally
            {
                try
                {
                    Console.WriteLine("Массив 1:");
                    for (int i = 0; i < size1; i++)
                    {
                        Console.WriteLine(mas1[i]);
                    }
                    Console.WriteLine("Массив 2:");
                    for (int i = 0; i < size21; i++)
                    {
                        for (int j = 0; j < size22; j++)
                        {
                            Console.WriteLine(mas2[i, j]);

                        }
                    }
                    Console.WriteLine("Массив 3:");
                    for (int i = 0; i < size31; i++)
                    {
                        for (int j = 0; j < size32; j++)
                        {
                            Console.WriteLine(mas3[i, j]);
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Ошибка при выводе массивов\n");
                }
            }
        }
    }
}