
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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

class Fibonacci
{
    static IEnumerable<int> Fibonachi(int n)
    {
        Console.WriteLine("Начало выполнения итератора...");
        for (int i = 1; i < n + 1; i++)
        {

            if (i % 2 == 0) yield return i * i;

            else yield return i;


        }

        Console.WriteLine("\nКонец выполнения итератора...");
    }
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        Console.WriteLine("\nПервый способ");

        Console.WriteLine("Начало программы...");
        var iter = Fibonachi(8);
        Console.WriteLine("Начало цикла...");
        foreach (int j in iter)
            Console.Write("{0} ", j);
        Console.WriteLine("Завершение цикла...");

        Console.WriteLine("\nВторой способ");
        var fibo = new Fibo(8);

        foreach (int n in fibo)
        {
            Console.Write("{0} ", n);
        }
    }

}
