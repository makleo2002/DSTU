package pack.NUM_4;

import pack.NUM_3.PairBag;
import pack.Num_1.Pair;

class NUM_4 {
    public static void main(String[] args) {
        GPairBag<Integer, String> gPairBag = new GPairBag(3);
        gPairBag.add(2, "2");
        System.out.println();

        gPairBag.add(4, "true");
        System.out.println();

        gPairBag.add(15, "22");
        System.out.println();

        gPairBag.add(4, "1.5");
        System.out.println();

        gPairBag.ret();
        System.out.println();

        gPairBag.ret();
        System.out.println();

        gPairBag.delete();
        System.out.println();

        gPairBag.delete();
        System.out.println();

        gPairBag.delete();
        System.out.println();

        gPairBag.delete();
        System.out.println();
    }
}

public class GPairBag<T1, T2> {

    private PairBag pairBag;

    public GPairBag(int length) {
        this.pairBag = new PairBag(length);
    }

    public int getLength() {
        return this.pairBag.getLength();
    }

    public int getAmount() {
        return this.pairBag.getAmount();
    }

    public void add(T1 value1, T2 value2) {
        pairBag.add(value1, value2);
    }

    public void delete() {
        pairBag.delete();
    }

    public Pair<T1, T2> ret() {
        return pairBag.ret();
    }
}
