#include <iostream>
#include <string>
#include <vector>
using namespace std;

class Fruit
{
protected:
	double sweetness, bitterness, sourness;
	string name;

public:
	Fruit(string n = "Fruit ", double sw = 0, double b = 0, double s = 0) //конструктор инициализации
	{
		name = n; sweetness = sw; bitterness = b; sourness = s;
	}

	Fruit(Fruit& fruit) {//конструктор копирования
		name = fruit.name;
		sweetness = fruit.sweetness;
		bitterness = fruit.bitterness;
		sourness = fruit.sourness;
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
	virtual void getname() {
		cout<< "Это фрукт\n";
	}

	void SetName(string n) {
		this->name = n;
	}
	string GetName() {
		return this->name;
	}
	void SetSweet(double sw) {
		this->sweetness = sw;
	}
	double GetSweet() {
		return this->sweetness;
	}
	void SetBitter(double b) {
		this->bitterness = b;
	}
	double GetBitter() {
		return this->bitterness;
	}
	void SetSour(double s) {
		this->sourness = s;
	}
	double GetSour() {
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

class Basket
{
private:
	Fruit* m_fruit;
	double volume = 5;
public:
	Basket(Fruit* fruit = nullptr)
		:m_fruit(fruit)
	{
		cout << "Корзинка создана\n";
	}
	virtual void GetFruit()														
	{
		cout << "Обьем: " << volume << endl;
		cout << endl;
	}
	virtual void getname() {
		cout << "Это корзинка\n";
	}
};

class Apple : public Fruit
{
	double weight;
public:
	Apple(string n = "", double sw = 0.5, double b = 0.2, double s = 0.6, double w = 100) //конструктор инициализации
	{
		name = n; sweetness = sw; bitterness = b; sourness = s; weight = w;
	}
	
	virtual void GetFruit()														
	{
		cout << "Имя:   " << name << endl;
		cout << "Сладость:  " << sweetness << endl;
		cout << "Горькость: " << bitterness << endl;
		cout << "Кислость: " << sourness << endl;
		cout << "Вес: " << weight << endl;
		cout << endl;
	}
	void SetWeight(double w) {
		this->weight = w;
	}
	double GetWeight() {
		return this->weight;
	}
	virtual void getname() {
		cout<< "Это яблоко\n";
	}

};


class menu
{
protected:
	vector <string> points{ " " };
	Fruit* k = nullptr;
	Apple* l = nullptr;
	Basket* ptr = nullptr;
	//bool exit;

public:
	menu() 
	{
		string word = "Создать фрукт";
		points.push_back(word);
		word = "Создать яблоко";
		points.push_back(word);
		word = "Создать корзинку";
		points.push_back(word);
	}
	int addM()
	{   
	
	};
	void delM(char* i)
	{

		points.erase(points.begin() + *i);
		cout << "Строка №" << *i << " удалена\n";
	};
	
	void quit()
	{
		//exit = true;


	}

	void processMenuItem(int itemNumber)
	{
		string name = "Фрукт";
		switch (itemNumber)
		{
		case 1:
		{Fruit* k = new Fruit(name);
		k->GetFruit();
		k->getname();
		break;
		}
		case 2:
		{
			Apple* l = new Apple(name);
			l->GetFruit();
			l->getname();
			break;
		}
		case 3:
		{
			Fruit* k = new Fruit(name);
			Basket* ptr = new Basket(k);
			ptr->getname();
			ptr->GetFruit();
			break;
		}
		}
		cout << endl;
		processMenu();
	};

	void processMenu()
	{
		cout << "\n Выберите пункт меню:\n";
		for (int i = 1; i < points.size(); i++)
		{
			cout << i << " : " << points[i] << "\n";
		};
		cout << "Если хотите выйти из меню,то напишите '0' \n";
		cout << "Если вы хотите добавить пункт,то напишите '4'\n";
		cout << "Если вы хотите удалить пункт,то напишите '5' \n";

		int itemnumber;
		cin >> itemnumber;
		if (itemnumber == 0)  
			exit(itemnumber);
		else {
			processMenuItem(itemnumber);
		}
	}
};

class Smenu : public menu
{
public:
	Smenu() : menu() {};
	int addM(string i)
	{
		points.push_back(i);
		cout << "Мы добавили строку \n";
		processMenu();
		return 0;
	};
	void delM()
	{

		points.pop_back();
		cout << "Строка №" << points.size() << " удалена ";
		processMenu();

	};
	
};

class Qmenu : public menu
{
public:
	int addM(string i)
	{
		points.push_back(i);
		cout << "Мы добавили строку \n";
		processMenu();
		return 0;
	};
	void delM()
	{
		points.erase(points.begin());
		cout << "Строка 1 удалена\n";
		processMenu();

	};
};


int main()
{   
	
	setlocale(LC_ALL, "Russian");
	Smenu m = Smenu();
	m.processMenu();
	m.addM("Собака");
	m.processMenu();
	cout << endl;
	m.delM();
	m.processMenu();
	//Qmenu m1 = Qmenu();
	//m1.processMenu();
	//m1.addM("Кот");
	//cout << endl;
	//m1.delM();
	system("pause");
}