#include <iostream>
#include <cstring>
using namespace std;

#define INF INT_MAX

#define n 7   //количество вершин в графе

int G[n][n] = {    //матрица смежности
  {0,2,0,1,0,0,0},
  {2,0,2,0,1,0,0},
  {0,2,0,0,2,1,0},
  {1,0,0,0,3,0,4},
  {0,1,2,3,3,0,0},
  {0,0,1,0,3,0,3},
  {0,0,0,4,0,3,0}
};

int main() {
    setlocale(LC_ALL, "Russian");
    int min_edge = 0;           // количество ребер в мин.остовном дереве


    bool selected[n+1];  //массив для отслеживания выбранной вершины

   
    memset(selected, false, sizeof(selected)); // изначально выбранное значение false

 // количество ребер в минимальном остовном дереве будет
 // всегда (n-1), где n - количество вершин в графе
 // выбераем 1-ю вершину и делаем ее истинной
    selected[0] = true;

    int x;            //  номер строки
    int y;            //  номер колонки
    int tree_weight=0; //суммарный вес остова

    cout << "Ребро" << " : " << "Вес";
    cout << endl;
    while (min_edge < n - 1) {

        int min = INF;
        x = 0;
        y = 0;

        for (int i = 0; i < n; i++) {
            if (selected[i]) {
                for (int j = 0; j < n; j++) {
                    if (!selected[j] && G[i][j])
                    { 
                        if (min > G[i][j]) {
                            min = G[i][j];
                            x = i;
                            y = j;
                           
                        }
                        
                    }
                }
            }
        }
        tree_weight += G[x][y];
        cout << x+1 << " - " << y+1 << " :  " << G[x][y];
        cout << endl;
        selected[y] = true;
        min_edge++;
    }
    cout << "Вес минимального остова: "<<tree_weight;
    return 0;
}