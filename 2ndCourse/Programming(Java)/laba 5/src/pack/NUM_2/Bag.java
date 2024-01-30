package pack.NUM_2;

class NUM_2 {
    public static void main(String[] args) {
        Bag bag = new Bag(5);
        Object obj;

        obj = bag.add(true);
        if (obj != null)
            System.out.println(obj + " добавлен");

        obj = bag.add("str");
        if (obj != null)
            System.out.println(obj + " добавлен");

        obj = bag.add(15);
        if (obj != null)
            System.out.println(obj + " добавлен");

        obj = bag.add(1.5);
        if (obj != null)
            System.out.println(obj + " добавлен");

        obj = bag.add(false);
        if (obj != null)
            System.out.println(obj + " добавлен");

        obj = bag.add(3.6);
        if (obj != null)
            System.out.println(obj + " добавлен");

        obj = bag.ret();
        if (obj != null)
            System.out.println(obj + " взят");

        obj = bag.ret();
        if (obj != null)
            System.out.println(obj + " взят");

        obj = bag.ret();
        if (obj != null)
            System.out.println(obj + " взят");

        obj = bag.delete();
        if (obj != null)
            System.out.println(obj + " удален");

        obj = bag.delete();
        if (obj != null)
            System.out.println(obj + " удален");

        obj = bag.delete();
        if (obj != null)
            System.out.println(obj + " удален");

        obj = bag.delete();
        if (obj != null)
            System.out.println(obj + " удален");

        obj = bag.delete();
        if (obj != null)
            System.out.println(obj + " удален");

        obj = bag.delete();
        if (obj != null)
            System.out.println(obj + " удален");

    }
}

public class Bag {
    private final Object[] arr;
    protected int amount;

    public Bag(int length) {
        this.arr = new Object[length];
        this.amount = 0;
    }

    public int getAmount() {
        return this.amount;
    }

    public int getLength() {
        return this.arr.length;
    }

    public boolean isEmpty() {
        return amount == 0;
    }

    public final Object add(Object value) {
        if (this.amount == this.arr.length) {
            System.out.println("не добавлен, т.к. места больше нет");
            return null;
        }
        arr[amount++] = value;
        return value;
    }

    public Object delete() {
        if (amount == 0) {
            System.out.println("Пустой");
            return null;
        }

        int I = (int)(Math.random() * amount);
        Object cur = arr[I];
        for (int i = I; i < amount - 1; i++)
            arr[i] = arr[i + 1];

        arr[--amount] = null;
        return cur;
    }

    public Object ret() {
        if (amount == 0) {
            System.out.println("Рюкзак пустой");
            return null;
        }

        return arr[(int)(Math.random() * amount)];
    }
}

