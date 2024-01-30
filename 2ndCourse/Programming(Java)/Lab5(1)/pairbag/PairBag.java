package lab5.pairbag;

import java.util.concurrent.ThreadLocalRandom;

public class PairBag extends Bag {

    public PairBag(int size) { super(size); }

    public void addItem(Pair item)
    {
        if (m_current_size < m_size)
        { m_arr_items[m_current_size++] = item; }
        else
        { System.out.println("There is no space in the Bag"); }
    }

    public Pair getItem()
    {
        if (m_current_size > 0)
        {
            int ind = 0;
            do { ind = ThreadLocalRandom.current().nextInt(0,m_size); }
            while (m_arr_items[ind] == null);

            return (Pair) m_arr_items[ind];
        }
        else
        {
            System.out.println("There are no items in the Bag, so null has been returned");
            return null;
        }
    }
    public Pair deleteItem()
    {
        if (m_current_size > 0)
        {
            m_current_size--;
            int ind = 0;
            do { ind = ThreadLocalRandom.current().nextInt(0,m_size); }
            while (m_arr_items[ind] == null);

            Object temp = m_arr_items[ind];
            m_arr_items[ind] = null;

            return (Pair) temp;
        }
        else
        {
            System.out.println("There are no items in the Bag, so null has been returned");
            return null;
        }
    }


    public static void main(String[] args)
    {
        PairBag pair_bag_obj = new PairBag(21);
        Pair<String,Integer> test_pair1 = new Pair<>("3",5);
        Pair test_pair2 = Pair.make_pair(54,"Snoop Dog");

        pair_bag_obj.addItem(test_pair1);
        pair_bag_obj.addItem(test_pair2);

        Pair received_pair = pair_bag_obj.getItem();
    }
    }