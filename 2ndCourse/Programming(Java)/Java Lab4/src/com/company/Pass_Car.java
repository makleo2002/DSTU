package com.company;

import com.company.Car;
import com.company.Engine;

class Pass_Car extends Car {
    private String model;
    private String type;
    private String transmission;
    final String getModel(){
        return model;
    }
    final String getType(){
        return type;
    }
    final String getTrans(){return transmission;}
    public Pass_Car(String brand, String color, Engine engine, int num_of_wheels, String model, String type, String transmission){
        super(brand, color, engine, num_of_wheels);
        //this.view=view;
        //this.power=power;
        this.model=model;
        setColor(color);
        setEngine(engine);
        this.type=type;
        this.transmission=transmission;

    }

    public Pass_Car(String reg_number,String brand, String color, Engine engine, int num_of_wheels,String model,String type,String transmission) {
        super(brand, color, engine, num_of_wheels);
        //this.view=view;
        //this.power=power;
        setReg_number(reg_number);
        setColor(color);
        setEngine(engine);
        this.model=model;
        this.type=type;
        this.transmission=transmission;

    }
    void Info(){
        System.out.println("Информация о машине: ");
        //   System.out.println("Вид: "+view);
        System.out.println("Регистрационный номер: "+getReg_number());
        System.out.println("Марка: "+getBrand());
        //System.out.println("Мощность двигателя: "+power+" л.с.");
        System.out.println("Количество колёс: "+getNum_of_wheels());
        System.out.println("Цвет: "+getColor());
        System.out.println("Тип: "+type);
        System.out.println("Коробка передач: "+transmission);
        getEngine().printInfo();
        System.out.println();
    }
}