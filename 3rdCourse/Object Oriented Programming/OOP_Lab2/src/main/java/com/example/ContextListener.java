package com.example;

import com.example.entity.User;
import com.example.entity.UserList;

import jakarta.servlet.ServletContext;
import jakarta.servlet.ServletContextEvent;
import jakarta.servlet.ServletContextListener;
import jakarta.servlet.annotation.WebListener;
import java.util.concurrent.atomic.AtomicReference;

import static com.example.entity.User.Role.ADMIN;
import static com.example.entity.User.Role.USER;


@WebListener
public class ContextListener implements ServletContextListener {
    private AtomicReference<UserList> db;

    @Override
    public void contextInitialized(ServletContextEvent servletContextEvent) {

        db = new AtomicReference<>(new UserList());

        db.get().add(new User(1, "Maxim", "12345", ADMIN));
        db.get().add(new User(2, "Andrey", "123", USER));

        final ServletContext servletContext =
                servletContextEvent.getServletContext();

        servletContext.setAttribute("db", db);
    }

    @Override
    public void contextDestroyed(ServletContextEvent sce) {
        db = null;
    }
}