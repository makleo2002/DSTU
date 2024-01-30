#include <iostream>
#include <string>
using namespace std;
class Fruit
{ private:
    double sweetness, bitterness, sourness;
    string name;
public:
    void juice() {
        double sugar;
        sugar = sweetness+bitterness+sourness;
        cout<<"Sugar:"<< sugar<<endl;
    }
    void plant() {
        cout << name << " is planted" <<endl<<"Sweetness:"<<sweetness<<endl<<"Bitterness:"<<bitterness<<endl<<"Sourness:"<<sourness<<endl;
    }
    Fruit() { //конструктор по умолчанию
        name = "Apple";
        sweetness = 0.6;
        bitterness = 0.1;
        sourness = 0.3;
        
    }

    Fruit(Fruit& name1, Fruit& sweetness1, Fruit& bitterness1, Fruit& sourness1) {//конструктор копирования
        name = name1.name;
        sweetness = sweetness1.sweetness;
        bitterness = bitterness1.bitterness;
        sourness = sourness1.sourness;
    }
    Fruit(string n, double sw,double b,double s) //конструктор инициализации
    {
        name = n; sweetness = sw; bitterness = b; sourness = s;
    }
    
};

int main()
{
    Fruit fruit1("mango", 6.4, 4.4, 3.4);
    fruit1.plant();
    fruit1.juice();
    Fruit fruit2("banana", 7.5, 2.0, 1.8);
    fruit2.plant();
    fruit2.juice();
    Fruit fruit3("pear", 3.7, 3.4, 5.2);
    fruit3.plant();
    fruit3.juice();
    Fruit fruit4;
    fruit4.plant();
    return 0;
}