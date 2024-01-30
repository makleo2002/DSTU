public class Automaton
{
    char[] alphabet;
    string[] states;
    string startState;
    HashSet<string> finalStates;
    private List<HashSet<string>> markedStates;
    private Dictionary<string, Dictionary<char, HashSet<string>>> initialTable;

    Automaton(char[] alphabet, string[] states, string startState, HashSet<string> finalStates)
    {
        this.alphabet = alphabet;
        this.states = states;
        this.startState = startState;
        this.finalStates = finalStates;
        markedStates = new List<HashSet<string>>();
        initialTable = new();
    }
    private string StateSetToString(HashSet<string> stateSet)
    {
        // вспомогательная функция для преобразования множества состояний в строку
        return "{" + string.Join(",", stateSet) + "}";
    }
    private void initTable(string[,] transitions)
    {
        // Заполнение начальной таблицы
        for (int i = 0; i < states.Length; i++)
        {
            var dict = new Dictionary<char, HashSet<string>>();
            for (int j = 0; j < alphabet.Length; j++)
            {
                //  Console.Write("({0},{1}): ", states[i], alphabet[j]);
                //  string input = Console.ReadLine();

                HashSet<string> statesTo = transitions[i, j].Split(',').ToHashSet();
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
    private HashSet<string> RemoveUnreachableStates()
    {
        var reachableStates = new HashSet<string> { startState }; //достижимые вершины
        var unprocessedStates = new HashSet<string> { startState };//необработанное состояние
        //проверяем состояния
        while (unprocessedStates.Count > 0)
        {
            //берем непроверенное состояние и удаляем его из множества
            var currentState = unprocessedStates.First();
            unprocessedStates.Remove(currentState);

            foreach (var symbol in alphabet)
            {
                foreach (var nextState in initialTable[currentState][symbol])
                {
                    //если множество достижимых вершин не содержит состояние
                    if (!reachableStates.Contains(nextState))
                    {
                        //помечаем его как достижимое
                        reachableStates.Add(nextState);
                        unprocessedStates.Add(nextState);
                    }
                }
            }
        }

        for (int i = 0; i < states.Length; i++)
        {
            //если состояние не нулевое и недостижимо,то помечаем состояние null-значением и удаляем его из массивов.
            if (states[i] != null && !reachableStates.Contains(states[i]))
            {
                string stateToRemove = states[i];
                states[i] = null; // Можно также удалить состояние из массива, но тогда придется переиндексировать массивы finalStates, markedStates и т.д.
                initialTable.Remove(stateToRemove);
                finalStates.Remove(stateToRemove);
                if (i < markedStates.Count)
                    markedStates[i] = null;
            }
        }
        //возвращаем достижимые вершины
        return reachableStates;
    }

    private Dictionary<string, Dictionary<string, string>> Minimize()
    {
        // Удаление недостижимых состояний
        HashSet<string> reachableStates = RemoveUnreachableStates();
        // Разбиение состояний на классы эквивалентности
        HashSet<string> finalStatesCopy = new HashSet<string>(finalStates);
        HashSet<string> nonFinalStates = new HashSet<string>(reachableStates.Except(finalStates));
        List<HashSet<string>> classes = new List<HashSet<string>> { finalStatesCopy, nonFinalStates };
        Console.WriteLine("Изначальные классы эквивалентности:");
       
        Console.WriteLine($"Класс конечных состояний: {{ {string.Join(", ", classes[0])} }}");
        Console.WriteLine($"Класс начальных состояний: {{ {string.Join(", ", classes[1])} }}\n");
        
        bool changed;
        do
        {
            changed = false;
            for (int i = 0; i < classes.Count; i++)
            {
                var class_ = classes[i];
                var new_classes = new List<HashSet<string>>();
                foreach (var symbol in alphabet)
                {
                    var transitions = new Dictionary<string, HashSet<string>>();
                    foreach (var state in class_)
                    {
                        //Для каждого состояния в классе находится его следующее состояние, куда оно переходит по данному символу.
                        var next_state = initialTable[state][symbol];
                        string str = StateSetToString(next_state);
                        if (!transitions.ContainsKey(str))
                            transitions[str] = new HashSet<string>();
                        transitions[str].Add(state);
                    }
                    //разбиения текущего класса эквивалентности на более мелкие, если переходы из состояний в классе приводят к различным классам эквивалентных состояний.
                    if (transitions.Count > 2)
                    {
                        //проходимся по достижимым состояниям
                        foreach (var transition_class in transitions.Values)
                        {
                            // Дополнительная проверка на нахождение в другом классе эквивалетности
                            if (transition_class.Any(s => classes.Any(c => c.Contains(s) && !c.SetEquals(class_))))
                            {
                                //создаем новый класс,включающий в себя только те состояния, которых нет в исходном классе, и добавляет его в список новых классов.
                                var new_class = new HashSet<string>(transition_class.Where(s => !class_.Contains(s)));
                                new_classes.Add(new_class);
                                changed = true;
                                continue;
                            }
                            //добавляем отделенное состояние, как новый класс.
                            new_classes.Add(transition_class);
                            Console.WriteLine("Классы эквивалентности:");
                            for (int m = 0; m < new_classes.Count; m++)
                            {
                                Console.WriteLine($"Класс {m + 1}: {{ {string.Join(", ", new_classes[m])} }}");
                            }
                        }
                        changed = true;
                        break;
                    }
                }
                //если классы обьединились,то делаем замену старых классов на новые классы.
                if (changed)
                {
                   classes.RemoveAt(i);
                    foreach (var new_class in new_classes)
                        classes.Add(new_class);
                    break;
                }

            }
        } while (changed);

        

        Console.WriteLine("Классы эквивалентности:");
        for (int i = 0; i < classes.Count; i++)
        {
            Console.WriteLine($"Класс {i + 1}: {{ {string.Join(", ", classes[i])} }}");
        }
        // 5. Возвращение результата
        return new();
    }
    private static void Main(string[] args)
    {

        char[] alphabet = { '0', '1' };
        string[] states = { "q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7" };
        string startState = "q0";
        HashSet<string> finalStates = new() { "q2", "q3", "q6", "q7" };
        string[,] transitions = new string[8, 2] {
        {"q1","q4" },{"q5","q6"},{"q1","q6"},{"q2","q3"},{"q1","q5"},{"q5","q6"},{"q5","q2"},{"","q6" }
    };
        Automaton automaton = new Automaton(alphabet, states, startState, finalStates);
        automaton.initTable(transitions);
        Console.WriteLine("\n");
        automaton.Minimize();

    }
}

/*
 Данный алгоритм детерминизации работает с любым конечным состоянием, не обязательно последним. Он перебирает все недетерминированные состояния и строит таблицу переходов для детерминированного автомата. В результате работы алгоритма получается детерминированный автомат, который имеет единственное конечное состояние. Если входное НКА имеет несколько конечных состояний, то они объединяются в одно конечное состояние в детерминированном автомате.
*/