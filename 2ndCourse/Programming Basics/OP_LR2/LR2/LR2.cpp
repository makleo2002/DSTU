#include <string>
#include <iostream>
using namespace std;
class Fruit
{
private:
    double sweetness, bitterness, sourness;
    string name;
    static int counter;
    Fruit() {
        cout << "Конструктор вызван"<<endl<<endl;
    }
    Fruit(const Fruit&) {};

    Fruit(string n, double sw, double b, double s) //конструктор инициализации
    {
        name = n; sweetness = sw; bitterness = b; sourness = s;
    }
    Fruit(Fruit& fruit) {//конструктор копирования
        name = fruit.name;
        sweetness = fruit.sweetness;
        bitterness = fruit.bitterness;
        sourness = fruit.sourness;
    }
    ~Fruit() {
        cout << "Деструктор вызван" << endl<<endl;
        counter--; //деструктор
    };
public:
   static Fruit* CreateFruit(string name, double sweetness, double bitterness, double sourness) {
        if (Fruit::counter >= 3) {
            cout << "Нельзя создать больше 3 фруктов" << endl;
            return NULL;
        }
        else {
            Fruit* newFruit = new Fruit();
            newFruit->name = name;
            newFruit->sweetness = sweetness;
            newFruit->bitterness = bitterness;
            newFruit->sourness = sourness;
            Fruit::counter++;
            return newFruit;
        }
    }

    static Fruit* DestroyFruit(Fruit*& CurrentFruit) {
        delete CurrentFruit;
        Fruit::counter--;
        return NULL;
    }
     void juice(double sugar) {
        double n = 10;
        double fruit = 100;
        double juice = fruit * n * 0.6 + sugar;
        cout << "Сок из 1 кг " << name <<" c добавлением "<<sugar<<" грамм сахара"<< endl << juice <<" грамм"<< endl<<endl;
    }
      void plant() {
         cout << name << " посажен" <<endl;
    }
    friend Fruit* CreateFruit(string name, double sweetness, double bitterness, double sourness);
    friend Fruit* DestroyFruit(Fruit*& CurrentFruit);

    static int GetCount() {
        return counter;
    }
     void SetName(string n) {
        this->name = n;
    }
    string GetName() {
        return this->name;
    }
    void SetSweet(int sw) {
        this->sweetness = sw;
    }
    double GetSweet() {
        return this->sweetness;
    }
    void SetBitter(int b) {
        this->bitterness = b;
    }
    double GetBitter() {
        return this->bitterness;
    }
    void SetSour(int s) {
        this->sourness = s;
    }
    double GetSour() {
        return this->sourness;
    }
};

int Fruit::counter = 0;


Fruit* CreateFruit(string name, double sweetness, double bitterness, double sourness) {
    if (Fruit::counter >= 3) {
        cout << "Нельзя создать больше 3 фруктов"<<endl;
        return NULL;
    }
    else {
        Fruit* newFruit = new Fruit();
        newFruit->name = name;
        newFruit->sweetness = sweetness;
        newFruit->bitterness = bitterness;
        newFruit->sourness = sourness;
        Fruit::counter++;
        return newFruit;
    }
}


Fruit* DestroyFruit(Fruit*& CurrentFruit) {
    delete CurrentFruit;
    Fruit::counter--;
    return NULL;
}

void DataFruit(Fruit*& fruit) {
    if (fruit == NULL) return;
    cout << "Название фрукта: " << fruit->GetName() <<endl;
    cout << "Сладость:  " << fruit->GetSweet() << endl;
    cout << "Горькость: " << fruit->GetBitter() << endl;
    cout << "Кислость:  " << fruit->GetSour() << endl;
}

int main()
{
setlocale(LC_ALL, "Russian");
string name;

name = "Яблоко";
Fruit* Fruit1 = CreateFruit (name, 0.6, 0.1, 0.3);
DataFruit(Fruit1);
Fruit1->plant();
Fruit1->juice(60);
DestroyFruit(Fruit1);
//если удалить один фрукт, то можно создать новый

name = "Банан";
Fruit* Fruit2 = Fruit::CreateFruit(name, 0.75, 0.2, 0.1);
DataFruit(Fruit2);
Fruit2->plant();
Fruit2->juice(40);
Fruit2=Fruit::DestroyFruit(Fruit2);

name = "Манго";
Fruit* Fruit3 = CreateFruit(name, 0.8, 0.1, 0.2);
DataFruit(Fruit3);
Fruit3->plant();
Fruit3->juice(30);

name = "Киви";
Fruit* Fruit4=Fruit::CreateFruit(name, 0.4, 0.3, 0.5);
DataFruit(Fruit4);
Fruit4->plant();
Fruit4->juice(50);
cout <<"Количество фруктов "<< Fruit::GetCount();
return 0;
}