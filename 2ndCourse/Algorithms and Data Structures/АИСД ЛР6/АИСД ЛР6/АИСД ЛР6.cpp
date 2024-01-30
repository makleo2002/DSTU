#include <iostream>
#define n_ 10
using namespace std;

class Stack {
public:
	int value;
	Stack* next;
    Stack* head;
	Stack* CreateElem(int x) {
		Stack* p;
		p = new Stack;
		p->value = x;
		p->next = nullptr;
		return p;
	}
	Stack() {
		next = nullptr;
		head = nullptr;
	}
	bool isEmpty() {
		if (head == nullptr) return true;
		else return false;
	}
  Stack* push(int value) {
		Stack* p = CreateElem(value);
		p->next = head;
		head = p;
		return head;
	}
  Stack* pop() {
	  Stack* p = head;
	  head = head->next;
	  delete[] p;
	  return head;
  }
  void top() {
	  if (this->head == nullptr) cout << "Стек пуст"<<endl;
	  else cout << "Вершина стэка: " << this->head->value<<endl;
  }
  void show() {
	  Stack* p=head;
	  while (p->next!=nullptr) {
		  cout << p->value;
		  p = p->next;
	  }
	  cout << p->value<<" ";
  }
};

struct stack {
	int a[n_];
	int index;
};
void Create(struct stack* stack) {
	stack->index=NULL;
}
bool isEmpty_(struct stack* stack) {
	if (stack->index == NULL) return true;
	else return false;
}
void push_(int elem, struct stack* stack) {
	if (stack->index == n_) cout << "Стэк полон";
	else {
		
		    stack->a[stack->index] = elem;
			stack->index = stack->index + 1;
	}
}
void pop_(struct stack* stack) {
	if (stack->index == NULL) cout<<"Нельзя удалить элемент из пустого стэка";
	else {
		stack->a[stack->index] = NULL;
		 stack->index = stack->index - 1;
	}
}
 void show_(struct stack* stack) {
	 if (stack->index == NULL) cout << "Пустой стэк";
	int i =stack->index-1;
	for (i; i >=0; i--) {
		if(stack->a[i]!=NULL) cout << stack->a[i]<<" ";
	}
}
int main() {
	setlocale(LC_ALL, "Russian");
	int select;
	cout << "Выберите способ: "<<endl;
	cout << "1)Цепной стэк" << endl;
	cout << "2)Сплошной стэк" << endl;
	cin >> select;
	if (select == 1) {
		int n, n1, x;
		string string1;
		Stack stack;
		cout << "Пустой стэк создан" << endl;
		cout << "Проверка стэка на пустоту: " << stack.isEmpty() << endl;
		cout << "Введите количество элементов для заполнения стэка: ";
		cin >> n;
		for (int i = 0; i < n; i++) {
			cout << "Введите элемент: ";
			cin >> x;
			stack.push(x);
		}
		cout << "Проверка стэка на пустоту: " << stack.isEmpty() << endl;
		if (stack.isEmpty() == 0) stack.top();

		else 0;
		cout << "Вывод элементов стэка" << endl;
		stack.show();
		cout << endl;
		cout << "Хотите ли вы удалить элементы и сколько?" << endl;
		cin >> string1;
		if (string1 == "yes" or string1 == "Yes") {
			cin >> n1;
			for (int i = 0; i < n1; i++) {
				stack.pop();
				cout << endl;
			}
			stack.show();
		}
		else cout << "конец";

	}
	else if (select == 2) {
		stack* stk = new stack;
		int n, n1,x=0;
		string string1;
		Create (stk);
		cout << "Пустой стэк создан" << endl;
		cout << "Проверка стэка на пустоту: " <<  isEmpty_(stk) << endl;
		cout << "Введите количество элементов для заполнения стэка: ";
		cin >> n;
		for (int i = 0; i < n; i++) {
			cout << "Введите элемент: ";
			cin >> x;
			push_(x,stk);
		}
		cout << "Проверка стэка на пустоту: " << isEmpty_(stk) << endl;
		cout << "Вывод элементов стэка" << endl;
		show_(stk);
		cout << endl;
		cout << "Хотите ли вы удалить элементы и сколько?" << endl;
		cin >> string1;
		if (string1 == "yes" or string1 == "Yes") {
			cin >> n1;
			for (int i = 0; i < n1; i++) {
				pop_(stk);
				cout << endl;
			}
			show_(stk);
		}
		else cout << "конец";
	}
	else cout << "Неправильный номер";

}



/*template<typename T> T Create() {
	*index=0;
	return *index;
}
template<typename T> T isEmpty_(int* index) {
	if (*index == 0) return true;
	else return false;
}
template<typename T> T push_(T elem,int n,T stack[],int* index) {
	if (*index == n) return false;
	else {
		
		    stack[*index] = elem;
			*index = *index + 1;	
	}
}
template<typename T> T pop_(T stack[], int *index) {
	if (*index == 0) return false;
	else {
		 stack[*index] = NULL;
		 *index = *index - 1;
	
	}
}
template<typename T> T show_(T stack[],int *index) {
	if (*index == 0) return false;
	int i =*index-1;
	for (i; i >=0; i--) {
		if(stack[i]!=NULL) cout << stack[i]<<" ";
	}
}*/