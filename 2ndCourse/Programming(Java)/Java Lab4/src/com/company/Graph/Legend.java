package com.company.Graph;
import java.util.ArrayList;
public class Legend {
    private  ArrayList<String> legendlist=new ArrayList<>(10);
    public ArrayList<String> getLegendlist(){
        return legendlist;
    }
    public void AddLegend(Curve curve) {
        legendlist.add(curve.getName()+" "+curve.getColor());
    }
    public void show(){
        for(int i=0;i< legendlist.size();i++){
            System.out.println(legendlist.get(i));
            System.out.println();
        }
    }
}
