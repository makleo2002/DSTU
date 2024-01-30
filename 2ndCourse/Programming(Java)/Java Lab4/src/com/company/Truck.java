package com.company;

import com.company.Car;
import com.company.Engine;

class Truck extends Car {
    private int weight;
    private int lifting_capacity;
    private int cabin;
    String dimensions;
    final int getWeight(){
        return weight;
    }
    final int getLifting_capacity(){return lifting_capacity;}
    final int getCabin(){return cabin;}
    final String getDimensions(){
        return dimensions;
    }
    public Truck(String brand, String color, Engine engine, int num_of_wheels, int weight, int lifting_capacity, int cabin, String dimensions) {
        super(brand, color, engine, num_of_wheels);
        //this.view=view;
        //this.power=power;
        this.lifting_capacity = lifting_capacity;
        this.weight = weight;
        this.cabin = cabin;
        this.dimensions = dimensions;
    }
    public Truck(String reg_number,String brand, String color, Engine engine, int num_of_wheels, int weight, int lifting_capacity, int cabin, String dimensions) {
        super(brand, color, engine, num_of_wheels);
        //this.view=view;
        //this.power=power;
        setReg_number(reg_number);
        this.lifting_capacity = lifting_capacity;
        this.weight = weight;
        this.cabin = cabin;
        this.dimensions = dimensions;
    }
    void Info(){
        System.out.println("Информация о машине: ");
        //   System.out.println("Вид: "+view);
        System.out.println("Регистрационный номер: "+getReg_number());
        System.out.println("Марка: "+getReg_number());
        //System.out.println("Мощность двигателя: "+power+" л.с.");
        System.out.println("Количество колёс: "+getNum_of_wheels());
        System.out.println("Цвет: "+getColor());
        System.out.println("Грузподъемность: "+lifting_capacity);
        System.out.println("Вес: "+weight);
        System.out.println("Мест в кабине: "+cabin);
        System.out.println("Размеры: "+dimensions);
        getEngine().printInfo();
        System.out.println();
    }
}