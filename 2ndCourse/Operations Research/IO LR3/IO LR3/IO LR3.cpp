
#include <iostream>
#include <vector>
#include <stack>
using namespace std;

#define n 6

int G[6][6]{
{0, 1, 1, 0, 0, 0},
{1, 0, 1, 1, 0, 0},
{1, 1, 0, 1, 1, 0},
{0, 1, 1, 0, 1, 1},
{0, 0, 1, 1, 0, 1},
{0, 0, 0, 1, 1, 0}
};

void Lee(int S, int F) {
    S--;
    F--;
    int length, wawe[n];
    stack<int> way;
    vector<int> NewFront, OldFront;
    for (int i = 0; i < n; i++)
        wawe[i] = -1;

    wawe[S] = 0;
    cout << "Wawe: " << endl;
    for (int k = 0; k < n; k++) {
        cout << wawe[k] << " ";
    }
    cout << endl;
    OldFront.push_back(S);
    cout << "NewFront: {} " << endl;
    cout << "OldFront: " << S + 1 << endl;
    length = 0;
    cout << "Length " << length << endl << endl;
    while (true) {
        for (int i = 0; i < OldFront.size(); i++) {
            for (int j = 0; j < n; j++) {
                if (G[OldFront[i]][j] == 1 && wawe[j]) {
                    if (wawe[j] == -1) {
                        if (j == F) {
                            wawe[j] = length + 1;
                            NewFront.push_back(j);
                            break;
                        }

                        wawe[j] = length + 1;
                    }

                    NewFront.push_back(j);
                }
            }
        }
        cout << "Wawe: " << endl;
        for (int k = 0; k < n; k++) {
            cout << wawe[k] << " ";
        }
        cout << endl;
        cout << "NewFront: " << endl;
        for (int k = 0; k < NewFront.size(); k++) {
            cout << NewFront[k] + 1 << " ";
        }
        cout << endl;
        cout << "OldFront: " << endl;
        for (int k = 0; k < OldFront.size(); k++) {
            cout << OldFront[k] + 1 << " ";
        }
        cout << endl;
        cout << "length " << length + 1 << endl;
        cout << endl;
        if (NewFront.empty()) {
            cout << "Нет пути";
            break;
        }
        for (int m = 0; m < NewFront.size(); m++) {
            if (NewFront[m] == F) {

                way.push(F+1);
                for (int d = F; d != S; ) {

                    for (int j = 0; j < n; j++) {
                        if (G[d][j] == 1 && wawe[d] - wawe[j] == 1) {
                            d = j;
                            way.push(d + 1);
                            break;
                        }
                    }
                }
                cout << endl << "Путь: "<<endl;
                for (int i = 0; i< way.size()+3; i++) {
                    cout << way.top() << " ";
                    way.pop();
                }
                cout << endl;
                cout << "Длина пути: " << length + 1;
                return;
            }
        }
        OldFront = NewFront;
        NewFront = {};
        length++;
    }

}

int main()
{
    setlocale(LC_ALL, "Russian");
    Lee(1, 6);

}
