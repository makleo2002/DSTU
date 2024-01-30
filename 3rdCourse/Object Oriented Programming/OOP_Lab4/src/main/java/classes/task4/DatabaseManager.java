package classes.task4;

import classes.task3.Singer;
import classes.task3.Song;
import jakarta.persistence.*;

import java.util.List;


public class DatabaseManager
{
    private static final EntityManagerFactory m_factory = Persistence.createEntityManagerFactory("Music");



    public static void addToDatabase(Object obj)
    {
        EntityManager manager = m_factory.createEntityManager();
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


    public static boolean deleteById(Class<?> type, int id)
    {
        EntityManager manager = m_factory.createEntityManager();
        EntityTransaction transaction = manager.getTransaction();
        boolean res = false;

        try
        {
            transaction.begin();
            //находим обьект  по айди
            Object persistentInstance = manager.find(type, id);
            if (persistentInstance != null)
            {
                //удаляем если нашелся
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


    public static void updateUserLogin(int user_id, String new_login)
    {
        EntityManager manager = m_factory.createEntityManager();
        EntityTransaction transaction = manager.getTransaction();

        try
        {
            //находим обьект по айди в БД
            SimpleUser user_obj = manager.find(SimpleUser.class,user_id);

            transaction.begin();

            //меняем логин юзера
            user_obj.setLogin(new_login);
            manager.merge(user_obj);

            transaction.commit();
        }
        finally
        {
            if (transaction.isActive())
            { transaction.rollback(); }

            manager.close();
        }
    }


    public static List<Song> getSongs()
    {
        //получаем с помощью SQL запроса песни
        EntityManager manager = m_factory.createEntityManager();
        Query query = manager.createQuery("SELECT a FROM Song a", Song.class);

        List<Song> list = query.getResultList();
        manager.close();

        return list;
    }


    public static Singer getSinger(String first_name, String second_name)
    {
        EntityManager manager = m_factory.createEntityManager();
        Singer singer = null;
        try
        {
            //получаем певца с данным именем и фамилией
            Query query = manager.createQuery("SELECT a FROM Singer a WHERE a.first_name LIKE '" + first_name + "' AND a.second_name LIKE '" + second_name + "'", Singer.class);
            singer = (Singer) query.getSingleResult();
        }
        catch (NoResultException exep)
        { exep.printStackTrace(); }
        finally
        { manager.close(); }

        return singer;
    }


    public static SimpleUser getUser(String login, String password)
    {
        //creating a query and getting results
        EntityManager manager = m_factory.createEntityManager();
        SimpleUser user = null;
        try
        {
            //Получаем юзера с данным логином и хешкодом
            Query query = manager.createQuery("SELECT a FROM SimpleUser a WHERE a.login LIKE '" + login + "' AND a.password  LIKE '" + password +"'", SimpleUser.class);
            user = (SimpleUser) query.getSingleResult();
        }
        catch (NoResultException exep)
        { exep.printStackTrace(); }
        finally
        { manager.close(); }

        return user;
    }


    public static Admin getAdmin(String login, String password)
    {
        //creating a query and getting results
        EntityManager manager = m_factory.createEntityManager();
        Admin admin = null;
        try
        {
            //Получаем админа с данным логином и хешкодом
            Query query = manager.createQuery("SELECT a FROM Admin a WHERE a.login LIKE '" + login + "' AND a.password LIKE '" + password +"'", Admin.class);
            admin = (Admin) query.getSingleResult();
        }
        catch (NoResultException exep)
        { exep.printStackTrace(); }
        finally
        { manager.close(); }

        return admin;
    }
}
