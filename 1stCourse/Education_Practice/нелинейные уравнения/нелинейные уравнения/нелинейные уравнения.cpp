#include <iostream>
#include <math.h>
#include <cmath>

using namespace std;
using namespace std;
double f(double x)
{
    return  3 * pow(x, 4) + 4 * pow(x, 3) - 12 * pow(x, 2) - 5;//функция
}
double df(double x)
{
    return 12 * pow(x, 3) + 12 * pow(x, 2) - 24 * x;//производная
}

double dixit(double a, double b, double eps)// метод дихотомии,фунция f(x)=0 непрерывна 
// на отрезке [a;b] и f(a)*f(b)<0.
{
    double c;
    do {
        c = (a + b) / 2.0;//находим точку c=(a+b)/2
        if (f(a) * f(c) < 0)   b = c;//если это условие выполнено,то корень лежит на [a;c]
        else if (f(b) * f(c) < 0)   a = c;//иначе корень лежит на [c;b]
        else {
            cout << "Корень не найден" << endl;//если оба условия не выполняются,то корня нет на данном промежутке
            return 0;
        }
    } while (fabs(b - a) > eps);//пока значение в функции в точке b-a больше заданной точности,
    //выполняем алгоритм нахождения с,описанный сверху
    return c;//возвращаем значение с после выполнения цикла

}
double Hord(double a, double b, double eps)//метод хорд
//разбиение отрезка [a; b] на два отрезка с помощью хорды и выборе нового отрезка от точки
//пересечения хорды с осью абсцисс до неподвижной точки, на котором
//функция меняет знак и содержит решение, причём подвижная точка
//приближается к ε - окрестности решения.
{
    while (fabs(b - a) > eps)//пока значение в функции в точке b-a больше заданной точности,
      //выполняем алгоритм,описанный ниже
    {
        a = b - (b - a) * f(b) / (f(b) - f(a));//расчет нового значения а по формуле
        b = a - (a - b) * f(a) / (f(a) - f(b));//расчет нового значения b по формуле
    }

    return b;//возвращаем b после выполнения цикла
}
double Newton(double x, double& n, double eps)//метод Ньютона
//процесс итераций состоит в том, что в качестве
//приближений к корню принимаются значения х0, х1, х2… точек пересечения
//касательной к кривой
{
    double dx;
    n = 0;
    while (1) {
        dx = f(x) / df(x);
        x = x - dx;
        if (fabs(dx) < eps)
            break;
        n++;
        if (n > 100)
            break;
    }
    return x;
}
double Iter(double x, double b, double& n, double eps)
{
    double dx;
    n = 0;
    while (1) {
        dx = b * f(x);
        x = x + dx;
        if (fabs(dx) < eps)
            break;
        if (n > 100) break;
    }
    return x;
}
int main()
{

    setlocale(LC_ALL, "rus");
    double a;
    double b;
    double eps;
    double x;
    cout << "Введите а " << endl;
    cin >> a;
    cout << "Введите b" << endl;
    cin >> b;
    cout << "Введите eps" << endl;
    cin >> eps;
    printf("Корень,найденный методом дихотомии =  %7f", dixit(a, b, eps));
    cout << endl;
    printf("Корень,найденный методом хорд =  %7f", Hord(a, b, eps));
    cout << endl;
    printf("Корень,найденный методом Ньютона =  %7f", Newton(a, b, eps));
    cout << endl;
    cout << "Введите x0 " << endl;
    cin >> x;
    cout << endl;
    printf("Корень,найденный методом простых итераций =  %7f", Iter(x, a, b, eps));
}


