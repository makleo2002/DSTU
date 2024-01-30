package com.company;

class Table{

    public void unitable(int num,int columns,int strings){
        int num1=num;
        int num0=0000;
        System.out.print("     ");
        for(int ct=0;ct<strings;ct++) {
            Integer.toHexString(num0);
            System.out.print(Integer.toHexString(num0));
            num0+=0x0001;
            System.out.print(" ");
        }
        System.out.println(" ");
        for (int s=0; s <columns; s++) {
            System.out.print(" ");
            System.out.printf("" + Integer.toHexString(num));
            System.out.print(" ");
            num += 0x10;
            for (int st=0;st<strings;st++) {
                Integer.toHexString(num1);
                System.out.print(Character.toChars(num1));
                num1 += 0001;
                System.out.print(" ");
            }
            System.out.println("");
        }

    }
}
public class Lab2 {

    public static void main(String[] args) {
        System.out.println("1 задание: ");
        String format = "|%1$-10s|%2$-22s|%3$-22s|\n";
        System.out.format(format, "----------", "----------------------", "----------------------");
        System.out.format(format, "Type", "MinValue", "MaxValue");
        System.out.format(format, "----------", "----------------------", "----------------------");
        System.out.format(format, "Byte", Byte.MIN_VALUE, Byte.MAX_VALUE);
        System.out.format(format, "Short", Short.MIN_VALUE, Short.MAX_VALUE);
        System.out.format(format, "Integer", Integer.MIN_VALUE, Integer.MAX_VALUE);
        System.out.format(format, "Long", Long.MIN_VALUE, Long.MAX_VALUE);
        System.out.format(format, "Float", Float.MIN_VALUE, Float.MAX_VALUE);
        System.out.format(format, "Double", Double.MIN_VALUE, Double.MAX_VALUE);
        String ex[] = {"----------", "----------------------", "----------------------"};
        System.out.format(String.format(format, (Object[]) ex));
        System.out.println("2 задание: ");
        int[] mas = {1, 7, 8, 3, -3, 5, -4, 0, 1, -1, -2, 9, 3, 1, -5, 7, 9, 1, 7, 2};
        double sg = 1;
        int n = 0;
        for (int m = 0; m < mas.length; m++) {
            if (mas[m] < 0) {
                sg *= mas[m];
                n += 1;
            }
        }
        System.out.println(sg);
        if (n==0) System.out.println("Отрицательных элементов нет");
        else if(n%2==0) System.out.println(Math.pow(sg,1.0/n));
        else System.out.println(Math.pow(Math.abs(sg),1.0/n));
        System.out.println("3 задание: ");
        double R = 10, r = 5, x = 4, y = 4;
        double cd = Math.sqrt(x*x+y*y);
        if (cd > R) System.out.println("Не обнаружен");
        else if (cd > r) System.out.println("Обнаружен");
        else  System.out.println("Тревога");
        System.out.println("4 задание: ");
        double R1=0,r1=0,x1=0,y1=0;

            R1 = Double.parseDouble(args[0]);
            r1 = Double.parseDouble(args[1]);
            x1 = Double.parseDouble(args[2]);
            y1 = Double.parseDouble(args[3]);

        double cd1 = Math.sqrt(x1*x1+y1*y1);
        if (cd1 > R1) System.out.println("Не обнаружен");
        else if ( cd1 > r1) System.out.println("Обнаружен");
        else System.out.println("Тревога");
        System.out.println("5 задание: ");
        int num=Integer.parseInt(args[4]);
        System.out.printf("Число в десятичной системе - " + num);
        System.out.println("");
        System.out.printf("Число в шестнадцатеричной системе - " + Integer.toHexString(num));
        System.out.println("");
        System.out.printf("Число в восьмеричной системе - " + Integer.toOctalString(num));
        System.out.println("");
        System.out.printf("Число в двоичной системе - " + Integer.toBinaryString(num));
        System.out.println(" ");
        System.out.printf("Число в троичной системе - " + Integer.toString(num,3));
        System.out.println(" ");

        System.out.println("6 задание: ");
        Table table=new Table();
        table.unitable(0x0400,16,16);
        System.out.println("");
        table.unitable(0x20a0,2,16);
        System.out.println("7 задание: ");
        String str1 = "Ld56123/%6*^,ажцйjfk1234";
        int count = 0, numbers = 0, letters = 0, other = 0, uppercase = 0, lowercase = 0, arabic_numbers = 0, not_arabic_numbers = 0;
        char[] arrayChars = str1.toCharArray();
        for (int p = 0; p < arrayChars.length; p++) {
            count += 1;
            if(Character.isDigit(arrayChars[p])==true){
                numbers+=1;
                if (arrayChars[p] >= '\u0030' && arrayChars[p] <= '\u0039') {

                    arabic_numbers += 1;
                }
                if (arrayChars[p] >= '\u2160' && arrayChars[p] <= '\u216F') {

                    not_arabic_numbers += 1;
                }
            }

            if(Character.isLetter(arrayChars[p])==true){
                if (Character.isUpperCase(arrayChars[p])==true) {
                    uppercase += 1;
                }
                if (Character.isLowerCase(arrayChars[p])==true) {
                    lowercase += 1;
                }
                letters+=1;
            }


            else if(Character.isLetterOrDigit(arrayChars[p])==false) {
                other+=1;}

        }
        System.out.println("Количество букв: " + letters);
        System.out.println("Количество строчных букв: " + lowercase);
        System.out.println("Количество прописных букв: " + uppercase);
        System.out.println("Количество цифр: " + numbers);
        System.out.println("Количество арабских цифр: " + arabic_numbers);
        System.out.println("Количество не арабских цифр: " + not_arabic_numbers);
        System.out.println("Количество других символов: " + other);
        System.out.println("Количество всех символов: " + count);
        System.out.println("8 и 9 задание: ");
        String text = "London is the capital of London Great Britain London";
        String substr = "London";
        int Indsub;
        int CurInd = 0;
        int counter = 0;
        while ((Indsub = text.indexOf(substr, CurInd)) != -1) {
            counter++;
            CurInd = Indsub + substr.length();
        }
        System.out.println("Количество вхождений подстроки в строку: " + counter);
        System.out.println("10 задание: ");
        System.out.println("Все циклические перестановки строки: ");
        String str_ = "abcd";
        String str_1="";
        for(int n1=0;n1<str_.length();n1++) {
            String result = str_.substring(n1) + str_.substring(0, n1);
            System.out.println(result);
        }
        System.out.println();
        char[] array = str_.toCharArray();
     /*   for(int i=0;i<str_.length();i++) {
            str_1+=array[i];
            for(int j=i+1;j<str_.length();j++) {
              str_1+=array[j];
            }
            for(int k=0;k<i;k++){
                str_1+=array[k];
            }
            System.out.println(str_1);
            str_1="";
        }
        */
        for(int i=0;i<str_.length();i++) {
            System.out.print(array[i]);
            for(int j=i+1;j<str_.length();j++) {
                System.out.print(array[j]);
            }
            for(int k=0;k<i;k++){
                System.out.print(array[k]);
            }
            System.out.println();
        }
    }
}
