package lab5.g_pair_bag;
import lab5.pairbag.Pair;
import java.util.ArrayList;
import java.util.concurrent.ThreadLocalRandom;

//put items in an ArrayList
public class GenericPairBag<T> {

    private ArrayList<Pair<T,T>> m_arr_items;

    public GenericPairBag() { m_arr_items = new ArrayList<>(); }

    public void addItem(Pair<T,T> item) { m_arr_items.add(item); }

    public boolean isEmpty() { return m_arr_items.isEmpty(); }

    public Pair<T,T> getItem()
    {
            int ind = 0;
            do { ind = ThreadLocalRandom.current().nextInt(0,m_arr_items.size()); }
            while (m_arr_items.get(ind) == null);

            return m_arr_items.get(ind);

    }
    public Pair<T,T> deleteItem()
    {
            int ind = 0;
            do { ind = ThreadLocalRandom.current().nextInt(0,m_arr_items.size()); }
            while (m_arr_items.get(ind) == null);

            Pair<T,T> temp = m_arr_items.get(ind);
            m_arr_items.remove(ind);

            return temp;

    }

    public static void main(String[] args) {

        GenericPairBag<Short> bag_obj = new GenericPairBag<>();
        Short n1 = 51,n2 = 4;

        Pair<Short,Short> test_pair = Pair.make_pair(n1,n2);
        bag_obj.addItem(test_pair);

        Pair<Short,Short> del_value1 = bag_obj.deleteItem();
        bag_obj.addItem(del_value1);
    }
}
