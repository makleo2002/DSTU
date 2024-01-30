// Test.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//
#include <iostream>
#include<stack>
#include <string>
#include<ctime>
#include<chrono>
#include <ratio>
#include<vector> 
using namespace std;
void SelectionSort(int* a, int n) {
    chrono::high_resolution_clock::time_point t1 = chrono::high_resolution_clock::now();
    int min, minNum = 0, L = 1, R = n - 1, assigns = 0, cmp = 0;
    for (int i = 0; i < n - 1; ++i) {
        min = 1000000;
        for (int j = i+1; j < n; ++j) {
            if (a[j] < min) {
                min = a[j];
                minNum = j;
                assigns += 2;
            }
            ++cmp;
        }
        a[minNum] = a[i];
        a[i] = min;
        assigns += 2;
        L++;
    }
    chrono::high_resolution_clock::time_point t2 = chrono::high_resolution_clock::now();
    chrono::duration<double> seconds = chrono::duration_cast<chrono::duration<double>>(t2 - t1);
    printf("|%-24s|%18d|%24d|%22d|%28.10f|\n", "Метод простого выбора", n, cmp, assigns, seconds.count());
}


void DirectInclusion(int* a, int n) {
    chrono::high_resolution_clock::time_point t1 = chrono::high_resolution_clock::now();
    int cmp = 0, assigns = 0;
    for (int i = 1; i < n; ++i) {
        if (a[i] >= a[i - 1]) {  
            ++cmp;
            continue; 
        }
        
        int x = a[i], j = i;
        assigns += 2;
        do { 
            a[j] = a[j - 1];
            assigns++;
        } while (--j > 0 && a[j - 1] > x);
        a[j] = x;
        assigns++;
    }
    chrono::high_resolution_clock::time_point t2 = chrono::high_resolution_clock::now();
    chrono::duration<double> seconds = chrono::duration_cast<chrono::duration<double>>(t2 - t1);
    printf("|%-24s|%18d|%24d|%22d|%28.10f|\n", "Метод прямого включения", n, cmp, assigns, seconds.count());
}

void BubbleSort(int* a, int n) {
    chrono::high_resolution_clock::time_point t5 = chrono::high_resolution_clock::now();
    int tmp, L = 0, R = n - 1, assigns = 0, cmp = 0;
    bool flag = false;
    while (R>0) {
        int j = 0;
       while(j<R) {
            if (a[j] > a[j+1]) {
                tmp = a[j];
                a[j] = a[j+1];
                a[j+1] = tmp;
                flag = true;
            }
            ++cmp;
            j++;
            
        }
        if (flag == false) {
            ++cmp;
            break;
        }
        R--;
        ++cmp;
       
    }
    chrono::high_resolution_clock::time_point t6 = chrono::high_resolution_clock::now();
    chrono::duration<double> seconds = chrono::duration_cast<chrono::duration<double>>(t6 - t5);
    printf("|%-24s|%18d|%24d|%22d|%28.10f|\n", "Метод простого обмена", n, cmp, assigns, seconds.count());
}


bool QuickSort(int* arr, int n) {
    chrono::high_resolution_clock::time_point t5 = chrono::high_resolution_clock::now();
    int piv, beg[1000], end[1000], i = 0, L, R, assigns = 0, cmp = 0;

    beg[0] = 0;
    end[0] = n;
    while (i >= 0) {
        L = beg[i];
        R = end[i] - 1;
        if (L < R) {
            ++cmp;
            piv = arr[L];
            if (i == 1000 - 1) {               
                return false;
            }
            ++cmp;
            while (L < R) {
                while (arr[R] >= piv && L < R)
                    R--;
                if (L < R) {
                    arr[L++] = arr[R];
                    ++assigns;
                }
                ++cmp;
                while (arr[L] <= piv && L < R)
                    L++;
                if (L < R) {
                    ++cmp;
                    arr[R--] = arr[L];
                    ++assigns;
                }
            }
            arr[L] = piv;
            beg[i + 1] = L + 1;
            end[i + 1] = end[i];
            end[i++] = L;
        }
        else {
            i--;
        }
    }

    chrono::high_resolution_clock::time_point t6 = chrono::high_resolution_clock::now();
    chrono::duration<double> seconds = chrono::duration_cast<chrono::duration<double>>(t6 - t5);
    printf("|%-24s|%18d|%24d|%22d|%28.10f|\n", "Быстрая сортировка", n, cmp, assigns, seconds.count());
    return true;
}

void QSortRec(int* a,int n){
    int L = 0;
    int R = n - 1;
    int x = a[n / 2];
    do {
        while (a[L] < x) L++;
        while (a[L] > x) R--;
        if (L <= R) {
            int tmp = a[L];
            a[L] = a[R];
            a[R] = tmp;
            L++;
            R--;
        }
    } while (L <= R);
    if (R > 0) {
        QSortRec(a, R + 1);
    }
    if (L < 0) {
        QSortRec(&a[L], n - L);
    }
}
void BubbleSortTest(int* a, int n) {
    int tmp, i, L = 0, R = n - 1, pos = 0, assigns = 0, cmp = 0;
    while (L < R) {
        i = L;
        pos = -1;
        for (int j = i + 1; j < n; ++j) {
            if (a[i] > a[j]) {
                tmp = a[i];
                a[i] = a[j];
                a[j] = tmp;
                pos = i;
                assigns += 3;
            }
            ++i;
            ++cmp;
            L++;
        }
        if (pos == -1) {
            ++cmp;
            break;
        }
    }
    L++;

}

int main()
{
    chrono::high_resolution_clock::time_point t1 = chrono::high_resolution_clock::now();
    setlocale(LC_ALL, "Russian");
    int* mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    cout << endl << "------------------------------------------------------------------------";
    cout << endl << endl;
    SelectionSort(mas1, 20);
    cout << endl;
    for (int i = 0; i < 20; i++) {
        cout << mas1[i] << " ";
    }
    cout << endl << "------------------------------------------------------------------------";
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    cout << endl;
    DirectInclusion(mas1, 20);
    cout << endl;
    for (int i = 0; i < 20; i++) {
        cout << mas1[i] << " ";
    }
    cout <<endl<< "------------------------------------------------------------------------";

    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    cout << endl;
    BubbleSort(mas1, 20);
    cout << endl;
    for (int i = 0; i < 20; i++) {
        cout << mas1[i] << " ";
    }
    cout << endl << "------------------------------------------------------------------------";
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    cout << endl;
    QuickSort(mas1, 20);
    cout << endl;
    for (int i = 0; i < 20; i++) {
        cout << mas1[i] << " ";
    }

    delete[] mas1;
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }

    cout << endl << endl;

 

    
    cout << "1 задание: " << endl << endl;
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "------------------------", "------------------", "------------------------", "----------------------", "----------------------------");
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "Метод", "Размер массива", "Количество сравнений", "Количество обменов", "Скорость");
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "------------------------", "------------------", "------------------------", "----------------------", "----------------------------");


    SelectionSort(mas1, 20);
    delete[] mas1;
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    DirectInclusion(mas1, 20);
    delete[] mas1;
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
   
    BubbleSort(mas1, 20);
    delete[] mas1;
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }

    QuickSort(mas1, 20);
    delete[] mas1;
    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }

    SelectionSort(mas1, 500);
    delete[] mas1;
    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }

    DirectInclusion(mas1, 500);
    delete[] mas1;
    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSort(mas1, 500);
    delete[] mas1;
    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    QuickSort(mas1, 500);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    SelectionSort(mas1, 1000);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    DirectInclusion(mas1, 1000);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSort(mas1, 1000);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    QuickSort(mas1, 1000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    SelectionSort(mas1, 3000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    DirectInclusion(mas1, 3000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSort(mas1, 3000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    QuickSort(mas1, 3000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    SelectionSort(mas1, 5000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    DirectInclusion(mas1, 5000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSort(mas1, 5000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    QuickSort(mas1, 5000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    SelectionSort(mas1, 10000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    DirectInclusion(mas1, 10000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSort(mas1, 10000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    QuickSort(mas1, 10000);
    delete[] mas1;
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "------------------------", "------------------", "------------------------", "----------------------", "----------------------------");
    cout << endl;
    cout << "2 задание: " << endl << endl;
    cout << "Сортировка для упорядоченного на 25% массива" << endl;
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "------------------------", "------------------", "------------------------", "----------------------", "----------------------------");
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "Метод", "Размер массива", "Количество сравнений", "Количество обменов", "Скорость");
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "------------------------", "------------------", "------------------------", "----------------------", "----------------------------");
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 5);
    SelectionSort(mas1, 20);
    delete[] mas1;
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 5);
    DirectInclusion(mas1, 20);
    delete[] mas1;
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 5);
    BubbleSort(mas1, 20);
    delete[] mas1;
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 5);
    QuickSort(mas1, 20);
    delete[] mas1;

    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 125);
    SelectionSort(mas1, 500);
    delete[] mas1;
    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 125);
    DirectInclusion(mas1, 500);
    delete[] mas1;
    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 125);
    BubbleSort(mas1, 500);
    delete[] mas1;
    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 125);
    QuickSort(mas1, 500);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 250);
    SelectionSort(mas1, 1000);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 250);
    DirectInclusion(mas1, 1000);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 250);
    BubbleSort(mas1, 1000);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 250);
    QuickSort(mas1, 1000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 750);
    SelectionSort(mas1, 3000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 750);
    DirectInclusion(mas1, 3000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 750);
    BubbleSort(mas1, 3000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 750);
    QuickSort(mas1, 3000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 1250);
    SelectionSort(mas1, 5000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 1250);
    DirectInclusion(mas1, 5000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 1250);
    BubbleSort(mas1, 5000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 1250);
    QuickSort(mas1, 5000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 2500);
    SelectionSort(mas1, 10000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 2500);
    DirectInclusion(mas1, 10000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 2500);
    BubbleSort(mas1, 10000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 2500);
    QuickSort(mas1, 10000);
    delete[] mas1;
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "------------------------", "------------------", "------------------------", "----------------------", "----------------------------");
    cout << endl;
    cout << "Сортировка для упорядоченного на 50% массива" << endl;
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "------------------------", "------------------", "------------------------", "----------------------", "----------------------------");
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "Метод", "Размер массива", "Количество сравнений", "Количество обменов", "Скорость");
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "------------------------", "------------------", "------------------------", "----------------------", "----------------------------");
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 10);
    SelectionSort(mas1, 20);
    delete[] mas1;
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 10);
    DirectInclusion(mas1, 20);
    delete[] mas1;
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 10);
    BubbleSort(mas1, 20);
    delete[] mas1;
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 10);
    QuickSort(mas1, 20);
    delete[] mas1;

    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 250);
    SelectionSort(mas1, 500);
    delete[] mas1;
    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 250);
    DirectInclusion(mas1, 500);
    delete[] mas1;
    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 250);
    BubbleSort(mas1, 500);
    delete[] mas1;
    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 125);
    QuickSort(mas1, 500);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 500);
    SelectionSort(mas1, 1000);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 500);
    DirectInclusion(mas1, 1000);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 500);
    BubbleSort(mas1, 1000);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 500);
    QuickSort(mas1, 1000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 1500);
    SelectionSort(mas1, 3000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 1500);
    DirectInclusion(mas1, 3000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 1500);
    BubbleSort(mas1, 3000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 1500);
    QuickSort(mas1, 3000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 2500);
    SelectionSort(mas1, 5000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 2500);
    DirectInclusion(mas1, 5000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 2500);
    BubbleSort(mas1, 5000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 2500);
    QuickSort(mas1, 5000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 5000);
    SelectionSort(mas1, 10000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 5000);
    DirectInclusion(mas1, 10000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 5000);
    BubbleSort(mas1, 10000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 5000);
    QuickSort(mas1, 10000);
    delete[] mas1;
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "------------------------", "------------------", "------------------------", "----------------------", "----------------------------");
    cout << endl;
    cout << "Сортировка для упорядоченного на 75% массива" << endl;
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "------------------------", "------------------", "------------------------", "----------------------", "----------------------------");
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "Метод", "Размер массива", "Количество сравнений", "Количество обменов", "Скорость");
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "------------------------", "------------------", "------------------------", "----------------------", "----------------------------");
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 15);
    SelectionSort(mas1, 20);
    delete[] mas1;
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 15);
    DirectInclusion(mas1, 20);
    delete[] mas1;
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 15);
    BubbleSort(mas1, 20);
    delete[] mas1;
    mas1 = new int[20];
    for (int i = 0; i < 20; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 15);
    QuickSort(mas1, 20);
    delete[] mas1;

    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 375);
    SelectionSort(mas1, 500);
    delete[] mas1;
    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 375);
    DirectInclusion(mas1, 500);
    delete[] mas1;
    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 375);
    BubbleSort(mas1, 500);
    delete[] mas1;
    mas1 = new int[500];
    for (int i = 0; i < 500; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 375);
    QuickSort(mas1, 500);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 750);
    SelectionSort(mas1, 1000);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 750);
    DirectInclusion(mas1, 1000);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 750);
    BubbleSort(mas1, 1000);
    delete[] mas1;
    mas1 = new int[1000];
    for (int i = 0; i < 1000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 750);
    QuickSort(mas1, 1000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 2250);
    SelectionSort(mas1, 3000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 2250);
    DirectInclusion(mas1, 3000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 2250);
    BubbleSort(mas1, 3000);
    delete[] mas1;
    mas1 = new int[3000];
    for (int i = 0; i < 3000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 2250);
    QuickSort(mas1, 3000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 3750);
    SelectionSort(mas1, 5000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 3750);
    DirectInclusion(mas1, 5000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 3750);
    BubbleSort(mas1, 5000);
    delete[] mas1;
    mas1 = new int[5000];
    for (int i = 0; i < 5000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 3750);
    QuickSort(mas1, 5000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 7500);
    SelectionSort(mas1, 10000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 7500);
    DirectInclusion(mas1, 10000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 7500);
    BubbleSort(mas1, 10000);
    delete[] mas1;
    mas1 = new int[10000];
    for (int i = 0; i < 10000; i++) {
        mas1[i] = rand() % 1000 + 0;
    }
    BubbleSortTest(mas1, 7500);
    QuickSort(mas1, 10000);
    delete[] mas1;
    printf("|%-24s|%-18s|%-24s|%-22s|%-28s|\n", "------------------------", "------------------", "------------------------", "----------------------", "----------------------------");
    chrono::high_resolution_clock::time_point t2 = chrono::high_resolution_clock::now();
    chrono::duration<double> seconds = chrono::duration_cast<chrono::duration<double>>(t2 - t1);
    
    printf("%20.10f", seconds.count());
}

