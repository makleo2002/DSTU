package com.company;

import java.util.Scanner;
import java.util.Arrays;
import java.util.regex.*;


class task4 {
    enum condition {intersect, not_intersect, touch, two_in_one, one_in_two, match}

    Scanner data= new Scanner( System.in );

    int x1= data.nextInt();
    int y1=data.nextInt();
    int r1=data.nextInt();

    int x2=data.nextInt();
    int y2=data.nextInt();
    int r2=data.nextInt();


    void check_circle(){
        System.out.println("x1:"+x1+"  y1:"+y1+"  r1:"+r1);
        System.out.println("x2:"+x2+"  y2:"+y2+"  r2:"+r2);
        double d = Math.sqrt(Math.pow(x1-x2,2.)+Math.pow(y1-y2,2.));
        System.out.println("distance between r1 and r2 ="+d);
        if(d>0)
            if(r1+r2<d) System.out.print("не пересекаются");
            else if (r1+r2>d) System.out.print("пересекаются");
            else System.out.print("соприкасаются");
        else if (r1>2) System.out.print("2-ая оркужность вложена в 1-ую");
        else if (r1<r2) System.out.print("1-ая оркужность вложена в 2-ую");
        else System.out.print("совпадают");
    }
    condition check_circle2(){
        System.out.println("x1:"+x1+"  y1:"+y1+"  r1:"+r1);
        System.out.println("x2:"+x2+"  y2:"+y2+"  r2:"+r2);
        double d = Math.sqrt(Math.pow(x1-x2,2.)+Math.pow(y1-y2,2.));
        System.out.println("distance between r1 and r2 ="+d);
        if(d>0)
            if(r1+r2<d) return (condition.not_intersect);
            else if (r1+r2>d) return (condition.intersect);
            else return (condition.touch);
        else if (r1>2) return (condition.two_in_one);
        else if (r1<r2) return (condition.one_in_two);
        else return (condition.match);

    }
}



public class Main {

    public static void task1() {
        double x = Math.PI/15;
        System.out.printf("%5s"," x");
        System.out.printf("%15s"," sin(x)");
        System.out.printf("%16s","e^x/(x*lg(x))");
        System.out.println();
        while(x<=Math.PI){ /*Для столбца со значениями
            аргумента нужно использовать представление с фиксированной точкой,
                    ширина столбца - 10 позиций, точность - 5 знаков после запятой. Для
            столбца со значениями функции: экспоненциальное представление,
            ширина 15 позиций, точность 7 знаков. */
            System.out.printf("%10.5f",x);
            System.out.printf("%10.5f",Math.sin(x));
            System.out.printf("%15.7e",Math.exp(x)/(x*Math.log(x)));
            System.out.println();
            x+=Math.PI/15;
        }
    }
    public static void task2(){ //изменить
        int[][] array = {
                { 5, 2, 3, 5, 7 }, // 0-я строка
                { 4, -5, 6 }, // 1-я строка
                { 1, 8, 9 }, // 2-я строка
                { 1, 2, 3 } // 3-я строка
        };
        int m_neg=array[0][0];
        int i = 0;
        while (i<array.length) {

            Arrays.sort(array[i]);
            if (m_neg>array[i][0]) m_neg=array[i][0];
            i++;
        }
        System.out.println("Most_negative = " + m_neg);

    }
    public static void out_f(int[][] array){
        for (int i =0;i<3;i++){
            for (int j =0;j<3;j++)
                System.out.print(array[i][j]+"\t");
            System.out.println();
        }
    }
    public static void task3(){
        int i = 0;
        int[][] array = {
                { 5, 2, 3 }, // 0-я строка
                { 4, -5, 6 }, // 1-я строка
                { 1, 8, 9 }, // 2-я строка
        };
        out_f(array);
        while (i<array.length) {
            Arrays.sort(array[i]);
            i++;
        }
        System.out.println();
        out_f(array);
    }
    public static double  InFunction(double x) { //Подынтегральная функция
        return (Math.exp(x)-Math.pow(x,3.));
    }
    public static double task6_1(){

        Scanner data1= new Scanner( System.in );
        Scanner data2= new Scanner( System.in );

        double a = data1.nextDouble();
        double b = data2.nextDouble();
        double result = 0, h = (b - a) / 100.;

        for(int i = 0; i < 100; i++) {
            result += InFunction(a + h * (i + 0.5));
        }

        result *= h;
        return result;


    }
    public static double task6_2(){
        Scanner data1= new Scanner( System.in );
        Scanner data2= new Scanner( System.in );

        double a = data1.nextDouble();
        double b = data2.nextDouble();

        double sum = 0;
        double h = (b-a)/101;
        double x = a;
        double[]arg= new double[101];
        double[]value= new double[101]; //f(x)

        for(int i=0;i<=100;i++){
            sum+=h*InFunction(x);
            value[i]=InFunction(x);
            arg[i]=x;
            x+=h;
        }
        for(double i:value) System.out.printf("%10.5f",i);
        System.out.println();
        for(double i:arg)System.out.printf("%10.5f",i);
        System.out.println();
        return sum;
    }
    public static void task7(int val, int k ){
        int res = 0, i = 1, val1 = val;
        val = Math.abs(val);
        while(val > k){
            res += (val % k) * i;
            val /= k;
            i *= 10;
        }
        res += (val % k) * i;

        if(val1 < 0)
            System.out.println("Ответ программы: " + -1 * res);
        else
            System.out.println("Ответ программы: " + res);

        System.out.println("Проверка: " + Integer.toString(val1, k));
    }
    public static void task8(int n, int x){
        Scanner data1= new Scanner( System.in );
        n++;
        int[] array = new int[n];
        for (int i=n-1;i>=0;i--) array[i]= data1.nextInt();
        for (int i: array) System.out.println(i);
        n--;
        int P=array[n]*x+array[n-1];
        //System.out.println(P);
        for (int i=n-2;i>=0;i--) P=P*x+array[i];
        System.out.println(P);
    }
    public static void task9(String number){
        //System.out.println(number.matches("^(8|\\+7)[\\- ]?\\(?\\d{3}\\)?[\\- ]?\\d{3}[\\- ]?\\d{2}[\\- ]?\\d{2}$"));
        System.out.println(number.matches("^(8|\\+7)[\\- ]?\\(?\\d{3}\\)?[\\- ]?[2,3]\\d{2}[\\- ]?\\d{2}[\\- ]?\\d{2}$"));
        System.out.println(number.matches("^[2,3][\\- ]?\\d{2}[\\- ]?\\d{2}[\\- ]?\\d{2}$"));
    }
    public static void task10(String number){
        Pattern p = Pattern.compile("([2,3][\\- ]?\\d{2}[\\- ]?\\d{2}[\\- ]?\\d{2})|(8|\\+7)[\\- ]?\\(?\\d{3}\\)?[\\- ]?[2,3]\\d{2}[\\- ]?\\d{2}[\\- ]?\\d{2}");
        Matcher m = p.matcher(number);
        while(m.find()) {
            int begin = m.start();
            int end = m.end();
            System.out.println(number.substring(begin, end));
        }

    }


    public static void main(String[] args) {

        //task1();
        //System.out.println();
        task2();
        //System.out.println();
        //task3();
        //System.out.println();
        //task4 f = new task4(); System.out.println(f.check_circle2());//f.check_circle();
        //System.out.println(task6_1());
        //System.out.println(task6_2());
         //task7(10,8);
        //task8(4,2); //5x^4+5x^3+x^2-11 x=2
        //task9("220-30-40");
       // task10("Мои номера 220-30-40 и 8904-378-16-61 не считая служебных");

        System.out.println();
    }
}
