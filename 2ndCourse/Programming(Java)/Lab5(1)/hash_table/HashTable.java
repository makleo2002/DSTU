package lab5.hash_table;
import java.util.LinkedList;

public class HashTable<T extends Containing<Key>,Key extends String> {

    final private int m_table_size;
    private LinkedList<T>[] m_arr_lists;
    final private HashFunction<String> m_func;

    public HashTable(HashFunction<String> func)
    {
        m_table_size = func.getSize();
        m_func = func;
        m_arr_lists = (LinkedList<T>[]) new LinkedList[m_table_size];

        for (int j = 0; j < m_table_size; j++)
        {
            m_arr_lists[j] = new LinkedList<>();
        }
    }

    public T get(Key key)
    {
        int arr_ind = m_func.hashCode(key);
        T temp = null;

        int i = 0;
        while (!m_arr_lists[arr_ind].get(i).contains(key)) { i++; }

        if (i == m_arr_lists[arr_ind].size())
        { System.out.println("There is no person with such name"); }
        else
        { temp = m_arr_lists[arr_ind].get(i); }

        return temp;
    }

    public void add(Key key,T obj)
    {
        int arr_ind = m_func.hashCode(key);
        m_arr_lists[arr_ind].add(obj);
    }

    public void delete(Key key)
    {
        int arr_ind = m_func.hashCode(key);

        int i = 0;
        while (!m_arr_lists[arr_ind].get(i).contains(key)) { i++; }

        if (i == m_arr_lists[arr_ind].size())
        { System.out.println("There is no person with such name"); }
        else
        { m_arr_lists[arr_ind].remove(i); }

    }


    public static void main(String[] args) {

        final int table_size = 10;
        HashFunction<String> func = new HashFuncChild<>(table_size);
        HashTable<Person,String> table_obj = new HashTable<>(func);

        Person p1 = new Person("Luke",43);
        Person p2 = new Person("Amber",38);
        Person p3 = new Person("Paul",40);

        String key1 = "Luke", key2 = "Amber", key3 = "Paul";

        table_obj.add(key1,p1);
        table_obj.add(key2,p2);
        table_obj.add(key3,p3);

        Person test_p1 = table_obj.get(key2);
        table_obj.delete(key3);

        System.out.println("Check");
    }
}
