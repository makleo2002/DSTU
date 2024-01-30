package com.company;

class Engine {
    private final String serial_number;
    private final double fuel_rate;
    private final String fuel_type;
    private final int power;
    private final double capacity;
    private final int cylinders_num;
    private final double torque;
    private final int max_speed;

    public Engine(double fuel_rate, String fuel_type, int power, double capacity, int cylinders_num, double torque, int max_speed) {
        this.serial_number="";
        this.fuel_rate = fuel_rate;
        this.fuel_type = fuel_type;
        this.power = power;
        this.capacity = capacity;
        this.cylinders_num = cylinders_num;
        this.torque = torque;
        this.max_speed = max_speed;
    }

    public Engine(String serial_number, double fuel_rate, String fuel_type, int power, double capacity, int cylinders_num, double torque, int max_speed) {
        this.serial_number = serial_number;
        this.fuel_rate = fuel_rate;
        this.fuel_type = fuel_type;
        this.power = power;
        this.capacity = capacity;
        this.cylinders_num = cylinders_num;
        this.torque = torque;
        this.max_speed = max_speed;
    }


    void printInfo(){
        System.out.println("Характеристики двигателя: ");
        System.out.println("Серийный номер: № "+serial_number);
        System.out.println("Расход топлива: "+fuel_rate+" л/100 км");
        System.out.println("Тип топлива: "+fuel_type);
        System.out.println("Мощность: "+power+" л.с.");
        System.out.println("Обьем: "+capacity+" л");
        System.out.println("Количество цилиндров: "+cylinders_num);
        System.out.println("Крутящий момент: "+torque+" Нм");
        System.out.println("Максимальное число оборотов: "+max_speed+" об/мин");
        System.out.println();
    }
}

