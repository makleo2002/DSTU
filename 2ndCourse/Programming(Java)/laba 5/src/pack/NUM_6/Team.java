package pack.NUM_6;

import pack.NUM_2.Bag;
import pack.NUM_5.GenericPairBag;
import pack.Num_1.Pair;

import java.util.Scanner;

class NUM_6 {
    public static void main(String[] args) {
        Team team = new Team(4);
        team.RES();
    }
}

public class Team {
    private Bag bag;
    private GenericPairBag<String, String> genericPairBag;
    private int amount;
    private int round;

    public Team(int n) {

//        double N = Math.log(n)/Math.log(2);
//        if(N % 1 != 0) {
        if((n & (n - 1)) != 0) {
            System.out.println("Введено недопустимое значение. Установленно значение по умолчанию - 8\n");
            bag = new Bag(8);
        }
        else
            bag = new Bag(n);
        genericPairBag = new GenericPairBag<>();
        amount = bag.getLength();
        round = 1;
    }

    public void RES() {
        this.SET();
        while (bag.getAmount() != 1) {
            this.GET();
            this.event();
//            this.event2(); // ручной ввод
        }

        System.out.println("Победитель: " + bag.delete().toString());
    }

    private void SET() {
        if(bag.isEmpty())
            for (int i = 0; i < amount; i++)
                bag.add("'Команда " + (i + 1) + "'");

    }

    private void GET() {
        while (!bag.isEmpty()) {
            String str1 = (String) bag.delete();
            String str2 = (String) bag.delete();
            genericPairBag.add(str1, str2);
        }
    }

    private void event() {
        System.out.println("------------------------------------------------");
        if (genericPairBag.getSize() == 1)
            System.out.println("Финал");
        else
            System.out.println("Раунд " + round);

        while (!genericPairBag.isEmpty()) {
            Pair cur = genericPairBag.delete();

            System.out.println("Битва между " + cur.getFirst() + " и " + cur.getSecond());

            int point = ((int) (Math.random() * 2));

            if(point == 0) {
                bag.add(cur.getFirst());
                System.out.println("Победила " + cur.getFirst());
            }
            else {
                bag.add(cur.getSecond());
                System.out.println("Победила " + cur.getSecond());
            }

            System.out.println();
        }
        round++;
        System.out.println("------------------------------------------------");
        System.out.println();
    }

    private void event2() {
        if (genericPairBag.getSize() == 1)
            System.out.println("Финал");
        else
            System.out.println("Раунд " + round);

        while (!genericPairBag.isEmpty()) {
            Pair cur = genericPairBag.delete();

            System.out.println("Битва между " + cur.getFirst() + " и " + cur.getSecond());

            Scanner IN = new Scanner(System.in);

            int point = IN.nextInt();

            if(point == 1) {
                bag.add(cur.getFirst());
                System.out.println("Победила " + cur.getFirst());
            }
            else {
                bag.add(cur.getSecond());
                System.out.println("Победила " + cur.getSecond());
            }

            System.out.println();
        }
        round++;
        System.out.println();
    }
}
