using System.Text;

class GeneticAlgorithm
{
    int[,] matrix;
    List<Tuple<int, int>> intervals;
    int N, M;
    int populationSize;
    int maxBestCount;
    double crossoverProb;
    double mutationProb;
    StreamWriter writer;
    GeneticAlgorithm(int[,] randMatrix, int k, double cp, double mp,int b)
    {
        maxBestCount = b;
        writer = new("C:\\Users\\Максим\\source\\repos\\Alg_Lab5\\Alg_Lab5\\output.txt");
        intervals = new();
        matrix = randMatrix;
        populationSize = k;
        crossoverProb = cp;
        mutationProb = mp;
        N = matrix.GetLength(0);
        M = matrix.GetLength(1);
        int prev = 0;
        writer.WriteLine("Интервалы: ");
        for (int i = 1; i < N + 1; i++)
        {
            var tuple = new Tuple<int, int>(prev, (255 * i) / N);
            intervals.Add(tuple);
           if(i==1) writer.WriteLine(tuple.Item1 + " - " + tuple.Item2);
           else if(i>1) writer.WriteLine(tuple.Item1+1 + " - " + tuple.Item2);
            prev = ((255 * i) / N);
        }
    }
    private int[][] InitializePopulation()
    {
        int[][] population = new int[populationSize][];

        for (int i = 0; i < populationSize; i++)
            population[i] = GenerateRandomSolution();

        return population;
    }
    private int[] GenerateRandomSolution()
    {
        int[] solution = new int[M];

        for (int i = 0; i < M; i++)
            solution[i] = new Random().Next(0, 256);

        return solution;
    }
    private Tuple<int[], int[]> Crossover(int[] parent1, int[] parent2,string p1,string p2)
    {
        int[] child1 = new int[M];
        int[] child2 = new int[M];

        // Single-point crossover
        int crossoverPoint = new Random().Next(1, M);

        writer.WriteLine(" в точке " + crossoverPoint);
        writer.AutoFlush = true;

        for (int i = 0; i < crossoverPoint; i++)
        {
            child1[i] = parent1[i];
            child2[i] = parent2[i];
        }
        for (int i = crossoverPoint; i < M; i++)
        {
            child1[i] = parent2[i];
            child2[i] = parent1[i];
        }
        writer.WriteLine("\nродитель "+p1+": ");
        foreach (var i in parent1) writer.Write("{0}\t", i);
        writer.WriteLine("\nродитель "+p2+": ");
        foreach (var i in parent2) writer.Write("{0}\t", i);
        writer.WriteLine("\nП1(" + p1 + "+" + p2 + "): ");
        for (int i = 0; i < child1.Length; i++)
        {
            writer.Write("{0}\t", child1[i]);
            if (i == crossoverPoint - 1) writer.Write("| ");
        }
        writer.WriteLine("\nП2(" + p2 + "+" + p1 + "): ");
        for (int i = 0; i < child2.Length; i++)
        {
            writer.Write("{0}\t", child2[i]);
            if (i == crossoverPoint - 1) writer.Write("| ");
        }
        writer.WriteLine("\n");

        return new Tuple<int[], int[]>(child1, child2);
    }
    private int[][] Crossover(int[][] selectedPopulation)
    {
        int[][] newPopulation = new int[populationSize][];
        int childrenCount = 0;
        for (int i = 0; i < populationSize; i++)
        {
            int parentIndex1 = i;
            int parentIndex2 = (i + 1) % populationSize;
            int[] o1 = selectedPopulation[parentIndex1];
            int[] selectedSolution = selectedPopulation[i];
            if (new Random().NextDouble() < crossoverProb)
            {
                int[] o2 = selectedPopulation[parentIndex2];
                int parent1Fit = EvaluateSolutionFitness(o1);
                int parent2Fit = EvaluateSolutionFitness(o2);
                Tuple<int[], int[]> pair;
                
                writer.Write("Произошел кроссовер между родителем О" + (parentIndex1 + 1) + " и родителем О" + (parentIndex2 + 1));
                pair = Crossover(o1, o2, "O" + (parentIndex1 + 1),"O" + (parentIndex2 + 1));

                // Применение мутации к новым решениям
                childrenCount++;
                int[] child1 = Mutation(pair.Item1,childrenCount.ToString(), false);
                childrenCount++;
                int[] child2 = Mutation(pair.Item2,childrenCount.ToString(), false);
                int childFit1 = EvaluateSolutionFitness(child1);
                int childFit2 = EvaluateSolutionFitness(child2);
                if (childFit1 < childFit2)
                {
                    if (childFit1 < parent1Fit)
                    {
                        //writer.WriteLine("Потомок 1 лучше родителя");
                        selectedSolution = child1;
                    }
                    if (childFit1 < parent1Fit&& childFit1 < parent2Fit)
                    {
                        writer.WriteLine("Потомок 1 лучше обоих родителей");
                    }
                }
                else
                {
                    if (childFit1 < parent1Fit && childFit2 < parent2Fit && childFit1 < childFit2)
                    {
                        writer.WriteLine("Потомок 1 лучше обоих родителей");
                        selectedSolution = child1;
                    }
                    if (childFit2 < parent1Fit && childFit2 < parent2Fit && childFit2 < childFit1)
                    {
                        writer.WriteLine("Потомок 2 лучше обоих родителей");
                        selectedSolution= child2;
                    }
                }
            }
            else
            {
                int parentFit=EvaluateSolutionFitness(selectedSolution);
                int[] mutParent;
                mutParent = Mutation(selectedSolution, "О"+ (parentIndex1 + 1), true);

                int mutParentFit = EvaluateSolutionFitness(mutParent);
                if(mutParentFit < parentFit) writer.WriteLine("Мутированный родитель лучше немутированного родителя");
            }
            newPopulation[i] = selectedSolution;
        }
        return newPopulation;
    }
    private int EvaluateSolutionFitness(int[] solution)
    {
        int fitness;
        List<List<int>> procMas = new(N);
        for (int i = 0; i < N; i++)
            procMas.Add(new List<int>());
        for (int i = 0; i < solution.Length; i++)
        {
            for (int j = 0; j < N; j++)
                if (solution[i] > intervals[j].Item1 && solution[i] <= intervals[j].Item2)
                    procMas[j].Add(matrix[0, i]);
        }
        int[] loads = new int[N];
        for (int i = 0; i < N; i++)
            loads[i] = procMas[i].Sum();

        fitness = loads.Max();
        return fitness;
    }
    private int[] EvaluatePopulationFitness(int[][] population)
    {
       int[] fitness = new int[populationSize];

        for (int i = 0; i < populationSize; i++)
            fitness[i] = EvaluateSolutionFitness(population[i]);

        return fitness;
    }
    private int[] Mutation(int[] solution, string i,bool mode)
    {
      if (new Random().NextDouble() < mutationProb)
      {
          int index1 = new Random().Next(0, M);
          int index2 = new Random().Next(0, 8);
          int num = solution[index1];
          int prevFitness = EvaluateSolutionFitness(solution);

          if(!mode) writer.WriteLine("Потомок "+i+" до мутации: ");
          else writer.WriteLine("Родитель " + i + " до мутации: ");
            for (int j = 0; j < M; j++)
              writer.Write("{0}\t", matrix[0, j]);
          writer.WriteLine();
          foreach (var j in solution)
              writer.Write("{0}\t", j);
          writer.WriteLine("\n");
          DecodeSolution(solution,true);

         int[] newSolution=Mutate(solution, num, index1, index2);
         int newFitness = EvaluateSolutionFitness(newSolution);

         if(!mode) writer.WriteLine("Произошла мутация гена " + (index1 + 1) + " потомка " + i);
         else writer.WriteLine("Произошла мутация гена " + (index1 + 1) + " родителя " + i);
         if (newFitness < prevFitness) writer.WriteLine("В данной мутации критерий уменьшился");
            writer.WriteLine("Гены: "+solution[index1] + "->" + newSolution[index1]);
           
         for (int j = 0; j < N; j++)
             if (solution[index1] > intervals[j].Item1 && solution[index1] <= intervals[j].Item2)
                 writer.Write("Задание "+matrix[0,index1]+": p" + j+"->");

         for (int j = 0; j < N; j++)
             if (newSolution[index1] > intervals[j].Item1 && newSolution[index1] <= intervals[j].Item2)
                 writer.Write("p" + j+"\n" );

         if (!mode) writer.WriteLine("Потомок " + i + " после мутации:");
         else writer.WriteLine("Родитель " + i + " после мутации:");
         for (int j = 0; j < M; j++)
              writer.Write("{0}\t", matrix[0, j]);
          writer.WriteLine();
          foreach (var j in newSolution)
              writer.Write("{0}\t", j);
          writer.WriteLine("\n");
          DecodeSolution(newSolution,true);
          return newSolution;
      }
        return solution;
    }
    private int[] Mutate(int[] solution,int gene,int index1,int index2)
    {
        int[] newSolution = new int[M];
        for (int i = 0; i < solution.Length; i++) newSolution[i] = solution[i];
        string str = Convert.ToString(gene, 2).PadLeft(8, '0');
        StringBuilder build = new(str);
        if (build[index2] == '0') build[index2] = '1';
        else build[index2] = '0';
        newSolution[index1] = Convert.ToInt32(build.ToString(), 2);
        return newSolution;
    }
    public List<List<int>> Run()
    {
        int[][] population = InitializePopulation();
        int[] bestSolution = population[0];
        double bestFitness = EvaluateSolutionFitness(bestSolution);
        int counter = 0;
        int generation = 0;
        while (true)
        {
            writer.WriteLine("Поколение " + (generation + 1) + ":");
            for (int i = 0; i < population.Length; i++)
            {
            writer.Write("{0}\t", "O" + (i + 1) + ":");
            for (int j = 0; j < M; j++)
                writer.Write("{0}\t", matrix[0, j]);
            writer.WriteLine();
            writer.Write("{0}\t", " ");
            foreach (var j in population[i])
                writer.Write("{0}\t", j);
            writer.WriteLine("\n");
           DecodeSolution(population[i],false);
            }
            // Оценка приспособленности каждого решения в популяции
            int[] fitness = EvaluatePopulationFitness(population);
        
            // Создание новых решений с помощью кроссовера
            int[][] newPopulation = Crossover(population);
            population = newPopulation;
            
            int bestIndex = 0;
            if (bestFitness == fitness.Min()) counter++;
            else counter = 1;
            bestFitness = fitness.Min();
            for (int i = 0; i < fitness.Length; i++)
                if (fitness[i] == bestFitness)
                {
                    bestSolution = population[i];
                    bestIndex = i;
                }
            writer.WriteLine();
            writer.WriteLine("Лучшая особь - O" + (bestIndex + 1) + ": " + string.Join(",", bestSolution));
            writer.WriteLine("Лучшая приспособленность: " + bestFitness + "\n");
            writer.WriteLine();
            if (counter == maxBestCount) {
                writer.WriteLine("Особь c приспособленностью "+bestFitness+" повторилась "+counter+" раз.");
                break;
            }
           
            generation++;
            Console.WriteLine("Поколение - "+generation);
        }
        // Выбор лучшего решения из популяции
        List<List<int>> bestMatrix = DecodeSolution(bestSolution,true);
        return bestMatrix;
    }
    private List<List<int>> DecodeSolution(int[] solution,bool mode)
    {
        List<List<int>> procMas = new(N);
        for (int i = 0; i < N; i++)
            procMas.Add(new List<int>());
        for (int i = 0; i < solution.Length; i++)
        {
            for (int j = 0; j < N; j++)
                if (solution[i] > intervals[j].Item1 && solution[i] <= intervals[j].Item2)
                    procMas[j].Add(matrix[0, i]);
        }
        if (mode)
        {
            for (int j = 0; j < N; j++)
                writer.Write("{0}\t", "p" + j);
            writer.WriteLine();
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    try
                    {
                        writer.Write("{0}\t", procMas[j][i]);
                    }
                    catch
                    {
                        writer.Write("{0}\t", "");
                    }
                }
                writer.WriteLine();
            }
        }
      
        int[] loads = new int[N];
        for (int i = 0; i < N; i++)
        {
            loads[i] = procMas[i].Sum();
           if(mode) writer.Write("{0}\t", loads[i]);
        }
        writer.WriteLine("\n");
        writer.WriteLine("Приспособленность = " + loads.Max());
        writer.WriteLine("\n");

        return procMas;
    }
    static int[,] Randomize(int N, int M, int t1, int t2)//генерация массива с рандомными числами
    {
        int[,] tasks = new int[N, M];
        Random rnd = new();
        for (int i = 0; i < M; i++)
        {
            int num = rnd.Next(t1, t2 + 1);
            for (int j = 0; j < N; j++)
                tasks[j, i] = num;
        }
        return tasks;
    }
    public static void Main()
    {
        int N = 5, M = 12, t1 = 9, t2 = 21;
        int[,] randMatrix = Randomize(N, M, t1, t2);
        GeneticAlgorithm g = new(randMatrix, 11, 0.7, 0.75,10);
   
        g.writer.WriteLine("Начальная матрица");

        g.writer.Write("{0}\t", " ");
        for (int j = 0; j < N; j++)
            g.writer.Write("{0}\t", "p" + j);
        g.writer.WriteLine();
        for (int i = 0; i < M; i++)
        {
            g.writer.Write("{0}\t", i + " |");
            for (int j = 0; j < N; j++)
                g.writer.Write("{0}\t", randMatrix[j, i]);
            g.writer.WriteLine();
        }
        g.Run();
        Console.WriteLine("Конец");
    }
}
