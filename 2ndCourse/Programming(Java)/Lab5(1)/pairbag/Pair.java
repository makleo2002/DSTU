package lab5.pairbag;

public class Pair<T1,T2> {
    private T1 m_value1;
    private T2 m_value2;

    public Pair(T1 value1, T2 value2)
    {
        m_value1 = value1;
        m_value2 = value2;
    }

    public void setValue1(T1 val) { m_value1 = val; }

    public void setValue2(T2 val) { m_value2 = val; }

    public T1 getValue1() { return m_value1; }

    public T2 getValue2() { return m_value2; }

    public static <T1,T2> Pair make_pair(T1 val1,T2 val2) { return new Pair(val1,val2); }

    public static void main(String[] args) {

        Pair test_pair = Pair.make_pair(1,"d");

        Pair<Integer,Double> test_pair2 = new Pair<>(32,4.2);

        System.out.println("Value1: " + test_pair.getValue1());
        System.out.println("Value2: " + test_pair.getValue2());
    }
}
