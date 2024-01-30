package servlets.task3;

import classes.task3.Singer;
import classes.task3.Song;
import jakarta.persistence.*;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.util.List;

@WebServlet(name = "CompanyController2", value = "/CompanyController2")
public class CompanyController2 extends HttpServlet
{
    private static final EntityManagerFactory factory = Persistence.createEntityManagerFactory("Music");


    private static void addToDatabase(Object obj)
    {

        EntityManager manager = factory.createEntityManager();
        EntityTransaction transaction = manager.getTransaction();
        try
        {
            transaction.begin();
            manager.persist(obj);
            transaction.commit();
        }
        finally
        {
            if (transaction.isActive())
            { transaction.rollback(); }

            manager.close();
        }
    }


    private boolean deleteById(Class<?> type, int id)
    {
        EntityManager manager = factory.createEntityManager();
        EntityTransaction transaction = manager.getTransaction();
        boolean res = false;

        try
        {
            transaction.begin();

            Object persistentInstance = manager.find(type, id);
            if (persistentInstance != null)
            {
                manager.remove(persistentInstance);
                res = true;
            }

            transaction.commit();
        }
        finally
        {
            if (transaction.isActive())
            { transaction.rollback(); }

            manager.close();
        }
        return res;
    }


    private static Singer findSinger(String first_name, String second_name)
    {

        
        EntityManager manager = factory.createEntityManager();
        Singer singer = null;
        try
        {
            Query query = manager.createQuery("SELECT a FROM Singer a WHERE a.first_name LIKE '" + first_name + "' AND a.second_name LIKE '" + second_name + "'", Singer.class);
            singer = (Singer) query.getSingleResult();
        }
        catch (NoResultException exep)
        { exep.printStackTrace(); }
        finally
        { manager.close(); }

        return singer;
    }


    private static List<Song> getSongs()
    {
        //создаем строку и получаем песни
        EntityManager manager = factory.createEntityManager();
        Query query = manager.createQuery("SELECT a FROM Song a", Song.class);

        List<Song> list = query.getResultList();
        manager.close();

        return list;
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    { doPost(request,response);}

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException
    {
        request.setCharacterEncoding("UTF-8");
        String chooser = request.getParameter("action");
        request.setAttribute("action",chooser);

        switch (chooser)
        {
            case "View" ->
            {
                List<Song> list_songs = getSongs();

                
                request.setAttribute("list_songs",list_songs);
            }
            case "Add" ->
            {
                String input_name = request.getParameter("field_name");
                String input_singer_first_name = request.getParameter("field_first_name");
                String input_singer_second_name = request.getParameter("field_second_name");

                //ищем певца
                Singer singer = findSinger(input_singer_first_name,input_singer_second_name);
                if (singer == null)
                {
                    //создаем нового,если не нашли
                    System.out.println("There is no such singer");
                    Singer singer_created = new Singer(input_singer_first_name,input_singer_second_name);
                    addToDatabase(singer_created);

                    Song song = new Song(input_name, singer_created);
                    addToDatabase(song);
                }
                else
                {
                    //если нет певца в БД, создается обьект песни с использованием певца
                    Song song = new Song(input_name, singer);
                    addToDatabase(song);
                }
            }
            case "Delete" ->
            {
                String input_id = request.getParameter("field_id");
                boolean flag = deleteById(Song.class,Integer.parseInt(input_id));
                if (flag)
                { System.out.println("The song has been successfully deleted"); }
                else
                { System.out.println("deleteById has failed"); }
            }
        }


        //перенаправляемся на company view,чтобы показать таблицу
        request.getRequestDispatcher("CompanyView2").forward(request,response);
    }
}
