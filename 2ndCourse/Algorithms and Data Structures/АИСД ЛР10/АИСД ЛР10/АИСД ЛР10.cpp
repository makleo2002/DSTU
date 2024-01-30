#include <iostream>
#include <string>
#include <list>
#include <vector>
#include <iterator>
#include <fstream>
using namespace std;

vector< list<string>*> hash_table(10);

void hash_(string word) {
    int sum = 0;
    int num = 0;
    char numbers1[] = { '0','А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
    char numbers2[] = { '0','а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

    for (int k = 0; k < word.size(); k++) {
        for (int m = 0; m < sizeof(numbers1); m++) {
            if (word[k] == numbers1[m]) {
                sum += m;
                num++;
            }
        }
        for (int t = 0; t < sizeof(numbers2); t++) {
            if (word[k] == numbers2[t]) {
                sum += t;
                num++;
            }
        }

    }
    sum = sum % 10;
    if (hash_table[sum]->empty()) {
        hash_table[sum]->push_front(word);
    }
    else {
        hash_table[sum]->push_back(word);
        ofstream fout("collisions.txt");
        fout << "Коллизии по хешу " << sum << " : " << endl << word;
    }
    cout << "Слово " << num << " : " << sum << endl;

}
int getHash(string word) {
    int sum = 0;
    int num = 0;
    char numbers1[] = { '0','А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
    char numbers2[] = { '0','а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

    for (int k = 0; k < word.size(); k++) {
        for (int m = 0; m < sizeof(numbers1); m++) {
            if (word[k] == numbers1[m]) {
                sum += m;
                num++;
            }
        }
        for (int t = 0; t < sizeof(numbers2); t++) {
            if (word[k] == numbers2[t]) {
                sum += t;
                num++;
            }
        }

    }
    sum = sum % 10;
    return sum;
}

auto string_find(string word) {
    int count = 0;
    int num = getHash(word);
    auto it= hash_table[num]->begin();
    if (*it == word) {
        cout << "Шаги поиска: 1" << " ";
        return *it;
    }
       
    else for (it; it != hash_table[num]->end(); it++) {
        count++; 
        if (*it == word) {
           
            cout << "Шаги поиска: " << count << " ";
            return *it;
        }
    }
        
}
int main()
{
    setlocale(LC_ALL, "Russian");
    cout << "Задание 1: " << endl;
    for (size_t i = 0; i < hash_table.size(); i++)
        hash_table[i] = new list< string >();

    vector<string> words = { "Ноутбук","Компьютер","Телефон","Планшет","Приставка","Умные часы","Наушники" };
    for (int i = 0; i < 7; i++) {
        hash_(words[i]);
    }
    for (int i = 0; i < 7; i++) {
        cout << string_find(words[i])<<endl;
    }
  
    cout << endl << "Задание 2: " << endl;

    return 0;
}



