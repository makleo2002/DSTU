package lab5.pairbag;

import java.util.concurrent.ThreadLocalRandom;

public class Bag {

    protected Object[] m_arr_items;
    protected final int m_size;
    protected int m_current_size;

    public Bag(int size)
    {
        m_size = size;
        m_arr_items = new Object[size];
        m_current_size = 0;
    }
    public final int getCurrentSize() { return m_current_size; }

    public final boolean isEmpty() { return m_current_size == 0; }

    public void addItem(Object item)
    {
        if (m_current_size < m_size)
        { m_arr_items[m_current_size++] = item; }
        else
        { System.out.println("There is no space in the Bag"); }
    }

    public Object getItem()
    {
        if (m_current_size > 0)
        {
            int ind = 0;
            do { ind = ThreadLocalRandom.current().nextInt(0,m_size); }
            while (m_arr_items[ind] == null);

            return m_arr_items[ind];
        }
        else
        {
            System.out.println("There are no items in the Bag, so null has been returned");
            return null;
        }
    }
    public Object deleteItem()
    {
        if (m_current_size > 0)
        {
            m_current_size--;
            int ind = 0;
            do { ind = ThreadLocalRandom.current().nextInt(0,m_size); }
            while (m_arr_items[ind] == null);

            Object temp = m_arr_items[ind];
            m_arr_items[ind] = null;

            return temp;
        }
        else
        {
            System.out.println("There are no items in the Bag, so null has been returned");
            return null;
        }
    }

    public static void main(String[] args) {

        Bag bag_obj = new Bag(12);
        Integer n1 = 21,n2 = 54;

        Object del_value1 = bag_obj.deleteItem();
        bag_obj.addItem(n2);
        bag_obj.addItem(n1);
        Object del_value2 = bag_obj.deleteItem();
    }
}
