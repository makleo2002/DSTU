package servlets.task3;

import classes.task3.Song;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

@WebServlet(name = "CompanyView2", value = "/CompanyView2")
public class CompanyView2 extends HttpServlet
{
    private PrintWriter writer;


    private void showList(List<Song> list)
    {
        writer.println("<html>");
        writer.println("<title>List of songs</title>");
        writer.println("<body>");
        writer.println("<h1 style=color:darkviolet;text-align:center>Your songs</h1>");
        writer.println("<table style=margin-left:auto;margin-right:auto>");
        writer.println("<tr>");
        writer.println("<th>Id</th>");
        writer.println("<th>Song name</th>");
        writer.println("<th>First Name</th>");
        writer.println("<th>Second Name</th>");
        writer.println("</tr>");

        for (Song song : list)
        {
            writer.println("<tr>");
            writer.println("<td style=text-align:center>" + song.getId() + "</td>");
            writer.println("<td style=text-align:center>" + song.getSinger().getFirstName() + "</td>");
            writer.println("<td style=text-align:center>" + song.getSinger().getSecondName()+ "</td>");
            writer.println("<td style=text-align:center>" + song.getName() + "</td>");
            writer.println("</tr>");
        }

        writer.println("</table>");
        writer.println("<br><br>");
        writer.println("<a href = http://localhost:8080/OOP_Lab4_war/>Go back</a>");
        writer.println("</html>");
        writer.println("</body>");
    }


    private void printMessage(String message)
    {
        writer.println("<html>");
        writer.println("<title>Message</title>");
        writer.println("<body>");

        writer.println("<p>" + message + "</p>");

        writer.println("<a href = http://localhost:8080/OOP_Lab4_war/>Go back</a>");
        writer.println("</html>");
        writer.println("</body>");
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    { doPost(request,response); }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        response.setContentType("text/html;charset=UTF-8");
        writer = response.getWriter();

        String chooser = request.getParameter("action");
        switch(chooser)
        {
            case "View" ->
            {
                List<Song> list_songs = (List<Song>) request.getAttribute("list_songs");
                showList(list_songs);
            }

            case "Add" -> printMessage("A new song has been added");

            case "Delete" -> printMessage("The song has been deleted");
        }
    }
}
