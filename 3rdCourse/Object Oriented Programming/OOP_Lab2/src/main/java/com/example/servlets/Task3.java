package com.example.servlets;

import java.io.*;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.TimeZone;
import java.util.concurrent.atomic.AtomicReference;

import com.example.entity.User;
import com.example.entity.UserList;
import jakarta.servlet.*;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.*;


import static java.util.Objects.nonNull;



@WebServlet(name="Servlet3", value = "/task3")
public class Task3 extends HttpServlet {
    public static String date;

    public static int count=0;


    private void moveToMenu(final HttpServletRequest req,
                            final HttpServletResponse res,
                            final User.Role role)
            throws ServletException, IOException {


        if (role.equals(User.Role.ADMIN)) {
            req.setAttribute("date", date);
            req.setAttribute("count", count);
            if(count<=3) req.getRequestDispatcher("/WEB-INF/view/Task3/admin_menu.jsp").forward(req, res);
            else req.getRequestDispatcher("/WEB-INF/view/Task3/error_page.jsp").forward(req, res);

        } else if (role.equals(User.Role.USER)) {
            req.setAttribute("date", date);
            req.setAttribute("count", count);
            if(count<=3)  req.getRequestDispatcher("/WEB-INF/view/Task3/user_menu.jsp").forward(req, res);
            else req.getRequestDispatcher("/WEB-INF/view/Task3/error_page.jsp").forward(req, res);
        } else {
            count++;
            if(count<=3){
                req.setAttribute("date", date);
                req.setAttribute("count", count);
                req.getRequestDispatcher("/WEB-INF/view/Task3/unknown_menu.jsp").forward(req, res);
            }
            if(count>3){
                req.getRequestDispatcher("/WEB-INF/view/Task3/error_page.jsp").forward(req, res);
            }

        }
    }

    @Override
    public void init(ServletConfig sc) {
        SimpleDateFormat date_format = new SimpleDateFormat("EEE MMM dd hh:mm:ss zzz yyyy");
        date_format.setTimeZone(TimeZone.getDefault());
        date = date_format.format(new Date());
    }
    public void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException,IOException {


        final HttpSession session = req.getSession();

        res.setContentType("text/html");
        res.setCharacterEncoding("utf-8");

        final String login = req.getParameter("login");
        final String password = req.getParameter("password");

        @SuppressWarnings("unchecked")
        final AtomicReference<UserList> db = (AtomicReference<UserList>) req.getServletContext().getAttribute("db");


        //Logged user.
        if (nonNull(session) &&
                nonNull(session.getAttribute("login")) &&
                nonNull(session.getAttribute("password"))) {

            final User.Role role = (User.Role) session.getAttribute("role");

            moveToMenu(req, res, role);


        } else if (db.get().userIsExist(login, password)) {
            final User.Role role = db.get().getRoleByLoginPassword(login, password);

            req.getSession().setAttribute("password", password);
            req.getSession().setAttribute("login", login);
            req.getSession().setAttribute("role", role);

            moveToMenu(req, res, role);

        } else {

            moveToMenu(req, res, User.Role.UNKNOWN);
        }

        session.removeAttribute("password");
        session.removeAttribute("login");
        session.removeAttribute("role");
        SimpleDateFormat date_format = new SimpleDateFormat("EEE MMM dd hh:mm:ss zzz yyyy");
        date_format.setTimeZone(TimeZone.getDefault());
        date = date_format.format(new Date());
    }
    @Override
    public void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException,IOException {
        final HttpSession session = req.getSession();


        res.setContentType("text/html");
        res.setCharacterEncoding("utf-8");


        final String login = req.getParameter("login");
        final String password = req.getParameter("password");

        @SuppressWarnings("unchecked")
        final AtomicReference<UserList> db = (AtomicReference<UserList>) req.getServletContext().getAttribute("db");



        if (nonNull(session) &&
                nonNull(session.getAttribute("login")) &&
                nonNull(session.getAttribute("password"))) {

            final User.Role role = (User.Role) session.getAttribute("role");

            moveToMenu(req, res, role);


        } else if (db.get().userIsExist(login, password)) {
            final User.Role role = db.get().getRoleByLoginPassword(login, password);

            req.getSession().setAttribute("password", password);
            req.getSession().setAttribute("login", login);
            req.getSession().setAttribute("role", role);

            moveToMenu(req, res, role);

        } else {
            moveToMenu(req, res, User.Role.UNKNOWN);
        }


        session.removeAttribute("password");
        session.removeAttribute("login");
        session.removeAttribute("role");
        SimpleDateFormat date_format = new SimpleDateFormat("EEE MMM dd hh:mm:ss zzz yyyy");
        date_format.setTimeZone(TimeZone.getDefault());
        date = date_format.format(new Date());

    }
    public void destroy() {
    }
}