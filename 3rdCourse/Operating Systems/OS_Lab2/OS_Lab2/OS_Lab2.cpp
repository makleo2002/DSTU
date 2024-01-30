#include <iostream>
using namespace std;

struct Byte{
	int value;
	int n;
	int page_index;
	int ID;
};

Byte Memory[256];

Byte ExtMemory[256];

void init() {
	int block = 1, block1 = 1;
	int num = 1010000, num1 = 2010000;
	for (int i = 0; 32 * block <= 256+32; i++) {
		Memory[i].page_index = block;//определяем номер страницы для ячейки
		Memory[i].ID = num;
		if (i % 31 == 0 && i != 0) {
			num += 10000;
			block++;//если переходим на след блок,то block++
		} 
		num++;
	}
	for (int i = 0; 32 * block1 <= 256 + 32; i++) {
		ExtMemory[i].page_index = block1;//определяем номер страницы для ячейки
		ExtMemory[i].ID = num1;
		if (i % 31 == 0 && i != 0) {
			num1 += 10000;
			block1++;//если переходим на след блок,то block++
		}
		num1++;
	}
}

void readMemory() {
	
	int id;
	cout << "Введите id ячейки: "<<endl;
	cin >> id;
	int block = Memory[0].page_index;
	if ((id/1000000)==1) {
		for (int i = 0; i <256;i++) {
			if (id == Memory[i].ID) {
				cout << "Значение ячейки с id " << id << " : " << Memory[i].value << endl;//если введенный ID равен ID какой-нибудь ячейки,то выводим ее значение
				Memory[i].n++;
				break;
			} 
		}
	}
	else if ((id / 1000000) == 2) {

		int count,start=0,end=0,min=100000,minIndex=100;
		int block = Memory[0].page_index,block1= ExtMemory[0].page_index;
		int tmp,find=0,st=0;
		int mas[33] = { 0 };


		while (32 * block <256+32) { //проходимся по страницам
			count = 0;
			start = end;
            end = 32*block;
			for (int i = start; i < end; i++) { //текущая страница
				if (Memory[i].n > 0) {
					count += Memory[i].n;
				}//считаем количество обращений в странице
			}
			mas[block] += count;//заносим в массив обращений	
			block++;
		}
		cout << "Массив обращений: ";
		for (int i = 1; i < 33; i++) {//находим страницу с наименьшим количеством обращений
			cout << mas[i] << " ";
			if (mas[i] < min) {
				min = mas[i];
				minIndex = i;
			}
		}
		cout << endl;
		block = minIndex;//подходящая страница ОЗУ
		for (int i = 0; i < 256; i++) {
			if (id == ExtMemory[i].ID) {
				cout << "Значение ячейки с id " << id << " : " << ExtMemory[i].value << endl;//если введенный ID равен ID какой-нибудь ячейки,то выводим ее значение
				find = i;
				break;
			}
		}
		block1 = find / 32+1;
		st = (find / 32) * 32;
		for (int i = (block) * 32; i < (block * 32)+32; i++) {//обмен страниц
			tmp = Memory[i].value;
			Memory[i].value = ExtMemory[st].value;
			ExtMemory[st].value = tmp;	
			st++;
		}
		 Memory[minIndex*32-1].n++;
		
		cout << "Произведен обмен страницы №" << block << " ОЗУ  на страницу №" << block1 << " внешнего носителя" << endl << endl;
	}
	else cout << "Ячейки с таким ID не существует" << endl;
}

void writeMemory() {
	int id,val;
	cout << "Введите id ячейки b и значение для записи: " << endl;
	cin >> id>>val;
	int block = Memory[0].page_index;
	if ((id / 1000000) == 1) {
		for (int i = 0; i < 256; i++) {
			if (id == Memory[i].ID) {
				cout << "Значение ячейки с id " << id << " заменено с " << Memory[i].value<<" на "<<val<<endl;
				Memory[i].value = val;//если введенный ID равен ID какой-нибудь ячейки,то меняем ее значение
				Memory[i].n++;
				break;
			}
		}
	}
	else if ((id / 1000000) == 2) {
		int count, start = 0, end = 0, min = 100000, minIndex = 100;
		int block = Memory[0].page_index, block1= ExtMemory[0].page_index;
		int tmp, find = 0, st = 0;
		int mas[33] = { 0 };

		while (32 * block < 256+32) { //проходимся по страницам
			count = 0;
			start = end;
			end = block * 32;
			for (int i = start; i < end; i++) { //текущая страница
				if (Memory[i].n > 0) count += Memory[i].n; //считаем количество обращений в странице
			}
			mas[block] += count;//заносим в массив обращений	
			block++;
		}
		cout << "Массив обращений: ";
		for (int i = 1; i < 33; i++) {//находим страницу с наименьшим количеством обращений
			cout<< mas[i] << " ";
			if (mas[i] < min) {
				min = mas[i];
				minIndex = i;
			}
		}
		cout << endl;
		block = minIndex;//подходящая страница ОЗУ
		
		for (int i = 0; i < 256; i++) {//ищем элемент во внешнем носителе
			if (id == ExtMemory[i].ID) {
				cout << "Значение ячейки с id " << id << " заменено с " << ExtMemory[i].value << " на " << val << endl;
				Memory[i].value = val;//выводим значение и запоминаем индекс
				find = i;
				break;
			}
		}
		block1 = find / 32+1;
		st = (find/ 32) * 32;
		for (int i = (block) * 32; i < (block * 32)+32; i++) {//обмен страниц
			tmp = Memory[i].value;
			Memory[i].value = ExtMemory[st].value;
			ExtMemory[st].value = tmp;
			st++;
		}
		Memory[minIndex * 32 - 1].n++;//записываем обращение
		cout << "Произведен обмен страницы №" << block << " ОЗУ  на страницу №" << block1 << " внешнего носителя" << endl<<endl;
		
	}
	else cout << "Ячейки с таким ID не существует" << endl;
}

void getInfo() {

	printf("|%-27s|%-17s|%-24s|%-20s|\n", "---------------------------", "-----------------", "------------------------", "--------------------");
	printf("|%-27s|%-17s|%-24s|%-20s|\n", "         Тип памяти        ", "     Страница    ", "         Ячейка         ", "         ID         ");
	printf("|%-27s|%-17s|%-24s|%-20s|\n", "---------------------------", "-----------------", "------------------------", "--------------------");
	for (int i = 0; i < 256; i ++) {
	printf("|%-27s|%17d|%24d|%20d|\n"   ,  "        Оперативная       ", Memory[i].page_index  , Memory[i].value          , Memory[i].ID);
	printf("|%-27s|%-17s|%-24s|%-20s|\n", "---------------------------", "-----------------", "------------------------", "--------------------");
	}
	for (int i = 0; i < 256; i ++) {
	printf("|%-27s|%17d|%24d|%20d|\n",    "      Внешний носитель     ", ExtMemory[i].page_index , ExtMemory[i].value,      ExtMemory[i].ID);
	printf("|%-27s|%-17s|%-24s|%-20s|\n", "---------------------------", "-----------------", "------------------------", "--------------------");
	}

}

int main()
{
	setlocale(LC_ALL, "Russian");

	int select;

	cout << "Моделирование страничной вирутальной памяти и алгоритмов свопинга\n\n";
	cout << "1)Чтение\n";
	cout << "2)Запись\n";
	cout << "3)Информация\n";
	cout << "4)Выход\n\n";

	init();

	while (1) {
		cout << "Выбор : ";
		cin >> select;
		cout << endl;
		if (select == 1) readMemory();
		else if (select == 2) writeMemory();
		else if (select == 3) getInfo();
		else if (select == 4) {
			cout << "Программа завершена";
			break;
		}
	}
	
	

	
}
