package com.company.Graph;

public class Curve {
    private double[] x;
    private double[] y;
    private String name;
    private String color;

    public String getName() {
        return name;
    }

    public String getColor() {
        return color;
    }

    public Curve(double[] x1, double[] y1, String name1, String color1) {
        this.x = x1;
        this.y = y1;
        this.name = name1;
        this.color = color1;
    }

    public void show(int a, int b) {
        for (int i = a; i < b; i++) {
            System.out.println("x: " + x[i] + "   " + "y: " + y[i]);
        }
        System.out.println();
    }
}
