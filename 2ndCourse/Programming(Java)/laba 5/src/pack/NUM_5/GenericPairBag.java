package pack.NUM_5;

import pack.Num_1.Pair;

import java.util.ArrayList;
import java.util.List;

class NUM_5 {
    public static void main(String[] args) {
        GenericPairBag<Integer, String> genericPairBag = new GenericPairBag<>();
        Pair<Integer, String> pair;

        pair = genericPairBag.add(2, "2");
        if(pair != null) {
            pair.view();
            System.out.println("добавлен");
        }
        System.out.println();

        pair = genericPairBag.add(4, "true");
        if(pair != null) {
            pair.view();
            System.out.println("добавлен");
        }
        System.out.println();

        pair = genericPairBag.add(15, "22");
        if(pair != null) {
            pair.view();
            System.out.println("добавлен");
        }
        System.out.println();

        pair = genericPairBag.add(4, "1.5");
        if(pair != null) {
            pair.view();
            System.out.println("добавлен");
        }
        System.out.println();

        pair = genericPairBag.ret();
        if(pair != null) {
            pair.view();
            System.out.println("взят");
        }
        System.out.println();

        pair = genericPairBag.ret();
        if(pair != null) {
            pair.view();
            System.out.println("взят");
        }
        System.out.println();

        pair = genericPairBag.delete();
        if(pair != null) {
            pair.view();
            System.out.println("удален");
        }
        System.out.println();

        pair = genericPairBag.delete();
        if(pair != null) {
            pair.view();
            System.out.println("удален");
        }
        System.out.println();

        pair = genericPairBag.delete();
        if(pair != null) {
            pair.view();
            System.out.println("удален");
        }
        System.out.println();

        pair = genericPairBag.delete();
        if(pair != null) {
            pair.view();
            System.out.println("удален");
        }
        System.out.println();

        pair = genericPairBag.delete();
        if(pair != null) {
            pair.view();
            System.out.println("удален");
        }
        System.out.println();
    }
}

public class GenericPairBag<T1, T2> {

    List<Pair<T1, T2>> list;

    public GenericPairBag() {
        this.list = new ArrayList<>();
    }

    public int getSize() {
        return this.list.size();
    }

    public boolean isEmpty() {
        return list.isEmpty();
    }

    public final Pair<T1, T2> add(T1 value1, T2 value2) {
        Pair<T1, T2> cur = new Pair<>(value1, value2);
        cur.setFirst(value1);
        cur.setSecond(value2);
        list.add(cur);
        return list.get(list.size() - 1);
    }

    public Pair<T1, T2> delete() {
        if (list.isEmpty()) {
            System.out.println("пустой");
            return null;
        }
        return list.remove((int)(Math.random() * list.size()));
    }

    public Pair<T1, T2> ret() {
        if(list.isEmpty()) {
            System.out.println("пустой");
            return null;
        }
        return list.get((int)(Math.random() * list.size()));
    }
}
