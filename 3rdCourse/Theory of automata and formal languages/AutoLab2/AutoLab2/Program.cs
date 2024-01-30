//Произвольная цепочка символов a, b и c, заканчивающаяся символом !
//Произвольная цепочка символов a, b и c, заканчивающаяся символами сс
using System;
using System.Security;
using System.Text.RegularExpressions;

class Program
{
    static List<char> alphabet=new List<char>() { 'a', 'b', 'c' };
    static List<string> GenerateWords(int n, List<char> alph)
    {
        
        List<string> words = new();
        int alphabetSize = alph.Count;

        for (int i = 0; i < n; i++)
        {
            // Преобразование индекса в базовый алфавит и добавление соответствующих букв
            string word = "";
            int index = i;
            while (index > 0)//генерация символов в слове
            {
                int remainder = index % alphabetSize;//Вычисляет остаток от деления index на размер алфавита.
                word = alph[remainder] + word;//Добавляет символ, соответствующий остатку, в начало слова.
                index /= alphabetSize;// Уменьшает значение index на размер алфавита
            }
            while (word.Length < 1)//Добавление недостающих символов
            {
                word = alph[0] + word;
            }
            Console.WriteLine(word);
            words.Add(word);
        }
        return words;
    }
    static void FindRegex(string finalChars)
    {
        char symbol=' ';
        List<char> newAlphabet = new();
        foreach(var i in alphabet)
        {
            newAlphabet.Add(i);
        }
        for (int j = 0; j < finalChars.Length; j++)
            if (!newAlphabet.Contains(finalChars[j])) {
                symbol = finalChars[j];
                newAlphabet.Add(finalChars[j]);
        }
        Console.WriteLine("Words:");
        List<string> words = GenerateWords(30,newAlphabet);

        string regex = "^[";
        for(int i = 0; i < newAlphabet.Count; i++)
        {
           if(newAlphabet[i]!=symbol) regex += newAlphabet[i];
        }
        regex += "]*" + finalChars;
        Console.WriteLine("Regular expression: " + regex);
        regex += "$";

        List<string> matchingWords = new List<string>();
        foreach (string word in words)
        {
            if (Regex.IsMatch(word, regex))
            {
                matchingWords.Add(word);
            }
        }
        
            Console.WriteLine("Matching words: ");
            foreach (string word in matchingWords)
            {
                Console.WriteLine(word);
            }
        Console.WriteLine("\n");
        
       

    }
    static void Main(string[] args)
    {
        
        FindRegex("!");
        FindRegex("cc");
      
       
       

    }
}