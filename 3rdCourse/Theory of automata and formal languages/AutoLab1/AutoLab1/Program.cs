
using System;

int FindLNumber(char[] alphabet,string word)
{
    int n = alphabet.Length, k = word.Length;
    int sum = 0;
    int num = 0;
    bool found = false;
    for (int i = 0; i < word.Length; i++)  {//проходимся по слову
        if (k < 0) break;
        for (int j = 0; j < n; j++)// проверяем букву на присутствие в алфавите
        {
            if (word[i] == alphabet[j]) {
                num = j + 1;//запоминаем номер буквы в алфавите
                found = true;
            } 
           
        }
         if(!found)
        {
            Console.WriteLine("Буква " + word[i] + " отсутствует в алфавите");
            return 0;
        }
        sum += (int)(Math.Pow(n, k - 1) * num);//формула

       
        Console.Write(n + "^" + (k - 1) + " * " + num);

        if (k > 1) Console.Write(" + ");
        else Console.Write(" = " + sum);

        found = false;
        k--;
    }
    Console.WriteLine();
    return sum;
}

string FindWord(int LNum, char[] alphabet)
{
    int sum = 0, n = alphabet.Length;
    List<int> nums = new();//массив для кода слова
    string word = "";
    for(; ;)
    {
        if (LNum <= n) {
            nums.Add(LNum);
            break;
        }
        if ((LNum % n) == 0)//если остатка нет
        {
            Console.WriteLine(LNum + " = " + (LNum / n) + " * "+n+" + " + 0 + " = " + ((LNum / n) - 1) + " * " + n + " + " + n);
            sum = ((LNum / n) - 1) * n + n;
            nums.Add(n);
            LNum = (LNum / n) - 1;
        }
        else {//если есть
            Console.WriteLine(LNum + " = " + (LNum / n) + " * " + n + " + " + LNum % n);
            sum = (LNum / n) * n + LNum % n;
            nums.Add(LNum % n);
            LNum = LNum / n;
        }
    }

    for(int i=nums.Count-1;i>=0;i--) Console.Write(nums[i] +" ");

    Console.WriteLine();

    for (int j = nums.Count - 1; j >= 0; j--)//преобразуем код в слово, идя с конца
    {
        for (int i = 0; i < alphabet.Length; i++)
        {
            if (nums[j] - 1 == i) word += alphabet[i];
        }
    }

    return word;
}

FindLNumber(new char[3] { 'a','b','c'}, "acbbab");

Console.WriteLine(FindWord(563, new char[3] { 'a', 'b', 'c'}));