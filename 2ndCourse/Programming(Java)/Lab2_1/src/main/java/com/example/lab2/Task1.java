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

@WebServlet("/task1")
public class Task1 extends HttpServlet {

	public static String reply = "";
	public static int count;
	public static String date;
	public static String login = "";
	public static String password = "";

	public static class User{
		String login;
		String password;

		User(String login, String password){
			this.login = login;
			this.password = password;
		}

		public void checkAkk(String login, String password){
			if(this.login.equals(login)){
				if(this.password.equals(password)){
					reply = "GOod \n" + date;
					count = 3;
				} else {
					count--;
					reply = "NogooD " + count;
				}
			} else {
				count--;
				reply = "NogooD,  " + count;
			}
		}
	}

	@Override
	public void init() throws ServletException {
		count = 3;
		Date temp = new Date();
		SimpleDateFormat date_format = new SimpleDateFormat("EEE MMM dd hh:mm:ss zzz yyyy");
		date_format.setTimeZone(TimeZone.getDefault());
		date = date_format.format(temp);
	}

	@Override
	public void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		PrintWriter pw = resp.getWriter();
		pw.println("dawd");
	}

	@Override
	public void doPost(HttpServletRequest req, HttpServletResponse resp) throws IOException {
		resp.setContentType("text/html");
		resp.setCharacterEncoding("utf-8");
		HttpSession session = req.getSession();
		User user = new User("1", "1");
		PrintWriter pw = resp.getWriter();

		if(count > 0) {
			login = req.getParameter("login");
			password = req.getParameter("password");

			user.checkAkk(login, password);
			pw.println(reply);

		} else {
			pw.println("this is the end");
		}
	}

	public void destroy() {}

}
