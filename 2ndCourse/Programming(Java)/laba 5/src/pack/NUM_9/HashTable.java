package pack.NUM_9;

import pack.Num_1.Pair;

import java.util.ArrayList;

public class HashTable<K, T> {
    private final ArrayList<ArrayList<Pair<K, T>>> table;
    private final HairHashFunction<K> func;
    private final int size;

    public HashTable(int n) {
        this.size = n;
        this.func = new HairHashFunction<>(size);
        this.table = new ArrayList<>(size);
        for (int i = 0; i < n; i++) {
            table.add(new ArrayList<>());
        }
    }


    public T find(K key) {
        int index = func.hash(key);

        for(var l : table.get(index)){
            if(l.getFirst().equals(key)) {
                return l.getSecond();
            }
        }

        return null;
    }

//    public T find(K key, int i) {
//        int index = func.hash(key);
//        if(!table.get(index).isEmpty() && i < table.get(index).size())
//            return table.get(index).get(i);
//        else
//            return null;
//    }

    public void add(K key, T value) {
        int hash = func.hash(key);
        table.get(hash).add(new Pair<>(key, value));
    }

    public boolean delete(K key) {
        int index = func.hash(key);
        T del = find(key);
        if(del == null)
            return false;

        table.get(index).remove(key);
        return true;

    }

//    public boolean delete(K key, T value) {
//        ArrayList<T> del = find(key);
//        if(!del.isEmpty() && del.contains(value)) {
//            del.remove(value);
//            return true;
//        }
//        return false;
//    }

//    public boolean deleteI(K key, int i) {
//        ArrayList<T> del = find(key);
//        if(del.isEmpty() || i >= del.size())
//            return false;
//
//        del.remove(i);
//        return true;
//    }

//    public ArrayList<T> get(K key) {
//        ArrayList<T> get = find(key);
//        if(!get.isEmpty())
//            return get;
//        else
//            return null;
//    }
//
//    public T get(K key, int i) {
//        ArrayList<T> get = find(key);
//        if(!get.isEmpty() && i < get.size())
//            return get.get(i);
//        else
//            return null;
//    }
}
