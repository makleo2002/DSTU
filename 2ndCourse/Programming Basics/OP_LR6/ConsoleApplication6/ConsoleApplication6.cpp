
#include <iostream>
#include <string>
using namespace std;
class Human {
    string m_name;
    int m_age;
public:
    Human(string name = " ", int age = 0) {
        m_name = name;
        m_age = age;
        }
    string getName() {
        return m_name;
    }
};
class Basketball : public Human {
    int num_player;
public:
    Basketball(string name = "", int age = 0, int num_pl = 0)
        :Human(name,age),num_player(num_pl) {}
        
    
    void f() {
        cout<<getName();
    }
};


class Animal
{
protected:
    std::string m_name;

    // Мы делаем этот конструктор protected так как не хотим, чтобы пользователи имели возможность создавать объекты класса Animal напрямую,
    // но хотим, чтобы в дочерних классах доступ был открыт
    Animal(std::string name)
        : m_name(name)
    {
    }

public:
    std::string getName() { return m_name; }
    virtual const char* speak() { return "???"; }
};

class Cat : public Animal
{
public:
    Cat(std::string name)
        : Animal(name)
    {
    }

    virtual const char* speak() { return "Meow"; }
};

class Dog : public Animal
{
public:
    Dog(std::string name)
        : Animal(name)
    {
    }

    virtual const char* speak() { return "Woof"; }
};

void report(Animal& animal)
{
    std::cout << animal.getName() << " says " << animal.speak() << '\n';
}


int main()
{
    Basketball H1;
    H1.f();
    Cat cat("Matros");
    Dog dog("Barsik");

    report(cat);
    report(dog);
}

