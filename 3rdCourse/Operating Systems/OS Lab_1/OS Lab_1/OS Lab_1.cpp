// OS Lab_1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;

int BitMap[64];//битовая карта

void allocMemory() //функция выделения памяти
{

    int c = 0, count, block = 1, start = 0, end = 0; //количество нулевых байтов,номер участка памяти,начальный и конечный адрес.
    bool f = false;//показывает,выделена или не выделена память

    cout << "Введите количество памяти, которое хотите выделить\n";
    cin >> c;
    int cnt = c;
    while (8 * block <= sizeof(BitMap) / 4)//проходимся по блокам
    {
        count = 0;
        start = end;
        end = 8 * block;

        for (int i = start; i < end; i++)
        {
            if (BitMap[i] == 0) count++;
        }
        if (count > c)//если свободных байтов больше,чем указал пользователь,то выделяем память.
        {
            for (int i = start; i < start + c; i++)
            {
                if (BitMap[i] == 0) {
                    BitMap[i] = 1;
                    cnt--;

                } //заполняем участок памяти количеством байтов,которые указал пользователь

            }
            cout << "Память выделена" << endl;
            cout << "Блок №" << block << endl;
            cout << "Адрес участка памяти: " << &BitMap[start] << endl;
            cout << endl;
            f = true;
            break;
        }
        else if(count<=c && c<= sizeof(BitMap) / 4){
            for (int i = start; i < end; i++)
            {
                if (cnt == 0) break;
                if (BitMap[i] == 0) {
                    BitMap[i] = 1;
                    cnt--;
                };
            }
            for (int i = 0; i < 64; i++)
            {
                if (cnt == 0) break;
                if (BitMap[i] == 0) {
                    BitMap[i] = 1;
                    cnt--;
                } //заполняем участок памяти количеством байтов,которые указал пользователь

            }

            cout << "Память выделена" << endl;
            cout << "Адрес участка памяти: " << &BitMap[start] << endl;
            cout << endl;
           // f = true;
            break;
        }
        else {
            cout << "Нехватка памяти \n";//если память не выделилась,то значит ее не хватает.
            return;
        }
        block++;
    }
   
    // for(int i=0;i<64;i++) cout<<BitMap[i]<<endl; 
}

void freeMemory(int* address) //функция освобождения памяти
{
    for (int* i = address; i < address + 8; i++)
    {
        *i = 0;//обнуляем байты определенного участка памяти.
    }
    cout << "Участок с начальным адресом " << address << " освобожден" << endl << endl;
}

void getInfo() //функции получения инф-ии
{
    cout << "Информация о блоках:\n";
    int block = 1, start = 0, end = 0;
    int free_count, filled_count;//количество свободных и занятых байтов в участке памяти
    int all_free_count = 0, all_filled_count = 0;//общее количество свободных и занятых байтов
    int free_blocks = 0, filled_blocks = 0;//количество свободных и занятых блоков

    while (8 * block <= sizeof(BitMap) / 4)//проходимся по участкам памяти
    {
        free_count = 0;
        filled_count = 0;
        start = end;
        end = 8 * block;
        for (int i = start; i < end; i++)//проходимся по блоку
        {
            if (BitMap[i] == 0) free_count++;//считаем свободные и занятые байты в определенном блоке
            else filled_count++;
        }
        all_free_count += free_count;//добавляем их общему кол-ву
        all_filled_count += filled_count;
        cout << "Блок №" << block << endl;
        if (filled_count == 0)//выводим тип участка
        {
            cout << "Тип: Свободный" << endl;
            free_blocks++;
        }
        else {
            cout << "Тип: Занятый" << endl;
            filled_blocks++;
        }

        cout << "Адрес участка: " << &BitMap[start] << endl;
        cout << "Размер участка: " << end - start << endl << endl;

        block++;//переход на следующий участок памяти
    }
    cout << endl;
    cout << "Всего памяти: " << sizeof(BitMap) / 4 << " байт" << endl;
    cout << "Количество свободных участков: " << free_blocks << endl;
    cout << "Количество занятых участков: " << filled_blocks << endl;
    cout << "Свободная память: " << all_free_count << " байт" << endl;
    cout << "Занятая память: " << all_filled_count << " байт" << endl;
}

int main()
{
    int* ptr1 = &BitMap[0];
    int* ptr2 = &BitMap[8];
    int* ptr3 = &BitMap[16];
    int* ptr4 = &BitMap[24];
    int* ptr5 = &BitMap[32];
    int* ptr6 = &BitMap[40];
    int* ptr7 = &BitMap[48];
    int* ptr8 = &BitMap[56];
    int* ptr9 = &BitMap[64];
    int select;
    int b;

    setlocale(LC_ALL, "Russian");
    cout << "Эмуляция динамической памяти\n";
    cout << "1)Выделить память\n";
    cout << "2)Освободить память\n";
    cout << "3)Получить информацию о блоках\n";
    cout << "4)Выйти\n\n";

  
    while (1) {
        cout << "Выбор: ";
        cin >> select;
        cout << endl;
        if (select == 1) allocMemory();
        else if (select == 2) {
            cout << "Введите № блока:\n";
            cin >> b;
            if (b == 1) freeMemory(ptr1);
            else if (b == 2) freeMemory(ptr2);
            else if (b == 3) freeMemory(ptr3);
            else if (b == 4) freeMemory(ptr4);
            else if (b == 5) freeMemory(ptr5);
            else if (b == 6) freeMemory(ptr6);
            else if (b == 7) freeMemory(ptr7);
            else if (b == 8) freeMemory(ptr8);
            else if (b == 9) freeMemory(ptr9);
            else {
                cout << "Блок с таким номером отсутствует\n";
            }
        }
        else if (select == 3) getInfo();
        else if (select == 4) {
            cout << "Программа завершена";
            break;
        }
    }
    //62
    //15
    //63
    //63
    //48
    //free
    //63

}

