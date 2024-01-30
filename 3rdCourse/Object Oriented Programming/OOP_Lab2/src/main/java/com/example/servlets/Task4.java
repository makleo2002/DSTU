package com.example.servlets;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;
import com.example.entity.ValCurs;
import com.example.entity.Valute;
import com.example.entity.ValCursPeriod;
import com.example.entity.ValutePeriod;
import com.example.entity.MetalCurs;
import com.example.entity.PreciousMetal;


import javax.swing.*;
import java.io.IOException;
import java.io.PrintWriter;
import java.net.URL;

import jakarta.xml.bind.JAXBContext;
import jakarta.xml.bind.JAXBException;
import jakarta.xml.bind.Marshaller;
import jakarta.xml.bind.Unmarshaller;

@WebServlet(name="Servlet4", value="/task4")
public class Task4 extends HttpServlet
{
    private PrintWriter m_writer;

    public ValCurs getCurrencyForOneDay(String date)
    {

        ValCurs temp = null;

        //задаем ссылку на страницу с курсом валют
        String str_url = "http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + date;
        try
        {
            //демаршаллим(преобразуем данные из формата хранения и передачи в формат представления в памяти)
            URL url = new URL(str_url);
            JAXBContext context = JAXBContext.newInstance(ValCurs.class);
            Unmarshaller unmarshaller = context.createUnmarshaller();

            temp = (ValCurs) unmarshaller.unmarshal(url);



        }
        catch (IOException exep)
        { exep.printStackTrace(); }
        catch (JAXBException exep)
        {
            exep.printStackTrace();
            JOptionPane.showMessageDialog(null,"JAXBE error","Error",JOptionPane.ERROR_MESSAGE);
        }

        return temp;
    }

    public void showAllCurrencyForOneDay(ValCurs currency)
    {

        m_writer.println("<html>");
        m_writer.println("<body>");

        m_writer.println("<table style=margin-left:auto;margin-right:auto>");
        m_writer.println("<tr>");
        m_writer.println("<th>Name</th>");
        m_writer.println("<th>Value</th>");
        m_writer.println("</tr>");


        String name, value;

        //выводим информацию о всех валютах
        for (Valute temp : currency.getListValutes())
        {
            name = temp.getName();
            value = temp.getValue();
            m_writer.println("<tr>");
            m_writer.println("<td>" + name + "</td>");
            m_writer.println("<td>" + value + "</td>");
            m_writer.println("</tr>");
        }

        m_writer.println("</table>");
        m_writer.println("</html>");
        m_writer.println("</body>");
    }

    public ValCursPeriod getCurrencyPeriod(String date1, String date2, String id)
    {
        ValCursPeriod temp = null;

        //задаем ссылку на страницу с курсом валют
        String str_url = "http://www.cbr.ru/scripts/XML_dynamic.asp?date_req1=" + date1 + "&date_req2=" + date2 + "&VAL_NM_RQ=" + id;
        try
        {

            URL url = new URL(str_url);

             //демаршаллим данные
            JAXBContext context = JAXBContext.newInstance(ValCursPeriod.class);
            Unmarshaller unmarshaller = context.createUnmarshaller();

            temp = (ValCursPeriod) unmarshaller.unmarshal(url);

        }
        catch (IOException exep)
        { exep.printStackTrace(); }
        catch (JAXBException exep)
        {
            exep.printStackTrace();
            JOptionPane.showMessageDialog(null,"JAXBE error","Error",JOptionPane.ERROR_MESSAGE);
        }

        return temp;
    }

    public void showCurrencyPeriod(ValCursPeriod currency_period)
    {

        m_writer.println("<html>");
        m_writer.println("<body>");

        m_writer.println("<table style=margin-left:auto;margin-right:auto>");
        m_writer.println("<tr>");
        m_writer.println("<th>Date</th>");
        m_writer.println("<th>Value</th>");
        m_writer.println("</tr>");

        //выводим информацию о всех валютах
        String date, value;

        for (ValutePeriod temp : currency_period.getListValutes())
        {
            date = temp.getDate();
            value = temp.getValue();
            m_writer.println("<tr>");
            m_writer.println("<td>" + date + "</td>");
            m_writer.println("<td>" + value + "</td>");
            m_writer.println("</tr>");
        }

        m_writer.println("</table>");
        m_writer.println("</html>");
        m_writer.println("</body>");
    }


    public MetalCurs getMetallsPeriod(String date1, String date2)
    {
        MetalCurs temp = null;

        //задаем ссылку на страницу с курсом валют
        String str_url = "http://www.cbr.ru/scripts/xml_metall.asp?date_req1=" + date1 + "&date_req2=" + date2;
        try
        {
            //демаршаллим данные
            URL url = new URL(str_url);


            JAXBContext context = JAXBContext.newInstance(MetalCurs.class);
            Unmarshaller unmarshaller = context.createUnmarshaller();

            temp = (MetalCurs) unmarshaller.unmarshal(url);

        }
        catch (IOException exep)
        { exep.printStackTrace(); }
        catch (JAXBException exep)
        {
            exep.printStackTrace();
            JOptionPane.showMessageDialog(null,"JAXBE error","Error",JOptionPane.ERROR_MESSAGE);
        }

        return temp;
    }

    public void showMetallPeriod(MetalCurs metals)
    {

        m_writer.println("<html>");
        m_writer.println("<body>");

        m_writer.println("<table style=margin-left:auto;margin-right:auto>");
        m_writer.println("<tr>");
        m_writer.println("<th>Metall</th>");
        m_writer.println("<th>Buy price</th>");
        m_writer.println("<th>Sell price</th>");
        m_writer.println("<th>Date</th>");
        m_writer.println("</tr>");

        //выводим информацию о курсах всех металлов
        for (PreciousMetal temp : metals.getListMetals())
        {
            m_writer.println("<tr>");
            m_writer.println("<td>" + temp.toString() + "</td>");
            m_writer.println("<td>" + temp.getBuyPrice() + "</td>");
            m_writer.println("<td>" + temp.getSellPrice() + "</td>");
            m_writer.println("<td>" + temp.getDate() + "</td>");
            m_writer.println("</tr>");
        }

        m_writer.println("</table>");
        m_writer.println("</html>");
        m_writer.println("</body>");
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    { doPost(request,response); }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        response.setContentType("text/html;charset=UTF-8");
        m_writer = response.getWriter();

        //получаем данные от пользователя из запроса
        String choice = request.getParameter("chooser");
        String input_date1 = request.getParameter("field_date1");
        String input_date2 = request.getParameter("field_date2");
        String input_id = request.getParameter("field_id");

        //выбираем,какую страницу показать
        if (choice.equals("Currency"))//если выбраны котировки валют
        {
            if (input_date2.equals("")) //если поле со 2 датой пусто,то выводим курс валют для одного дня
            {
                ValCurs valutes = getCurrencyForOneDay(input_date1);
                showAllCurrencyForOneDay(valutes);
            }
            else //выводим курс валют для периода
            {
                ValCursPeriod valutes_period = getCurrencyPeriod(input_date1,input_date2,input_id);
                showCurrencyPeriod(valutes_period);
            }
        }
        else //если выбраны котировки металлов
        {
                MetalCurs metalls_period = getMetallsPeriod(input_date1,input_date2);
                showMetallPeriod(metalls_period);
        }

    }
}




