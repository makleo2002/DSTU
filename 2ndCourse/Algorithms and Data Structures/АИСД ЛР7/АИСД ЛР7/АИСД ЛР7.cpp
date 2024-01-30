#include <iostream>
#define n_ 10
using namespace std;

class Queue {
public:
	int value;
	Queue* next;
	Queue* head;
	Queue* tail;
	Queue() {
		next = nullptr;
		head = nullptr;
		tail = nullptr;
	}
	Queue* CreateElem(int x) {
		Queue* p;
		p = new Queue;
		p->value = x;
		p->next = nullptr;
		return p;
	}
	bool isEmpty() {
		if (tail == nullptr) return true;
		else return false;
	}
	Queue* push(int value) {
		Queue* p = CreateElem(value);
		if (this->tail == nullptr) {
			this->head = this->tail = p; 
			return p;
		}
		this->tail->next = p;
		this->tail = p;
		return tail;
	}
	Queue* pop() {
		if (this->head == nullptr) return nullptr;
		Queue* p = this->head;
		this->head = this->head->next;
        delete p;
		if (this->head == nullptr) this->tail = nullptr;
		return this->head;
	}
	void front() {
		if (tail == nullptr) cout << "Стек пуст" << endl;
		else cout << "Вершина очереди: " << head->value << endl;
	}
	void back() {
		if (tail == nullptr) cout << "Стек пуст" << endl;
		else cout << "Конец очереди: " << tail->value << endl;
	}
	void show() {
		Queue* p = head;
		while (p->next != nullptr) {
			cout << p->value;
			p = p->next;
		}
		cout << p->value<<" ";
	}
};

struct queue {
	int a[n_];
	int index;
	int head;
	int tail;
};
void Create(queue* q) {
	 q->head = NULL;
	 q->tail = NULL;
	 q->index = NULL;
}
bool isEmpty_(queue* q) {
	if (q->tail == NULL) return true;
	else return false;
}
void push_(int elem, queue* q) {
	if (q->index == n_) cout<<"Нет места "<<endl;
	else {
		     q->a[q->index] = elem;
			 q->tail = q->tail + 1;
			 q->index = q->index + 1;
	}
}
void pop_(queue* q) {
	if (q->index == 0) cout << "Нельзя удалить элемент из пустого массива";
	else {
		q->a[q->head] = NULL;
		q->head = q->head + 1;
	}
     if (q->head == n_ + 1) q->head = 0;
}
void show_(queue* q) {
	if (q->index == 0) cout << "Массив пуст";
	for (int i = q->head; i < q->index; i++) {
		if (q->a[i] != NULL) cout << q->a[i]<<" ";
	}
}

int main() {
	setlocale(LC_ALL, "Russian");
	int select;
	cout << "Выберите способ: " << endl;
	cout << "1)Цепная очередь" << endl;
	cout << "2)Сплошная очередь" << endl;
	cin >> select;
	if (select == 1) {
		int n, n1, x;
		string string1;
		Queue queue;
		cout << "Пустая очередь создана" << endl;
		cout << "Проверка очереди на пустоту: " << queue.isEmpty() << endl;
		cout << "Введите количество элементов для заполнения очереди: ";
		cin >> n;
		for (int i = 0; i < n; i++) {
			cout << "Введите элемент: ";
			cin >> x;
			queue.push(x);
		}
		cout << "Проверка очереди на пустоту: " << queue.isEmpty() << endl;
		if (queue.isEmpty() == 0) queue.front();

		else 0;
		cout << "Вывод элементов очереди: " << endl;
		queue.show();
		cout << endl;
		cout << "Хотите ли вы удалить элементы и сколько?" << endl;
		cin >> string1;
		if (string1 == "yes" or string1 == "Yes") {
			cin >> n1;
			for (int i = 0; i < n1; i++) {
				queue.pop();	
				cout << endl;
			}
			queue.show();
		}
		else cout << "конец";

	}
	else if (select == 2) {
		queue* q=new queue;
		int n, n1,x;
		string string1;
		Create(q);
		cout << "Пустая очередь создана" << endl;
		cout << "Проверка очереди на пустоту: " << isEmpty_(q) << endl;
		cout << "Введите количество элементов для заполнения очереди: ";
		cin >> n;
		for (int i = 0; i < n; i++) {
			cout << "Введите элемент: ";
			cin >> x;
			push_(x, q);
		}
		cout << "Проверка очереди на пустоту: " << isEmpty_(q) << endl;
		cout << "Вывод элементов очереди" << endl;
		show_(q);
		cout << endl;
		cout << "Хотите ли вы удалить элементы и сколько?" << endl;
		cin >> string1;
		if (string1 == "yes" or string1 == "Yes") {
			cin >> n1;
			for (int i = 0; i < n1; i++) {
				pop_(q);
				cout << endl;
			}
			show_(q);
			
		}

		else cout << "конец";

	}
	else cout << "Неправильный номер";
}