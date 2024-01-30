#include <iostream>

using namespace std;


struct Tree {
    int value;
    Tree* left;
    Tree* right;
};

Tree* Add(Tree*& a, int elem) {
    if (!a) {
        a = new Tree;
        a->value = elem;
        a->left = nullptr;
        a->right = nullptr;
        return 0;
    }
    else if (elem < a->value) {
        Add(a->left, elem);
    }
    else {
        Add(a->right, elem);
    }
    return a;
}

Tree* FindParent(Tree*& start, int x, Tree* parent = nullptr) {

    if (start == nullptr)
        return NULL;
    if (start->value == x)
        return parent;
    else {
        if (x < start->value)  return FindParent(start->left, x, parent);
        else return FindParent(start->right, x, parent);
    }
}

Tree*& Delete(Tree*& tree, int value) {
    if (tree == NULL)
        return tree;

    if (value == tree->value) {

        Tree* tmp;
        if (tree->right == NULL)
            tmp = tree->left;
        else {

            Tree* ptr = tree->right;
            if (ptr->left == NULL) {
                ptr->left = tree->left;
                tmp = ptr;
            }
            else {

                Tree* pmin = ptr->left;
                while (pmin->left != NULL) {
                    ptr = pmin;
                    pmin = ptr->left;
                }
                ptr->left = pmin->right;
                pmin->left = tree->left;
                pmin->right = tree->right;
                tmp = pmin;
            }
        }
       Tree* parent= FindParent(tree, value);
        delete tree;
        return tmp;
    }
    else if (value < tree->value)
        tree->left = Delete(tree->left, value);
    else
        tree->right = Delete(tree->right, value);
    return tree;
}
void printTree(Tree*& a) {
    if (a) {
        cout << a->value << " ";
        printTree(a->left);
        printTree(a->right);

    }
    else return;
}

bool findTree(Tree* a, int value) {
    int cmp = 0;
    while (a && value != a->value) {
        if (value < a->value) a = a->left;
        else a = a->right;
        cmp++;
    }
    cout << "Количество сравнений: " << cmp << endl;
    return a != NULL;
}



/* Tree* b=new Tree;
    b->value = x;
    int cmp = 0;
    Tree* parent = nullptr;
    Barrier(a,b);
    while (x != b->value) {
        if (x < a->value) a = a->left;
        else a = a->right;
        cmp++;
    }
    if (&a == &b) return false;
    cout << "Количество сравнений: " << cmp << endl;
    return a != NULL;*/
int main()
{
    setlocale(LC_ALL, "Russian");
    int x;
    int n;
    cout << "Введите количество элементов: " << endl;
    cin >> n;
    Tree* tree = NULL;
    cout << "Введите элементы дерева: " << endl;
    for (int i = 0; i < n; i++) {
        cin >> x;
        Add(tree, x);
    }
    cout << "Элементы дерева: " << endl;
    printTree(tree);
    cout << endl;
    cout << findTree(tree, 5) << endl << endl;
    cout << endl;
    Delete(tree, 3);
    printTree(tree);
}


















/*Tree*& addBarrier(Tree*& start, int stop) {
    return start;
}
Tree*& findBTree(Tree*& start, int value, int stop) {
    int cmp = 0;
    if (start->value == stop)
        return start;
    if (start->value == value)
        return start;
    else {
        if (value < start->value)
            start = findBTree(start->left, value, stop);
        else start = findBTree(start->right, value, stop);
    }
}*/