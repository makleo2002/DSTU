package com.example.task5;
import com.example.entity.*;
import jakarta.xml.bind.JAXBContext;
import jakarta.xml.bind.JAXBException;
import jakarta.xml.bind.Unmarshaller;

import javax.swing.*;
import java.io.IOException;
import java.net.URL;
import java.util.List;


public class DataGetter
{
    public static List<Valute> getCurrencyOneDay(String date)
    {

        ValCurs temp = null;

        //задаем ссылку на страницу с курсом валют
        String str_url = "http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + date;
        try
        {
            //демаршаллим данные
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

        //если темп равен null, то выбросится исключение
        assert temp != null;
        return temp.getListValutes();//возвращаем список валют
    }


    public static List<ValutePeriod> getCurrencyPeriod(String date1, String date2, String id)
    {
        ValCursPeriod temp = null;

        //задаем ссылку на страницу с курсом валют
        String str_url = "http://www.cbr.ru/scripts/XML_dynamic.asp?date_req1=" + date1 + "&date_req2=" + date2 + "&VAL_NM_RQ=" + id;
        try
        {
            //демаршаллим данные
            URL url = new URL(str_url);


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

       //если темп равен null, то выбросится исключение
        assert temp != null;
        return temp.getListValutes();//получаем список дат для валют
    }


    public static List<PreciousMetal> getMetallsPeriod(String date1, String date2)
    {
        MetalCurs temp = null;

        //если темп равен null, то выбросится исключение

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

        //если темп равен null, то выбросится исключение
        assert temp != null;
        return temp.getListMetals();//получаем список металлов
    }
}
