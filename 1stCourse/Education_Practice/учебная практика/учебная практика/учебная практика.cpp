#include <iostream>
#include <math.h>
#include <cmath>
#include "Header.h"
using namespace std;

int main()
{
    setlocale(LC_ALL, "rus");
    int variant;
    double a;
    double b;
    double eps;
   
    do {
        print_menu(); // выводим меню на экран

        variant = get_variant(5); // получаем номер выбранного пункта меню

        switch (variant) {
        case 1:
            cout << "Введите а " << endl;
            cin >> a;
            cout << "Введите b" << endl;
            cin >> b;
            cout << "Введите eps" << endl;
            cin >> eps;
            printf("Корень,найденный методом дихотомии =  %7f", dixit(a, b, eps));
            cout << endl;
            break;

        case 2:
            cout << "Введите а " << endl;
            cin >> a;
            cout << "Введите b" << endl;
            cin >> b;
            cout << "Введите eps" << endl;
            cin >> eps;
            printf("Корень,найденный методом хорд =  %7f", Hord(a, b, eps));
            cout << endl;
            break;

        case 3:
            cout << "Введите а " << endl;
            cin >> a;
            cout << "Введите b" << endl;
            cin >> b;
            cout << "Введите eps" << endl;
            cin >> eps;
            printf("Корень,найденный методом Ньютона =  %7f", Newton(a, b, eps));
            cout << endl;
            break;

        case 4:
            cout << "Введите а " << endl;
            cin >> a;
            cout << "Введите b" << endl;
            cin >> b;
            cout << "Введите eps" << endl;
            cin >> eps;
            printf("Корень,найденный методом простых итераций =  %7f", Iter(a, b, b, eps));
            cout << endl;
            break;
        }

        if (variant != 5)
            system("pause"); // задерживаем выполнение, чтобы пользователь мог увидеть результат выполнения выбранного пункта
    } while (variant != 5);

    return 0;   
}


