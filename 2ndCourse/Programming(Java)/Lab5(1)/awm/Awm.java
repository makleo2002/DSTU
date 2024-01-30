package lab5.awm;
import sorting_algorithms.Sorting_Algorithms;
import java.util.ArrayList;
import java.util.Arrays;

public class Awm {

    private Integer[] m_arr_coins;

    public Awm(Integer[] arr_coins)
    {
        m_arr_coins = arr_coins;
    }

    public ArrayList<Integer> GetMoneySet(int amount_money)
    {
        int sum = 0;
        ArrayList<Integer> arr_coins = new ArrayList<>();

        Arrays.sort(m_arr_coins);

        System.out.println("After sorting: ");
        System.out.println(Arrays.toString(m_arr_coins));

        for (int j = m_arr_coins.length - 1; j >= 0; j--)
        {
            if (sum + m_arr_coins[j] <= amount_money)
            {
                sum += m_arr_coins[j];
                arr_coins.add(m_arr_coins[j]);
            }
        }
        return arr_coins;
    }

    public static void main(String[] args)
    {
        Integer[] arr = {5,2,1,10};
        System.out.println("Before sorting: ");
        System.out.println(Arrays.toString(arr));

        Awm awm_obj = new Awm(arr);
        int amount_m = 13;

        ArrayList<Integer> arr1 = awm_obj.GetMoneySet(amount_m);
        for (Integer v : arr1)
        { System.out.print(v + " "); }
        System.out.println();
    }
}
