package com.company;

import java.util.ArrayList;

class Pair<T,M>{
   private T max;
   private M index;
    final T getMax(){
        return max;
    }
    final M getIndex(){
        return index;
    }
   final void setMax(T m){
        this.max=m;
    }
   final void setIndex(M i){
        this.index=i;
    }
    public static <T,M>  void make_pair(T max,M index){
        System.out.println("Пара значений:");
        System.out.println(max+ " "+index);
    }
    Pair(T max,M index){
      this.max=max;
      this.index=index;
    }
    void show(){
        System.out.println(max);
        System.out.println(index);
    }

}
class Bag{
   static class objects<T>{
        T num;
        objects(){}
        objects(T n){
            this.num=n;
        }
    }
    ArrayList<objects> mas=new ArrayList<>();

    Bag(int n){
        for(int i = 0; i<n;i++){
            mas.add(i,null);
        }
    }
    <T> void add (T num) {
        int count=0;
        boolean flag = false;
        objects<T> obj1 = new objects<>(num);
        while (!flag) {
            int R = (int) Math.round(Math.random() * (mas.size() - 1));
            for (int k = 0; k < mas.size(); k++) {
                if (mas.get(k) == null && R == k) {
                    mas.set(R, obj1);
                    System.out.println("Предмет "+mas.get(k).num+" добавлен в мешок");
                    flag=true;
                    break;
                }
                else count++;
            }
            if(mas.size()-1==count){
                System.out.println("Мешок полон");
                break;
            }
        }
    }
    objects del(){
        boolean flag = false;
        objects tmp=new objects();
        if(mas.size()==0) return tmp;
        while (!flag) {
            int R = (int) Math.round(Math.random() * (mas.size() - 1));
            for (int k = 0; k < mas.size(); k++) {
                if (mas.get(k) != null && R == k) {
                    tmp=mas.get(k);
                    System.out.println("Предмет "+mas.get(k).num+" удален");
                    mas.remove(k);
                    flag=true;
                    break;
                }
            }
        }
        return tmp;
    }
    final Object retElem(int i){
    return mas.get(i).num;
    }
   final int retSize(){
       return mas.size();
    }
    void show(){
     for(int i=0;i<mas.size();i++){
         if(mas.get(i)!=null) System.out.print(mas.get(i).num  +" ");
         else System.out.print(mas.get(i)+" ");
     }
        System.out.println();
    }
}

public class Lab5 {
    public static void main(String[] args){
        com.company.Pair.make_pair(5,"s");
        Bag bag=new Bag(5);
        bag.add(5);
        bag.add(1);
        bag.add(52);
        bag.add(-6);
        bag.add(3);
        bag.add(4);
        System.out.println(bag.retSize());
        System.out.println(bag.retElem(1));
        bag.show();
        bag.del();
        bag.show();
        bag.del();
        bag.show();
        bag.del();
        bag.show();
    }
}
