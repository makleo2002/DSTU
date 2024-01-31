#include <iostream>
#include <set>
#include <map>
#include <algorithm>
#include<vector>
#include <windows.h>

#define _SCL_SECURE_NO_WARNINGS
#include <boost/graph/graphviz.hpp>
#include <boost/graph/adjacency_list.hpp>
#include <boost/graph/iteration_macros.hpp>
using namespace std;

vector<pair<string, string>> woodEdges;
map<string, vector<string>>  AdjacencyList;
vector<pair<string, int>> steps;
vector<vector<string>> cycles;


void saveCycle(const string& start, const string& end) {

    string tmp = end;
    cycles.push_back({});

    while (tmp != start) {
        // {{}, {}, {} <- добавление temp в последний массив}
        cycles[cycles.size() - 1].push_back(tmp);
        // среди woodEdges найти pair<first, second>
        // tmp = woodEdges.find(edge => edge.first === temp).second;
        for (const auto& edge: woodEdges) {
            if (edge.second == tmp) {
                tmp = edge.first;
                break;
            }
        }
    }

    // {{}, {}, {} <- добавление temp в последний массив}
    cycles[cycles.size() - 1].push_back(tmp);
    // {{}, {}, {} <- развернуть последний массив}
    std::reverse(cycles[cycles.size() - 1].begin(), cycles[cycles.size() - 1].end());
    // {{}, {}, {} <- вывод на экран последнего массива}

    for (const auto& x: cycles[cycles.size() - 1]) { //Выводим цикл
        cout << x << " ";
    }
    cout << "Cycle saved" << endl<<endl;
}

void FSC(const string& vertex, int depth) {
    steps.push_back(make_pair(vertex, depth));
    depth++;
    for (const auto& friendVertex : AdjacencyList.at(vertex)) {  //    adjencyList.at(node): {"", "", ""} - вершины смежные с node
       cout << "Vertex|Friend Vertex  " << vertex << " " << friendVertex << endl<<endl;
        bool isFriendNodeInSteps = false;        // if (!steps.find(step => step.node === friend)) {
        for (const auto& step: steps) { 
            if (step.first == friendVertex) {
                isFriendNodeInSteps = true;
            }
        }

        if (!isFriendNodeInSteps) {
            cout << "Push to woodEdges " << vertex << " " << friendVertex << endl<<endl;
            woodEdges.push_back(make_pair(vertex, friendVertex));
            FSC(friendVertex, depth);
        } else {
            for (const auto& x: woodEdges) {     //            else if (woodEdges.find(edge => edge.data.source === node && edge.data.target !== friend))
                if (x.first == vertex && x.second != friendVertex) {
                    cout << "Cycle found reverse edge of the original edge " << x.first << " " << x.second << endl<<endl;
                    saveCycle(vertex, friendVertex);
                }
            }

        }
    }
}



void FundamentalSystemofCycles() {
    cout << "FundamentalCutsBasis() run" << endl<<endl;
    int depth = 0;
    FSC(AdjacencyList.begin()->first, depth);
    ofstream fout("Cycles.txt");
    
    // print cycles
    cout << "Cycles: " << endl<<endl;
    for (const auto& cycle: cycles) {
        fout << "graph{ ";
        for (const auto& x: cycle) {
            cout << x << " ";
            fout << x;
            if (x != cycle[cycle.size() - 1]) fout << "--";
            else fout <<"--"<<cycle[0];
        }
        cout << endl<<endl;
        fout << endl << "}" << endl<<endl;
    }
    fout.close();
    system("dot Cycles.txt -Tpng -OCycles.png");
    // print woodEdges
    cout << "WoodEdges" << endl<<endl;
    for (const auto& x: woodEdges) {
        cout << x.first << " " << x.second << endl<<endl;
    }
    cout << "Cyclomatic number of the graph G: " << cycles.size() << endl << endl;
}

vector<pair<string, string>> createEdgesFromCycle(vector<string> cycle) {   //делим цикл на ребра
    vector<pair<string, string>> edges;
    for (int i = 0; i < cycle.size(); i++) {
        edges.push_back(make_pair(cycle[i], cycle[(i + 1) % cycle.size()]));
    }
    return edges;
}

void FundamentalCutsSystem() {
    cout << "FundamentalCutsSystem() run" << endl << endl;
    vector<vector<pair<string, string>>> edgedCycles;

    for (const auto& cycle: cycles) {
        edgedCycles.push_back(createEdgesFromCycle(cycle)); //записываем в  edgedCycles массив с ребрами цикла
    }
    vector<vector<pair<string, string>>> cuts;
    
    for (const auto& edge: woodEdges) {
        cuts.push_back({edge});
        for (const auto& cycle: edgedCycles) {
            for (const auto& cycleEdge: cycle) {
                if (cycleEdge.first == edge.first && cycleEdge.second == edge.second) {
                    cuts[cuts.size() - 1].push_back(cycle[cycle.size() - 1]);
                }
            }
        }
    }
    ofstream fout("Cuts.txt");

    cout << "Cuts: " << endl<<endl;
    for (const auto& cut: cuts) { //вывод разрезов
        fout << "graph{ "<<endl;
        for(const auto& edge: cut) {
            cout << edge.first << " " << edge.second << endl;
            fout << edge.first << "--" << edge.second <<"[style=dashed]" <<endl;
        }
        cout << endl;
        fout <<endl<< "} "<<endl;
    }
    system("dot Cuts.txt -Tpng -OCuts.png");
    cout << "Number of cuts: " << cuts.size();
}

int main() {
//    IEdje[] = vector<pair<string, string>>
//    map<string, vector<string>> adjencyList;
    setlocale(LC_ALL, "Russian");
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    AdjacencyList["1"] = {"2", "3", "4", "5"};
    AdjacencyList["2"] = {"1", "3", "4", "5"};
    AdjacencyList["3"] = {"1", "2", "4"};
    AdjacencyList["4"] = {"1", "2", "3"};
    AdjacencyList["5"] = {"1", "2"};
    ifstream in("input1.txt");
    in.close();
    system("dot input1.txt -Tpng -oInputGraph.png");
    FundamentalSystemofCycles();
    
    FundamentalCutsSystem();
   
};