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
	virtual const char* getname() {
		return "Fruit";
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
	void GetFruit()														//показать объект на экране
	{
		cout << "Имя:  " << name << endl;
		cout << "Сладость " << sweetness << endl;
		cout << "Горькость" << bitterness << endl;
		cout << "Кислость" << sourness << endl;
		cout << endl;
	}
};

class Basket
{
private:
	Fruit* m_fruit;

public:
	Basket(Fruit* fruit = nullptr)
		:m_fruit(fruit)
	{
		cout << "Корзинка создана\n";
	}
};

class Apple : public Fruit
{
	double weight;
public:
public:
	Apple(string n = "", double sw = 0, double b = 0, double s = 0, double w = 0) //конструктор инициализации
	{
		name = n; sweetness = sw; bitterness = b; sourness = s; weight = w;
	}
	void data(Apple*& apple) {
		if (apple == NULL) return;
		cout << "Название фрукта: " << apple->GetName() << endl;
		cout << "Сладость:  " << apple->GetSweet() << endl;
		cout << "Горькость: " << apple->GetBitter() << endl;
		cout << "Кислость:  " << apple->GetSour() << endl;
		cout << "Вес:  " << apple->GetWeight() << endl;
	}
	void SetWeight(double w) {
		this->weight = w;
	}
	double GetWeight() {
		return this->weight;
	}
	virtual const char* getname() {
		return "Apple";
	}

};


class menu
{
protected:
	vector <string> commands{ " " };
	Fruit* k = nullptr;
	Apple* l = nullptr;
	Basket* ptr = nullptr;
	bool exit;

public:
	menu() :exit(false)
	{
		string word = "Создать фрукт";
		commands.push_back(word);

		word = "Создать яблоко";
		commands.push_back(word);
		word = "Создать корзинку";
		commands.push_back(word);
	}
	int addM()
	{
	};
	void delM(char* item)
	{

		commands.erase(commands.begin() + *item);
		cout << "Строки №" << *item << " удалены\n";
	};
	void del(int q);
	void quit()
	{
		exit = true;
	}

	void processMenuItem(int itemNumber)
	{
		string name = "ramis";
		switch (itemNumber)
		{
		case 1:
		{Fruit* k = new Fruit(name);
		k->GetFruit();
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

			break;
		}
		}
		cout << endl;
		processMenu();
	};

	void processMenu()
	{
		if (exit) { exit = false; return; }
		cout << "\n choose point in the Menu:\n";
		for (int i = 1; i < commands.size(); i++)
		{
			cout << i << " : " << commands[i] << "\n";
		};
		cout << "if you want to exit, wtire '0' \n";
		//cout << "if you want to add command, write '-1'\n";
		//cout << "if you want to delete command, write '-2' \n";

		int q;
		cin >> q;
		if (q == 0) quit();
		/*if (q == -1)

			if (q == -2)
			{
				cout << "How do to delete? FIFO,CIFO or by number ('1', '2', '3') ";
				q = -1;
				void del(q)
				{
				};
			}*/
		else
		{
			processMenuItem(q);
		}

	};
};

class Smenu : public menu
{
public:
	Smenu() : menu() {};
	int addM(string item)
	{
		commands.push_back(item);
		cout << "We added function!!! \n";
		processMenu();
		return 0;
	};
	void delM()
	{

		commands.pop_back();
		cout << "Commands №" << commands.size() << " is deleted :D";
		processMenu();

	};
	// commands.pop_back();
};

class Qmenu : public menu
{
public:
	int addM(string item)
	{
		commands.push_back(item);
		cout << "We added function!!! \n";
		processMenu();
		return 0;
	};
	void delM()
	{

		commands.erase(commands.begin());
		cout << "Commands №1 is deleted :D\n";
		processMenu();

	};
};

int main()
{
	system("chcp 1251");
	Smenu m = Smenu();
	m.processMenu();
	m.addM("Jump");
	cout << endl;
	m.delM();
	Qmenu m1 = Qmenu();
	m1.processMenu();
	m1.addM("Sit down");
	cout << endl;
	m1.delM();
	system("pause");
}