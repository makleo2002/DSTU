package com.company;

import java.io.PrintStream;
import java.util.*;

class Pair<T,M>{
    private T first;
    private M second;
    final T getFirst(){
        return first;
    }
    final M getSecond(){
        return second;
    }
    final void setFirst(T m){
        this.first=m;
    }
    final void setSecond(M i){
        this.second=i;
    }
    protected Pair(){}
    public Pair(T max,M index){
        this.first=max;
        this.second=index;

    }
    public static <T,M>  Pair make_pair(T max,M index){
        return new Pair<T,M>(max,index);
    }
    final void show(){
        System.out.print(first+" ");
        System.out.print(second+" ");
    }

}


class Bag {
    private  Object[] mas ;
    protected int cur_size;
    public Object[] getMas() {
        return mas;
    }

    public Bag(int n) {
       mas=new Object [n];
       this.cur_size=0;
    }


    public int getCur_size() {
        return this.cur_size;
    }

    public boolean isEmpty() {
        return this.cur_size == 0;
    }
    public void add(Object num) {
        int count = -1;
        boolean flag = false;
        int r = (int) Math.round(Math.random() * (mas.length - 1));
        while (!flag) {
            for (int k = 0; k < mas.length; k++) {
                if (mas[k] == null) {
                    if(r == k) {
                        mas[k]=num;
                        System.out.println("Предмет " + mas[k] + " добавлен в мешок");
                        flag = true;
                        this.cur_size++;
                        break;
                    }
                } else  count++;
            }
            r = (int) Math.round(Math.random() * (mas.length - 1));
            if (mas.length - 1 == count) {
                System.out.println("Мешок полон");
                break;
            }
        }
    }

    public Object remove() {
        boolean flag = false;
        Object tmp=null;
        if (mas.length == 0) return tmp;
        while (!flag) {
            int r = (int) Math.round(Math.random() * (mas.length - 1));
            for (int k = 0; k < mas.length; k++) {
                if (mas[k] != null && r == k) {
                    tmp = mas[k];
                    System.out.println("Предмет " + mas[k] + " удален");
                    mas[k]=null;
                    flag = true;
                    this.cur_size--;
                    break;
                }
            }
        }
        return tmp;
    }

    public final Object retElem(int i) {
        return mas[i];
    }

    public final int retSize() {
        return mas.length;
    }

    public void show() {
        for (Object i : mas) {
            if(i!=null)
            System.out.print(i + " ");
        }
        System.out.println();
    }
}

    class PairBag {
      private final Bag bag;

      public final Bag getBag() {
          return bag;
      }
      public  PairBag(int n) {
          this.bag=new Bag(n);
        }

      public int getCur_size() {
            return this.bag.getCur_size();
        }

       public void add(Object num,Object num1) {
            int count = -1;
            boolean flag = false;
            Pair pair1 = Pair.make_pair(num,num1);
            int r = (int) Math.round(Math.random() * (bag.getMas().length - 1));
            while (!flag) {
                for (int k = 0; k < bag.getMas().length; k++) {
                    if (bag.getMas()[k] == null) {
                        if(r==k) {
                            bag.getMas()[k]=pair1;
                            System.out.println("Пара значений ");
                            pair1.show();
                            System.out.print("добавлена в мешок");
                            System.out.println();
                            flag = true;
                            bag.cur_size++;
                            break;
                        }
                    } else count++;
                }
                r = (int) Math.round(Math.random() * (bag.getMas().length - 1));
                if (bag.getMas().length - 1 == count) {
                    System.out.println("Мешок полон");
                    break;
                }
            }
        }
       public Object remove() {
            boolean flag = false;
            Pair tmp = new Pair();
            if (bag.getMas().length == 0) return tmp;
            while (!flag) {
                int R = (int) Math.round(Math.random() * (bag.getMas().length - 1));
                for (int k = 0; k < bag.getMas().length; k++) {
                    if (bag.getMas()[k] != null && R == k) {
                        tmp = (Pair)bag.getMas()[k];
                        System.out.println("Пара значений ");
                        ((Pair<?, ?>) bag.getMas()[k]).show();
                        System.out.print(" удалена");
                        bag.getMas()[k]=null;
                        flag = true;
                        bag.cur_size--;
                        break;
                    }
                }
            }
            return tmp;
        }
        public final Object retElem(int i) {
            return bag.getMas()[i];
        }
        public final int retSize(){return this.bag.retSize();}
        public void show() {
            for (int i=0;i<bag.getMas().length;i++) {
                if(bag.getMas()[i]!=null)
                System.out.print(bag.getMas()[i] + " ");
            }
            System.out.println();
        }
    }

class GPairBag<T1, T2> {
    private PairBag pairBag;

    public GPairBag(int length) {
        this.pairBag = new PairBag(length);
    }

    public int retSize() {
        return this.pairBag.retSize();
    }

    public int getCur_size() {
        return this.pairBag.getCur_size();
    }

    public void add(T1 value1, T2 value2) {
        this.pairBag.add(value1, value2);
    }

    public void remove() {
        this.pairBag.remove();
    }

    public Pair<T1, T2> ret(int i) {
        return (Pair<T1, T2>) this.pairBag.retElem(i);
    }
}

class GenericPairBag<T1,T2>{
    ArrayList<Pair<T1,T2>> mas;
    public  GenericPairBag(int n) {
        mas=new ArrayList<>(n);
        for(int i=0;i<n;i++){
            mas.add(i,null);
        }
    }
    protected GenericPairBag(){};
    public boolean isEmpty() {
        return this.mas.isEmpty();
    }
    public void add(T1 num,T2 num1) {
        int count = -1;
        boolean flag = false;
        Pair pair1 = Pair.make_pair(num,num1);
        int r = (int) Math.round(Math.random() * (mas.size() - 1));
        while (!flag) {
            for (int k = 0; k < mas.size(); k++) {
                if (mas.get(k) == null) {
                    if(r==k) {
                        mas.set(k,pair1);
                        System.out.println("Пара значений ");
                        pair1.show();
                        System.out.print("добавлена в мешок");
                        System.out.println();
                        flag = true;
                        break;
                    }
                } else count++;
            }
            r = (int) Math.round(Math.random() * (mas.size() - 1));
            if (mas.size() - 1 == count) {
                System.out.println("Мешок полон");
                break;
            }
        }
    }
    public Pair<T1,T2> remove() {
        boolean flag = false;
        Pair tmp = new Pair();
        if (mas.size() == 0) return tmp;
        while (!flag) {
            int R = (int) Math.round(Math.random() * (mas.size() - 1));
            for (int k = 0; k < mas.size(); k++) {
                if (mas.get(k) != null && R == k) {
                    tmp = mas.get(k);
                    System.out.println("Пара значений ");
                    mas.get(k).show();
                    System.out.print(" удалена");
                    mas.set(k,null);
                    flag = true;
                    break;
                }
            }
        }
        return tmp;
    }
    public final Pair retElem(int i) {
        return mas.get(i);
    }
    public final int retSize(){return mas.size();}
    public void show() {
        for (int i=0;i<mas.size();i++) {
            if(mas.get(i)!=null)
                System.out.print(mas.get(i) + " ");
        }
        System.out.println();
    }
}

class Team {
    private Bag bag;
    private GenericPairBag<String, String> genericPairBag;
    private int amount;
    private int round;

    public Team(int n) {
        if ((n & n - 1) != 0) {
            System.out.println("Введено недопустимое значение. Установленно значение по умолчанию - 8\n");
            this.bag = new Bag(8);
        } else {
            this.bag = new Bag(n);
        }

        this.genericPairBag = new GenericPairBag();
        this.amount = this.bag.retSize();
        this.round = 1;
    }

    public void tournament() {
        this.SET();

        while(this.bag.getCur_size() != 1) {
            this.GET();
            this.event();
        }

        System.out.println("Победитель: " + this.bag.remove().toString());
    }

    private void SET() {
        if (this.bag.isEmpty()) {
            for(int i = 0; i < this.amount; ++i) {
                this.bag.add("'Команда " + (i + 1) + "'");
            }
        }

    }

    private void GET() {
        while(!this.bag.isEmpty()) {
            String str1 = (String)this.bag.remove();
            String str2 = (String)this.bag.remove();
            this.genericPairBag.add(str1, str2);
        }

    }

    private void event() {
        System.out.println("------------------------------------------------");
        if (this.genericPairBag.retSize() == 1) {
            System.out.println("Финал");
        } else {
            System.out.println("Раунд " + this.round);
        }

        for(; !this.genericPairBag.isEmpty(); System.out.println()) {
            Pair cur = this.genericPairBag.remove();
            //PrintStream var10000 = System.out;
            //Object var10001 = cur.getFirst();
            System.out.println("Битва между " + cur.getFirst() + " и " + cur.getSecond());
            int point = (int)(Math.random() * 2);
            if (point == 0) {
                this.bag.add(cur.getFirst());
                System.out.println("Победила " + cur.getFirst());
            } else {
                this.bag.add(cur.getSecond());
                System.out.println("Победила " + cur.getSecond());
            }
        }

        ++this.round;
        System.out.println("------------------------------------------------");
        System.out.println();
    }

    private void event2() {
        if (this.genericPairBag.retSize() == 1) {
            System.out.println("Финал");
        } else {
            System.out.println("Раунд " + this.round);
        }

        for(; !this.genericPairBag.isEmpty(); System.out.println()) {
            Pair cur = this.genericPairBag.remove();
            System.out.println("Битва между " + cur.getFirst() + " и " + cur.getSecond());
            Scanner IN = new Scanner(System.in);
            int point = IN.nextInt();
            if (point == 1) {
                this.bag.add(cur.getFirst());
                System.out.println("Победила " + cur.getFirst());
            } else {
                this.bag.add(cur.getSecond());
                System.out.println("Победила " + cur.getSecond());
            }
        }

        ++this.round;
        System.out.println();
    }
}

    class DList<T1, T2> {

        private ArrayList<T1> m_arr;
        private ArrayList<ArrayList<T2>> m_list_arr;


        public java.util.ArrayList<T1> getM_arr() {
            return m_arr;
        }
        public ArrayList<ArrayList<T2>> getM_list_arr(){
            return m_list_arr;
        }

        public DList() {
            m_arr = new ArrayList<>();
            m_list_arr = new ArrayList<>();
        }

        public void addList(T1 list_id, ArrayList<T2> arr) {
            if (!m_arr.contains(list_id))                       //if the id is not the list1
            {
                m_arr.add(list_id);                             //add id to the list1
                m_list_arr.add(arr);                            //add the list to the m_list_arr
            } else {
                int ind = m_arr.indexOf(list_id);           //if the id is already int the list1, find index of that id

                m_list_arr.add(ind, arr);                    //add the list to the respective list in m_list_arr
            }
        }

        public void deleteList(int i) {
            if (i >= 0) {
                if (i < m_arr.size()) {
                    m_arr.remove(i);
                    m_list_arr.remove(i);
                } else {
                    System.out.println("Индекс должен быть меньше чем " + m_arr.size());
                }
            } else {
                System.out.println("Индекс не должен быть отрицательным");
            }
        }

        public void deleteList(T1 id) {
            if (m_arr.contains(id))                 //if m_arr contains the id, find its index and delete it
            {
                int ind = m_arr.indexOf(id);
                m_arr.remove(ind);
                m_list_arr.remove(ind);
            } else {
                System.out.println("Здесь нет такого элемента");
            }

        }

        public ArrayList<T2> getList(int i) {
            ArrayList<T2> temp_list = null;

            if (i >= 0) {
                if (i < m_arr.size()) {
                    temp_list = m_list_arr.get(i);
                } else {
                    System.out.println("Индекс должен быть меньше чем " + m_arr.size());
                }
            } else {
                System.out.println("Индекс должен быть неотрицательным");
            }

            return temp_list;
        }

        public ArrayList<T2> getList(T1 id) {
            ArrayList<T2> temp_list = null;

            if (m_arr.contains(id)) {
                temp_list = m_list_arr.get(m_arr.indexOf(id));
            } else {
                System.out.println("Здесь нет элемента с таким значением");
            }

            return temp_list;
        }
    }

class AWM { // use DLIST

    private DList list=new DList<>();


    public ArrayList<Integer> GetMoneySet(int amount_money,ArrayList<Integer> arr_coins) {

        Arrays.sort(arr_coins.toArray());
        System.out.println("After sorting: ");
        System.out.println(Arrays.toString(arr_coins.toArray()));
        System.out.println();
        list.addList(amount_money,arr_coins);

        Integer temp = amount_money;
        ArrayList<Integer> m_coins=new ArrayList<>();

        for (int j = arr_coins.size()- 1; j >= 0; j--) {
            if (temp - arr_coins.get(j) >= 0)
            {

                m_coins.add(arr_coins.get(j));
                temp -= arr_coins.get(j);
                System.out.println("temp: "+temp);
                System.out.println("arr_coins :"+arr_coins.get(j));

            }


        }
        list.getM_list_arr().set(0,m_coins);
        return  list.getM_list_arr();
    }
}
class Awm1 {

    private Integer[] m_arr_coins;

    public Awm1(Integer[] arr_coins) {
        m_arr_coins = arr_coins;
    }

    public ArrayList<Integer> getMoney(int amount_money) {

        ArrayList<Integer> arr_coins = new ArrayList<>();
        Arrays.sort(m_arr_coins);

        System.out.println("Sorted: ");
        System.out.println(Arrays.toString(m_arr_coins));
        int temp = amount_money;

        for (int j = m_arr_coins.length - 1; j >= 0; j--) {
            if (temp - m_arr_coins[j] >= 0)
            {
                arr_coins.add(m_arr_coins[j]);
                temp -= m_arr_coins[j];
            }
        }

        return arr_coins;
    }
    }
class Person {
    private String firstName;
    private String lastname;
    private int age;

    public Person(String firstName, String lastname) {
        this.firstName = firstName;
        this.lastname = lastname;
    }

    public Person(String firstName, String lastname, int age) {
        this.firstName = firstName;
        this.lastname = lastname;
        this.age = age;
    }

    public String getFirstName() {
        return this.firstName;
    }

    public String getLastname() {
        return this.lastname;
    }

    public int getAge() {
        return this.age;
    }

    public void view() {
        System.out.println("First name: " + this.firstName);
        System.out.println("Last name: " + this.lastname);
        System.out.println("Age: " + this.age);
    }
}

abstract class HashFunction<K> {
    protected final int size;

    public abstract int hash(K var1);

    public HashFunction(int size) {
        this.size = size;
    }
}
class StrHashFunction<K> extends HashFunction<K> {
    public StrHashFunction(int size) {
        super(size);
    }

    public int hash(K key) {
        int p = 53,p_pow=1;
        Integer hash=0;
        char[] arr = key.toString().toCharArray();
        for(var i:arr){
            hash += (i - 'a' + 1) * p_pow;
            p_pow *= p;
        }

        return hash%size;
    }
}
class HashTable<K, T> {
    private final ArrayList<ArrayList<Pair<K, T>>> table;
    private final StrHashFunction<K> func;
    private final int size;

    public HashTable(int n) {
        this.size = n;
        this.func = new StrHashFunction(this.size);
        this.table = new ArrayList(this.size);

        for(int i = 0; i < n; ++i) {
            this.table.add(new ArrayList());
        }

    }

    public T find(K key) {
        int index = this.func.hash(key);
        Iterator var3 = (this.table.get(index)).iterator();

        Pair l;
        do {
            if (!var3.hasNext()) {
                return null;
            }

            l = (Pair)var3.next();
        } while(!l.getFirst().equals(key));

        return (T) l.getSecond();
    }

    public void add(K key, T value) {
        int hash = this.func.hash(key);
        (this.table.get(hash)).add(new Pair(key, value));
    }

    public boolean delete(K key) {
        int index = this.func.hash(key);
        T del = this.find(key);
        if (del == null) {
            return false;
        } else {
            (this.table.get(index)).remove(key);
            return true;
        }
    }
}
    public class Main {

        public static void main(String[] args) {
/*
            Pair.make_pair(5, "s");
            Pair pair=new Pair<>();
            pair.setFirst(1);
            pair.setSecond("cat");
            pair.show();
            System.out.println();
            Bag bag = new Bag(5);
            bag.add(5);
            bag.add(1);
            bag.add(52);
            bag.add(-6);
            bag.add(3);
            bag.add(3);
            bag.add(4);
            bag.add(8);
            System.out.println(bag.retSize());
            System.out.println();
            System.out.println(bag.retElem(1));
            System.out.println();
            bag.show();
            bag.remove();
            bag.show();
            bag.remove();
            bag.show();
            bag.remove();
            bag.show();


            PairBag pairbag = new PairBag(5);
            pairbag.add(7, "cats");
            pairbag.add(5, "dogs");
            pairbag.add(10, "parrots");
            pairbag.add(2, "bears");
            pairbag.add(1, "tiger");
            pairbag.show();


            DList list=new DList<>();
            ArrayList<Integer> list1=new ArrayList<>();
            list1.add(1);
            list1.add(2);
            list1.add(5);
            list1.add(10);

           list.addList(15,list1);


 */
           AWM awm=new AWM();
           ArrayList<Integer> list2=new ArrayList<>();
           list2.add(1);
           list2.add(2);
           list2.add(5);
           list2.add(10);
           var awm1=awm.GetMoneySet(16,list2);
           for(int i=0;i<awm1.size();i++){
               System.out.println(awm1.get(i));
           }
        }
    }



