#include <iostream>
#include<stack>
#include <string>
#include<ctime>
#include<chrono>
#include <ratio>

using namespace std;

void BubbleSort(int* a, int n) {
    int tmp, L = 0, R = n - 1;
    bool flag = false;
    while (R > 0) {
        int j = 0;
        while (j < R) {
            if (a[j] > a[j + 1]) {
                tmp = a[j];
                a[j] = a[j + 1];
                a[j + 1] = tmp;
                flag = true;
            }
            j++;

        }
        if (flag == false) {
            break;
        }
        R--;

    }
}


int LinearSearch(int* a, int n, int x) {
    chrono::high_resolution_clock::time_point t1 = chrono::high_resolution_clock::now();
    int i = 0;
    while (i < n && a[i] != x) { i++; }
    chrono::high_resolution_clock::time_point t2 = chrono::high_resolution_clock::now();
    chrono::duration<double> seconds1 = chrono::duration_cast<chrono::duration<double>>(t2 - t1);
    printf("|%-20s|%14d|%22d|%30d|%20.10f|\n", "   Линейный поиск   ", n,i,i, seconds1.count());
    printf("|%-20s|%-14s|%-22s|%-30s|%-20s|\n", "--------------------", "--------------", "----------------------", "------------------------------", "--------------------");
    if (i == n) return -1;
    return i;
}

int BinarySearch(int* a,int n,int x) {
    chrono::high_resolution_clock::time_point t1 = chrono::high_resolution_clock::now();
    int L = 0, R = n - 1,m=0,i=0,k=0;
    bool flag = false;
    while (L < R&& flag != true) {
        m = (L + R) / 2;
        if (a[m] == x) flag = true;
        if (a[m] > x)  R = m-1; 
        else L = m+1;
        i += 2;
        k++;   
    }
    chrono::high_resolution_clock::time_point t2 = chrono::high_resolution_clock::now();
    chrono::duration<double> seconds1 = chrono::duration_cast<chrono::duration<double>>(t2 - t1);
    printf("|%-20s|%14d|%22d|%30d|%20.10f|\n", "   Бинарный поиск   ", n, i,k, seconds1.count());
    printf("|%-20s|%-14s|%-22s|%-30s|%-20s|\n", "--------------------", "--------------", "----------------------", "------------------------------", "--------------------");
    return m;
}

int BarrierSearch(int* a, int n, int x) {
    chrono::high_resolution_clock::time_point t1 = chrono::high_resolution_clock::now();
    int i = 0;
    a[n] = x;
    while (a[i] != x) i++;
    chrono::high_resolution_clock::time_point t2 = chrono::high_resolution_clock::now();
    chrono::duration<double> seconds1 = chrono::duration_cast<chrono::duration<double>>(t2 - t1);
    printf("|%-26s|%14d|%22d|%30d|%20.10f|\n", "Линейный поиск с барьером", n, i,i, seconds1.count());
    printf("|%-26s|%-14s|%-22s|%-30s|%-20s|\n", "--------------------------", "--------------", "----------------------", "------------------------------", "--------------------");
    if(i==n) return -1;
    return i;
}

int main()
{ 
    setlocale(LC_ALL, "Russian");
    
    int* a1 = new int[100];
    int* a2 = new int[100];
    int* a3 = new int[100];
    int* b1 = new int[500];
    int* b2 = new int[500];
    int* b3 = new int[500];
    int* c1 = new int[1000];
    int* c2 = new int[1000];
    int* c3 = new int[1000];
    int* d1 = new int[3000];
    int* d2 = new int[3000];
    int* d3 = new int[3000];
    int* e1 = new int[10000];
    int* e2 = new int[10000];
    int* e3 = new int[10000];
    for (int i = 0; i < 100; i++) {
        a1[i] = rand() % 1000 + 0;
    }
    for (int i = 0; i < 100; i++) {
        a2[i] = rand() % 1000 + 0;
    }
    for (int i = 0; i < 100; i++) {
        a3[i] = rand() % 1000 + 0;
    }
    for (int i = 0; i < 100; i++) {
        b1[i] = rand() % 1000 + 0;
    }
    for (int i = 0; i < 100; i++) {
        b2[i] = rand() % 1000 + 0;
    }
    for (int i = 0; i < 100; i++) {
        b3[i] = rand() % 1000 + 0;
    }
    for (int i = 0; i < 100; i++) {
        c1[i] = rand() % 1000 + 0;
    }
    for (int i = 0; i < 100; i++) {
        c2[i] = rand() % 1000 + 0;
    }
    for (int i = 0; i < 100; i++) {
        c3[i] = rand() % 1000 + 0;
    }
    for (int i = 0; i < 100; i++) {
        d1[i] = rand() % 1000 + 0;
    }
    for (int i = 0; i < 100; i++) {
        d2[i] = rand() % 1000 + 0;
    }
    for (int i = 0; i < 100; i++) {
        d3[i] = rand() % 1000 + 0;
    }
    for (int i = 0; i < 100; i++) {
        e1[i] = rand() % 1000 + 0;
    }
    for (int i = 0; i < 100; i++) {
        e2[i] = rand() % 1000 + 0;
    }
    for (int i = 0; i < 100; i++) {
        e3[i] = rand() % 1000 + 0;
    }
   
    cout << "Задание 1:" << endl;
    printf("|%-20s|%-14s|%-22s|%-30s|%-20s|\n", "--------------------", "--------------", "----------------------","------------------------------", "--------------------");
    printf("|%-20s|%-14s|%-22s|%-30s|%-20s|\n", "        Метод       ", "Размер массива", "Количество сравнений"," Количество повторений цикла ", "      Скорость     ");
    printf("|%-20s|%-14s|%-22s|%-30s|%-20s|\n", "--------------------", "--------------", "----------------------", "------------------------------", "--------------------");

    LinearSearch(a1, 100, 12);
    LinearSearch(a2, 100, 12);  
    LinearSearch(a3, 100, 12);
    LinearSearch(b1, 500, 12);
    LinearSearch(b2, 500, 12);
    LinearSearch(b3, 500, 12);
    LinearSearch(c1, 1000, 12);
    LinearSearch(c2, 1000, 12); 
    LinearSearch(c3, 1000, 12);
    LinearSearch(d1, 3000, 12);
    LinearSearch(d2, 3000, 12);
    LinearSearch(d3, 3000, 12);
    LinearSearch(e1, 10000, 12);
    LinearSearch(e2, 10000, 12);
    LinearSearch(e3, 10000, 12);

    cout << endl;

    cout << "Задание 3: " << endl;

    printf("|%-26s|%-14s|%-22s|%-30s|%-20s|\n", "--------------------------", "--------------", "----------------------", "------------------------------", "--------------------");
    printf("|%-26s|%-14s|%-22s|%-30s|%-20s|\n", "           Метод          ", "Размер массива", "Количество сравнений", " Количество повторений цикла ", "      Скорость     ");
    printf("|%-26s|%-14s|%-22s|%-30s|%-20s|\n", "--------------------------", "--------------", "----------------------", "------------------------------", "--------------------");


    BarrierSearch(a1, 100, 12);
    BarrierSearch(a2, 100, 12);
    BarrierSearch(a3, 100, 12);
    BarrierSearch(b1, 500, 12);
    BarrierSearch(b2, 500, 12);
    BarrierSearch(b3, 500, 12);
    BarrierSearch(c1, 1000, 12);
    BarrierSearch(c2, 1000, 12);
    BarrierSearch(c3, 1000, 12);
    BarrierSearch(d1, 3000, 12);
    BarrierSearch(d2, 3000, 12);
    BarrierSearch(d3, 3000, 12);
    BarrierSearch(e1, 10000, 12);
    BarrierSearch(e2, 10000, 12);
    BarrierSearch(e3, 10000, 12);

    cout << endl;

    cout << "Задание 2"<<endl;

    printf("|%-20s|%-14s|%-22s|%-30s|%-20s|\n", "--------------------", "--------------", "----------------------", "------------------------------", "--------------------");
    printf("|%-20s|%-14s|%-22s|%-30s|%-20s|\n", "        Метод       ", "Размер массива", "Количество сравнений", " Количество повторений цикла ", "      Скорость     ");
    printf("|%-20s|%-14s|%-22s|%-30s|%-20s|\n", "--------------------", "--------------", "----------------------", "------------------------------", "--------------------");

    BubbleSort(a1, 100);
    BubbleSort(a2, 100);
    BubbleSort(a3, 100);
    BubbleSort(b1, 500);
    BubbleSort(b2, 500);
    BubbleSort(b3, 500);
    BubbleSort(c1, 1000);
    BubbleSort(c2, 1000);
    BubbleSort(c3, 1000);
    BubbleSort(d1, 3000);
    BubbleSort(d2, 3000);
    BubbleSort(d3, 3000);
    BubbleSort(e1, 10000);
    BubbleSort(e2, 10000);
    BubbleSort(e3, 10000);


    LinearSearch(a1, 100, 12);
    BinarySearch(a1, 100, 12);
    LinearSearch(a2, 100, 12);
    BinarySearch(a2, 100, 12);
    LinearSearch(a3, 100, 12);
    BinarySearch(a3, 100, 12);
    LinearSearch(b1, 500, 12);
    BinarySearch(b1, 500, 12);
    LinearSearch(b2, 500, 12);
    BinarySearch(b2, 500, 12);
    LinearSearch(b3, 500, 12);
    BinarySearch(b3, 500, 12);
    LinearSearch(c1, 1000, 12);
    BinarySearch(c1, 1000, 12);
    LinearSearch(c2, 1000, 12);
    BinarySearch(c2, 1000, 12);
    LinearSearch(c3, 1000, 12);
    BinarySearch(c3, 1000, 12);
    LinearSearch(d1, 3000, 12);
    BinarySearch(d1, 3000, 12);
    LinearSearch(d2, 3000, 12);
    BinarySearch(d2, 3000, 12);
    LinearSearch(d3, 3000, 12);
    BinarySearch(d3, 3000, 12);
    LinearSearch(e1, 10000, 12);
    BinarySearch(e1, 10000, 12);
    LinearSearch(e2, 10000, 12);
    BinarySearch(e2, 10000, 12);
    LinearSearch(e3, 10000, 12);
    BinarySearch(e3, 10000, 12);


   
}
