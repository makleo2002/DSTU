package servlets.task1;

import classes.task1.Configuration;
import classes.task1.Product;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.xml.bind.JAXBContext;
import jakarta.xml.bind.JAXBException;
import jakarta.xml.bind.Unmarshaller;

import javax.swing.*;
import java.io.File;
import java.io.IOException;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;

@WebServlet(name = "CompanyController1", value = "/CompanyController1")
public class CompanyController1 extends HttpServlet
{
    private String name_db;
    private String url1;
    private String url2;
    private String user;
    private String password;

    private File xml;

    //Демаршаллим xml
    private Configuration readXml()
    {
        Configuration temp = null;
        try
        {
            JAXBContext context = JAXBContext.newInstance(Configuration.class);
            Unmarshaller unmarshaller = context.createUnmarshaller();
            temp = (Configuration) unmarshaller.unmarshal(xml);
        }
        catch (JAXBException exep)
        {
            exep.printStackTrace();
            JOptionPane.showMessageDialog(null,"JAXBE error","Error",JOptionPane.ERROR_MESSAGE);
        }

        assert temp != null;
        return temp;
    }


    @Override
    public void init()
    {
        //читаем хмл файл и заполняем строки
        xml= new File("C:/Users/Максим/IdeaProjects/OOP_Lab4/src/main/webapp/xml/task2_conf.xml");
        Configuration config = readXml();

        name_db = config.getNameDb();
        url1 = config.getUrl1();
        url2 = config.getUrl2();
        user = config.getUser();
        password = config.getPassword();
        
    }

// Создаем БД
    private Connection createDatabase()
    {
        Connection conn = null;
        try
        {
            //устанавливаем подключение
            conn = DriverManager.getConnection(url2,user,password);

            //создание БД
            Statement st = conn.createStatement();
            st.executeUpdate("CREATE DATABASE " + name_db);
            st.close();

            //создаем таблицы
            conn = DriverManager.getConnection(url2 + name_db,user,password);
            Statement st_new_db = conn.createStatement();
            st_new_db.executeUpdate(
                    "CREATE TABLE Categories" +
                    "(id integer PRIMARY KEY NOT NULL," +
                    "name varchar(50) NULL)");

            st_new_db.executeUpdate(
                    "CREATE TABLE Products" +
                            "(Id integer PRIMARY KEY NOT NULL," +
                            "Name varchar(50)  NULL," +
                            "Id_Manufacturer integer  NOT NULL," +
                            "Id_Category integer NOT NULL ," +
                            "Price integer ,"+
                            "Id_Store integer  NOT NULL)");

            st_new_db.executeUpdate(
                    "CREATE TABLE Manufacturers" +
                            "(Id integer PRIMARY KEY NOT NULL," +
                            "Name varchar(50) NULL)");

            st_new_db.executeUpdate(
                    "CREATE TABLE Stores" +
                            "(Id integer PRIMARY KEY NOT NULL," +
                            "Name varchar(50) NULL)");

            st_new_db.close();
        }
        catch (SQLException exep)
        {
            exep.printStackTrace();
            System.out.println("Database creating has failed");
        }

        return conn;
    }


    //подключение к BD
    private Connection getConnection()
    {

        Connection connection = null;

        try
        {
            //подключение по первой ссылке
           connection = DriverManager.getConnection(url1,user,password);
        }
        catch (SQLException exep)
        {
            exep.printStackTrace();
            System.out.println("Getting Connection has failed.");

            //создать БД,если подключение не прошло
            connection = createDatabase();
        }
        return connection;

    }

    //считываем таблицу продуктов и создаем список
    private List<Product> getProducts()
    {
        List<Product> list_temp = new ArrayList<>();
        try (Connection connection = getConnection())
        {
            String query = "SELECT * FROM Products";
            int id_temp, category_id_temp, manufacturer_id_temp,price_temp,store_id_temp;
            String name_temp = null;
            try (PreparedStatement statement = connection.prepareStatement(query); ResultSet result = statement.executeQuery())
            {
                //читаем данные с таблицы
                while (result.next())
                {
                    id_temp = result.getInt("Id");
                    name_temp = result.getString("Name");
                    manufacturer_id_temp = result.getInt("Id_Manufacturer");
                    category_id_temp = result.getInt("Id_Category");
                    price_temp = result.getInt("Price");
                    store_id_temp = result.getInt("Id_Store");



                    //создаем обьекты и доавбляем в список
                    list_temp.add(new Product(id_temp,name_temp,manufacturer_id_temp,category_id_temp,price_temp,store_id_temp));
                }
            }
            catch (SQLException exep)
            { exep.printStackTrace(); }
        }
        catch (SQLException exep)
        { exep.printStackTrace(); }

        return list_temp;
    }


    private int addProductToDatabase(String name,int id_manufacturer,int id_category, int price,int id_store )
    {
        int id_generated = 0;
        String query = "INSERT INTO Products(name,id_manufacturer,id_category,price,id_store) VALUES(?,?,?,?,?)";


        try (Connection connection = getConnection();
             PreparedStatement statement = connection.prepareStatement(query,Statement.RETURN_GENERATED_KEYS))
        {
            //устанавливаем значения
            //вставляем данные в строку вместо ?
            statement.setString(1,name);
            statement.setInt(2,id_manufacturer);
            statement.setInt(3,id_category);
            statement.setInt(4,price);
            statement.setInt(5,id_store);


            //executing the query
            int affected_rows = statement.executeUpdate();
            if (affected_rows > 0)
            {
                try (ResultSet result = statement.getGeneratedKeys())
                {
                    if (result.next())
                    { id_generated = result.getInt(1); }
                }
                catch (SQLException exep)
                { exep.printStackTrace(); }
            }
        }
        catch (SQLException exep)
        { exep.printStackTrace(); }

        return id_generated;
    }


    private int updateProductNameAndPrice(int id, String name,int price)
    {
        int affected_rows = 0;
        //Обновляем имя и цену продукта
        String query = "UPDATE Products SET name = ? WHERE id = ?  ";
        String query1 = "UPDATE Products SET Price = ? WHERE id = ?  ";

        try (Connection connection = getConnection(); PreparedStatement statement = connection.prepareStatement(query))
        {
            statement.setString(1,name);
            statement.setInt(2,id);

            affected_rows = statement.executeUpdate();
        }
        catch (SQLException exep)
        { exep.printStackTrace(); }

        try (Connection connection = getConnection(); PreparedStatement statement = connection.prepareStatement(query1))
        {
            statement.setInt(1,price);
            statement.setInt(2,id);
            affected_rows = statement.executeUpdate();
        }
        catch (SQLException exep)
        { exep.printStackTrace(); }

        return affected_rows;
    }


    private int deleteProduct(int id)
    {
       int affected_rows = 0;
       //Удаляем продукт
       String query = "DELETE FROM Products WHERE id = ?";

        try (Connection connection = getConnection(); PreparedStatement statement = connection.prepareStatement(query))
        {
            statement.setInt(1,id);
            affected_rows = statement.executeUpdate();
        }
        catch (SQLException exep)
        { exep.printStackTrace(); }

        return affected_rows;
    }


    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    { doPost(request,response);}

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        request.setCharacterEncoding("UTF-8");
        String chooser = request.getParameter("action");
        request.setAttribute("action",chooser);

        switch(chooser)
        {
            //вывод таблицы
            case "View" ->
            {
                List<Product> list_products = getProducts();
                //перенаправляем запрос на CompanyView1
                request.setAttribute("list_products", list_products);
            }
            case "Add" ->
            {
                //получение данных с формы
                String input_id_category = request.getParameter("field_id_category");
                String input_id_manufacturer = request.getParameter("field_id_manufacturer");
                String input_name = request.getParameter("field_product_name");
                String input_price = request.getParameter("field_price");
                String input_id_store = request.getParameter("field_id_store");

                //добавляем строку в таблицу
                int id_new_product = addProductToDatabase(input_name,Integer.parseInt(input_id_manufacturer),Integer.parseInt(input_id_category),
                        Integer.parseInt(input_price) ,Integer.parseInt(input_id_store));


            }
            case "Update" ->
            {
                //получение данных с формы
                String input_id = request.getParameter("field_id");
                String input_name = request.getParameter("field_product_name");
                String input_price = request.getParameter("field_price");

                //изменяем продукт
                int number_affected_rows = updateProductNameAndPrice(Integer.parseInt(input_id),input_name,Integer.parseInt(input_price));


            }
            case "Delete" ->
            {
                //получение данных с формы
                String input_id = request.getParameter("field_id");

                //удаляем продукт
                int number_affected_rows = deleteProduct(Integer.parseInt(input_id));

            }
        }

        //показываем результаты
           request.getRequestDispatcher("CompanyView1").forward(request,response);
    }
}
