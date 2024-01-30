package lab5.g_pair_bag;
import lab5.pairbag.Pair;
import lab5.pairbag.PairBag;
import java.util.concurrent.ThreadLocalRandom;

//didn't show this task

public class GPairBag<T> extends PairBag {

    public GPairBag(int size) { super(size);}

    public Pair<T,T> getItem()
    {
        if (m_current_size > 0)
        {
            int ind = 0;
            do { ind = ThreadLocalRandom.current().nextInt(0,m_size); }
            while (m_arr_items[ind] == null);

            return (Pair<T,T>) m_arr_items[ind];
        }
        else
        {
            System.out.println("There are no items in the Bag, so null has been returned");
            return null;
        }
    }
    public Pair<T,T> deleteItem()
    {
        if (m_current_size > 0)
        {
            m_current_size--;
            int ind = 0;
            do { ind = ThreadLocalRandom.current().nextInt(0,m_size); }
            while (m_arr_items[ind] == null);

            Object temp = m_arr_items[ind];
            m_arr_items[ind] = null;

            return (Pair<T,T>) temp;
        }
        else
        {
            System.out.println("There are no items in the Bag, so null has been returned");
            return null;
        }
    }

    public static void main(String[] args)
    {
        GPairBag<Integer> pair_bag_obj = new GPairBag<>(10);
        Pair<Integer,Integer> test_pair1 = new Pair<>(3,5);
        Pair<Integer,Integer> test_pair2 = Pair.make_pair(6,18);

        pair_bag_obj.addItem(test_pair1);
        pair_bag_obj.addItem(test_pair2);

        Pair<Integer,Integer> received_pair = pair_bag_obj.getItem();
    }
}
