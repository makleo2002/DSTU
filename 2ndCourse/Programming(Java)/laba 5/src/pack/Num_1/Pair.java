package pack.Num_1;

import java.util.ArrayList;
import java.util.List;

class NUM_1 {
    public static void main(String[] args) {
        Pair<Integer, Integer> myPair = new Pair<>(12, 32);
        myPair.view();

        System.out.println("=====================================================");

        Pair a = Pair.make_pair(23, "1gdgd");
        a.view();

        List<Integer> list = new ArrayList<>();
        list.add(3);
        System.out.println(list);
        foo(list);
        System.out.println(list);





    }

    public static void foo(List list){
        list.clear();
    }

    public static void foo2(List list){
        list.clear();
    }
}

public class Pair<T,R> {
    private T first;
    private R second;

    public Pair(T first, R second) {
        if(first.getClass() == second.getClass()) {
//            System.out.println("Типы данных совпадают. Объект до конца не создан");
            return;
        }
        this.first = first;
        this.second = second;
    }

    public T getFirst() {
        return first;
    }

    public R getSecond() {
        return second;
    }

    public void setFirst(T first) {
        this.first = first;
    }

    public void setSecond(R second) {
        this.second = second;
    }

    public void view() {
        System.out.println("First: " + first + "    Second: " + second);
    }

    public static <T, R> Pair make_pair(T v1, R v2) {
        return new Pair(v1, v2);
    }
}
