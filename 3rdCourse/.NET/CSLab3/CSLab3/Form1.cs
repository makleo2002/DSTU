using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static CSLab3.AutumnLab3.ICollection;

namespace CSLab3
{
    public class AutumnLab1
    {
        private StreamWriter writer;

        public AutumnLab1()
        {
            writer = new("C:\\Users\\Максим\\source\\repos\\CSLab3\\CSLab3\\output.txt");
            writer.AutoFlush = true;
        }
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
            writer.WriteLine(res);
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
                    //  writer.WriteLine(small[i, j] + " " + big[i + rowOffset, j + colOffset] + "\n");
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
                writer.WriteLine("Сумма элементов " + i + " строки: ");

                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    str_sum += mas[i, j];
                }
                writer.Write(str_sum + "\n\n");
                str_sum = 0;
            }
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                writer.WriteLine("Сумма элементов " + i + " столбца: ");

                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    col_sum += mas[j, i];
                }
                writer.Write(col_sum + "\n\n");
                col_sum = 0;
            }

            writer.WriteLine("Сумма элементов главной диагонали: ");

            for (int i = 0; i < mas.GetLength(0); i++)
            {

                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (i == j) main_sum += mas[i, j];
                }

            }
            writer.Write(main_sum + "\n\n");

            writer.WriteLine("Сумма элементов побочной диагонали: ");

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (i + j == mas.GetLength(0) - 1) sec_sum += mas[i, j];
                }

            }
            writer.Write(sec_sum + "\n\n");
        }
        void DirectInclusion(int[] a, int n)
        {
            for (int i = 1; i < n; ++i)
            {
                if (a[i] >= a[i - 1])
                {
                    writer.WriteLine("Сортировка массива на итерации " + i + " ");
                    for (int k = 0; k < a.Length; k++)
                    {
                        writer.Write("{0}\t", a[k]);
                    }
                    writer.WriteLine();
                    continue;
                }

                int x = a[i], j = i;
                do
                {
                    a[j] = a[j - 1];
                } while (--j > 0 && a[j - 1] > x);
                a[j] = x;

                writer.WriteLine("Сортировка массива на итерации " + i + " ");
                for (int k = 0; k < a.Length; k++)
                {
                    writer.Write("{0}\t",a[k]);
                }
                writer.WriteLine();
            }
        }
        public void run(string input0, string input1, string input2, string input3)
        {
            int size1 = 0, size21 = 0, size22 = 0, size31 = 0, size32 = 0;

            int[] mas1 = { }; int[,] mas2 = { }; int[,] mas3 = { };
            try
            {
                string[] str;
                string str1;
                int cnt = 0;

                writer.WriteLine("Введите размер для 3 массивов");

                str = input0.Split();

                size1 = int.Parse(str[0]);

                size21 = int.Parse(str[1]);

                size22 = int.Parse(str[2]);

                size31 = int.Parse(str[3]);

                size32 = int.Parse(str[4]);

                mas1 = new int[size1];

                mas2 = new int[size21, size22];

                mas3 = new int[size31, size32];


                writer.WriteLine("Введите элементы 1 массива\n");
                writer.WriteLine();

                for (int k = 0; k < mas1.Length; k++)//вносим в массив строку из консоли
                {
                    mas1[k] = int.Parse(input1.Split()[k]);
                }

                writer.WriteLine("Самая длинная последовательность одинаковых чисел в массиве");
                find(mas1);

                DirectInclusion(mas1, size1);

                writer.WriteLine("Введите элементы 2 массива\n");

                str = input2.Split();

                for (int i = 0; i < size21; i++)
                {
                    for (int j = 0; j < size22; j++)
                    {
                        mas2[i, j] = int.Parse(str[cnt]);
                        cnt++;
                    }

                }

                cnt = 0;

                writer.WriteLine("Введите элементы 3 массива\n");

                str = input3.Split();

                for (int i = 0; i < size31; i++)
                {
                    for (int j = 0; j < size32; j++)
                    {
                        mas3[i, j] = int.Parse(str[cnt]);
                        cnt++;
                    }
                }

                writer.WriteLine("\nСуммы для 3 массива:");
                sum(mas3);

                //  4 3 3 2 2
                //  5 5 2 9
                //  2 3 5 6 4 5 8 9 1
                //  2 3 6 4

                writer.WriteLine("Проверка на вхождение второго массива в первый массив: " + ContainsMatrix(mas2, mas3) + "\n");
            }
            catch (IndexOutOfRangeException)
            {
                writer.WriteLine("Количество введенных чисел не соответствует размеру массива(ов)\n");
            }
            finally
            {
                try
                {
                    writer.WriteLine("Массив 1:");
                    for (int i = 0; i < size1; i++)
                    {
                        writer.Write("{0}\t",mas1[i]);
                    }
                    writer.WriteLine("\nМассив 2:");
                    for (int i = 0; i < size21; i++)
                    {
                        for (int j = 0; j < size22; j++)
                        {
                            writer.Write("{0}\t", mas2[i, j]);
                        }
                        writer.WriteLine();
                    }
                    writer.WriteLine("\nМассив 3:");
                    for (int i = 0; i < size31; i++)
                    {
                        for (int j = 0; j < size32; j++)
                        {
                            writer.Write("{0}\t", mas3[i, j]);
                        }
                        writer.WriteLine();
                    }
                    writer.WriteLine();
                }
                catch (IndexOutOfRangeException)
                {
                    writer.WriteLine("Ошибка при выводе массивов\n");
                }
            }
            writer.Close();
        }


    }
    public class AutumnLab2
    {
        private static StreamWriter writer;
        public AutumnLab2()
        {
            writer = new("C:\\Users\\Максим\\source\\repos\\CSLab3\\CSLab3\\output.txt");
            writer.AutoFlush = true;
        }
        public abstract class Animal
        {

            string name;
            double weight;
            int age;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public double Weight
            {
                get { return weight; }
                set { weight = value; }
            }

            public int Age
            {
                get { return age; }
                set { age = value; }
            }

            public Animal()
            {
                name = "";
                weight = 0;
                age = 0;
            }

            public Animal(string name, double weight, int age)
            {
                this.name = name;
                this.weight = weight;
                this.age = age;
            }
            virtual public void max_speed() { }

            virtual public void bite() { }

            virtual public void eat() { }
            virtual public void move() { }
            virtual public void makeSound() { }

        }

        public abstract class Mammals : Animal
        {

            string color;
            const bool wool = true;
            public string Color
            {
                get { return color; }
                set { color = value; }
            }

            public bool Wool
            {
                get { return wool; }
            }
            public Mammals(string color, string name, double weight, int age) : base(name, weight, age)
            {
                this.color = color;
            }
            virtual public void sleep()
            {
                writer.WriteLine("The mammal is sleeping...\n");
            }
        }

        public abstract class Insects : Animal
        {
            bool wings;
            int legs;

            public int Legs
            {
                get { return legs; }
                set { legs = value; }
            }
            public bool Wings
            {
                get { return wings; }
                set { wings = value; }
            }

            public Insects(bool wings, int legs)
            {
                this.wings = wings;
                this.legs = legs;
            }
            override public void eat()
            {
                writer.WriteLine("Insect " + Name + " eating plants\n");
            }

        }

        public class Spider : Animal
        {
            const int legs = 8;
            int eyes;
            bool poisonous;

            public int Legs
            {
                get { return legs; }
            }
            public int Eyes
            {
                get { return eyes; }
                set { eyes = value; }
            }
            public bool Poisonous
            {
                get { return poisonous; }
                set { poisonous = value; }
            }

            public Spider(int eyes, bool poisonous, string name, double weight, int age) : base(name, weight, age)
            {
                writer.WriteLine("Spider " + name + "\n");
                this.eyes = eyes;
                this.poisonous = poisonous;
            }

            public void feedSpider()
            {
                writer.WriteLine("You fed the spider " + Name);
            }
            override public void bite()
            {
                if (poisonous) writer.WriteLine("You are SpiderMan :)\n");
                else writer.WriteLine("Spider isn't poisonous.It's OK :)\n");
            }

            override public void move()
            {
                writer.WriteLine("Spider " + Name + " crawling\n");
            }

            override public void eat()
            {
                writer.WriteLine("Spider " + Name + " eats insects\n");
            }
        }

        public class Horse : Mammals
        {
            string hairColor;
            public string HairColor
            {
                get { return hairColor; }
                set { hairColor = value; }
            }

            public Horse(string hairColor, string color, string name, int weight, int age) : base(color, name, weight, age)
            {
                writer.WriteLine("Horse " + name + "\n");
                this.hairColor = hairColor;
            }

            public void rideHorse()
            {
                writer.WriteLine("You got on horse " + Name);
            }

            override public void sleep()
            {
                writer.WriteLine("The horse is sleeping...\n");
            }
            override public void max_speed()
            {
                writer.WriteLine("Max speed: 88 km/h\n");
            }
            override public void makeSound()
            {
                writer.WriteLine("Horse neighs\n");
            }

            override public void eat()
            {
                writer.WriteLine("Horse " + Name + " eats grass\n");
            }

            override public void move()
            {
                writer.WriteLine("Horse " + Name + " running\n");
            }
        }

        public class Fish : Animal
        {
            int fins;
            string color;

            public int Fins
            {
                get { return fins; }
                set { fins = value; }
            }
            public string Color
            {
                get { return color; }
                set { color = value; }
            }
            public Fish(int fins, string color, string name, double weight, int age) : base(name, weight, age)
            {
                writer.WriteLine("Fish " + name + "\n");
                this.fins = fins;
                this.color = color;
            }

            public void catchFish()
            {
                writer.WriteLine("You caught a fish " + Name);
            }

            override public void move()
            {
                writer.WriteLine("Fish " + Name + " swimming\n");
            }
            override public void eat()
            {
                writer.WriteLine("Fish " + Name + " eats plankton\n");
            }
            override public void bite()
            {
                writer.WriteLine("You are hurt.It's piranha or shark\n");
            }


        }

        public class Dog : Mammals
        {
            string habitat;
            public string Habitat
            {
                get { return habitat; }
                set { habitat = value; }
            }

            public Dog(string habitat, string color, string name, int weight, int age) : base(color, name, weight, age)
            {
                writer.WriteLine("Dog " + name + "\n");
                this.habitat = habitat;
            }
            public void playwithDog()
            {
                writer.WriteLine("You play with dog " + Name);
            }

            override public void sleep()
            {
                writer.WriteLine("The dog is sleeping...\n");
            }
            override public void max_speed()
            {
                if (Weight < 40) writer.WriteLine("Max speed: 15.5 km/h\n");
                else if (Weight < 90) writer.WriteLine("Max speed: 18.3 km/h\n");
                else writer.WriteLine("Max speed: 16.2 km/h\n");
            }
            override public void makeSound()
            {
                writer.WriteLine("Waff-Waff\n");
            }

            override public void bite()
            {
                if (habitat == "street") writer.WriteLine("Maybe you got rabies\n");
                else writer.WriteLine("You are hurt\n");
            }
            override public void eat()
            {
                if (habitat == "street") writer.WriteLine("Dog " + Name + " eating garbage food\n");
                else writer.WriteLine("Dog " + Name + " eats dog food\n");
            }
            override public void move()
            {
                writer.WriteLine("Dog " + Name + " running around\n");
            }
        }
        public class Crocodile : Animal
        {
            double length;

            public double Length
            {
                get { return length; }
                set { length = value; }
            }

            public Crocodile(double length, string name, double weight, int age) : base(name, weight, age)
            {
                writer.WriteLine("Crocodile " + name + "\n");
                this.length = length;
            }

            public void feedCrocodile()
            {
                writer.WriteLine("You fed the crocodile " + Name);
            }
            override public void max_speed()
            {
                writer.WriteLine("Max speed: 48 km/h\n");
            }

            override public void eat()
            {
                writer.WriteLine("Crocodile " + Name + " eats fish\n");
            }

            override public void bite()
            {
                writer.WriteLine("Crocodile bit off your leg\n");
            }
            override public void move()
            {
                writer.WriteLine("Crocodile " + Name + " swimming\n");
            }
        }

        public void run()
        {
            //  Animal animal;
            //  Mammals mammals;
            //  Insects insects;
            Horse horse = new Horse("black", "white", "Phantom", 200, 12);
            writer.WriteLine("Haircolor " + horse.HairColor + " color " + horse.Color + "\n");
            horse.eat();
            horse.move();
            horse.makeSound();
            horse.bite();
            horse.max_speed();
            horse.sleep();
            horse.rideHorse();
            writer.WriteLine("\n");

            Dog dog = new Dog("street", "yellow", "Jeff", 20, 4);

            dog.eat();
            dog.move();
            dog.makeSound();
            dog.bite();
            dog.max_speed();
            dog.sleep();
            dog.playwithDog();
            writer.WriteLine("\n");

            Fish fish = new Fish(3, "orange", "Nemo", 0.2, 5);

            fish.eat();
            fish.move();
            fish.makeSound();
            fish.bite();
            fish.max_speed();
            fish.catchFish();
            writer.WriteLine("\n");

            Crocodile croco = new Crocodile(2.5, "Gena", 700, 10);

            croco.eat();
            croco.move();
            croco.makeSound();
            croco.bite();
            croco.max_speed();
            croco.feedCrocodile();
            writer.WriteLine("\n");

            Spider spider = new Spider(4, true, "Peter", 0.3, 4);

            spider.eat();
            spider.move();
            spider.makeSound();
            spider.bite();
            spider.max_speed();
            spider.feedSpider();
            writer.WriteLine("\n");
            writer.Close();
        }

    }
    public class AutumnLab3
    {
        private static StreamWriter writer;
        public AutumnLab3() {
            writer = new("C:\\Users\\Максим\\source\\repos\\CSLab3\\CSLab3\\output.txt");
            writer.AutoFlush = true;
        }
        public interface IENumerable
        {
            IEnumerator GetEnumerator();
        }
        public interface ICollection : IENumerable
        {
            public delegate void ElementAdded();


            public delegate void ElementChanged();


            public delegate void ElementRemoved();

        }
        public interface IList : ICollection
        {
            public void Add(Object elem);
            public void Change(int i, Object elem);
            public void Remove(int i);
        }
        public interface IDictionary : ICollection
        {
            public void Add(Object elem1, Object elem2);
            public void Change(int i, Object elem1, Object elem2);
            public void Remove(int i);
        }
        public class List : IList
        {
            public Object[] list;

            public IEnumerator GetEnumerator() => list.GetEnumerator();

            public event ElementAdded elemAddedToListEvent;
            public event ElementChanged elemChangedFromListEvent;
            public event ElementRemoved elemRemovedFromListEvent;


            static int count = 0, count1 = 0, count2 = 0;
            public List(int n)
            {

                list = new Object[n];
            }
            public void addedToList()
            {
                for (int i = 0; i < count; i++)
                {
                    if (elemAddedToListEvent != null)
                    {
                        elemAddedToListEvent();
                    }
                }
            }
            public void changedFromList()
            {
                for (int i = 0; i < count1; i++)
                {
                    if (elemChangedFromListEvent != null)
                    {
                        elemChangedFromListEvent();
                    }
                }
            }
            public void removedFromList()
            {
                for (int i = 0; i < count2; i++)
                {
                    if (elemRemovedFromListEvent != null)
                    {
                        elemRemovedFromListEvent();
                    }

                }
            }

            public void Add(Object elem)
            {
                list[count] = elem;
                count++;
            }

            public void Change(int i, Object elem)
            {
                list[i] = elem;
                count1++;
            }
            public void Remove(int i)
            {
                list[i] = null;
                count2++;
            }
            public void addedResult()
            {
                writer.WriteLine("Element added to List");
            }
            public void changedResult()
            {
                writer.WriteLine("Element from List changed");
            }
            public void removedResult()
            {
                writer.WriteLine("Element from List removed");
            }
        }
        public class Queue : ICollection
        {
            public Object[] queue;

            static int count = 0, count1 = 0, count2 = 0;
            public IEnumerator GetEnumerator() => queue.GetEnumerator();

            public event ElementAdded elemAddedToQueueEvent;
            public event ElementChanged elemChangedFromQueueEvent;
            public event ElementRemoved elemRemovedFromQueueEvent;

            public Queue(int n)
            {
                queue = new Object[n];
            }
            public void addedToQueue()
            {
                for (int i = 0; i < count; i++)
                {
                    if (elemAddedToQueueEvent != null)
                    {
                        elemAddedToQueueEvent();
                    }
                }
            }
            public void changedFromQueue()
            {
                for (int i = 0; i < count1; i++)
                {
                    if (elemChangedFromQueueEvent != null)
                    {
                        elemChangedFromQueueEvent();
                    }
                }
            }
            public void removedFromQueue()
            {
                for (int i = 0; i < count2; i++)
                {
                    if (elemRemovedFromQueueEvent != null)
                    {
                        elemRemovedFromQueueEvent();
                    }

                }
            }

            public void Push(Object elem)
            {
                queue[count] = elem;
                count++;
            }

            public void Front(Object elem)
            {
                queue[0] = elem;
                count1++;
            }
            public void Pop()
            {
                queue[0] = null;
                count2++;
            }
            public void addedResult()
            {
                writer.WriteLine("Element added to Queue");
            }
            public void changedResult()
            {
                writer.WriteLine("First Element from Queue changed");
            }
            public void removedResult()
            {
                writer.WriteLine("First Element from Queue removed");
            }
        }
        public class Dictionary : IDictionary
        {
            public Dictionary<Object, Object> map;


            static int count = 0, count1 = 0, count2 = 0;

            public IEnumerator GetEnumerator() => map.GetEnumerator();

            public event ElementAdded elemAddedToDictionaryEvent;
            public event ElementChanged elemChangedFromDictionaryEvent;
            public event ElementRemoved elemRemovedFromDictionaryEvent;

            public Dictionary()
            {
                map = new Dictionary<Object, Object>();
            }
            public void addedToDictionary()
            {
                for (int i = 0; i < count; i++)
                {
                    if (elemAddedToDictionaryEvent != null)
                    {
                        elemAddedToDictionaryEvent();
                    }
                }
            }
            public void changedFromDictionary()
            {
                for (int i = 0; i < count1; i++)
                {
                    if (elemChangedFromDictionaryEvent != null)
                    {
                        elemChangedFromDictionaryEvent();
                    }
                }
            }
            public void removedFromDictionary()
            {
                for (int i = 0; i < count2; i++)
                {
                    if (elemRemovedFromDictionaryEvent != null)
                    {
                        elemRemovedFromDictionaryEvent();
                    }

                }
            }
            public void Add(Object elem1, Object elem2)
            {

                map.Add(elem1, elem2);
                count++;
            }
            public void Change(int i, Object elem1, Object elem2)
            {
                map[i] = new Dictionary<Object, Object>() { { elem1, elem2 } };
                count1++;
            }
            public void Remove(int i)
            {
                map[i] = 9999;
                map.Remove(9999);
                count2++;
            }

            public void addedResult()
            {
                writer.WriteLine("Element added to Dictionary");
            }
            public void changedResult()
            {
                writer.WriteLine("Element from Dictionary changed");
            }
            public void removedResult()
            {
                writer.WriteLine("Element from Dictionary removed");
            }
        }

        public void run()
        {
            writer.WriteLine("List\n");

            List list = new List(10);
            list.elemAddedToListEvent += list.addedResult;
            list.elemChangedFromListEvent += list.changedResult;
            list.elemRemovedFromListEvent += list.removedResult;

            list.Add(1);
            list.Add(1);
            list.Add(1);

            list.Change(1, "5");
            list.Change(2, 10);
            list.Remove(0);

            list.addedToList();
            list.changedFromList();
            list.removedFromList();


            writer.WriteLine();

            writer.WriteLine("Dictionary\n");

            Dictionary dict = new Dictionary();
            dict.elemAddedToDictionaryEvent += dict.addedResult;
            dict.elemChangedFromDictionaryEvent += dict.changedResult;
            dict.elemRemovedFromDictionaryEvent += dict.removedResult;

            dict.Add(7, 8);
            dict.Add(9, "5");


            dict.Change(0, 1, "5");
            dict.Change(0, "5", false);
            dict.Change(1, "d", "g");
            dict.Remove(0);

            dict.addedToDictionary();
            dict.changedFromDictionary();
            dict.removedFromDictionary();

            writer.WriteLine();

            writer.WriteLine("Queue\n");

            Queue queue = new Queue(10);
            queue.elemAddedToQueueEvent += queue.addedResult;
            queue.elemChangedFromQueueEvent += queue.changedResult;
            queue.elemRemovedFromQueueEvent += queue.removedResult;

            queue.Push(8);
            queue.Push("5");

            queue.Front(0);
            queue.Front(false);
            queue.Front("g");
            queue.Pop();

            queue.addedToQueue();
            queue.changedFromQueue();
            queue.removedFromQueue();
            writer.Close();
        }
    }
    public class AutumnLab5
    {
        private static StreamWriter writer;
        public AutumnLab5()
        {
            writer = new("C:\\Users\\Максим\\source\\repos\\CSLab3\\CSLab3\\output.txt");
            writer.AutoFlush = true;
        }
        public interface IEnumerator<T>
        {
            T Current { get; }
            bool MoveNext();
            void Reset();
        }
        public interface IEnumerable
        {
           IEnumerator GetEnumerator();
        }
        class Fibo : IEnumerator
        {
            int n = 8;

            int index = 1;

            int i = 1;
            public Fibo(int n)
            {
                this.n = n;
            }
            public int Current => i;

            object IEnumerator.Current => Current;
            public IEnumerator GetEnumerator() => this;

            public bool MoveNext()
            {

                if (index % 2 == 0)
                {
                    i++;
                    i *= i;

                }
                else
                {
                    i = index;
                }
                index++;

                if (index == n + 2)

                    return false;

                else

                    return true;
            }

            public void Reset() => index = 0;

        }
        static IEnumerable<int> Fibonachi(int n)
        {
            writer.WriteLine("Начало выполнения итератора...");
            for (int i = 1; i < n + 1; i++)
            {
                if (i % 2 == 0) yield return i * i;

                else yield return i;
            }
            writer.WriteLine("\nКонец выполнения итератора...");
        }
        public void run()
        {
            writer.WriteLine("\nПервый способ");

            writer.WriteLine("Начало программы...");
            var iter = Fibonachi(8);
            writer.WriteLine("Начало цикла...");
            foreach (int j in iter)
                writer.Write("{0} ", j);
            writer.WriteLine("Завершение цикла...");

            writer.WriteLine("\nВторой способ");
            var fibo = new Fibo(8);

            foreach (int n in fibo)
            {
                writer.Write("{0} ", n);
            }
            writer.Close();
        }
    }
    public class AutumnLab6
    {

        private static StreamWriter writer;

        public AutumnLab6()
        {
            writer = new("C:\\Users\\Максим\\source\\repos\\CSLab3\\CSLab3\\output.txt");
            writer.AutoFlush = true;
        }
        static void CopyFile(string path, string newName)
        {
            try
            {
                newName += Path.GetExtension(path);//получаем расширение
                string dir = Path.GetDirectoryName(path);//имя директории
                dir += "\\";
                string path2 = dir + newName;//совмещаем
                File.Copy(path, path2);
            }
            catch (IOException) { writer.WriteLine("Указанный файл не существует либо в директории,в которую копируется файл,есть файл с таким же именем"); }
        }

        static void MoveFile(string path, string path1)
        {
            try
            {
                path1 += Path.GetFileName(path);
                File.Move(path, path1);
            }
            catch (IOException) { writer.WriteLine("Такого файла не существует,либо путь перемещения указан неправильно, либо файл с таким названием уже есть в директории перемещения"); }
        }

        static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (IOException) { writer.WriteLine("Такого файла не существует"); }
        }

        static void CreateDir(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (IOException) { writer.WriteLine("Такая директория уже есть"); }
        }

        static void ChangeDir(string path)
        {
            try
            {
                Directory.SetCurrentDirectory(path);

                writer.WriteLine("Текущая директория:\n", Directory.GetCurrentDirectory());
            }
            catch (IOException) { writer.WriteLine("Директория пуста"); }
        }

        static void CheckDir(string path)
        {
            try
            {
                string[] mas = Directory.GetFiles(path);
                string[] mas1 = Directory.GetDirectories(path);
                writer.WriteLine("Файлы директории:");
                foreach (var i in mas) writer.WriteLine(Path.GetFileName(i));

                writer.WriteLine("Папки директории:");
                foreach (var i in mas1) writer.WriteLine(Path.GetFileName(i));

            }
            catch (IOException) { writer.WriteLine("Директория пуста"); }
        }
        static void BubbleSort(DateTime[] a, int n)
        {
            DateTime tmp;
            int L = 0, R = n - 1;
            bool flag = false;
            while (R > 0)
            {
                int j = 0;
                while (j < R)
                {
                    if (a[j] > a[j + 1])
                    {
                        tmp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = tmp;
                        flag = true;
                    }
                    j++;

                }
                if (flag == false)
                {
                    break;
                }
                R--;

            }
        }
        static void SortDir(string path)
        {
            try
            {
                string[] mas = Directory.GetFiles(path);

                DateTime[] dateTimes = new DateTime[mas.Length];
                writer.WriteLine("Файлы директории:");
                for (int i = 0; i < mas.Length; i++) dateTimes[i] = File.GetLastWriteTime(mas[i]);
                BubbleSort(dateTimes, dateTimes.Length);
                for (int i = 0; i < dateTimes.Length; i++)
                {
                    for (int j = 0; j < mas.Length; j++)
                        if (dateTimes[i] == File.GetLastWriteTime(mas[j]))
                            writer.Write(Path.GetFileName(mas[j]));
                    writer.WriteLine(" " + dateTimes[i]);
                }
            }
            catch (IOException) { writer.WriteLine("Директория пуста"); }
        }

        public void run(string input0,string input1,string input2)
        {
            string path = "", path1 = "";

           

            writer.WriteLine("Выбор : ");

            string select = input0;

            writer.WriteLine();
            
            if (select == "1")
            {
                path = input1;
                string name = input2;
                CopyFile(path, name);
            }
            else if (select == "2")
            {
                path = input1;
                path1 = input2;
                MoveFile(path, path1);
            }
            else if (select == "3")
            {
                path = input1;
                DeleteFile(path);
            }
            else if (select == "4")
            {
                path = input1;
                CreateDir(path);
            }
            else if (select == "5")
            {
                path = input1;
                ChangeDir(path);
            }
            else if (select == "6")
            {
                path = input1;
                CheckDir(path);
            }
            else if (select == "7")
            {
                path = input1;
                SortDir(path);
            }
            writer.Close();
        }
    }
    public class SpringLab1
    {
        private static StreamWriter writer;
        public SpringLab1()
        {
            writer = new("C:\\Users\\Максим\\source\\repos\\CSLab3\\CSLab3\\output.txt");
            writer.AutoFlush = true;
        }
        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property)]
        public class CommandLineAttribute : Attribute
        {
            public string CommandSwitch { get; set; }
            public CommandLineAttribute()
            {
                CommandSwitch = " ";
            }
            public CommandLineAttribute(string name)
            {
                this.CommandSwitch = name;
            }

        }

        class Commands
        {
            [CommandLine] public bool IpConfig;
            [CommandLine] public bool GetMac;
            [CommandLine] public bool Netstat;
            [CommandLine] public string Pathping { get; set; }

            [CommandLine]
            public void ping(string address)
            {
                writer.WriteLine("Ping:");
                Process.Start("ping", address).WaitForExit();
                writer.WriteLine();
            }

            [CommandLine]
            public void tracert(string address)
            {
                writer.WriteLine("Tracert:");
                Process.Start("tracert", address).WaitForExit();
                writer.WriteLine();
            }
        }

        class CMD
        {

            public static T ParseCommandLine<T>(string[] args) where T : new()
            {
                Type type = typeof(T);
                T obj = new T();

                bool found = false;
                string command = "";
                string value;

                var Members = type.GetMembers();

                for (int m = 0; m < args.Length; m++)
                {

                    for (int i = 0; i < Members.Length; i++)
                    {

                        if (!args[m].Contains("="))
                        {
                            command = args[m].Substring(1);
                            value = "true";
                        }
                        else
                        {
                            command = args[m].Substring(1, args[m].IndexOf('=') - 1);
                            value = args[m].Substring(args[m].IndexOf('=') + 1);
                        }


                        if (Members[i].Name == command)
                        {

                            found = true;
                            switch (Members[i].MemberType)
                            {
                                case MemberTypes.Field:
                                    {

                                        FieldInfo field = Members[i] as FieldInfo;

                                        var fieldType = field.FieldType;
                                        // Проверяем, входит ли тип поля в список допустимых для командной строки типов данных
                                        if (fieldType == typeof(int) || fieldType == typeof(double) || fieldType == typeof(bool) || fieldType == typeof(string))
                                        {
                                            writer.WriteLine("Type is valid");
                                        }
                                        else
                                        {
                                            writer.WriteLine("Type isn't valid");
                                            break;
                                        }

                                        object convertedValue = null;
                                        try
                                        {
                                            // Пытаемся провести преобразование строкового представления значения параметра командной строки к типу данных поля
                                            convertedValue = Convert.ChangeType(value, fieldType);
                                        }
                                        catch (Exception ex)
                                        {
                                            // Если такое преобразование невозможно, генерируем исключение InvalidCastException
                                            throw new InvalidCastException($"Cannot convert value '{value}' to type {fieldType.FullName}.", ex);
                                        }

            // Используем рефлексию, чтобы присвоить значение преобразованного значения параметра полю объекта
            ((FieldInfo)Members[i]).SetValue(obj, convertedValue);
                                        writer.WriteLine(field.Name + ":");
                                        Process.Start(field.Name).WaitForExit();
                                        writer.WriteLine();

                                    }
                                    break;
                                case MemberTypes.Property:
                                    {

                                        PropertyInfo property = Members[i] as PropertyInfo;
                                        var propertyType = property.PropertyType;
                                        if (propertyType == typeof(int) || propertyType == typeof(double) ||
                                            propertyType == typeof(bool) || propertyType == typeof(string))
                                        {
                                            writer.WriteLine("Type is valid");
                                        }
                                        else
                                        {
                                            writer.WriteLine("Type isn't valid");
                                        }

                                        object convertedValue = null;
                                        try
                                        {
                                            // Пытаемся провести преобразование строкового представления значения параметра командной строки к типу данных поля
                                            convertedValue = Convert.ChangeType(value, propertyType);
                                        }
                                        catch (Exception ex)
                                        {
                                            // Если такое преобразование невозможно, генерируем исключение InvalidCastException
                                            throw new InvalidCastException($"Cannot convert value '{value}' to type {propertyType.FullName}.", ex);
                                        }
                                        if (!property.CanWrite)
                                        {
                                            throw new InvalidOperationException();
                                        }
                                        property.SetValue(obj, convertedValue);
                                        writer.WriteLine(property.Name + ":");
                                        Process.Start(property.Name).WaitForExit();
                                        writer.WriteLine();
                                    }
                                    break;
                                case MemberTypes.Method:
                                    {

                                        var methodInfo = type.GetMethod(command);

                                        if (methodInfo == null)
                                        {
                                            throw new InvalidOperationException($"Method {value} not found.");
                                        }

                                        var parameters = methodInfo.GetParameters();



                                        if (parameters.Length != 1 || (parameters[0].ParameterType != typeof(int) && (parameters[0].ParameterType != typeof(double))
                                            && (parameters[0].ParameterType != typeof(bool)) && (parameters[0].ParameterType != typeof(string))))
                                        {
                                            throw new InvalidOperationException($"Method {args[1]} must have exactly one parameter of valid type.");
                                        }

                                        object convertedValue = null;
                                        try
                                        {
                                            // Пытаемся провести преобразование строкового представления значения параметра командной строки к типу данных поля
                                            convertedValue = Convert.ChangeType(value, parameters[0].ParameterType);
                                        }
                                        catch (Exception ex)
                                        {
                                            // Если такое преобразование невозможно, генерируем исключение InvalidCastException
                                            throw new InvalidCastException($"Cannot convert value '{value}' to type {parameters[0].ParameterType.FullName}.", ex);
                                        }
                                        methodInfo.Invoke(obj, new object[] { convertedValue });
                                    }
                                    
                                    break;
                            }
                        }
                    }

                }

                if (!found) throw new ArgumentException(String.Format("Command", command, "isn't found"), "num");

                return obj;
            }
        }
        public void run()
        {
            CMD.ParseCommandLine<Commands>(new string[4] { "-IpConfig", "-Pathping", "-ping=www.google.com", "-tracert=www.google.com" });
            writer.Close();
        }
    }
    public class SpringLab2
    {
        StreamWriter writer;
        public SpringLab2()
        {
            writer = new("C:\\Users\\Максим\\source\\repos\\CSLab3\\CSLab3\\output.txt");
            writer.AutoFlush = true;
        }
        private static string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
        private static double getIntervalLength(double a, double b, int intervalsCount)
        {
            return (b - a) / intervalsCount;
        }
        private double ThreadPoolWithLock(double[] f, int n, int h)
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
                            total += f[j + h / 2];
                        }
                    }
                });
            }

            Task.WaitAll(tasks);//ждем пока потоки завершат свою работу
            return total;
        }
        private double Rectangle(double[] f, int a, int b)
        {
            int n = f.Length - 1;
            double Integral = 0;
            double h = getIntervalLength(a, b, n);
            Integral = ThreadPoolWithLock(f, n, (int)h);
            return Integral * h;
        }    
        public void run(string input0, string input1, string input2)
        {

            writer.WriteLine("Введите a, b и eps: ");

            int a = int.Parse(input0);
            int b = int.Parse(input1);

            string eps = "0" + input2.Substring(2);
            eps = Reverse(eps);

            int n = b - a + int.Parse(eps);
            double length = getIntervalLength(a, b, n);
            double[] f = new double[n + 1];

            double leftX = a;
            
            writer.WriteLine("------------------------------");
            writer.WriteLine("{1,14:c}{0,8:c}", "x", "y(x)");
            writer.WriteLine("------------------------------");

            for (int k = 0; k <= n; k++, leftX += length)
            {
                writer.WriteLine("{1,20:f15}{0,10:f4}", leftX, Math.Pow(Math.E, leftX) - leftX * leftX * leftX);
                writer.WriteLine("------------------------------");
                f[k] = Math.Pow(Math.E, leftX) - leftX * leftX * leftX;
            }
            writer.WriteLine(Rectangle(f, a, b));
            double result = Math.Pow(Math.E, 4) - 65;
            writer.WriteLine("Проверка: " + result);
            writer.WriteLine("Разница: " + Math.Abs(result - Rectangle(f, a, b)));
            writer.Close();
        }
    }
    public partial class Form1 : Form
    {
        string fileName;
        public Form1()
        {
            InitializeComponent();
            fileName = "C:\\Users\\Максим\\source\\repos\\CSLab3\\CSLab3\\output.txt";
        }
        private void GetTextFromFile()
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                // Чтение содержимого файла
                string fileContent = reader.ReadToEnd();
                // Добавление содержимого файла в RichTextBox
                richTextBox1.AppendText(fileContent);
            }
        }
        private void AutumnLab1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            AutumnLab1 autumnLab1 = new();
            autumnLab1.run(tb1.Text,tb2.Text,tb3.Text,tb4.Text);
            GetTextFromFile();
        }
        private void AutumnLab2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            AutumnLab2 autumnLab2 = new();
            autumnLab2.run();
            GetTextFromFile();
        }
        private void AutumnLab3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            AutumnLab3 autumnLab3 = new();
            autumnLab3.run();
            GetTextFromFile();
        }
        private void AutumnLab5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            AutumnLab5 autumnLab5 = new();
            autumnLab5.run();
            GetTextFromFile();
        }
        private void AutumnLab6_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.AppendText("Файловый менеджер\n\n");
            richTextBox1.AppendText("1)Копировать файл\n");
            richTextBox1.AppendText("2)Переместить файл\n");
            richTextBox1.AppendText("3)Удалить файл\n");
            richTextBox1.AppendText("4)Создать каталог\n");
            richTextBox1.AppendText("5)Изменить каталог\n");
            richTextBox1.AppendText("6)Просмотреть каталог\n");
            richTextBox1.AppendText("7)Сортировать каталог по дате\n");
            richTextBox1.AppendText("8)Выход\n\n");
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            AutumnLab6 autumnLab6 = new();
            autumnLab6.run(tb5.Text, tb6.Text, tb7.Text);
            GetTextFromFile();
        }
        private void SpringLab1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            SpringLab1 springLab1 = new();
            springLab1.run();
            GetTextFromFile();
        }
        private void SpringLab2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            SpringLab2 springLab2 = new();
            springLab2.run(a.Text,b.Text,eps.Text);
            GetTextFromFile();
        }
    }
}