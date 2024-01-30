package com.company.Graph;
import java.util.ArrayList;
 public class Graph {
    private  int width = 640;
    private  int height = 480;
    private final ArrayList<Axis> axis=new ArrayList<>(5);
    private final Grid grid;
    private final ArrayList<Curve> curves=new ArrayList<>(10);
    private Legend legend=new Legend();

   public ArrayList<Axis> getAxis(){return axis;}
   public Grid getGrid(){return grid;}
   public ArrayList<Curve> getCurves(){return curves;}
   Legend getLegend(){return legend;}

    public Graph(){
        Axis Ox=new Axis(0,10,1);
        axis.add(Ox);
        Axis Oy=new Axis(0,10,1);
        axis.add(Oy);
        grid=new Grid(axis.get(0),axis.get(1));
    }
    public void Draw(int a, int b){
        for(int i=0;i<axis.size();i++){
            axis.get(i).show();
        }
        grid.show();
        for(int i=0;i<curves.size();i++){
        curves.get(i).show(a,b);
        }
        legend.show();
    }
    public void addCurve(double [] x,double[] y,String name,String color){
        Curve newCurve=new Curve(x,y,name,color);
        this.curves.add(newCurve);
        Legend legend1=new Legend();
        legend1.AddLegend(newCurve);
        legend=legend1;
    }
     public void changeCurve(int number,double [] x,double[] y,String name,String color){
         Curve newCurve=new Curve(x,y,name,color);
         this.curves.set(number,newCurve);
         Legend legend1=new Legend();
         legend1.AddLegend(newCurve);
     }
     public void delCurve(int number){
        curves.remove(number);
        legend.getLegendlist().remove(number);
     }
     public void addAxis(int a,int b,int step){
         Axis newAxis=new Axis(a,b,step);
         axis.add(newAxis);
     }
     public void changeAxis(int number,int a,int b,double step) {
        Axis cAxis=new Axis(a,b,step);
        axis.set(number,cAxis);
     }

     public void delAxis(int number){
         axis.remove(number);
     }
     public void changeStep(double StepX,double StepY){
        this.grid.ChangeGrid(StepX,StepY);
    }

}
