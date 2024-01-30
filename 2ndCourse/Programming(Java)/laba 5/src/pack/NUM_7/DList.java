package pack.NUM_7;

import java.util.ArrayList;
import java.util.List;

class NUM_7 {
    public static void main(String[] args) {
        //DList<Integer, List<Integer>>
        var dList = new DList<>();
        List<Integer> list1 = new ArrayList<>();
        list1.add(1);
        list1.add(1);
        dList.add(1, list1);

        List<Integer> list2 = new ArrayList<>();
        list2.add(2);
        dList.add(2, list2);

        List<Integer> list3 = new ArrayList<>();
        list3.add(3);
        list3.add(2);
        list3.add(1);
        dList.add(5, list3);

        List<Integer> list4_1 = new ArrayList<>();
        list4_1.add(2);
        List<Integer> list4_2 = new ArrayList<>();
        list4_2.add(6);
        list4_2.add(8);
        List<List<Integer>> list4 = new ArrayList<>();
        list4.add(list4_1);
        list4.add(list4_2);
        dList.add(5, list4);

        dList.view();

        System.out.println("---------------------------------------------------");
        dList.getI(1);
        dList.getV(5);

        System.out.println("---------------------------------------------------");
        dList.delI(0);
        dList.delV(5);
    }
}

public class DList<T1, T2> {
    private List<T1> list1;
    private List<T2> list2;

    public DList() {
        list1 = new ArrayList<>();
        list2 = new ArrayList<>();
    }

    public void add(T1 value1, T2 value2) {
        list1.add(value1);
        list2.add(value2);
    }

    public void getI(int index) {
        if(index >= list1.size())
            System.out.println("Индекс " + index + " не найден");
        else
            System.out.println(list1.get(index) + "    " + list2.get(index));
    }

    public void getV(T1 value) {
        int index = 0;
        for(var l : list1) {
            if (l.equals(value))
                break;
            index++;
        }
        if(index >= list1.size())
            System.out.println(value + " не найден");
        else
            System.out.println(list1.get(index) + "    " + list2.get(index));
    }

    public void delI(int index) {
        if(index >= list1.size())
            System.out.println("Индекс " + index + " не найден");
        else
            System.out.println(list1.remove(index) + " и " + list2.remove(index) + " успешно удалены");
    }

    public void delV(T1 value) {
        int index = 0;
        for(var l : list1) {
            if (l.equals(value))
                break;
            index++;
        }
        if(index >= list1.size())
            System.out.println(value + " не найден");
        else
            System.out.println(list1.remove(index) + " и " + list2.remove(index) + " успешно удалены");
    }

    public void view() {
        for(int i = 0; i < list1.size(); i++)
            System.out.println(list1.get(i) + "    " + list2.get(i));

//        System.out.println();
//        System.out.println(list1);
//        System.out.println(list2);
    }
}
