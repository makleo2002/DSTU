package pack.NUM_9;

abstract class HashFunction<K> {
    protected final int size;
    public abstract int hash(K key);
    public HashFunction(int size) {
        this.size = size;
    }
}

public class HairHashFunction<K> extends HashFunction<K> {

    public HairHashFunction(int size) {
        super(size);
    }

    @Override
    public int hash(K key) {
        int res = 0;
        char[] arr = key.toString().toCharArray();
        for(char a : arr) {
            res += a;
        }
        return res % size;
    }

}
