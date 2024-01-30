#include <string>
#include <iostream>
using namespace std;
class Fruit
{
private:
    double sweetness, bitterness, sourness;
    int w;
    string name;
    static int counter;
  
    Fruit(int _w) //конструктор инициализации
    {
        w = _w;

    }
    void Z()
    {
        cout << "Это закрытая функция класса Fruit" << endl;
    } //закрытая функция
public:
    
    Fruit() {
        w = 1; //конструктор по умолчанию
    }
    ~Fruit() {
        cout << "Деструктор вызван" << endl << endl;
        counter--; //деструктор
    }
    
    void juice(double sugar) {
        double k = 1;
        double fruit = 100;
        double juice = fruit * k * 0.6 + sugar;
        cout << "Сок из 1 кг " << name << " c добавлением " << sugar << " грамм сахара" << endl << juice << " грамм" << endl << endl;
    }
    void plant() {
        cout << name << " посажен" << endl;
    }
    
    friend void Fun(Fruit & F);
    friend void fun(Fruit & F);
    
   
   
};

int Fruit::counter = 0;

void Fun(Fruit & F) {
    
}
void fun(Fruit & F) {
    cout << F.w<<endl;
    F.Z();
}
class Complex {
    public:
    double x;
    double y;
    Complex() {};
    friend Complex operator+(Complex c1,Complex c2);
    friend Complex operator-(Complex c1,Complex c2);
    friend ostream& operator<<(ostream& out, Complex& c);
    friend istream& operator>>(istream& in, Complex& c);
    Complex(double x1,double y1){
        x = x1;
        y = y1;
    }
};

Complex operator+(Complex c1,Complex c2) {
    return Complex(c1.x + c2.x , c1.y + c2.y);
}
Complex operator-(Complex c1,Complex c2) {
    return  Complex(c1.x - c2.x , c1.y - c2.y);
}
ostream& operator <<(ostream& out, Complex& c) {
    out<<c.x<<"+"<<c.y<<"i"<<endl;
    return out;
}
istream& operator>>(istream& in, Complex& c) {
    in >> c.x >>c.y;
    return in;
}
int main()
{
    setlocale(LC_ALL, "Russian");
   Fruit Fruit1;
    fun(Fruit1);
    Complex c1(3, 4);
    Complex c2(1, 2);
    Complex c;
    Complex c3 = c1 + c2;
    Complex c4 = c1 - c2;
    cout << c1;
    cout << c2;
    cout <<"Результат сложения с1 и с2: "<<c3;
    cout <<"Результат вычитания с1 и с2: "<<c4;
    cout << "Введите комплексное число" << endl;
    cin >> c;
    cout << "Вы ввели: " << c;
}