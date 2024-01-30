package com.example.Entity;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.io.PrintWriter;
import java.io.Serializable;
import java.util.Random;

@WebServlet(name = "Tic_tac_toe", value = "/task2")
public class GameServlet extends HttpServlet implements Serializable {

    PrintWriter writer;
    final char X = 'x';
    final char O= 'o';
    final char Empty = '.';
    char[][] table;
    Random random;

    void initTable() {
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                table[row][col] = Empty;
    }

    void printTable( ) {
        writer.println("<!DOCTYPE html>");
        writer.println("</html>");
        writer.println("<head>\n" +
                "    <meta charset=\"UTF-8\">\n" +
                "    <title>Tic-Tac-Toe</title>\n" +
                "    <style>\n" +
                "        table {\n" +
                "            width: 80%;\n" +
                "            height: 80%;\n" +
                "            background: gray;\n" +
                "            color: gray; \n" +
                "            border-spacing: 5px; \n" +
                "            font-size: 200px;\n"+
                "            text-align: center;\n"+
                "        }\n" +
                "        td{\n" +
                "            height:200px;\n" +
                "            background: darkgray; \n" +
                "            padding: 5px; \n" +
                        "        }\n"+
                "    </style>\n" +
                "</head>");
        writer.println("<body>");
        writer.println("<table>");
        writer.println("<tbody>");
        for (int row = 0; row < 3; row++) {
            writer.println("<tr>");
            for (int col = 0; col < 3; col++){
                if(table[row][col]==X)  writer.println(" <td> <font  color=\"red\"/>"+ table[row][col] + "</td>");
                else if(table[row][col]==O) writer.println(" <td> <font   color=\"green\"/>"+ table[row][col] + "</td>");
                else writer.println(" <td> "+ table[row][col] + "</td>");
            }
            writer.println("</tr>");
        }
        writer.println("</tbody>");
        writer.println("</table>");
        writer.println("<form action=\"http://localhost:8080/OOP_Lab3_war/task2\" method = \"POST\">\n" +
                "    <br>Enter cell number(column, row).<br><br>\n" +
                "    <br>Column      <input type=\"text\"  name=\"column\"/><br><br>\n" +
                "    <br>Row     <input type=\"text\"  name=\"row\"/><br><br>\n" +
                "    <input type=\"submit\" value=\"Submit\">\n" +
                "</form>");
        writer.println("</body>");
        writer.println("</html>");
    }

    void turnHuman(HttpServletRequest request)  {
        int x, y;
        do {
           x= Integer.parseInt(request.getParameter("column"))-1;
           y= Integer.parseInt(request.getParameter("row"))-1;
        } while (!isCellCorrect(x, y));
        table[x][y] = X;
    }

    boolean isCellCorrect(int x, int y) {
        if (x < 0 || y < 0 || x >= 3|| y >= 3)
            return false;
        return table[x][y] == Empty;
    }

    void turnAI() {
        int x, y;
        do {
            x = random.nextInt(3);
            y = random.nextInt(3);
        } while (!isCellCorrect(x, y));

       if(!isTableFull()) table[x][y] = O;
    }
    boolean checkWin(char d) {
        for (int i = 0; i < 3; i++)
            if ((table[i][0] == d && table[i][1] == d &&
                    table[i][2] == d) ||
                    (table[0][i] == d && table[1][i] == d &&
                            table[2][i] == d))
                return true;
        if ((table[0][0] == d && table[1][1] == d &&
                table[2][2] == d) ||
                (table[2][0] == d && table[1][1] == d &&
                        table[0][2] == d))
            return true;
        return false;
    }
   private boolean isTableFull() {
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                if (table[row][col] == Empty)
                    return false;
        return true;
    }

    @Override
    public void init(ServletConfig sc) {
        random = new Random();
        table = new char[3][3];
        initTable();
    }
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html");
        response.setCharacterEncoding("utf-8");
        writer=response.getWriter();
        request.removeAttribute("column");
        request.removeAttribute("row");
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html");
        response.setCharacterEncoding("utf-8");
        writer=response.getWriter();

            turnHuman(request);
            turnAI();
            printTable();

               if (isTableFull()&&!checkWin(X)&&!checkWin(O)) {
                request.getRequestDispatcher("/html/draw.html").forward(request, response);
                }

                if (checkWin(X)) {
                    request.getRequestDispatcher("/html/humanWin.html").forward(request, response);
                }
                if (checkWin(O)) {
                    request.getRequestDispatcher("/html/AI_win.html").forward(request, response);
                }
    }
}
