#include<queue>
#include<cstring>
#include<vector>
#include<iostream>
#include<fstream>
using namespace std;
int c[10][10];
int flowPassed[10][10];
vector<int> g[10];
int parList[10];
int currentPathC[10];

int bfs(int source, int sink)//поиск в ширину
{
    memset(parList, -1, sizeof(parList));
    memset(currentPathC, 0, sizeof(currentPathC));
    queue<int> q;//очередь
    q.push(source);
    parList[source] = -1;//инициализируем исходный узел parlist для меток
    currentPathC[source] = 999;//инициализируем исходный узел currentpath для текущего потока
    while (!q.empty())// если очередь не пуста
    {
        int currNode = q.front();//берем первый элемент очереди
        q.pop();//удаляем из очереди
        for (int i = 0; i < g[currNode].size(); i++)
        {
            int to = g[currNode][i];//берем смежную с текущей вершину
            if (parList[to] == -1)//если вершина помечена 
            {
                if (c[currNode][to] - flowPassed[currNode][to] > 0)//остаточная пропускная способность положительна
                {
                    parList[to] = currNode;
                    currentPathC[to] = min(currentPathC[currNode], c[currNode][to] - flowPassed[currNode][to]);//находим наименьшую остаточную пропускную способность
                    if (to == sink)
                    {
                      
                        return currentPathC[sink];
                    }
                    q.push(to);
                }
            }
        }
    }
    return 0;
}
int edmondsKarp(int source, int sink)
{
    int maxFlow = 0;
    while (true)
    {
        int flow = bfs(source, sink);
        if (flow == 0)//если поток 0,то выходим
        {
            break;
        }
        maxFlow += flow;
        int currNode = sink;
        while (currNode != source)//увеличиваем поток
        {
            int prevNode = parList[currNode];
            flowPassed[prevNode][currNode] += flow;
            flowPassed[currNode][prevNode] -= flow;
           // cout <<prevNode<<" "<<currNode<<"  " <<flowPassed[prevNode][currNode] << " " <<  endl;
            currNode = prevNode;
        }
        cout << endl;
    }
    cout << "1-2 "<< flowPassed[1][2] << endl;
    cout << "1-4 "<< flowPassed[1][4] << endl;
    cout << "2-3 "<< flowPassed[2][3] << endl;
    cout << "2-4 " << flowPassed[2][4] << endl;
    cout << "2-5 " << flowPassed[2][5] << endl;
    cout << "3-2 " << flowPassed[3][2] << endl;
    cout << "3-5 " << flowPassed[3][5] << endl;
    cout << "4-3 " << flowPassed[4][3] << endl;
    cout << "4-5 " << flowPassed[4][5] << endl;

    return maxFlow;//возвращаем макс.поток
}
int main()
{
    setlocale(LC_ALL, "Russian");
    ifstream in("input1.txt");
    int n, m;
    cout << "Введите количество узлов и ребер\n";
    in >> n >> m;
    int source, sink;
    cout << "Введите сток и исток\n";
    cin >> source >> sink;
    for (int ed = 0; ed < m; ed++)
    {
 
        int from, to, cap;
        in >> from >> to >> cap;
        c[from][to] = cap;
        g[from].push_back(to);
        g[to].push_back(from);
    }
  
    int maxFlow = edmondsKarp(source, sink);
    cout << endl << endl << "Максимальный поток: " << maxFlow << endl;
}