using System;
using System.Collections.Generic;

class Program
{
    static int CountLowerLetters(string str)
    {
        int count = 0;
        foreach (char c in str)
            if (char.IsLower(c)) count++;
        return count;
    }

    static int CountUpperLetters(string str)
    {
        int count = 0;
        foreach (char c in str)
            if (char.IsUpper(c)) count++;
        return count;
    }

    static string GetGrammarType(List<string> grammar)
    {
        bool type0 = true, type1 = true, type2 = true, type3 = true;
        foreach (string rule in grammar)
        {
            string[] parts = rule.Split("->");
            string leftSide = parts[0];
            string rightSide = parts[1];
            HashSet<char> leftSymbols = new HashSet<char>(leftSide);
            HashSet<char> rightSymbols = new HashSet<char>(rightSide);
            int leftLen = leftSymbols.Count;
            int rightLen = rightSymbols.Count;

            if (!(leftLen == 1 && CountUpperLetters(rightSide) <= 1))
                type3 = false;
            else continue;

            if (!(leftLen == 1 && (CountUpperLetters(rightSide) + CountLowerLetters(rightSide)) > 0))
                type2 = false;
            else continue;

            if (!(leftLen <= rightLen))
                type1 = false;
            else continue;
        }

        if (type3)
            return "Регулярная грамматика (Тип 3)";
        else if (type2)
            return "Контекстно-свободная грамматика (Тип 2)";
        else if (type1)
            return "Неукорачиваемая (Тип 1)";
        else
            return "Неограниченная грамматика (Тип 0)";
    }

    static void Main()
    {
        List<string> lang1 = new List<string> { "S->aA", "A->bB", "B->b" };
        List<string> lang2 = new List<string> { "S->aBCa", "BC->Ba", "C->c", "B->b" };
        List<string> lang3 = new List<string> { "S->aS", "aS->a" };
        List<string> lang4 = new List<string> { "S->aAbB", "A->aA", "A->E", "B->bB", "B->E" };
       // List<string> grammar = new List<string> { "S->AB", "A->BC", "B->aB", "B->a", "C->bC", "C->b" };

        Console.WriteLine("Пример 1: " + GetGrammarType(lang1));
        Console.WriteLine("Пример 2: " + GetGrammarType(lang2));
        Console.WriteLine("Пример 3: " + GetGrammarType(lang3));
        Console.WriteLine("Пример 4: " + GetGrammarType(lang4));

    }
}