#include <iostream>
using namespace std;
#include<string>
#include <vector>
#include <set>
#include <algorithm>
/*1.	Организовать процедуру для задания элементов множества А. Организовать процедуру printset, пе-чатающую элементы множества А с определением их числа.
2.	Задать два текстовых предложения. Разбить первое и второе предложения на отдельные слова и поместить эти слова в два множества. Написать функцию сравнения полученных множеств, не используя опе-рации объединения и пересечения множеств, результатом работы которой будет являться массив слов, встре-чающихся в обоих предложениях.
3.	Задать множество S состоящее из символов. Разделить множество S на три подмножества: А – символы русского алфавита, Б – латинские символы, В – цифры.
 
 
*/
set<int> enterset(set<int> N, int n) {
	cout <<"Введите "<< n<<" чисел: " << endl;
	for (int i = 0; i < n; i++) {
		cout<< i + 1<< ") ";
		int dig;
		cin >> dig;
		N.insert(dig);
	}
	cout<< endl;
	return N;
}

void printset(set<int>arr) {
	cout << "Элементы множества A: ";
	copy(arr.begin(), arr.end(), ostream_iterator<int>(cout, " "));
	cout << endl;
}
void compareset(set<string> A, set<string> B) {
	vector <string> H;
	set<string> ::iterator it1; // объявляем итератор
	set<string> ::iterator it2;
	for (it1 = A.begin(); it1 != A.end(); ++it1) // пока итератор не достигнет последнего элемента
	{
		for (it2 = B.begin(); it2 != B.end(); ++it2) {
			if (*it1 == *it2) H.push_back(*it1);
		}
	}

	for (string i : H) {
		cout << i<<" ";
	}


}


set<string> separate(string query) {
	string word;
	set<string> arr;
	int k = 0;
	for (int i = 0; i <= query.size(); ++i)
	{
		if (query[i] != ' ' && i != query.size()) word += query[i];
		if (i == query.size()) {
			word += query[i];
			arr.insert(word);
		}
		else if (query[i] == ' ') {
			arr.insert(word);
			++k;
			word = ""s;

		}
	}
	copy(arr.begin(), arr.end(), ostream_iterator<string>(cout, " "));
	cout << endl;
	return arr;
}


	int main() {
		setlocale(LC_ALL,"Russian");
		srand(time(NULL));
		set<int> N;
		N=enterset(N, 5);
		printset(N);
		
		set<string> A;
	    set <string> B;
		
		int k = 0;
		
		string word, word1;
		string s1 = "Queen of Britain";
		
		
		cout << "Множество  A:" << endl;
		A=separate(s1);
		cout << endl;
		
		
		cout << endl;
		string s2 = "London is the capital of Great Britain";
		cout << "Множество  B:" << endl;
		B=separate(s2);
		cout << endl;
		
		

		cout << "Сравнение Множества А и B: ";
		compareset(A, B);
		cout << endl;
		

	
		char S[10] = { 'А','5','i','б','L','o','Т','y','9','и'};
		set <char> A1;
		set <char> B1;
		set <char> C1;
		for (int i = 0; i < 10; ++i) {
			if (S[i] >= 'а' && S[i] <= 'я' || S[i] >= 'А' && S[i] <= 'Я') A1.insert(S[i]);
		    if (S[i] >= 'a' && S[i] <= 'z' || S[i] >= 'A' && S[i] <= 'Z') B1.insert(S[i]);
			if (S[i] >= '0' && S[i] <= '9') C1.insert(S[i]);
		}
		cout << "Множество А: ";
		copy(A1.begin(), A1.end(), ostream_iterator<char>(cout, " "));
		cout << endl;
		cout << "Множество Б: ";
		copy(B1.begin(), B1.end(), ostream_iterator<char>(cout, " "));
		cout << endl;
		cout << "Множество В: ";
		copy(C1.begin(), C1.end(), ostream_iterator<char>(cout, " "));
		cout << endl;

	
	}