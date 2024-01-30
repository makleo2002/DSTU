package servlets.task1;

import classes.task1.Product;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

@WebServlet(name = "CompanyView1", value = "/CompanyView1")
public class CompanyView1 extends HttpServlet
{
    private PrintWriter writer;


    //выводим страницу с таблицей
    private void showList(List<Product> list)
    {
        writer.println("<html>");
        writer.println("<title>List of products</title>");
        writer.println("<body>");
        writer.println("<h1 style=color:darkviolet;text-align:center>Your products</h1>");
        writer.println("<table style=margin-left:auto;margin-right:auto>");
        writer.println("<tr>");
        writer.println("<th>Id</th>");
        writer.println("<th>Name</th>");
        writer.println("<th>Category Id</th>");
        writer.println("<th>Manufacturer Id</th>");
        writer.println("<th>Price Id</th>");
        writer.println("</tr>");

        for (Product product : list)
        {
            writer.println("<tr>");
            writer.println("<td style=text-align:center>" + product.getId() + "</td>");
            writer.println("<td style=text-align:center>" + product.getName() + "</td>");
            writer.println("<td style=text-align:center>" + product.categoryIdToString() + "</td>");
            writer.println("<td style=text-align:center>" + product.manufacturerIdToString() + "</td>");
            writer.println("<td style=text-align:center>" + product.getPrice() + "</td>");
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
                List<Product> list_products = (List<Product>) request.getAttribute("list_products");
                showList(list_products);
            }

            case "Add" -> printMessage("A new item has been added");

            case "Update" -> printMessage("A row has been updated");

            case "Delete" -> printMessage("An item has been deleted");
        }
    }
}
