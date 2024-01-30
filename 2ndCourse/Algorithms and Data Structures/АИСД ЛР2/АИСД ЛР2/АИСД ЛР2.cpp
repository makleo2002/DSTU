//1. Составить и отладить программу определения количества отрицательных элементов в файле действитель-ных чисел:

//1.1 из программы создать файл на диске, задав ему произвольное имя;

//1.2 заполнить файл с произвольными положительными и отрицательными числами;

//1.3 открыть файл для чтения и определить количество отрицательных чисел.

//2 Разработать и отладить процедуры, добавляющие заданную букву в произвольное место символьного файла.

//3 Создать на диске Текстовый файл, ввести в него произвольный текст, затем вывести n строку текста, предусмотреть возможность отсутствия строки с таким номером.

//4 Реализовать функцию поиска в Текстовом файле подстроки(можно использовать функцию pos()).Результатом поиска является пара значений номер сроки – номер позиции.Предусмотреть возможность более одного совпадения.

//5 Задать текстовый файл.Написать функцию определяющую количество уникальных слов в файле.Написать функцию определяющую количество повторов каждого слова, содержащегося в файле.Написать функцию удаляющую знаки препинания из файла.
#include <windows.h>
#include <iostream>
#include <fstream>
#include <string>
#include <map>

using namespace std;
void negnumber(ofstream& text) {
    int neg = 0;
    text << 1 << -2 << 3 << -3 << 5 << -5<<-9 <<8<<-20;
    text.close();
    ifstream fin("file.txt");
    if (!fin) {
        cerr << "error";
        exit(1);
    }
    else {
        while (fin) {
            int num;
            fin >> num;
            while (fin >> num) {
                if (num < 0) neg++;
            }

        }
    }
    cout << endl;
    cout << "Количество отрицательных элементов: " << neg << endl;
}

void addchar(ofstream& file) {
    int k;
    char c;
    cout << "Введите расположение символа: ";
    cin >> k;
    cout << "Введите символ ";
    cin >> c;
    file.seekp(k);
    file.put(c);
}

void addtext(fstream& text,int n) {
    string str;
    while(str!=" ") {
        for (int i = 0; i < n; i++) {
            getline(cin, str);
            text << str << endl;
        }
    }
    cout << "Текст записан в файл";
}

void strfind(fstream &text, int n, int m) {
    for (int i = 1; i <= n; i++) {
        string str;
        getline(text, str);
        if (m == i) cout << str<<endl;
    }
    if (m > n) cout << "Строка отсутствует";
}
 
void substr(string sub) {
    ifstream text1("string.txt");
    ifstream text2("string.txt");
    string str;
    int i = 0;
    cout << "Текст,записанный в файле string.txt: " << endl;
    while (!text2.eof()) {

        getline(text2, str);
        cout << str << endl;
    }
    for (;!text1.eof(); i++) {
        getline(text1, str);
        
        if (str.find(sub) != std::string::npos) {
            break;
        }
    }
        text1.close();
        
        int pos = str.find(sub);

        if (str.find(sub) == std::string::npos)
            cout << "not finded" << endl;
        else
            cout << "Подстрока нашлась в " <<i+1<<" cтроке"<< " и в "<<pos+1 << " позиции строки" << endl;
}
void uni(fstream& file) {
    string str;
    ifstream file1("file2.txt.");
    int i = 0;
    int u = 0;
    map<string,int> words;
    while (file1) {
        file1 >> str;
        string str1;
        for (int i = 0; i < str.size(); ++i) {
            if (str[i] == '.' || str[i] == ',') 0;
            else str1 += str[i];
        }
        if (words.count(str1) > 0) ++words[str1];
        else
        words.insert(pair<string,int>(str1,1));
    }
    for (auto it = words.begin(); it != words.end(); ++it) {
        cout << it->first << ' ' << it->second << endl;
        if (it->second == 1) u += 1;
    }
    
    cout<<"Количество уникальных слов: "<<u;
}
    int main()
    {  

        setlocale(LC_ALL, "Russian");
        SetConsoleCP(1251);
        SetConsoleOutputCP(1251);
        ofstream file("file.txt");
        
        negnumber(file);
        cout << "--------------------------------------------" << endl;
        ofstream Cout("char.txt",ios::ate);
        addchar(Cout);
        cout << endl;
        cout << "--------------------------------------------" << endl;
        fstream text("string.txt");
       
        cout << "n строка текста: "<<endl;
        strfind(text, 4, 4);
        cout << endl;
        cout << "--------------------------------------------" << endl;
        substr("la");
        cout << endl;
        cout << "--------------------------------------------" << endl;
        fstream file2("file2.txt");
        uni(file2);
        cout << endl;
    }


