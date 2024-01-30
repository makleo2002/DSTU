#ifndef ADD_H
#define ADD_H
#define _CRT_SECURE_NO_DEPRECATE
#pragma warning(disable : 4996)
#include <iostream>
#include <math.h>
#include <cmath>
using namespace std;
double f(double x);
double df(double x);
double dixit(double a, double b, double eps);
double Hord(double a, double b, double eps);
double Newton(double x, double& n, double eps);
double g(double x);
double Iter(double x, double b, int n, double eps);
void print_menu();
int get_variant(int count);
#endif