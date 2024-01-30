package lab5.hash_table;

public abstract class HashFunction<Key>
{
    final private int m_size;

    public HashFunction() { this(5); }

    public HashFunction(int size) { m_size = size; }

    public int getSize() { return m_size; }

    public abstract int hashCode(Key str);
}
