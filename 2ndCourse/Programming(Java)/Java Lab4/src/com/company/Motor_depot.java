package com.company;

import com.company.Car;

import java.util.ArrayList;

class Motor_depot{

    int k;
    int j = 0;
    void Free_Places(){
        System.out.println("Свободных мест осталость: " + (k-j));
    }

    ArrayList<Car> mas = new ArrayList<>();
    ArrayList<String> status = new ArrayList<>();
    ArrayList<Integer> Space = new ArrayList<>();

    public Motor_depot(int i){
        this.k = i;
        for(i = 0; i<k;i++){
            mas.add(i,null);
            status.add(i,"");
            Space.add(i,1);
        }
    }

    void addCar(Pass_Car s){
        if (k == j){
            System.out.println("Место закончилось");
        }
        else{
            for (int i = 0; i < k; i++){
                if (Space.get(i) != 0){
                    mas.set(i,s);
                    status.set(i,"Свободен");
                    Space.set(i,0);
                    j += 1;
                    System.out.println(mas.get(i).getBrand() + "_" +s.getModel()+" "+(i+1)+" Добавлена");
                    break;
                }
            }
        }
    }
    void deleteCar(int i){
        i -= 1;
        mas.set(i,null);
        status.set(i,"Списан");
        j -= 1;
        Space.set(i,i+1);
    }
    void For_Flight(int i){
        i -= 1;
        if (status.get(i) == "Свободен")
            status.set(i,"В рейсе");
    }
    void Vozvrashenie(int i){
        i -= 1;
        status.set(i,"Свободен");
    }
    void For_Repairs(int i){
        i -= 1;
        if(status.get(i)=="Списан")
            status.set(i,"На ремонте");
    }

    void print_Motor_depotAll(){
        System.out.println("\nСвободные машины: ");
        for (int i = 0; i<k;i++){
            if (mas.get(i) != null){
                if (status.get(i) == "Свободен"){
                    System.out.println(mas.get(i).getBrand() + " " + (i+1));
                }
            }
        }
        System.out.println("\nМашины в ремонте: ");
        for (int i = 0; i<k;i++){
            if (mas.get(i) != null){
                if (status.get(i) == "На ремонте"){
                    System.out.println(mas.get(i).getBrand() + " " + (i+1));
                }
            }
        }
        System.out.println("\nМашины в рейсе: ");
        for (int i = 0; i<k;i++){
            if (mas.get(i) != null){
                if (status.get(i) == "В рейсе"){
                    System.out.println(mas.get(i).getBrand() + " " + (i+1));
                }
            }
        }
    }
}