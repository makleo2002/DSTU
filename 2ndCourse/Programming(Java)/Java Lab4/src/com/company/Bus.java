package com.company;

class Bus extends Car {
    private final int space;
    private final String dimensions;
    final int getSpace(){
        return space;
    }
    final String getDimensions(){
        return dimensions;
    }
    public Bus(String brand, String color, Engine engine, int num_of_wheels, int space, String dimensions){
        super(brand, color, engine, num_of_wheels);
        //this.view=view;
        //this.power=power;
        this.space=space;
        this.dimensions=dimensions;

    }
    public Bus(String reg_number, String brand, String color, Engine engine, int num_of_wheels, int space, String dimensions){
        super(brand, color, engine, num_of_wheels);
        //this.view=view;
        //this.power=power;
        setReg_number(reg_number);
        this.space=space;
        this.dimensions=dimensions;

    }
    final void Info(){
        System.out.println("Информация о машине: ");
        //   System.out.println("Вид: "+view);
        System.out.println("Регистрационный номер: "+getReg_number());
        System.out.println("Марка: "+getReg_number());
        //System.out.println("Мощность двигателя: "+power+" л.с.");
        System.out.println("Количество колёс: "+getNum_of_wheels());
        System.out.println("Цвет: "+getColor());
        System.out.println("Количество мест: "+space);
        System.out.println("Размеры: "+dimensions);
        getEngine().printInfo();
        System.out.println();
    }
}