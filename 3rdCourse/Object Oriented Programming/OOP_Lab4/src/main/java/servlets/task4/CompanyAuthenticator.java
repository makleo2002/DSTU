package servlets.task4;

import classes.task4.Admin;
import classes.task4.DatabaseManager;
import classes.task4.SimpleUser;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;


@WebServlet(name = "CompanyAuthenticator", value = "/CompanyAuthenticator")
public class CompanyAuthenticator extends HttpServlet
{

    private boolean authenticateUser(String login, String password)
    {

        SimpleUser user = DatabaseManager.getUser(login,password);

        if (user != null)
        { return true; }

        return false;
    }


    private boolean authenticateAdmin(String login, String password)
    {
     
        Admin admin = DatabaseManager.getAdmin(login,password);


        if (admin != null)
        { return true; }

        return false;
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    { doPost(request,response); }


    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        request.setCharacterEncoding("UTF-8");

     
        String input_login = request.getParameter("field_login");
        String input_password = request.getParameter("field_password");


        if (authenticateUser(input_login,input_password))
        {
           
            request.getRequestDispatcher("jsp/task4_user_menu.jsp").forward(request,response);
            System.out.println("The user has been authenticated");
        }
        else if (authenticateAdmin(input_login,input_password))
        {
            request.getRequestDispatcher("jsp/task4_admin_menu.jsp").forward(request,response);
            System.out.println("The admin has been authenticated");
        }
        else
        {
            response.getWriter().println("Authentication error");
            System.out.println("Authentication has failed");
        }
    }
}
