#include <iostream>
#include <string>
#include <vector>
using namespace std;

class person
{
protected:
	string name;
	int age;
	int gender;

public:

	person(string name = "Man")			//Клнструткор по умолчанию с парамтером 1/none 
	{
		this->name = name;
		this->age = 18;
		this->gender = 1;
	};

	person()			//Клнструткор по умолчанию с парамтером 1/none 
	{
		this->name = "none";
		this->age = 1;
		this->gender = 1;
	};

	person(string name, int age, int gender)			//Клнструткор по умолчанию с парамтером 1/none 
	{
		this->name = name;
		this->age = age;
		this->gender = gender;
	};



	void gen()															//Пол человека 
	{
		if (gender == 1)
			cout << "man";
		else
			cout << "woman";
	}

	void setage()														//Установить возраст
	{
		cin >> age;
	}

	int getage()														//показать возраст
	{
		return age;
	}

	void gethuman()														//показать объект на экране
	{
		cout << "imya - " << name << endl;
		cout << "vozrast - " << age << endl;
		cout << "pol - ";
		gen();
		cout << endl;
	}

	void sethuman()
	{
		cout << "imya - "; cin >> this->name;
		cout << endl << "vozrast - "; cin >> this->age;
		cout << "pol (1 -> man, else woman) - ";  cin >> this->gender;
	};

	virtual void F()
	{
		cout << "I ma human :D\n";
	}

};

class Department
{
private:
	person* m_worker;

public:
	Department(person* worker = nullptr)
		:m_worker(worker)
	{
		cout << "Depatament was created\n";
	}
};

class dstu : public person
{
	int otmetki = 0;
public:
	dstu(string name) :person(name)
	{

	};


	virtual void F()
	{
		cout << "ya student\n";
	}
};


class menu
{
protected:
	vector <string> commands{ " " };
	person* k = nullptr;
	dstu* l = nullptr;
	Department* ptr = nullptr;
	bool exit;

public:
	menu() :exit(false)
	{
		string word = "Создать человека";
		commands.push_back(word);

		word = "Создать ДГТУшника";
		commands.push_back(word);
		word = "Создать челика, который находится в департаменте";
		commands.push_back(word);
	}
	int addM()
	{
	};
	void delM(char* item)
	{

		commands.erase(commands.begin() + *item);
		cout << "Commands №" << *item << " is deleted :D\n";
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
		{person* k = new person(name);
		k->gethuman();
		break;
		}
		case 2:
		{
			dstu* l = new dstu(name);
			l->gethuman();
			l->F();
			break;
		}
		case 3:
		{
			person* k = new person(name);
			Department* ptr = new Department(k);

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
		cout << "if you want to add command, write '-1'\n";
		cout << "if you want to delete command, write '-2' \n";

		int q;
		cin >> q;
		if (q == 0) quit();
		if (q == -1) addM();

			if (q == -2)
			{
				
			}
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