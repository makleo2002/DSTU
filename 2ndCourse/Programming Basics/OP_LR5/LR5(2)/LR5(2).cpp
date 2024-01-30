#include <iostream>
#include <string>
using namespace std;

template<class T>
class Complex
{
private:
	T x;
	T y;

public:
	Complex(T x, T y) : x(x), y(y) {}// конструктор инициализации
	T x1() { return x; }
	T y1() { return y; }
	void print()
	{
		cout << this->x << "+" << this->y << "i" << endl;
	}

	Complex<T> operator+(Complex& c2)
	{
		return Complex(this->x1() + c2.x1(), this->y1() + c2.y1());
	}

	Complex<T> operator-(Complex& c2)
	{
		return Complex(this->x1() - c2.x1(), this->y1() - c2.y1());
	}

};

template <class T>
class Calculator
{
private:
	T c1;
	T c2;

public:
	Calculator(T c1, T c2) : c1(c1), c2(c2) {}
	void print() {
		cout << "Первое число:" << c1 <<endl<< "Второе число:" << c2;
	}
	T getMaxNumber()
	{
		if (this->c1 > this->c2)
		{
			return this->c1;
		}
		else
			return this->c2;
		return false;
	}

	T Sum() { return this->c1 + this->c2; }
	T Sub() { return this->c1 - this->c2; }
	T Mul() { return this->c1 * this->c2; }
	T Div() { return this->c1 / this->c2; }
};

template <class T, class M>
class Fruit
{
protected:
	T sweetness, bitterness, sourness;
	M name;

public:
	Fruit(M n = "Apple", T sw = 6.8, T b = 1.4, T s = 3.3) //конструктор инициализации
	{
		name = n; sweetness = sw; bitterness = b; sourness = s;
	}


	Fruit(Fruit& fruit) {//конструктор копирования
		name = fruit.name;
		sweetness = fruit.sweetness;
		bitterness = fruit.bitterness;
		sourness = fruit.sourness;
	}

	void juice(T sugar) {
		T k = 1;
		T fruit = 100;
		T juice = fruit * k * 0.6 + sugar;
		cout << "Сок из 1 кг " << name << " c добавлением " << sugar << " грамм сахара" << endl << juice << " грамм" << endl << endl;
	}
	void plant() {
		cout << name << " посажен" << endl;
	}
	virtual void getname() {
		cout << "Это фрукт\n";
	}

	M GetName() {
		return this->name;
	}
	T GetSweet() {
		return this->sweetness;
	}

	T GetBitter() {
		return this->bitterness;
	}

	T GetSour() {
		return this->sourness;
	}
	virtual void GetFruit()														//показать объект на экране
	{
		cout << "Имя:   " << name << endl;
		cout << "Сладость:  " << sweetness << endl;
		cout << "Горькость: " << bitterness << endl;
		cout << "Кислость: " << sourness << endl;
		cout << endl;
	}
};


int main() {
	setlocale(LC_ALL, "Russian");

	Complex<int> c1(3.5, 2.5);
	Complex<int> c2(1.5, 0.5);
	Complex<int> c3 = c1 + c2;
	Complex<int> c4 = c1 - c2;
	cout << "Первое число: \n";
	c1.print();
	cout << "\nВторое Число: \n";
	c2.print();
	cout << "\nСумма: " << endl;
	c3.print();
	cout << "\nРазность:";
	c4.print();
	cout << endl;

	Calculator<int> c5(6, 3);
	c5.print();
	cout <<"\nМаксимальное число: "<< c5.getMaxNumber();
	cout<<"\nСумма: "<<c5.Sum();
	cout<< "\nРазность: " << c5.Sub();
	cout<< "\nУмножение: " << c5.Mul();
	cout << "\nДеление: " << c5.Div() << endl;

	Fruit<double, string> Apple;
	Fruit<int, string> Apple2;
	cout << endl;
	Apple.GetFruit();
	Apple2.GetFruit();

	return 0;
}
