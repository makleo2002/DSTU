package com.company;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


class Circle{
    int compare(double x1,double y1,double r1,double x2,double y2,double r2){
        int cmp=0;
        String info;
        double dist=Math.sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)) ;
        if(x1==x2&&y1==y2&&r1==r2) {
            info="Окружности совпадают";
            cmp=1;
        }
        else {
            if (dist> r1 + r2) {
                info="Окружности не пересекаются \nОкружности не вложенные";
                cmp=2;
            }
            else if (dist == r1 + r2||dist==Math.abs(r1-r2)) {
                info="Окружности пересекаются в одной точке";
                if (dist > Math.abs(r1 - r2)) {
                    info+="\nОкружности не вложенные";
                    cmp = 3;
                }
                else {
                    if (r1 < r2) {
                        info+="\nОкружность 1 вложена во вторую";
                        cmp=4;
                    }
                    if (r1 > r2) {
                        info+="\nОкружность 2 вложена во первую";
                        cmp=5;
                    }
                }
            }
            else {
                info="Окружности пересекаются в двух точках\nОкружности не вложенные";
                cmp=6;
            }

        }
        System.out.println("Взаимоположение окружностей: \n"+info);
        return cmp;
    }
}
class Circle1{
    enum num {
        position,
        coincidence,
        dont_intersect_not_nested,
        one_intersect_not_nested,
        one_intersect_first_nested_in_second,
        one_intersect_second_nested_in_first,
        two_intersects_not_nested
    }
    num compare(double x1,double y1,double r1,double x2,double y2,double r2){
        double dist=Math.sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)) ;
        if(x1==x2&&y1==y2&&r1==r2){
            System.out.println("Взаимоположение окружностей: \n"+num.coincidence);
            return num.coincidence;
        }
        else {
            if (dist > r1 + r2) {
                System.out.println("Взаимоположение окружностей: \n"+num.dont_intersect_not_nested);
                return num.dont_intersect_not_nested;
            }
            else if (dist == r1 + r2||dist==Math.abs(r1-r2)) {
                if (dist > Math.abs(r1 - r2)) {
                    System.out.println("Взаимоположение окружностей: \n"+num.one_intersect_not_nested);
                    return num.one_intersect_not_nested;
                }
                else {
                    if (r1 < r2) {
                        System.out.println("Взаимоположение окружностей: \n"+num.one_intersect_first_nested_in_second);
                        return num.one_intersect_first_nested_in_second;
                    }
                    if (r1 > r2) {
                        System.out.println("Взаимоположение окружностей: \n"+num.one_intersect_second_nested_in_first);
                        return num.one_intersect_second_nested_in_first;
                    }
                }
            }
            else {
                System.out.println("Взаимоположение окружностей: \n"+num.two_intersects_not_nested);
                return num.two_intersects_not_nested ;
            }

        }
        return num.position;
    }
}


public class Main {
    public static double getIntervalLength(double a, double b, int intervalsCount) {
        return (b - a) / intervalsCount;
    }
    public static double rectangle(double[] f,int a,int b){
        int intervalsCount=f.length;
        double h=getIntervalLength(a,b,intervalsCount);
        double Integral=0;
        for(int i=0;i<intervalsCount;i++) {
            Integral+=(f[i]);
        }
        return Integral*h;
    }

    public static void toBase(int value,int base){
        String newnumber="";
        char[] word={'0','1','2','3','4','5','6','7','8','9'};
        int pos;
        while(value>0){
            pos=value%base;
            newnumber+=word[pos%10];
            value=value/base;
        }
        //pos=value%base;
        //   newnumber+=word[pos%10];
        String rev="";
        char[] array=newnumber.toCharArray();
        for(int i=newnumber.length()-1;i>=0;i--){
            rev+=array[i];
        }
        System.out.println(rev);
        System.out.println("Проверка: "+Integer.toString(2048,2));
    }
    public static void polinom(int n,int x){
        Scanner index= new Scanner( System.in );

        int[] a = new int[n+1];
        System.out.println("Введите коээфициенты: ");
        for (int i = 0; i <= n; i++) a[i] = index.nextInt();
        if(n==0) System.out.println(a[0]);
        else {
            int p = a[n] * x + a[n - 1];
            for (int i = n-2; i >= 0; --i) {
                p = p * x + a[i];
            }

            System.out.println(p);
        }
    }
    public static Boolean MobilePhoneFind(String text){

        Pattern p=Pattern.compile("^((\\+7|8)[\\- ]?(\\d{3}|\\(\\d{3}\\))[\\- ]?\\d{3}[\\- ]?\\d{2}[\\- ]?\\d{2})$");
        Matcher matcher = p.matcher(text);
        System.out.println(matcher.matches());
        return matcher.matches();
    }
    public static Boolean CityPhoneFind(String text){
        Pattern p=Pattern.compile("^((2|3)[\\- ]?)?(\\(?\\d{2}\\)?[\\- ]?)?(\\(?\\d{2}\\)?[\\- ]?)(\\(?\\d{2}\\)?[\\- ]?)$");
        Matcher matcher = p.matcher(text);
        System.out.println(matcher.matches());
        return matcher.matches();
    }
    public static void PhoneFindText(String text){
        Pattern p = Pattern.compile("((\\+7|8)[\\- ]?((\\d{3})|(\\(\\d{3}\\)))[\\- ]?\\d{3}[\\- ]?\\d{2}[\\- ]?\\d{2})|((2|3)[\\- ]?)?(\\(?\\d{2}\\)?[\\- ]?)?(\\(?\\d{2}\\)?[\\- ]?)(\\(?\\d{2}\\)?[\\- ]?)");
        Matcher m = p.matcher(text);
        while (m.find()) {
            System.out.println(m.group());
        }
    }

    public static void main(String[] args) {
        /*
        System.out.println("1 задание: ");
        String format = "|%1$-16s|%2$-16s|%3$-10s|\n";
        System.out.format(format, "----------------", "----------------", "----------");
        System.out.format(format, "     Sin(x)", "  e^x/x*lg(x)", "     x");
        System.out.format(format, "----------------", "----------------", "----------");
        for (double x = Math.PI/15; x < Math.PI; x += Math.PI/15) {
            System.out.format("|%15.7e |%15.7e |%10.5f|%n", Math.sin(x), Math.pow(Math.E,x)/(x*Math.log(x)), x);
            System.out.format(format, "----------------", "----------------", "----------");
        }

        System.out.println("2 задание: ");
        int[][] mas2d={
                { 1, 2, -3, 5, 7 },
                { 4, -5, 6 },
                { 1, -2, 9,-7 },
                { 1, 2, -10,-40 }
        };
        int max=Integer.MIN_VALUE;
        for(int k=0;k<mas2d.length;k++){
            for(int m=0;m<mas2d[k].length;m++){
                if(mas2d[k][m]<0&&mas2d[k][m]>max) max=mas2d[k][m];

            }
        }
        if(max==Integer.MIN_VALUE) System.out.println("Отрицательного числа нет");
        else System.out.println(max);
        System.out.println("3 задание: ");
        int tmp,pos,j1,j,i;
        int[][] matrix= {
                { 25, 10, -3 },
                { 1, -5, 6 },
                { 1, -2,-1},
        };
        for(i=0;i<matrix.length;++i){ //проходим по строкам
            for(j1=0;j1<matrix[i].length;++j1){//j1- номер текущего элемента в строке
                pos=j1;//запоминаем номер текущего элемента в строке
                tmp=matrix[i][pos];//запоминаем текущий элемент
                for(j=j1+1;j<3;++j){//находим наименьший элемент в строке
                    if(matrix[i][j]<tmp){
                        pos=j;  //запоминаем номер наим.элемента
                        tmp=matrix[i][j];//запоминаем наим.элемент
                    }
                }
                matrix[i][pos]=matrix[i][j1];//меняем текущий элемент с минимальным
                matrix[i][j1]=tmp; //меняем текущий элемент с минимальным
            }
        }
        for(int k=0;k<matrix.length;k++){//выводим элементы массива
            for(int m=0;m<matrix[k].length;m++){
                System.out.println(matrix[k][m]);
            }
        }

        System.out.println("4 задание: ");
        Scanner num1= new Scanner( System.in );
        int[] mas=new int [6];
        System.out.println("Введите параметры окружностей:");
        for(int i1=0;i1<6;i1++){
            mas[i1]=num1.nextInt();
        }
        Circle c1=new Circle();
        c1.compare(mas[0],mas[1],mas[2],mas[3],mas[4],mas[5]);//-2,2,2,3,2,3
        System.out.println("5 задание: ");
        Circle1 c2=new Circle1();
        c2.compare(mas[0],mas[1],mas[2],mas[3],mas[4],mas[5]);


         */
        System.out.println("6 задание: ");
        Scanner interval=new Scanner(System.in);
        Scanner interval1=new Scanner(System.in);
        System.out.println("Введите интервал: ");
        int a=interval.nextInt(),b=interval1.nextInt(),intervalsCount=b-a+1000;
        double length=getIntervalLength(a,b,intervalsCount);
        double[] f=new double[intervalsCount];
        String format1 = "|%1$-16s|%2$-16s|\n";
        System.out.format(format1, "----------------", "----------------");
        System.out.format(format1, "      y(x)      ", "        x       ");
        System.out.format(format1, "----------------", "----------------");
        double leftX=a;
        for (int k = 0; k < intervalsCount;k++,leftX+=length) {
            System.out.format("|%15.7e |%15f |%n",Math.pow(Math.E, leftX)-leftX*leftX*leftX,leftX);
            System.out.format(format1, "----------------", "----------------");
            f[k] = Math.pow(Math.E, leftX) - leftX * leftX * leftX;
        }
        System.out.println(rectangle(f,a,b));
        double result=Math.pow(Math.E,4)-65;
        System.out.println("Проверка: "+result);
        System.out.println("Разница: "+Math.abs(result-rectangle(f,a,b)));

/*

        System.out.println("7 задание: ");
        toBase(2048,2);

        System.out.println("8 задание: ");
        polinom(1,1);



        System.out.println("9 задание: ");
        String text="+7\\928 906 37 07";
        String text1="220 30 40";
        MobilePhoneFind(text);
        CityPhoneFind(text1);
        System.out.println("10 задание: ");
        String text2 = "Программа для определения номера в строке. Примеры записи номеров, которые находит эта программа: +79043781661, +7 904 378 1661 ,+7 904 378 16 61, +7-904-378-16-61, +7(904)3781661 ,+7(904) 378-16 61, 89043781661 , 8 904 378-16-61, 220 30 40";
        PhoneFindText(text2);



 */
    }
}
