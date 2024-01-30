package pack.NUM_3;

import pack.NUM_2.Bag;
import pack.Num_1.Pair;

class NUM_3 {
    public static void main(String[] args) {
        PairBag pairBag = new PairBag(5);
        pairBag.add(true, 2);
        System.out.println();

        pairBag.add("str", true);
        System.out.println();

        pairBag.add(15, 2);
        System.out.println();

        pairBag.add("str", 1.5);
        System.out.println();

        pairBag.add(false, 2.4);
        System.out.println();

        pairBag.add(3.6, "awea");
        System.out.println();

        pairBag.ret();
        System.out.println();

        pairBag.ret();
        System.out.println();

        pairBag.ret();
        System.out.println();

        pairBag.delete();
        System.out.println();

        pairBag.delete();
        System.out.println();

        pairBag.delete();
        System.out.println();

        pairBag.delete();
        System.out.println();

        pairBag.delete();
        System.out.println();

        pairBag.delete();
        System.out.println();

    }
}

public class PairBag {
    protected Bag bag;

    public PairBag(int length) {
        bag = new Bag(length);
    }

    public int getLength() {
        return this.bag.getLength();
    }

    public int getAmount() {
        return this.bag.getAmount();
    }

    public void add(Object value1, Object value2) {
        Pair cur = new Pair(value1, value2);
        cur.setFirst(value1);
        cur.setSecond(value2);
        if (this.bag.getAmount() == this.bag.getLength()) {
            cur.view();
            System.out.println("не добавлен, т.к. места больше нет");
            return;
        }
        bag.add(cur);
        cur.view();
        System.out.println("добавлен");
    }

    public void delete() {
        Pair pair = (Pair) bag.delete();
        if(pair != null) {
            pair.view();
            System.out.println("удален");
        }
    }

    public Pair ret() {
        Pair pair = (Pair) bag.ret();
        if(pair != null) {
            pair.view();
            System.out.println("взят");
        }
        return pair;
    }
}
