package com.example.servlets;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.io.PrintWriter;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.TimeZone;

@WebServlet("/task2")
public class Task2 extends HttpServlet {

    public static String reply;
    public static String date;
    public static int count;

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {

        res.setContentType("text/html");
        res.setCharacterEncoding("utf-8");
        HttpSession session = req.getSession();
        Date time = new Date(session.getCreationTime());
        count++;

    String param=req.getParameter("contact");
    switch (param){
        case "1":
            reply = "Session ID: " + session.getId() + ", Time of creation: " + time;
            break;
        case "2":
            Date temp = new Date();
            SimpleDateFormat date_format = new SimpleDateFormat("EEE MMM dd hh:mm:ss zzz yyyy");
            date_format.setTimeZone(TimeZone.getDefault());
            date = date_format.format(temp);
            reply = "Date: " + date;
            break;
        case "3":
            reply = "Count: " + (count);
            break;
    }



        PrintWriter pw = res.getWriter();
        pw.println(reply);

    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {

    }

}

