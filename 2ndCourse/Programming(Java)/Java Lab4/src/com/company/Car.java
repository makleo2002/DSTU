package com.company;

abstract class Car{
    private String reg_number="Отсутствует";
    private final String brand;
    //  private final v view;
    private String color;
    //private int power;
    private Engine engine;
    private final int num_of_wheels;
    public  Car(String brand, String color, Engine engine, int num_of_wheels){ //(v view)
        this.brand=brand;
        // this.view=view;
        this.color=color;
        //this.power=power;
        this.engine=engine;
        this.num_of_wheels=num_of_wheels;
    }
    public Car(String reg_number, String brand, String color, Engine engine, int num_of_wheels){// v view
        this.brand=brand;
        //  this.view=view;
        this.color=color;
        //this.power=power;
        this.engine=engine;
        this.num_of_wheels=num_of_wheels;
        this.reg_number=reg_number;
    }

    final void   setReg_number(String reg_number){
        this.reg_number = reg_number;
    }
    final void   setColor(String color){
        this.color = color;
    }
    final void   setEngine(Engine engine){
        this.engine = engine;
    }
    final String getBrand(){
        return brand;
    }
    final String getReg_number(){
        return reg_number;
    }
    final String getColor(){
        return color;
    }
    final Engine getEngine(){
        return engine;
    }
    final int    getNum_of_wheels(){
        return num_of_wheels;
    }
    final void   ChangeColor(String color){
        this.color=color;
    }
    //void ChangePower(int power){
    //        this.power=power;
    //    }
    void ChangeNumber(String number){
        if (number.matches("^([АБЕКМНОРСТУХABEKMHOPCTYX] )[0-9]{3}[АБЕКМНОРСТУХABEKMHOPCTYX]{2} ([0-9]{2,3}) RUS$"))
            this.reg_number=number;
        else System.out.println("Номер задан неправильно");
    }
    void Info(){
        System.out.println("Информация о машине: ");
        //   System.out.println("Вид: "+view);
        System.out.println("Регистрационный номер: "+reg_number);
        System.out.println("Марка: "+brand);
        //System.out.println("Мощность двигателя: "+power+" л.с.");
        System.out.println("Количество колёс: "+num_of_wheels);
        System.out.println("Цвет: "+color);
        engine.printInfo();
        System.out.println();
    }
}