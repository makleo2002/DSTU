/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
#include <iostream>
#include <vector>
#include <cmath>
using namespace std;
int main()
{
    setlocale(LC_ALL, "Russian");
    double s = 0;
    int k = 1000000;
    int n;
    double a, b;
    int p = 0;
    cout << "Введите размер массива" << endl;
    cin >> n;
    vector <double> A(n);
    cout << "Заполните массив" << endl;
    for (int i = 0; i < n; i++) {
        cin >> A[i];
    }
    int min = A[0];
    for (int i = 0; i < n; i++) {
        if (abs(A[i]) < min) {
            min = abs(A[i]);
            p = i;
        }
    }
    for (int i = 0; i < n; i++) {
        if (A[i] < 0) {
            k = i;
            break;
        }
    }
    for (int i = k + 1; i < n; i++) {
        s = s + abs(A[i]);
    }
    cout << "Номер минимального по модулю элемента массива: " << p << endl;
    cout << "Сумма модулей элементов расположенных после первого отрицательного элемента: " << s << endl;
    cout << "Введите интервал " << endl;
    cin >> a >> b;

    for (int i = 0; i < n; i++) {
        if (A[i] >= a && A[i] <= b) {
            A[i] = 0;
            A.emplace(A.end(), A[i]);
        }
    }
    for (int i = 0; i < n; i++) {
        cout << A[i] << " ";
    }
    return 0;
}
