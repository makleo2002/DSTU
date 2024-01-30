package lab5.competition;
import lab5.g_pair_bag.GenericPairBag;
import lab5.pairbag.*;
import java.util.Scanner;

public class Competition {

    private Bag m_bag;
    private GenericPairBag<String>  m_pair_bag;
    private int m_initial_number_teams;
    private int m_current_number_teams;

    private static final int m_default_number_teams = 4;

    public Competition(int number_teams)        //check in number_teams in constructor
    {
        if ((number_teams & (number_teams - 1)) == 0)       //check if the number is a power of 2
        {
            m_initial_number_teams = number_teams;          //if it is, set that number of teams
        }
        else
        {
            number_teams =  m_default_number_teams;
            m_initial_number_teams = number_teams;
            System.out.println("The number of teams should be a power of two. The default number of teams " + number_teams + " was set");
        }
        m_current_number_teams = m_initial_number_teams;
        m_bag = new Bag(number_teams);
        m_pair_bag = new GenericPairBag<>();
    }

    public void fillBag()
    {
        String str = "Team";
        for (int i = 0; i < m_initial_number_teams; i++)
        {
            int num = i + 1;
            m_bag.addItem(str + num);
        }
    }

    public void fillPairBag()
    {
        Pair temp;
        while (!m_bag.isEmpty())
        {
            temp = new Pair<>(m_bag.deleteItem(), m_bag.deleteItem());
            m_pair_bag.addItem(temp);
        }
    }

    public String chooseTheWinner()
    {
        Scanner keyboard = new Scanner(System.in);
        Pair<String,String> temp;
        int numb = 0;

        do
        {
            fillPairBag();
            while (!m_pair_bag.isEmpty()) {
                System.out.println("What team shall win (1 or 2)?");
                temp = m_pair_bag.deleteItem();
                m_current_number_teams--;

                switch (numb = keyboard.nextInt()) {
                    case 1 -> m_bag.addItem(temp.getValue1());
                    case 2 -> m_bag.addItem(temp.getValue2());
                    default -> System.out.println("There is no team with this number. Please try again");
                }
            }
        } while (m_current_number_teams >= 2);

        return (String) m_bag.deleteItem();
    }

    public static void main(String[] args)
    {
        Scanner in = new Scanner(System.in);
        System.out.println("Please enter the number of teams. It should be more than 1");
        int num_teams = in.nextInt();
        Competition test_comp = new Competition(num_teams);

        test_comp.fillBag();
        String winner = test_comp.chooseTheWinner();

        System.out.println("The winner is " + winner);
    }
}
