package com.company;

import com.company.Car;
import com.company.Engine;

class FireTruck extends Car {
    private int weight;
    private int space;
    private  String passability;
    final int getWeight(){
        return weight;
    }
    final int getSpace(){
        return space;
    }
    final String getPassability(){
        return passability;
    }
    public FireTruck(String brand, String color, Engine engine, int num_of_wheels, int weight, int space, String Passability){
        super(brand, color, engine, num_of_wheels);
        //this.view=view;
        //this.power=power;
        this.weight=weight;
        this.space=space;
        this.passability=passability;
        setColor("Red");
    }
    public FireTruck(String reg_number,String brand, String color, Engine engine, int num_of_wheels,int weight,int space,String Passability){
        super(brand, color, engine, num_of_wheels);
        //this.view=view;
        //this.power=power;
        setReg_number(reg_number);
        this.weight=weight;
        this.space=space;
        this.passability=passability;
        setColor("Red");
    }
    void Info(){
        System.out.println("Информация о машине: ");
        //   System.out.println("Вид: "+view);
        System.out.println("Регистрационный номер: "+getReg_number());
        System.out.println("Марка: "+getReg_number());
        //System.out.println("Мощность двигателя: "+power+" л.с.");
        System.out.println("Количество колёс: "+getNum_of_wheels());
        System.out.println("Цвет: "+getColor());
        System.out.println("Вес: "+weight);
        System.out.println("Количество мест: "+space);
        System.out.println("Проходимость: "+passability);
        getEngine().printInfo();
        System.out.println();
    }
    @Override void ChangeNumber(String number){
        if (number.matches("^([АБЕКМНОРСТУХABEKMHOPCTYX]{2}[\\s]?)[0-9]{4}[\\s]?[5]{2}[A-Z]{3}$"))
            this.setReg_number(number);
        else System.out.println("Номер задан неправильно");
    }
}
