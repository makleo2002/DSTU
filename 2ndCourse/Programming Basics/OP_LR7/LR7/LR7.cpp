#include <iostream>
using namespace std;
struct StackElem {
    StackElem(StackElem* next, int value)
    {
        this->value = value;
        this->next= next;
    }
    StackElem* next;
    int value;
};

     void CreateElem(int x)
    {
        StackElem* p ;
        p->value = x;
        p->next = NULL;
    }
    
struct AddinEmpty {
    void addinemptylist(StackElem*& head, StackElem*& tail, int x)
    {
        head = CreateElem(x);
        tail = head;
    }
    StackElem*& head;
    StackElem*& tail;
    int x;
};
void push(StackElem* head, int x)
{
    StackElem* p = CreateElem(x);
    p->next = head;
    head = p;
}
void pop(StackElem* head)
{
    StackElem* p = head;
    head = head->next;
    delete p;
}

int main()
{
        int i = 0;
         p1, p2;
        while (i != 5) {
            int a;
            cin >> a;
            p1.push(a); 
            i++;
        }
        while (!p1.empty())
        {
            p2.push(p1.top());
            p1.pop();
        }

        cout << "Head of p2 is " << p2.top() << endl;

        return (0);

 

}