package lab5.d_list;

import java.util.ArrayList;

public class DList<T1,T2> {

    private ArrayList<T1> m_arr;
    private ArrayList<ArrayList<T2>> m_list_arr;

    public DList()
    {
        m_arr = new ArrayList<>();
        m_list_arr = new ArrayList<>();
    }

    public void addList(T1 list_id, ArrayList<T2> arr)
    {
        if (!m_arr.contains(list_id))                       //if the id is not the list1
        {
            m_arr.add(list_id);                             //add id to the list1
            m_list_arr.add(arr);                            //add the list to the m_list_arr
        }
        else
        {
            int ind = m_arr.indexOf(list_id);           //if the id is already int the list1, find index of that id

            m_list_arr.add(ind,arr);                    //add the list to the respective list in m_list_arr
        }
    }

    public void deleteList(int i)
    {
        if (i >= 0)
        {
            if (i < m_arr.size())
            {
                m_arr.remove(i);
                m_list_arr.remove(i);
            }
            else
            { System.out.println("The index should be less than " + m_arr.size());}
        }
        else
        { System.out.println("The index should not be negative"); }
    }

    public void deleteList(T1 id)
    {
        if (m_arr.contains(id))                 //if m_arr contains the id, find its index and delete it
        {
            int ind = m_arr.indexOf(id);
            m_arr.remove(ind);
            m_list_arr.remove(ind);
        }
        else
        { System.out.println("There is no such id in the list"); }

    }  public ArrayList<T2> getList(int i)
    {
        ArrayList<T2> temp_list = null;

        if (i >= 0)
        {
            if (i < m_arr.size())
            {
                temp_list = m_list_arr.get(i);
            }
            else
            { System.out.println("The index should be less than " + m_arr.size());}
        }
        else
        { System.out.println("The index should not be negative"); }

        return temp_list;
    }

    public ArrayList<T2> getList(T1 id)
    {
        ArrayList<T2> temp_list = null;

        if (m_arr.contains(id))
        {
            int ind = m_arr.indexOf(id);
            temp_list = m_list_arr.get(ind);
        }
        else
        { System.out.println("There is no such id in the list"); }

        return temp_list;
    }

    public static void main(String[] args)
    {
        DList<Integer,Double> test_list = new DList<>();
        ArrayList<Double> arr1 = new ArrayList<>();
        ArrayList<Double> arr2 = new ArrayList<>();
        arr1.add(4.2);
        arr1.add(6.5);
        arr2.add(7.5);
        arr2.add(10.5);

        test_list.addList(0,arr1);
        test_list.addList(1,arr2);

        Integer x = 1;
        test_list.deleteList(x);

        ArrayList list1 = test_list.getList(0);

    }
}
