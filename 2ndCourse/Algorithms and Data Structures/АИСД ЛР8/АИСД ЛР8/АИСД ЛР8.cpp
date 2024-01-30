#define n_ 10
#define no_init -842150451
#include <iostream>

using namespace std;

struct Node {
    int value;
    Node* next;
};


class List {
    
public:
    int size;
    Node* head;
    List() {
        head = nullptr;
    }
    bool isEmpty() {
        if (head == nullptr) return true;
        return false;
    }
    
    void push_front(int data)
    {
        head = new Node{ data, head };
    }
    void pop_front()
    {
        Node* temp = head;
        head = head->next;
        delete temp;
    }
  
    void insert(int data, int curr) {
        if (size == 0)
        {
            push_front(data);
        }

        else {
            Node* prev = this->head;
            for (int i = 0; i < curr - 1; i++) {
                prev = prev->next;
            }
            Node* newNode = new Node{ data, prev->next };
            prev->next = newNode;
        }
        size++;
    }
    void del(int curr) {
        if (size == 0)
        {
            pop_front();
        }
        else {
            Node* prev = this->head;
            for (int i = 0; i < curr - 1; i++) {
                prev = prev->next;
            }
            Node* toDel = prev->next;

            prev->next = toDel->next;

            delete toDel;
        }
        size--;
    }
    void top() {
        cout << head->value;
    }
    void show() {
        Node* h = head;
        while (h) {
            cout << h->value << " ";
            h = h->next;
        }
    }
    void clear() {
        Node* h = head;
        while (h != NULL) {
            h = NULL;
            h = h->next;
        }
    }
};


struct list {
    int a[n_];
    int index;
    int head;
    int tail;
};
void CreateList(list* l) {
    l->head = INT_MIN;
    l->tail = INT_MIN;
    l->index = NULL;
}
bool isEmpty_(list* l) {
    if (l->tail == INT_MIN) return true;
    else return false;
}

void insert_(int ind,int elem, list* l) {
    if (ind<0 || ind>l->index) cout << "Такого элемента нет";
    else {
        if (l->index == n_) cout << "Нет места " << endl;
        else if (l->tail == INT_MIN) {
            l->head = l->tail = elem;
            l->a[0] = elem;
            l->index++;
        }
        else {
            l->a[ind + 1] = elem;
            if (l->a[ind + 2] == INT_MIN) l->tail = elem;
            l->index++;
        }
    }
}
void del_(int ind,list* l) {
    if (ind<0 || ind>l->index) cout << "Такого элемента нет";
    else {
        if (l->index == 0) cout << "Нельзя удалить элемент из пустого массива";
        else if (l->index == 1) {
            l->a[0] = INT_MIN;
            l->head = l->tail = INT_MIN;
            l->index--;
        }
        else if (l->a[ind + 2] == INT_MIN) {
            l->a[ind + 1] = INT_MIN;
            l->tail = l->a[ind];
            l->index--;
        }
        else {
            l->a[ind + 1] = INT_MIN;
            l->index--;
        }
    }
}
void show_(list* l) {
    if (l->index == 0) cout << "Массив пуст";
    for (int i = 0; i < n_;i++) {
        if (l->a[i] != INT_MIN && l->a[i] != no_init) cout << l->a[i] << " ";
    }
}
void clear(list*l) {
    for (int i = 0; i < l->index; i++) {
        l->a[i] = INT_MIN;
    }
}
/*
 struct list {
     int a[n_];
     int count=0;
     list* next;
     list* head;
 };

void CreateList(list* l) {
     l->head = nullptr;
     l->next = nullptr;
 }

bool is_Empty(list* l) {
    if (l->head == nullptr) return true;
    else return false;
}

void Insert(list* l, int data,int curr) {
    if (l->count == n_) cout << "Массив заполнен";
    else {
        if (l->head == nullptr) {
            l->head->next = nullptr;
            l->a[0] = data;
            l->head->a[0] = data;
            l->count++;
        }
        else {
            list* prev = l;
            for (int i = 0; i < curr - 1; i++) {
                prev = prev->next;
            }
            l->a[curr + 1] = data;
        }
    }
 }

void Delete(list* l,int curr) {

    if (curr == 0)
    {
        l->a[0] = NULL;
    }
    else {
        list* prev = l->head;
        for (int i = 0; i < curr - 1; i++) {
            prev = prev->next;
        }
       list* toDel = prev->next;
       prev->next = toDel->next;
        delete toDel;
        l->count--;
    }
 }

void Top(list* l) {
    cout << l->a[0];
 }
void Show(list* l) {
    int i = 0;
    list* h = l->head;
    while (l->a[i] == NULL) {
        cout << h->a[i] << " ";
        h = h->next;
        i++;
    }
 }
void Clear() {

 }
*/
int main()
{
    setlocale(LC_ALL, "Russian");
    /*  List list;
    list.insert(5, 0);
    list.insert(2, 1);
    list.insert(-5, 2);
    list.show();
    list.clear();

      list* list1=new list;
    Insert(list1,5, 0);
    Insert(list1,2, 1);
    Insert(list1 ,-5, 2);
    Show(list1);
    //Top(list1);
    cout << endl;
*/

    int select;
    cout << "Выберите способ: " << endl;
    cout << "1)Цепной список" << endl;
    cout << "2)Сплошной список" << endl;
    cin >> select;
    if (select == 1) {
        int n, n1, x, ind;
        string string1;
        List list;
        cout << "Пустой список создан" << endl;
        cout << "Проверка списка на пустоту: " << list.isEmpty() << endl;
        cout << "Введите количество элементов для заполнения списка: ";
        cin >> n;
        for (int i = 0; i < n; i++) {
            cout << "Введите элемент: ";
            cin >> x;
            cout << "Введите индекс текущего элемента: ";
            cin >> ind;
            list.insert(x, ind);
        }
        cout << "Проверка список на пустоту: " << list.isEmpty() << endl;
        if (list.isEmpty() == 0) list.top();
        else 0;
        cout << endl;
        cout << "Вывод элементов списка" << endl;
        list.show();
        cout << endl;
        cout << "Хотите ли вы удалить элементы и сколько?" << endl;
        cin >> string1;
        if (string1 == "yes" or string1 == "Yes") {
            cin >> n1;
            for (int i = 0; i < n1; i++) {

                cout << "Введите индекс текущего элемента: ";
                cin >> ind;
                list.del(ind);
                cout << endl;
            }
            list.show();
        }
        else cout << "конец";

    }
    else if (select == 2) {
        list* list1 = new list;
        int n, n1, x = 0, ind1;
        string string1;
        CreateList(list1);
        cout << "Пустой список создан" << endl;
        cout << "Проверка список на пустоту: " << isEmpty_(list1) << endl;
        cout << "Введите количество элементов для заполнения списка: ";
        cin >> n;
        for (int i = 0; i < n; i++) {
            cout << "Введите элемент: ";
            cin >> x;
            cout << "Введите индекс текущего элемента: ";
            cin >> ind1;
            insert_(ind1, x,list1 );
        }
        cout << "Проверка списка на пустоту: " << isEmpty_(list1) << endl;
        cout << "Вывод элементов списка" << endl;
        show_(list1);
        cout << endl;
        cout << "Хотите ли вы удалить элементы и сколько?" << endl;
        cin >> string1;
        if (string1 == "yes" or string1 == "Yes") {
            cin >> n1;
            for (int i = 0; i < n1; i++) {
                cout << "Введите индекс текущего элемента: ";
                cin >> ind1;
                del_(ind1,list1);
                cout << endl;
            }
            show_(list1);
        }
        else cout << "конец";
    }
    else cout << "Неправильный номер";

    return 0;
}
