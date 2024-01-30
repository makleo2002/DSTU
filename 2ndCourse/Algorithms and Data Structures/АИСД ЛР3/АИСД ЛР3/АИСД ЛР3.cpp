#include <iostream>
#include <vector>
using namespace std;
void static_add(int* p,int* A[]) {
    int k = 0;
    if (p == nullptr) cout << "Вы пытаетесь добавить пустой указатель";
    else for (int i = 0; i < 8; i++) {
        if (A[i] == nullptr) {
            A[i] = new int;
            A[i] = p;
            break;
        }
        else {
            k++;
            continue;
        }
    }
    
    cout << "Результат работы функции:"<<endl;
    for (int i = 0; i < 8; i++) {
        cout << A[i]<<endl;
    }
    cout << endl;
    if (k == 8) cout << "Не хватает места"<<endl;
}
void ReadPoint(int* p) {
    cout << *p;
}
void WritePoint(int* p,int num) {
    *p = num;
    cout << *p;
}
void SetPointer(int* p, int* b) {
    *p = *b;
    cout << *p;
}
void FreePointer(int* p) {
    delete p;
}

void RusInEng(vector<string*> R, string word) {
    for (int i = 0; i < R.size(); i++) {
        if (word == *R[i]) {
            cout <<"Перевод на английский: "<< * R[i + 1]<<endl;
        }
    }
}

void EngInRus(vector<string*> R, string word) {
    for (int i = 0; i < R.size(); i++) {
        if (word == *R[i]) {
            cout << "Перевод на русский: " << *R[i-1]<<endl;
            break;
        }
    }
}

    
   int main()
{
    setlocale(LC_ALL, "Russian");
    int num = 3;
    int num1 = 1;
    int num2 = 10;
    int num3 = 2;
    int num4 = -4;
    int num5 = 8;
    int num6 = 9;
    int num7 = 0;
    int num8 = 8;
    int* ptr=&num;
    int* ptr1 = &num1;
    int* ptr2 = &num2;
    int* ptr3 = &num3;
    int* ptr4 = &num4;
    int* ptr5 = &num5;
    int* ptr6 = &num6;
    int* ptr7 = &num7;
    int* ptr8 = &num8;
    int* a[8] = {};
    cout << sizeof(a)<<" байт"<<endl;
    vector<int> mas1(2);
    cout<<sizeof(mas1)*mas1.size()<< " байт" << endl;
    vector<int> mas2(2);
    cout << sizeof(mas2) * mas2.size() << " байт" << endl;
    vector<int> mas3(2);
    cout << sizeof(mas3) * mas3.size() << " байт" << endl;
    vector<int> mas4(2);
    cout << sizeof(mas4) * mas4.size() << " байт" << endl;
    static_add(ptr,a);
    static_add(ptr1, a);
    static_add(ptr2, a);
    static_add(ptr3, a);
    static_add(ptr4, a);
    static_add(ptr5, a);
    static_add(ptr6, a);
    static_add(ptr7, a);
    static_add(ptr8, a);
    int number = 15;
    int* p = &number;
    int number1=5;
    int* b = &number1;
    ReadPoint(p);
    cout << endl;
    WritePoint(p, 20);
    cout << endl;
    SetPointer(p, b);
    cout << endl;
    cout << "Задание 2: "<<endl;
    vector <string> eng = { "cat","house","laptop","airplane","fridge","apple","sky","universe","music","flight" };
    vector <string> rus = { "кот","дом","ноутбук","самолет","холодильник","яблоко","небо","вселенная","музыка","полет" };
    vector <string*> engptr;
    for (int i = 0; i < eng.size(); i++) {
        string* ptr = &eng[i];
        engptr.push_back(ptr);
    }
    vector <string*> rusptr;
    for (int i = 0; i < rus.size(); i++) {
        string* ptr = &rus[i];
        rusptr.push_back(ptr);
        rusptr.push_back(&eng[i]);
    }
    for (int i = 0; i < engptr.size(); i++) {
        cout << *engptr[i]<<" ";
    }
    cout << endl;
    for (int i = 0; i < rusptr.size(); i++) {
        cout << *rusptr[i]<<" ";
    }
    cout << endl;
    RusInEng(rusptr, "яблоко");
    EngInRus(rusptr, "airplane");
} 