package pack.NUM_8;

import pack.NUM_7.DList;

import java.util.*;

class NUM_8 {
    public static void main(String[] args) {
        ArrayList<Integer> list = new ArrayList<>();
        list.add(10);
        list.add(2);
        list.add(1);
        list.add(5);

        ATM atm = new ATM(list);
        int value = 7;
        DList<Integer, List<Integer>> res = atm.issuance(value);
        System.out.println("Для " + value);
        res.view();
        System.out.println("При наборе " +  atm.getList());


        System.out.println("--------------------------------------------------------");

        value = 1;
        res = atm.issuance(value);
        System.out.println("Для " + value);
        res.view();
        System.out.println("При наборе " +  atm.getList());

        System.out.println("--------------------------------------------------------");
        System.out.println("--------------------------------------------------------");

        ArrayList<Integer> list2 = new ArrayList<>();
        list2.add(1);
        list2.add(4);
        list2.add(7);
        list2.add(9);

        ATM atm2 = new ATM(list2);
        value = 7;

        System.out.println("--------------------------------------------------------");
        DList<Integer, List<Integer>> res2 = atm2.issuance(value);
        System.out.println("Для " + value);
        res2.view();
        System.out.println("При наборе " + atm2.getList());
        System.out.println("--------------------------------------------------------");

    }
}

public class ATM {

    private final ArrayList<Integer> list;

    public ATM(ArrayList<Integer> list) {
        TreeSet<Integer> set = new TreeSet<>(list);
        set = (TreeSet<Integer>) set.descendingSet();
        this.list = new ArrayList<>(set);
    }

    public ArrayList<Integer> getList() {
        return list;
    }

    public DList<Integer, List<Integer>> issuance(int value) {
        if(value < this.list.get(this.list.size() - 1)) {
            DList<Integer, List<Integer>> dList = new DList<>();
            List<Integer> res = new ArrayList<>();
            res.add(0);
            dList.add(0, res);
            return dList;
        }

        ArrayList<Integer> res = new ArrayList<>();
        int count = 0;
        int countMin = Integer.MAX_VALUE;
        ArrayList<Integer> listSave1;
        ArrayList<Integer> listSave2 = new ArrayList<>(this.list);
        ArrayList<Integer> resSave = new ArrayList<>();

        int valueSave;
        while (!listSave2.isEmpty()) {
            valueSave = value;
            listSave1 = new ArrayList<>(listSave2);
            while (!listSave1.isEmpty()) {
                count = 0;
                while (!listSave1.isEmpty()) {
                    int a = listSave1.remove(0);
                    while (valueSave - a >= 0) {
                        valueSave -= a;

                        if(listSave1.size() > 0 && valueSave > 0)
                            if(valueSave < listSave1.get(listSave1.size() - 1)) {
                                valueSave += a;
                                break;
                            }

                        if (valueSave < 0) {
                            valueSave += a;
                            continue;
                        }
                        count++;
                        resSave.add(a);
                    }
                }
                if (valueSave == 0) {
                    if (count < countMin)
                        countMin = count;
                    res.addAll(resSave);
                    resSave.clear();
                    break;
                }
            }
            listSave2.remove(0);
        }

//        if(countMin == Integer.MAX_VALUE)
//            throw new Exception("Алгоритм не могет");

        TreeSet<Integer> set = new TreeSet<>(res);
        res = new ArrayList<>(set);

        DList<Integer, List<Integer>> dList = new DList<>();
        dList.add(countMin, res);
        return dList;
    }
}
