package com.company.Graph;

public class Axis {
    private double a;
    private double b;
    private double step;

    public double getA() {
        return a;
    }

    public double getB() {
        return b;
    }

    public double getStep() {
        return step;
    }


    public Axis(double start, double end, double mystep) {
        this.a = start;
        this.b = end;
        this.step = mystep;
    }

    public void ChangeAxis(double start, double end, double mystep) {
        this.a = start;
        this.b = end;
        this.step = mystep;
    }

    public void show() {
        System.out.println("Начало оси: " + a);
        System.out.println("Конец оси: " + b);
        System.out.println("Шаг оси: " + step);
        System.out.println();
    }
}
