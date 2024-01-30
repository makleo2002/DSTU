using System;
using System.Diagnostics;
using System.IO;
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
    GeneticAlgorithm(int[,] randMatrix, int k, double cp, double mp, int b)
    {
        maxBestCount = b;
        writer = new("C:\\Users\\Максим\\source\\repos\\Alg_Lab6\\Alg_Lab6\\output.txt");
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
            if (i == 1) writer.WriteLine(tuple.Item1 + " - " + tuple.Item2);
            else if (i > 1) writer.WriteLine(tuple.Item1 + 1 + " - " + tuple.Item2);
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
    private Tuple<int[], int[]> Crossover(int[] parent1, int[] parent2, string p1, string p2)
    {
        int[] child1 = new int[M];
        int[] child2 = new int[M];
        int crossoverPoint1, crossoverPoint2;
        int num1 = new Random().Next(1, M);
        int num2 = new Random().Next(1, M);
        while (num1 == num2) num2 = new Random().Next(1, M);
        // Double-point crossover
        if (num1 < num2)
        {
            crossoverPoint1 = num1;
            crossoverPoint2 = num2;
        }
        else
        {
            crossoverPoint1 = num2;
            crossoverPoint2 = num1;
        }

        writer.WriteLine(" в точках " + crossoverPoint1 + " и " + crossoverPoint2);
        writer.AutoFlush = true;

        for (int i = 0; i < crossoverPoint1; i++)
        {
            child1[i] = parent1[i];
            child2[i] = parent2[i];
        }
        for (int i = crossoverPoint1; i < crossoverPoint2; i++)
        {
            child1[i] = parent2[i];
            child2[i] = parent1[i];
        }
        for (int i = crossoverPoint2; i < M; i++)
        {
            child1[i] = parent1[i];
            child2[i] = parent2[i];
        }
        int parent1Fit = EvaluateSolutionFitness(parent1,new int[5],false);
        int parent2Fit = EvaluateSolutionFitness(parent2, new int[5], false);
        writer.WriteLine("\nродитель " + p1 + ": ");
        foreach (var i in parent1) writer.Write("{0}\t", i);
        writer.WriteLine("\nПриспособленность " + parent1Fit);
        writer.WriteLine("\nродитель " + p2 + ": ");
        foreach (var i in parent2) writer.Write("{0}\t", i);
        writer.WriteLine("\nПриспособленность " + parent2Fit);
        writer.WriteLine("\nП1(" + p1 + "+" + p2 + "): ");
        for (int i = 0; i < child1.Length; i++)
        {
            writer.Write("{0}\t", child1[i]);
            if (i == crossoverPoint1 - 1) writer.Write("| ");
            if (i == crossoverPoint2 - 1) writer.Write("| ");
        }
        writer.WriteLine("\nП2(" + p2 + "+" + p1 + "): ");
        for (int i = 0; i < child2.Length; i++)
        {
            writer.Write("{0}\t", child2[i]);
            if (i == crossoverPoint1 - 1) writer.Write("| ");
            if (i == crossoverPoint2 - 1) writer.Write("| ");
        }
        writer.WriteLine("\n");

        return new Tuple<int[], int[]>(child1, child2);
    }
    private int[][] Crossover(int[][] selectedPopulation)
    {
        int[][] newPopulation = new int[populationSize][];
        int[][] bestChildren = new int[populationSize][];
        for (int i = 0; i < populationSize; i++)
        {
            int parentIndex1 = i;
            int parentIndex2;
            int num1 = new Random().Next(0, populationSize);
            int num2 = new Random().Next(0, populationSize);
            while (num1 == parentIndex1) num1 = new Random().Next(0, populationSize);
            while (num2 == num1 || num2 == parentIndex1) num2 = new Random().Next(0, populationSize);
            int fitness1 = EvaluateSolutionFitness(selectedPopulation[num1], new int[5], false);
            int fitness2 = EvaluateSolutionFitness(selectedPopulation[num2], new int[5], false);
            if (fitness1 <= fitness2) parentIndex2 = num1;
            else parentIndex2 = num2;

            int parentFit1 = EvaluateSolutionFitness(selectedPopulation[parentIndex1], new int[5], false);
            int parentFit2 = EvaluateSolutionFitness(selectedPopulation[parentIndex2], new int[5], false);

            int[] o1 = selectedPopulation[parentIndex1];
            int[] selectedSolution = selectedPopulation[i];
            if (new Random().NextDouble() < crossoverProb)
            {
             int[] o2 = selectedPopulation[parentIndex2];
             Tuple<int[], int[]> pair;
             
             writer.Write("Произошел кроссовер между родителем О" + (parentIndex1 + 1) + " и родителем О" + (parentIndex2 + 1));
             pair = Crossover(o1, o2, "O" + (parentIndex1 + 1), "O" + (parentIndex2 + 1));
             
             // Применение мутации к новым решениям
             int[] child1 = Mutation(pair.Item1, "1", false);
             int[] child2 = Mutation(pair.Item2, "2", false);
             int[] bestChild=new int[M]; 
             int childFit1 = EvaluateSolutionFitness(child1, new int[5], false);
             int childFit2 = EvaluateSolutionFitness(child2, new int[5], false);
             
             
             if (childFit1<parentFit1&& childFit1 < parentFit2) writer.WriteLine("Потомок 1 лучше обоих родителей");
             else if(childFit2 < parentFit1 && childFit2 < parentFit2) writer.WriteLine("Потомок 2 лучше обоих родителей");
             
             if (childFit1 <= childFit2)
             {
                 writer.WriteLine("Потомок 1 лучше 2 потомка");
                 writer.WriteLine(childFit1 + "<" + childFit2);
                 bestChild = child1;
             }
             else
             {
                 writer.WriteLine("Потомок 2 лучше 1 потомка");
                 writer.WriteLine(childFit2 + "<" + childFit1);
                 bestChild = child2;
             }
             bestChildren[i] = bestChild;
            }
            else
            {
                int[] mutParent;
                mutParent = Mutation(selectedSolution, "О" + (parentIndex1 + 1), true);
                bestChildren[i] = mutParent;
            }
            newPopulation[i] = selectedSolution;
        }
        newPopulation=MergePopulation(newPopulation,bestChildren);
        return newPopulation;
    }
    private int[][] MergePopulation(int[][] newPopulation, int[][] bestChildren)
    {
        int[][] mergedPopulation = newPopulation.Concat(bestChildren).ToArray();
        writer.WriteLine("Удвоенная популяция");
        for (int i = 0; i < mergedPopulation.Length; i++)
        {
            if (i<newPopulation.Length) writer.Write("{0}\t", "O" + (i + 1) + ":");
            else writer.Write("{0}\t", "П" + (i % newPopulation.Length+1) + ":");
            for (int j = 0; j < M; j++)
                writer.Write("{0}\t", matrix[checkGene(mergedPopulation[i][j]), j]);
            writer.WriteLine();
            writer.Write("{0}\t", "");
            foreach (var j in mergedPopulation[i])
                writer.Write("{0}\t", j);
            writer.WriteLine();
            DecodeSolution(mergedPopulation[i],new int[5], false);
        }

        int[] populationFitness;
        populationFitness = EvaluatePopulationFitness(mergedPopulation,true);
        Array.Sort(populationFitness, mergedPopulation);

        writer.WriteLine("Сортировка:");
        for (int i = 0; i < mergedPopulation.Length; i++)
        {
            writer.Write("{0}\t", "O" + (i + 1) + ":");
            for (int j = 0; j < M; j++)
                writer.Write("{0}\t", matrix[checkGene(mergedPopulation[i][j]), j]);
            writer.WriteLine();
            writer.Write("{0}\t", "");
            foreach (var j in mergedPopulation[i])
                writer.Write("{0}\t", j);
            writer.WriteLine();
            DecodeSolution(mergedPopulation[i], new int[5], false);
        }

        int[][] resultPopulation = new int[populationSize][];
        for(int i = 0; i < populationSize; i++)
            resultPopulation[i] = mergedPopulation[i];

        return resultPopulation;
    }
    private int EvaluateSolutionFitness(int[] solution, int[] oldMatrix,bool mode)
    {
        int fitness;
        List<List<int>> procMas = new(N);
        for (int i = 0; i < N; i++)
            procMas.Add(new List<int>());
        for (int i = 0; i < solution.Length; i++)
        {
            int index = checkGene(solution[i]);
            if (mode) procMas[index].Add(oldMatrix[i]);
            else procMas[index].Add(matrix[index, i]);
        }
        int[] loads = new int[N];
        for (int i = 0; i < N; i++)
            loads[i] = procMas[i].Sum();

        fitness = loads.Max();
        return fitness;
    }
    private int[] EvaluatePopulationFitness(int[][] population,bool mode)
    {
        int[] fitness;
        if (!mode)
        {
            fitness = new int[populationSize];
            for (int i = 0; i < populationSize; i++)
                fitness[i] = EvaluateSolutionFitness(population[i], new int[5], false);
        }
        else {
            fitness = new int[population.Length];
            for (int i = 0; i < population.Length; i++)
                fitness[i] = EvaluateSolutionFitness(population[i], new int[5], false);
        } 
        return fitness;
    }
    private int[] Mutation(int[] solution, string i, bool mode)
    {
        if (new Random().NextDouble() < mutationProb)
        {
            int geneNum = new Random().Next(0, M);
            int bit1 = new Random().Next(0, 8);
            int bit2 = new Random().Next(0, 8);
            while (bit1 == bit2) bit2 = new Random().Next(0, 8);

            int prevFitness = EvaluateSolutionFitness(solution, new int[5], false);
            int[] oldMatrix = new int[M];

            if (!mode) writer.WriteLine("Потомок " + i + " до мутации: ");
            else writer.WriteLine("Родитель " + i + " до мутации: ");
            for (int j = 0; j < M; j++)
            {
                oldMatrix[j]=(matrix[checkGene(solution[j]), j]);
                writer.Write("{0}\t", oldMatrix[j]);
            }
               
            writer.WriteLine();
            foreach (var j in solution)
                writer.Write("{0}\t", j);
            writer.WriteLine("\n");
            DecodeSolution(solution,oldMatrix,true);

            int[] newSolution = Mutate(solution,geneNum,bit1,bit2);
        
            int newFitness = EvaluateSolutionFitness(newSolution,oldMatrix,true);

            if (!mode) writer.WriteLine("Произошла мутация гена " + (geneNum + 1) + " потомка " + i);
            else writer.WriteLine("Произошла мутация гена " + (geneNum + 1) + " родителя " + i);
         
            if (newFitness < prevFitness) writer.WriteLine("В данной мутации критерий уменьшился");
            writer.WriteLine("Ген: " + solution[geneNum]+"->"+ newSolution[geneNum]);
            for (int j = 0; j < N; j++)
                if (solution[geneNum] > intervals[j].Item1 && solution[geneNum] <= intervals[j].Item2)
                    writer.Write("Задание " + oldMatrix[geneNum] + ": p" + j + "->");

            for (int j = 0; j < N; j++)
                if (newSolution[geneNum] > intervals[j].Item1 && newSolution[geneNum] <= intervals[j].Item2)
                    writer.Write("p" + j + "\n");

            if (!mode) writer.WriteLine("Потомок " + i + " после мутации:");
            else writer.WriteLine("Родитель " + i + " после мутации:");
            for (int j = 0; j < M; j++)
                writer.Write("{0}\t", oldMatrix[j]);
            writer.WriteLine();
            foreach (var j in newSolution)
                writer.Write("{0}\t", j);
            writer.WriteLine("\n");
            DecodeSolution(newSolution,oldMatrix,true);
            return newSolution;
        }
        return solution;
    }
    private int[] Mutate(int[] solution, int geneNum, int bit1, int bit2)
    {
        int[] newSolution = new int[M];
        for (int i = 0; i < solution.Length; i++) newSolution[i] = solution[i];
        string str = Convert.ToString(solution[geneNum], 2).PadLeft(8, '0');
        StringBuilder build = new(str);
         var temp = build[bit1];
        build[bit1] = build[bit2];
        build[bit2] = temp;
        writer.WriteLine("Произошел обмен "+(bit1+1)+" бита с "+ (bit2+1)+" битом");
        newSolution[geneNum] = Convert.ToInt32(build.ToString(), 2);
        writer.WriteLine(solution[geneNum] + "=" + str + "=" + build.ToString() + "=" + newSolution[geneNum]);
        return newSolution;
    }
    private int checkGene(int gene)
    {
        for (int j = 0; j < N; j++)
            if (gene > intervals[j].Item1 && gene <= intervals[j].Item2)
                return j;
        return 0;
    }
    public void Run()
    {
        int[][] population = InitializePopulation();
        int[] bestSolution = population[0];
        double bestFitness = EvaluateSolutionFitness(bestSolution, new int[5], false);
        int counter = 0;
        int generation = 0;
        while (true)
        {
            writer.WriteLine("Поколение " + (generation + 1) + ":");
            for (int i = 0; i < population.Length; i++)
            {

                writer.Write("{0}\t", "O" + (i + 1) + ":");
                for (int j = 0; j < M; j++)
                    writer.Write("{0}\t", matrix[checkGene(population[i][j]), j]);
                writer.WriteLine();
                writer.Write("{0}\t", " ");
                foreach (var j in population[i])
                    writer.Write("{0}\t", j);
                writer.WriteLine("\n");
                DecodeSolution(population[i],new int[5],false);
            }
            int[] fitness = EvaluatePopulationFitness(population,false);
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
            writer.WriteLine("\nЛучшая особь - O" + (bestIndex + 1) + ": " + string.Join(",", bestSolution));
            writer.WriteLine("Лучшая приспособленность: " + bestFitness + "\n\n");

            // Оценка приспособленности каждого решения в популяции
         

            // Создание новых решений с помощью кроссовера
            int[][] newPopulation = Crossover(population);
            population = newPopulation;

          
            if (counter == maxBestCount)
            {
                writer.WriteLine("Особь c приспособленностью " + bestFitness + " повторилась " + counter + " раз.");
                break;
            }

            generation++;
            Console.WriteLine("Поколение - " + generation);

        }
        // Выбор лучшего решения из популяции
        //DecodeSolution(bestSolution, true);
    }
    private int[] DecodeSolution(int[] solution,int[] oldMatrix, bool mode)
    {
        List<List<int>> procMas = new(N);
        for (int i = 0; i < N; i++)
            procMas.Add(new List<int>());
        for (int i = 0; i < solution.Length; i++)
        {
            int index = checkGene(solution[i]);
            if (mode) procMas[index].Add(oldMatrix[i]);
            else procMas[index].Add(matrix[index, i]);
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
        if(mode)
        {
            writer.WriteLine("Фенотип");
            for (int j = 0; j < N; j++)
                writer.Write("{0}\t", "p" + j);
            writer.WriteLine();
        }
        for (int i = 0; i < N; i++)
        {
            loads[i] = procMas[i].Sum();
            if (mode) writer.Write("{0}\t", loads[i]);
        }
        writer.WriteLine("\nПриспособленность = " + loads.Max());
        writer.WriteLine("\n");

        return loads;
    }
    static int[,] Randomize(int N, int M, int t1, int t2)//генерация массива с рандомными числами
    {
        int[,] tasks = new int[N, M];
        Random rnd = new();
        for (int i = 0; i < M; i++)
            for (int j = 0; j < N; j++)
                tasks[j, i] = rnd.Next(t1, t2 + 1);
        return tasks;
    }
    public static void Main()
    {
        int N = 4, M = 12, t1 = 10, t2 = 20;
        int[,] randMatrix = Randomize(N, M, t1, t2);
        GeneticAlgorithm g = new(randMatrix, 10, 0.8, 0.8, 10);

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

