package servlets.task4;

import classes.task3.Song;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

@WebServlet(name = "CompanyView3", value = "/CompanyView3")
public class CompanyView3 extends HttpServlet
{
    private PrintWriter m_writer;


    private void showList(List<Song> list)
    {
        m_writer.println("<html>");
        m_writer.println("<title>List of songs</title>");
        m_writer.println("<body>");
        m_writer.println("<h1 style=color:darkviolet;text-align:center>Your songs</h1>");
        m_writer.println("<table style=margin-left:auto;margin-right:auto>");
        m_writer.println("<tr>");
        m_writer.println("<th>Id</th>");
        m_writer.println("<th>Song name</th>");
        m_writer.println("<th>First Name</th>");
        m_writer.println("<th>Second Name</th>");
        m_writer.println("</tr>");

        for (Song song : list)
        {
            m_writer.println("<tr>");
            m_writer.println("<td style=text-align:center>" + song.getId() + "</td>");
            m_writer.println("<td style=text-align:center>" + song.getSinger().getFirstName() + "</td>");
            m_writer.println("<td style=text-align:center>" + song.getSinger().getSecondName()+ "</td>");
            m_writer.println("<td style=text-align:center>" + song.getName() + "</td>");
            m_writer.println("</tr>");
        }

        m_writer.println("</table>");
        m_writer.println("<br><br>");
        m_writer.println("<button type=button name=back onclick=history.back()>Go back</button>");
       // m_writer.println("<br>");
        m_writer.println("</body>");
        m_writer.println("</html>");}


    private void printMessage(String message)
    {
        m_writer.println("<html>");
        m_writer.println("<title>Message</title>");
        m_writer.println("<body>");

        m_writer.println("<p>" + message + "</p>");
        m_writer.println("<br><br>");

        m_writer.println("<button type=button name=back onclick=history.back()>Go back</button>");
        m_writer.println("</body>");
        m_writer.println("</html>");
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    { doPost(request,response); }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        response.setContentType("text/html;charset=UTF-8");
        m_writer = response.getWriter();

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

            case "Change login" -> printMessage("The login has been changed");
        }
    }
}
