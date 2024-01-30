package lab5.hash_table;

public record Person(String m_name, int m_age) implements Containing<String>
{
    @Override
    public boolean contains(String str)
    {
        if (str.equals(m_name)) return true;
        else return false;
    }
}
