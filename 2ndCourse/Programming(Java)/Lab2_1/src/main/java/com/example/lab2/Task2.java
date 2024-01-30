package com.example.lab2;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;

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
	public void init() throws ServletException {
		count = 0;
	}

	@Override
	public void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		resp.setContentType("text/html");
		resp.setCharacterEncoding("utf-8");
		HttpSession session = req.getSession();
		Date time_Create = new Date(session.getCreationTime());
		count++;

		String input = req.getParameter("contact");
		switch (input){
			case "1":
				reply = "User ID: " + session.getId() + ", Time of creation: " + time_Create;
				break;
			case "2":
				Date temp = new Date();
				SimpleDateFormat date_format = new SimpleDateFormat("EEE MMM dd hh:mm:ss zzz yyyy");
				date_format.setTimeZone(TimeZone.getDefault());
				date = date_format.format(temp);
				reply = "Date: " + date;
				break;
			case "3":
				reply = "Count: " + count;
				break;
		}

		PrintWriter pw = resp.getWriter();
		pw.println(reply);

	}
}
