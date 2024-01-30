package lab5.hash_table;

public class HashFuncChild<Key extends String> extends HashFunction<Key>{

    public HashFuncChild(int size) { super(size); }

    @Override
    public int hashCode(Key key)
    {
        int hash = 11, div = 3;
        hash = (hash/div + key.length()) + key.hashCode();

        return (hash & 0x7fffffff) % this.getSize();
        //use hashCode from String, make it positive and mod arr.length in order to get the index less than arr.length - 1
    }

}
