using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public class Automaton
{
    char[] alphabet;
    string[] states;
    string startState;
    HashSet<string> finalStates;
    HashSet<string> initFinalStates;
    private List<HashSet<string>> markedStates;
    private Dictionary<string, Dictionary<char, HashSet<string>>> initialTable;
    private Dictionary<string, Dictionary<char, string>> dfaTable;
    Dictionary<string, Dictionary<char, HashSet<string>>> nfaTable;

    Automaton(char[] alphabet, string[] states, string startState, HashSet<string> finalStates)
    {
        this.alphabet = alphabet;
        this.states = states;
        this.startState = startState;
        this.finalStates = finalStates;
        markedStates = new List<HashSet<string>>();
        initialTable = new();
        dfaTable = new();
        nfaTable = new();
    }

    private HashSet<string> EpsilonClosure(string state)
    {
        // создать множество состояний, в которые можно перейти из state по ε
        var closure = new HashSet<string>();

        // если state пустая строка, то возвращаем пустое множество
        if (string.IsNullOrEmpty(state))
        {
            return closure;
        }

        // иначе добавляем все состояния из state
        foreach (var m in state.Split(','))
            closure.Add(m);


        var i = 0;
        while (i < closure.Count)
        {
            var s = closure.ElementAt(i);
            i++;
            //если состояние есть в таблице и для этого состояния имеется епсилон переход
            if (nfaTable.ContainsKey(s) && nfaTable[s].ContainsKey('e'))
            {
                //смотрим епсилон переходы
                foreach (var t in nfaTable[s]['e'])
                {
                    //если епсилон переход не пустой и если closure его не содержит,то добавляем его в замыкание
                    if (!string.IsNullOrEmpty(t) && !closure.Contains(t))
                    {
                        closure.Add(t);
                    }
                }
            }
        }
        return closure;
    }
    public void FindClosure(string state, HashSet<string> closure)
    {
        if (string.IsNullOrEmpty(state))
        {
            return;
        }

        closure.Add(state);

        foreach (string s in initialTable[state]['e'])
        {
            if (!closure.Contains(s))
            {
                FindClosure(s, closure);
            }
        }
    }

    //множество епсилон замыканий
    public HashSet<string> EpsilonClosures(HashSet<string> states)
    {
        // шаг 13: найти $\varepsilon$-замыкание множества состояний
        var closure = new HashSet<string>();
        foreach (var state in states)
        {
            foreach (var i in EpsilonClosure(state))
            {
                closure.Add(i);
            }

        }
        closure = closure.Distinct().ToHashSet();
        return closure;
    }

    private string StateSetTostring(HashSet<string> stateSet)
    {
        // вспомогательная функция для преобразования множества состояний в строку
        return "{" + string.Join(",", stateSet) + "}";
    }

    public void initTable()
    {
        // Заполнение начальной таблицы
        alphabet = alphabet.Append('e').ToArray();
        for (int i = 0; i < states.Length; i++)
        {
            var dict = new Dictionary<char, HashSet<string>>();
            for (int j = 0; j < alphabet.Length; j++)
            {
                Console.Write("({0},{1}): ", states[i], alphabet[j]);
                string input = Console.ReadLine();

                HashSet<string> statesTo = input.Split(',').ToHashSet();
                dict.Add(alphabet[j], statesTo);

                if (!initialTable.ContainsKey(states[i]))
                {
                    initialTable.Add(states[i], dict);
                }
                else
                {
                    initialTable[states[i]] = dict;
                }
            }
        }

        initFinalStates = finalStates;

        // Выводим таблицу
        Console.WriteLine("Initial Table:");
        Console.Write("{0,-6}", "");
        for (int i = 0; i < alphabet.Length; i++)
        {
            Console.Write("{0,-8}", alphabet[i]);
        }
        Console.WriteLine();

        for (int i = 0; i < states.Length; i++)
        {
            Console.Write("{0,-6}", states[i]);

            for (int j = 0; j < alphabet.Length; j++)
            {
                Console.Write("{0,-8}", string.Join(",", initialTable[states[i]][alphabet[j]]));
            }

            Console.WriteLine();
        }

        
    }
    private void Determine()
    {// Вывод начальной вершины и финальных вершин
        Console.WriteLine("startState: " + startState);
        Console.WriteLine("finalStates: ");
        foreach (var i in finalStates) Console.Write(i + " ");
        Console.WriteLine("\n");

        //меняем состояния q на s
        string[] states1 = new string[states.Length];

        for (int i = 0; i < states1.Length; i++)
        {
            states1[i] = states[i].Replace('q', 's');
        }

        Console.WriteLine();
        //находим епсилон замыкания и формируем таблицу S
        startState = states1[0];
        HashSet<string> finalStates1 = new();
        List<HashSet<string>> closures = new();
        for (int i = 0; i < states.Length; i++)
        {
            HashSet<string> set = new();
            FindClosure(states[i], set);
            closures.Add(set);
            foreach (var f in finalStates)
                if (set.Contains(f)) finalStates1.Add(states1[i]);
        }
        for (int i = 0; i < states1.Length; i++)
        {
            var dict = new Dictionary<char, HashSet<string>>();
            for (int j = 0; j < alphabet.Length - 1; j++)
            {
                HashSet<string> list = new HashSet<string>();
                foreach (var m in initialTable[states[i]][alphabet[j]])
                {
                    list.Add(m.Replace('q', 's'));
                }

                dict.Add(alphabet[j], list);
                if (!nfaTable.ContainsKey(states1[i]))
                {
                    nfaTable.Add(states1[i], dict);
                }
                else
                {
                    nfaTable[states1[i]] = dict;
                }
            }
        }


        finalStates = finalStates1;
        for (int i = 0; i < states.Length; i++)
        {
            states[i] = states[i].Replace('q', 's');
        }
        //вывод епсилон замыканий s
        Console.WriteLine("Замыкания:");
        for (int i = 0; i < closures.Count; i++)
        {
            Console.Write(states[i] + "={");
            for (int j = 0; j < closures[i].Count; j++)
            {
                Console.Write(closures[i].ElementAt(j));
                if (j != closures[i].Count - 1) Console.Write(',');
            }
            Console.Write('}');
            Console.WriteLine();
        }
        // вывод S таблицы
        Console.WriteLine();
        // Выводим таблицу
        Console.WriteLine("NFA Table:");
        Console.Write("{0,-6}", "");
        for (int i = 0; i < alphabet.Length - 1; i++)
        {
            Console.Write("{0,-8}", alphabet[i]);
        }
        Console.WriteLine();

        for (int i = 0; i < states1.Length; i++)
        {
            Console.Write("{0,-6}", states1[i]);

            for (int j = 0; j < alphabet.Length - 1; j++)
            {
                Console.Write("{0,-8}", string.Join(",", nfaTable[states1[i]][alphabet[j]]));
            }

            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("startState: " + startState);
        Console.WriteLine("finalStates: ");
        foreach (var i in finalStates) Console.Write(i + " ");
        Console.WriteLine("\n");

        HashSet<string> closures1 = new();
        List<string> finalDfaStates = new();
        // создать пустое множество недетерминированных состояний
        var unmarkedStates = new List<HashSet<string>>();

        // добавить начальное состояние в множество недетерминированных состояний
        HashSet<string> nfaStart = new HashSet<string> { states[0] };
        unmarkedStates.Add(new HashSet<string>(nfaStart));
        // пока есть недетерминированные состояния
        while (unmarkedStates.Any())
        {
            // выбрать одно недетерминированное состояние и пометить его
            var stateSet = unmarkedStates.First();
            unmarkedStates.RemoveAt(0);
            markedStates.Add(stateSet);

            if (stateSet.Any(s => finalStates.Contains(s)))
            {
                if (!finalDfaStates.Contains(StateSetTostring(stateSet)))
                    finalDfaStates.Add(StateSetTostring(stateSet));
            }
            // для каждого символа алфавита
            foreach (var symbol in alphabet)
            {
                // найти множество состояний, в которые можно перейти из текущего множества по данному символу
                var destStateSet = new HashSet<string>();
                foreach (var state in stateSet)
                {
                    if (nfaTable[state].ContainsKey(symbol))
                    {
                        foreach (var m in nfaTable[state][symbol])
                            destStateSet.Add(m);

                    }
                }

                // найти epsilon-замыкание множества состояний, в которые можно перейти из текущего множества по данному символу
                destStateSet = EpsilonClosures(destStateSet);
                closures1.Add(StateSetTostring(destStateSet));

                // добавить новое состояние в таблицу переходов и множество недетерминированных состояний, если оно еще не было добавлено
                if (!markedStates.Any(s => s.SequenceEqual(destStateSet)) && destStateSet.Any())
                {
                    unmarkedStates.Add(destStateSet);
                }
                var destStateName = StateSetTostring(destStateSet);
                if (!dfaTable.ContainsKey(StateSetTostring(stateSet)))
                    dfaTable.Add(StateSetTostring(stateSet), new Dictionary<char, string>());
                dfaTable[StateSetTostring(stateSet)][symbol] = destStateName;
            }
        }

        string[] pStates = new string[dfaTable.Keys.Count];
        Console.WriteLine("Замыкания:");
        for (int i = 0; i < dfaTable.Keys.Count; i++)
        {
            pStates[i] = "p" + i;
            Console.WriteLine(pStates[i] + "=" + closures1.ElementAt(i));
        }
        Console.WriteLine();
        // Выводим таблицу
        Console.WriteLine("DFA Table:");
        Console.Write("{0,-8}", "");

        // выводим заголовок таблицы
        foreach (var symbol in alphabet)
        {
            if (symbol != 'e') Console.Write("{0,-8}", symbol);
        }
        Console.WriteLine();


        // выводим строки таблицы
        for (int i = 0; i < dfaTable.Keys.Count; i++)
        {

            if (i == 0) startState = pStates[i];

            Console.Write("{0,-8}", pStates[i]);

            foreach (var symbol in alphabet)
            {
                if (symbol != 'e')
                {
                    var destState = dfaTable[dfaTable.Keys.ElementAt(i)][symbol] ?? "";
                    for (int c = 0; c < closures1.Count; c++)
                    {
                        if (destState == closures1.ElementAt(c) && destState != "{}") destState = pStates[c];
                    }
                    if(destState != "{}") Console.Write("{0,-8}", destState);
                    else Console.Write("{0,-8}", "");
                }

            }
            Console.WriteLine();
        }
        Console.WriteLine("Начальные точки:" + startState);
        Console.WriteLine("Конечные точки:");
        for (int i = 0; i < finalDfaStates.Count; i++)
        {
            for (int c = 0; c < closures1.Count; c++)
            {

                if (finalDfaStates[i] == closures1.ElementAt(c) && closures1.ElementAt(c) != "{}") {
                    finalDfaStates[i] = pStates[i + 1];
                } 
                        
            }
        }

        foreach (var i in finalDfaStates) Console.Write(i+" ");
    }
    private bool DepthFirstSearch(string input)
    {
        HashSet<string> visited = new HashSet<string>();
        Stack<string> stack = new Stack<string>();

        stack.Push(dfaTable.Keys.ElementAt(0)); // начальная вершина

        while (stack.Count > 0)
        {
            string currentState = stack.Pop();
            visited.Add(currentState);

            // Если мы достигли конца ввода и текущее состояние является конечным,
            // тогда вывод true
            if (input.Length == 0 && initFinalStates.Contains(currentState))
            {
                return true;
            }

            // Если мы еще не достигли конца ввода, продолжаем исследовать таблицу переходов            
            if (input.Length > 0)
            {
                char currentSymbol = input[0];
                input = input.Substring(1);

                // Если по текущему символу нет перехода, то ввод не принимается автоматом
                if (!initialTable.ContainsKey(currentState) || !initialTable[currentState].ContainsKey(currentSymbol))
                {
                    continue;
                }

                // Исследуем каждое достижимое состояние из текущего состояния с текущим символом
                foreach (string nextState in initialTable[currentState][currentSymbol])
                {
                    if (!visited.Contains(nextState))
                    {
                        stack.Push(nextState);
                    }
                }
            }
        }

        // If we've explored all reachable states and haven't found an accepting state, the input is not accepted by the machine
        return false;
    }
    static void Main(string[] args)
    {
        char[] alphabet = { '1', '0' };
        string[] states = { "q0", "q1", "q2" };
        string startState = "q0";
        HashSet<string> finalStates = new() { "q2" };
        Automaton automaton = new Automaton(alphabet, states, startState, finalStates);

        automaton.initTable();
        automaton.Determine();
        Console.WriteLine("\n");
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "quit") return;
            bool isValid = automaton.DepthFirstSearch(input);
            Console.WriteLine("Цепочка {0} допустима: {1}", input, isValid);
        }

    }
}

/*
 Данный алгоритм детерминизации работает с любым конечным состоянием, не обязательно последним. Он перебирает все недетерминированные состояния и строит таблицу переходов для детерминированного автомата. В результате работы алгоритма получается детерминированный автомат, который имеет единственное конечное состояние. Если входное НКА имеет несколько конечных состояний, то они объединяются в одно конечное состояние в детерминированном автомате.
*/