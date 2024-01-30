using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Alg_Lab7WPF
{
    public partial class MainWindow : Window
    {  
        class Graph
        {
            private int numVertices;
            private int[,] adjacencyMatrix;
            private int populationSize;
            double crossoverProb;
            double mutationProb;
            private int maxBestCount;
            StreamWriter writer;
            int[] path1, path2;
            Canvas canvas;

            public Graph(int num, int[,] matrix, int pSize, double cp, double mp, int maxbc)
            {
                numVertices = num;
                adjacencyMatrix = matrix;
                populationSize = pSize;
                crossoverProb = cp;
                mutationProb = mp;
                maxBestCount = maxbc;
                writer = new StreamWriter("C:\\Users\\Максим\\source\\repos\\Alg_Lab7WPF\\output.txt");
                writer.AutoFlush = true;
                writer.WriteLine("Матрица смежности");

                // Вывод номеров столбцов
                writer.Write("{0}\t", "");
                for (int j = 0; j < numVertices; j++)
                    writer.Write("{0}\t",(j+1));
                writer.WriteLine();

                for (int i = 0; i < numVertices; i++)
                {
                    // Вывод номеров строк
                    writer.Write("{0}\t",(i+1));

                    for (int j = 0; j < numVertices; j++)
                        writer.Write("{0}\t",adjacencyMatrix[i, j]);
                    writer.WriteLine();
                }
            }
            int[][] InitializePopulation(int firstNum)
            {
                int[][] population = new int[populationSize][];

                for (int i = 0; i < populationSize; i++)
                    population[i] = GenerateRandomSolution(firstNum);

                return population;
            }
            int[] GenerateRandomSolution(int firstNum)
            {
                int[] solution = new int[numVertices + 1];
                List<int> vertices = new() { };
                vertices.Add(firstNum);
                solution[0] = firstNum;
                solution[numVertices] = firstNum;

                for (int i = 1; i < numVertices; i++)
                {
                    int num = new Random().Next(1, numVertices + 1);
                    while (vertices.Contains(num))
                    {
                        num = new Random().Next(1, numVertices + 1);
                    }
                    vertices.Add(num);
                    solution[i] = num;
                }

                return solution;
            }
            Tuple<int[], int[]> Crossover(int[] parent1, int[] parent2, string p1, string p2)
            {
                int crossoverPoint = new Random().Next(1, numVertices + 1);
                int[] child1 = new int[numVertices + 1];
                int[] child2 = new int[numVertices + 1];
                for (int i = 0; i < crossoverPoint; i++)
                {
                    child1[i] = parent1[i];
                    child2[i] = parent2[i];
                }
                int child1Index = crossoverPoint;
                int child2Index = crossoverPoint;
                for (int i = crossoverPoint; i < numVertices + 1; i++)
                {
                    if (!child1.Contains(parent2[i]))
                    {
                        child1[child1Index] = parent2[i];
                        child1Index++;
                    }
                    if (!child2.Contains(parent1[i]))
                    {
                        child2[child2Index] = parent1[i];
                        child2Index++;
                    }
                }
                if (child1Index != numVertices + 1)
                    for (int i = crossoverPoint; i < numVertices + 1; i++)
                    {
                        if (i == numVertices)
                        {

                            child1[numVertices] = parent1[0];
                            child1Index++;
                        }
                        else if (!child1.Contains(parent1[i]))
                        {
                            child1[child1Index] = parent1[i];
                            child1Index++;
                        }
                    }
                if (child2Index != numVertices + 1)
                    for (int i = crossoverPoint; i < numVertices + 1; i++)
                    {
                        if (i == numVertices)
                        {
                            child2[numVertices] = parent2[0];
                            child2Index++;
                        }
                        else if (!child2.Contains(parent2[i]))
                        {
                            child2[child2Index] = parent2[i];
                            child2Index++;
                        }
                    }
                int parent1Fit = EvaluateSolutionFitness(parent1);
                int parent2Fit = EvaluateSolutionFitness(parent2);
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
            int[][] Crossover(int[][] selectedPopulation)
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
                    int fitness1 = EvaluateSolutionFitness(selectedPopulation[num1]);
                    int fitness2 = EvaluateSolutionFitness(selectedPopulation[num2]);
                    if (fitness1 <= fitness2) parentIndex2 = num1;
                    else parentIndex2 = num2;

                    int parentFit1 = EvaluateSolutionFitness(selectedPopulation[parentIndex1]);
                    int parentFit2 = EvaluateSolutionFitness(selectedPopulation[parentIndex2]);

                    int[] o1 = selectedPopulation[parentIndex1];
                    int[] selectedSolution = selectedPopulation[i];
                    if (new Random().NextDouble() < crossoverProb)
                    {
                        int[] o2 = selectedPopulation[parentIndex2];
                        Tuple<int[], int[]> pair;

                        writer.Write("Произошел кроссовер между родителем О" + (parentIndex1 + 1) + " и родителем О" + (parentIndex2 + 1));
                        pair = Crossover(o1, o2, "O" + (parentIndex1 + 1), "O" + (parentIndex2 + 1));

                        // Применение мутации к новым решениям
                        int[] child1 = Mutation(pair.Item1, "П1");
                        int[] child2 = Mutation(pair.Item2, "П2");
                        int[] bestChild = new int[numVertices + 1];
                        int childFit1 = EvaluateSolutionFitness(child1);
                        int childFit2 = EvaluateSolutionFitness(child2);

                        if (childFit1 < parentFit1 && childFit1 < parentFit2) writer.WriteLine("Потомок 1 лучше обоих родителей");
                        else if (childFit2 < parentFit1 && childFit2 < parentFit2) writer.WriteLine("Потомок 2 лучше обоих родителей");

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
                        mutParent = Mutation(selectedSolution, "О" + (parentIndex1 + 1));
                        bestChildren[i] = mutParent;
                    }
                    newPopulation[i] = selectedSolution;
                }
                newPopulation = MergePopulation(newPopulation, bestChildren);
                return newPopulation;
            }
            int[][] MergePopulation(int[][] newPopulation, int[][] bestChildren)
            {
                int[][] mergedPopulation = newPopulation.Concat(bestChildren).ToArray();
                writer.WriteLine("Удвоенная популяция");
                for (int i = 0; i < mergedPopulation.Length; i++)
                {
                    if (i < newPopulation.Length) writer.Write("{0}\t", "O" + (i + 1) + ": ");
                    else writer.Write("{0}\t", "П" + (i % newPopulation.Length + 1) + ": ");
                    foreach (var j in mergedPopulation[i])
                        writer.Write("{0}\t", j);
                    int fit = EvaluateSolutionFitness(mergedPopulation[i]);
                    writer.WriteLine("\nПриспособленность: " + fit);
                }

                int[] populationFitness;
                populationFitness = EvaluatePopulationFitness(mergedPopulation);
                Array.Sort(populationFitness, mergedPopulation);

                writer.WriteLine("Сортировка:");
                for (int i = 0; i < mergedPopulation.Length; i++)
                {
                    writer.Write("{0}\t", "O" + (i + 1) + ": ");
                    foreach (var j in mergedPopulation[i])
                        writer.Write("{0}\t", j);
                    int fit = EvaluateSolutionFitness(mergedPopulation[i]);
                    writer.WriteLine("\nПриспособленность: " + fit);
                }

                int[][] resultPopulation = new int[populationSize][];
                for (int i = 0; i < populationSize; i++)
                    resultPopulation[i] = mergedPopulation[i];

                return resultPopulation;
            }
            int[] EvaluatePopulationFitness(int[][] population)
            {
                int[] fitness = new int[population.Length];
                for (int i = 0; i < population.Length; i++)
                    fitness[i] = EvaluateSolutionFitness(population[i]);
                return fitness;
            }
            int EvaluateSolutionFitness(int[] solution)
            {
                int fitness = 0;
                for (int i = 0; i < solution.Length - 1; i++)
                    fitness += adjacencyMatrix[solution[i] - 1, solution[i + 1] - 1];
                return fitness;
            }
            int[] Mutation(int[] solution, string name)
            {
                if (new Random().NextDouble() < mutationProb)
                {
                    int num1 = new Random().Next(1, numVertices);
                    int num2 = new Random().Next(1, numVertices);
                    while (num2 == num1) num2 = new Random().Next(1, numVertices);
                    writer.WriteLine("Мутация:");
                    writer.WriteLine(name + " до мутации:");
                    foreach (var j in solution)
                        writer.Write("{0}\t", j);
                    int prevFitness = EvaluateSolutionFitness(solution);
                    writer.WriteLine("\nПриспособленность: " + prevFitness);
                    writer.WriteLine("\nМутация гена №" + num1 + " и гена №" + num2 + " " + name);
                    writer.WriteLine("Гены:" + solution[num1] + "<->" + solution[num2]);


                    int temp = solution[num1];
                    solution[num1] = solution[num2];
                    solution[num2] = temp;
                    int newFitness = EvaluateSolutionFitness(solution);
                    if(newFitness<prevFitness) writer.WriteLine("Критерий уменьшился");
                    writer.WriteLine(name + " после мутации:");

                    foreach (var j in solution)
                        writer.Write("{0}\t", j);
                  
                    writer.WriteLine("\nПриспособленность: " + newFitness);

                }
                return solution;
            }
            public async Task<Tuple<int, int[]>> Run(int firstNum)
            {
                int[][] population = InitializePopulation(firstNum);
                int[] bestSolution = population[0];
                int bestFitness = EvaluateSolutionFitness(bestSolution);
                int counter = 0;
                int generation = 0;
                while (true)
                {
                    writer.WriteLine("\nПоколение " + (generation + 1) + ":");
                    for (int i = 0; i < population.Length; i++)
                    {
                        writer.Write("O" + (i + 1) + ":");
                        writer.Write("{0}\t", " ");
                        foreach (var j in population[i])
                            writer.Write("{0}\t", j);
                        int fit = EvaluateSolutionFitness(population[i]);
                        writer.WriteLine("\nПриспособленность: " + fit);
                    }

                    // Оценка приспособленности каждого решения в популяции
                    int[] fitness = EvaluatePopulationFitness(population);
                    int bestIndex = 0;
                    if (bestFitness == fitness.Min())
                        counter++;
                    else
                        counter = 1;
                    bestFitness = fitness.Min();
                    for (int i = 0; i < fitness.Length; i++)
                    {
                        if (fitness[i] == bestFitness)
                        {
                            bestSolution = population[i];
                            bestIndex = i;
                        }
                    }
                    writer.WriteLine("\nЛучшая особь - O" + (bestIndex + 1) + ": " + string.Join(",", bestSolution));
                    writer.WriteLine("Лучшая приспособленность: " + bestFitness + "\n\n");

                    // Создание новых решений с помощью кроссовера
                    int[][] newPopulation = Crossover(population);
                    population = newPopulation;
                    if (counter == maxBestCount)
                    {
                        writer.WriteLine("Особь c приспособленностью " + bestFitness + " повторилась " + counter + " раз.");
                        break;
                    }
                    generation++;
                }

                // Выбор лучшего решения из популяции
                return new Tuple<int, int[]>(bestFitness, bestSolution);
            }
            public Tuple<int, int[]> GreedyAlg(int numVertice)
            {
                numVertice--;
                int sum = 0;
                int[] path = new int[numVertices];
                List<int> vertices = new List<int>();
                vertices.Add(numVertice);
                for (int i = 0; i < numVertices; i++)
                {
                    int min = int.MaxValue;
                    int minInd = 0;

                    for (int j = 0; j < numVertices; j++)
                    {
                        if (i == numVertices - 1)
                        {
                            min = adjacencyMatrix[numVertice, vertices[0]];
                            minInd = vertices[0];
                        }
                        else
                        {
                            if (adjacencyMatrix[numVertice, j] < min && !vertices.Contains(j) && adjacencyMatrix[numVertice, j] != 0)
                            {
                                min = adjacencyMatrix[numVertice, j];
                                minInd = j;
                            }
                        }

                    }
                    sum += min;
                    path[i] = minInd + 1;
                    numVertice = minInd;
                    vertices.Add(numVertice);

                }
                int[] newPath = new int[numVertices + 1];
                newPath[0] = path[numVertices - 1];
                for (int m = 1; m < numVertices + 1; m++) newPath[m] = path[m - 1];
                return new Tuple<int, int[]>(sum, newPath);
            }
            public void DrawGraph(int sum1, int[] path1, int sum2, int[] path2, Canvas canvas)
            {
                this.path1 = path1;
                this.path2 = path2;
                this.canvas = canvas;
                DrawVertices();
                DrawEdges();
                DrawLabels(sum1, sum2);
            }
            private void DrawVertices()
            {
                int centerX = 200;
                int centerY = 200;
                int radius = 150;

                // Draw vertices
                for (int i = 0; i < numVertices; i++)
                {
                    double angle = 2 * Math.PI * i / numVertices;
                    int x = (int)(centerX + radius * Math.Cos(angle));
                    int y = (int)(centerY + radius * Math.Sin(angle));

                    Ellipse ellipse = new Ellipse();
                   
                    ellipse.Stroke = Brushes.Black;
                    ellipse.Width = 40;
                    ellipse.Height = 40;
                    ellipse.Margin = new Thickness(x - 20, y - 20, 0, 0);
                    canvas.Children.Add(ellipse);

                    Label label = new Label();
                    label.Content = (i + 1).ToString();
                    label.FontSize = 16;

                    label.Margin = new Thickness(x - 10, y - 18, 0, 0);
                    canvas.Children.Add(label);
                }
            }
            private void DrawEdges()
            {
                int centerX = 200;
                int centerY = 200;
                int radius = 150;

                // Draw edges
                for (int i = 0; i < numVertices; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (adjacencyMatrix[i, j] != 0)
                        {
                            double angle1 = 2 * Math.PI * i / numVertices;
                            double angle2 = 2 * Math.PI * j / numVertices;

                            // Calculate edge start and end points based on vertex positions
                            int x1 = (int)(centerX + (radius - 20) * Math.Cos(angle1));
                            int y1 = (int)(centerY + (radius - 20) * Math.Sin(angle1));
                            int x2 = (int)(centerX + (radius - 20) * Math.Cos(angle2));
                            int y2 = (int)(centerY + (radius - 20) * Math.Sin(angle2));

                            Line line = new Line();
                            line.Stroke = Brushes.Black;
                            line.X1 = x1;
                            line.Y1 = y1;
                            line.X2 = x2;
                            line.Y2 = y2;
                            canvas.Children.Add(line);
                        }
                    }
                }
            }
            private void DrawPathEdges(int[] path,SolidColorBrush brush)
            {
                int centerX = 200;
                int centerY = 200;
                int radius = 150;

                for (int i = 0; i < path.Length - 1; i++)
                {
                    int vertex1 = path[i] - 1;
                    int vertex2 = path[i + 1] - 1;

                    double angle1 = 2 * Math.PI * vertex1 / numVertices;
                    double angle2 = 2 * Math.PI * vertex2 / numVertices;

                    // Calculate edge start and end points based on vertex positions
                    int x1 = (int)(centerX + (radius - 20) * Math.Cos(angle1));
                    int y1 = (int)(centerY + (radius - 20) * Math.Sin(angle1));
                    int x2 = (int)(centerX + (radius - 20) * Math.Cos(angle2));
                    int y2 = (int)(centerY + (radius - 20) * Math.Sin(angle2));

                    Line line = new Line();
                    line.Stroke = brush; // Set the color for the path edges
                    line.StrokeThickness = 2;
                    line.X1 = x1;
                    line.Y1 = y1;
                    line.X2 = x2;
                    line.Y2 = y2;
                    canvas.Children.Add(line);
                }
              
            }
            private void DrawLabels(int sum1, int sum2)
            {
                Label alg1 = new Label();
                alg1.Content = "Жадный алгоритм";
                alg1.Margin = new Thickness(10, 380, 0, 0);
                canvas.Children.Add(alg1);

                Label sumLabel1 = new Label();
                sumLabel1.Content = "Сумма: " + sum1;
                sumLabel1.Margin = new Thickness(10, 410, 0, 0);
                canvas.Children.Add(sumLabel1);

                Label pathLabel1 = new Label();
                pathLabel1.Width = 120;
                pathLabel1.Height = 50;

                string text1 = "Путь: ";
                for (int i = 0; i < path1.Length; i++) text1 += path1[i];
                pathLabel1.Content = text1;
                pathLabel1.Margin = new Thickness(10, 430, 0, 0);
                canvas.Children.Add(pathLabel1);

                Button btn1= new Button();
                btn1.Content = "Показать";
                btn1.Click += new RoutedEventHandler(btn1_Click);
                btn1.Margin = new Thickness(10, 470, 0, 0);
                canvas.Children.Add(btn1);

                Label alg2 = new Label();
                alg2.Content = "Генетический алгоритм";
                alg2.Margin = new Thickness(200, 380, 0, 0);
                canvas.Children.Add(alg2);

                Label sumLabel2 = new Label();
                sumLabel2.Content = "Сумма: " + sum2;
                sumLabel2.Margin = new Thickness(200, 410, 0, 0);
                canvas.Children.Add(sumLabel2);

                Label pathLabel2 = new Label();
                pathLabel2.Width = 120;
                pathLabel2.Height = 50;

                string text2 = "Путь: ";
                for (int i = 0; i < path1.Length; i++) text2 += path2[i];
                pathLabel2.Content = text2;
                pathLabel2.Margin = new Thickness(200, 430, 0, 0);
                canvas.Children.Add(pathLabel2);

                Button btn2 = new Button();
                btn2.Content = "Показать";
                btn2.Click += new RoutedEventHandler(btn2_Click);
                btn2.Margin = new Thickness(200, 470, 0, 0);
                canvas.Children.Add(btn2);

                Button clearBtn = new Button();
                clearBtn.Content = "Очистить";
                clearBtn.Click += new RoutedEventHandler(clear_Click);
                clearBtn.Margin = new Thickness(100, 510, 0, 0);
                canvas.Children.Add(clearBtn);
            }
            private void btn1_Click(object sender, RoutedEventArgs e)
            {
                DrawPathEdges(path1,Brushes.Red);
            }
            private void btn2_Click(object sender, RoutedEventArgs e)
            {
                DrawPathEdges(path2,Brushes.Blue);
            }
            private void clear_Click(object sender, RoutedEventArgs e)
            {
                foreach (var line in canvas.Children.OfType<Line>())
                {
                    line.Stroke = Brushes.Black;
                    line.StrokeThickness = 1;
                }
            }
        }
        static int[,] Randomize(int N, int M, int t1, int t2)//генерация массива с рандомными числами
        {
            int[,] tasks = new int[N, M];
            Random rnd = new();
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                    if (i != j && tasks[j,i]==0)
                    {
                        int num = rnd.Next(t1, t2 + 1);
                        tasks[j, i] = num;
                        tasks[i, j] = num;
                    }
                    else if (i == j ) tasks[j, i] = 0;
            return tasks;
        }
        public MainWindow()
        {
           InitializeComponent();
           int numVertices = 11;
           int[,] adjacencyMatrix = new int[,]
            {
                {0, 13, 11, 19, 17, 12, 15},
                {13, 0, 11, 18, 12, 10, 20},
                {11, 11, 0, 15, 17, 11, 16},
                {19, 18, 15, 0, 18, 19, 20},
                {17, 12, 17, 18, 0, 20, 10},
                {12, 10, 11, 19, 20, 0, 11},
                {15, 20, 16, 20, 10, 11, 0}
            };
            adjacencyMatrix = Randomize(numVertices, numVertices, 10, 25);
            Graph graph = new Graph(numVertices, adjacencyMatrix, 100, 1, 1, 100);
            int num = new Random().Next(1, numVertices+1);
            var pair1 = graph.GreedyAlg(num);
            int sum1 = pair1.Item1;
            int[] path1 = pair1.Item2;

            Task<Tuple<int, int[]>> runTask = graph.Run(num);
            runTask.Wait(); // Дождаться завершения задачи Run

            var pair2 = runTask.Result;
            int sum2 = pair2.Item1;
            int[] path2 = pair2.Item2;
            Canvas canvas = new Canvas();
            canvas.Width = 400;
            canvas.Height = 500;
            canvas.Background = Brushes.White;
            graph.DrawGraph(sum1, path1,sum2,path2, canvas);
            Content = canvas;
        }
    }
}
