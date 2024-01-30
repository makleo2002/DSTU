package servlets.task4;

import classes.task3.Singer;
import classes.task3.Song;
import classes.task4.DatabaseManager;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.util.List;

@WebServlet(name = "CompanyController3", value = "/CompanyController3")
public class CompanyController3 extends HttpServlet
{
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
                List<Song> list_songs = DatabaseManager.getSongs();

                //setting the list as an attribute
                request.setAttribute("list_songs",list_songs);
            }

            case "Add" ->
            {
                String input_name = request.getParameter("field_name");
                String input_singer_first_name = request.getParameter("field_first_name");
                String input_singer_second_name = request.getParameter("field_second_name");

                //trying to find the singer in the database
                Singer singer = DatabaseManager.getSinger(input_singer_first_name,input_singer_second_name);
                if (singer == null)
                {
                    //if there is no such singer, creating a new one and adding them to the database
                    log("There is no such singer");
                    Singer singer_created = new Singer(input_singer_first_name,input_singer_second_name);
                    DatabaseManager.addToDatabase(singer_created);

                    Song song = new Song(input_name, singer_created);
                    DatabaseManager.addToDatabase(song);
                }
                else
                {
                    //if there's such singer in the database, creating a song object using the singer
                    log("The singer has been found");
                    Song song = new Song(input_name, singer);
                    DatabaseManager.addToDatabase(song);
                }
            }

            case "Delete" ->
            {
                String input_id = request.getParameter("field_id");
                boolean flag = DatabaseManager.deleteById(Song.class,Integer.parseInt(input_id));
                if (flag)
                { log("The song has been successfully deleted"); }
                else
                { log("deleteById has failed"); }
            }

            case "Change login" ->
            {
                int input_user_id = Integer.parseInt(request.getParameter("field_user_id"));
                String input_new_login = request.getParameter("field_login");

                DatabaseManager.updateUserLogin(input_user_id,input_new_login);
            }
        }


        //redirecting the request to show the results to the user
        request.getRequestDispatcher("CompanyView3").forward(request,response);
    }
}
