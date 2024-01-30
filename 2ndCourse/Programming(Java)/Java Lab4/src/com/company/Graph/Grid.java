package com.company.Graph;
import java.util.ArrayList;
public class Grid {
    private ArrayList<Double> steps=new ArrayList<>(5);

    public Grid(){
      steps.add(0,2.0);
      steps.add(1,2.0);
    }

    public Grid(Axis Ox ,Axis Oy){
        steps.add(0,Ox.getStep());
        steps.add(1,Oy.getStep());
    }

    public ArrayList<Double> getSteps(){
        return steps;
    }

public void ChangeGrid(double StepX,double StepY){
        steps.set(0,StepX);
        steps.set(1,StepY);
}
    public void show() {
        for(int i=0;i<steps.size();i++){
            System.out.println("Шаг Оси "+i+" равен "+steps.get(i));
        }
        System.out.println();
    }
}
