package com.company;

import com.company.Graph.Graph;
import com.company.Graph.Curve;
import com.company.Graph.Axis;
import com.company.Graph.Grid;
import com.company.Graph.Legend;

public class Main {
    public static void main(String[] args){

        // Car Land_Cruiser = new Car ("Toyota",v.car,"White",300,4);
        Engine engine=new Engine("12345920",10.1,"Бензин",415,3.3,6,650,5200);
        engine.printInfo();
        Pass_Car Land_Cruiser = new Pass_Car("Toyota","Белый",engine,4,"Land_Cruiser","Внедорожник","Автоматическая");
        Land_Cruiser.Info();

        Land_Cruiser.ChangeNumber("X156YH76RUS");
        Land_Cruiser.ChangeColor("Зеленый");
        // Land_Cruiser.ChangePower(350);
        Land_Cruiser.Info();
        Pass_Car BMW_X5 = new Pass_Car ("BMW","Черный",engine,4,"X5","Внедорожник","Автоматическая");
        Pass_Car Mercedes_C200 = new Pass_Car ("Mercedes","Белый",engine,4,"C200","Седан","Автоматическая");
        Pass_Car Audi_A5 = new Pass_Car ("Audi","Белый",engine,4,"A5","Автоматическая","Хетчбэк");
        Pass_Car Kia_Rio = new Pass_Car ("Kia","Белый",engine,4,"Rio","Автоматическая","Седан");
        Pass_Car Lexus_rx507 = new Pass_Car ("Lexus","Черный",engine,4,"RX507","Автоматическая","Внедорожник");
        Pass_Car Nissan_X_trail = new Pass_Car ("Nissan ","Красный",engine,4,"X_trail","Автоматическая","Внедорожник");
        //String reg_number,String brand, String color, Engine engine, int num_of_wheels,String type,String transmission,int max_speed
        System.out.println("Задание 2");
        Complex z1 = new Complex(10,3);
        Complex z2 = new Complex(7,2);
        z1.Real();
        z1.Imaginary();
        z2.Real();
        z2.Imaginary();
        z1.AlgForm();
        z1.TrigForm();
        System.out.println(Complex.Compare(z1,z2));
        Complex.Sum(z1,z2);
        Complex.Diff(z1,z2);
        Complex.Mult(z1,z2);
        Complex.Div(z1,z2);
        System.out.println("Задание 3");
        Complex.exp(z1).AlgForm();
        Complex.sin(z1).AlgForm();
        Complex.cos(z1).AlgForm();
        Complex.tan(z1).AlgForm();
        Complex.atan(z1).AlgForm();
        Complex.sh(z1).AlgForm();
        Complex.ch(z1).AlgForm();
        Complex.ch(z1).AlgForm();
        Complex.cth(z1).AlgForm();
        System.out.println("Задание 7");
        Motor_depot Test = new Motor_depot(6);
        Test.addCar(Land_Cruiser);
        Test.addCar(BMW_X5);
        Test.addCar(Mercedes_C200);
        Test.addCar(Audi_A5);
        Test.addCar(Kia_Rio);
        Test.addCar(Lexus_rx507);
        Test.print_Motor_depotAll();
        Test.Free_Places();
        Test.For_Flight(1);
        Test.For_Flight(2);
        Test.Vozvrashenie(1);
        Test.For_Repairs(3);
        Test.For_Repairs(4);
        Test.Vozvrashenie(1);
        Test.deleteCar(1);
        Test.addCar(Nissan_X_trail);
        Test.addCar(Land_Cruiser);
        Test.print_Motor_depotAll();
        Test.Free_Places();



        double[] x={0,1,2,3,4,5,6,7,8,9};
        double[] y={11,2,-6,3,4,45,16,-9,1,0};
        Graph graph=new Graph();
        graph.addCurve(x,y,"Fun1","Red");
        graph.Draw(0,5);



    }
}
