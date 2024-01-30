package com.example.Entity;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

@WebServlet(name = "InfoSystem", value = "/task1")
public class InfoSystem extends HttpServlet implements Serializable {
     protected static String xml;
     protected static Document dom;
     protected static PrintWriter m_writer;

     static List<Song> songs;

    private String getTextValue(String def, Element doc, String tag)
    {
        String value = def;
        NodeList nl;
        nl = doc.getElementsByTagName(tag);
        if (nl.getLength() > 0 && nl.item(0).hasChildNodes()) {
            value = nl.item(0).getFirstChild().getNodeValue();
        }
        return value;
    }

     protected boolean readXML()
    {

        // Make an  instance of the DocumentBuilderFactory
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        try {
            // use the factory to take an instance of the document builder
            DocumentBuilder db = dbf.newDocumentBuilder();

            // parse using the builder to get the DOM mapping of the
            // XML file
            dom = db.parse(xml);
            dom.normalizeDocument();
            Element doc = dom.getDocumentElement();
            Song song=new Song();
            song.m_name = getTextValue(song.m_name, doc, "name");
            song.m_genre = getTextValue(song.m_genre, doc, "genre");
            song.m_author = getTextValue(song.m_author, doc, "author");
            song. m_format = getTextValue(song.m_format, doc, "format");
            song.m_duration = getTextValue(song.m_duration, doc, "duration");

            songs.add(song);
            return true;
        }
        catch (ParserConfigurationException | SAXException pce)
        { System.out.println(pce.getMessage()); } catch (IOException ioe)
        { System.err.println(ioe.getMessage()); }

        return false;
    }

    public void printSong() throws IOException { //выводим атрибуты каждой песни
        m_writer.println("<html>");
        m_writer.println("<body>");
        m_writer.println("<table style=margin-left:auto;margin-right:auto>");
        m_writer.println("<tr>");
        m_writer.println("<th>Name</th>");
        m_writer.println("<th>Genre</th>");
        m_writer.println("<th>Author</th>");
        m_writer.println("<th>Format</th>");
        m_writer.println("<th>Duration</th>");
        m_writer.println("<th>Player</th>");
        m_writer.println("</tr>");

        for(int i=0;i<songs.size();i++){
            m_writer.println("<tr>");
            Song song=songs.get(i);
            m_writer.println("<td>" + song.m_name + "</td>");
            m_writer.println("<td>" + song.m_genre + "</td>");
            m_writer.println("<td>" + song.m_author + "</td>");
            m_writer.println("<td>" + song.m_format + "</td>");
            m_writer.println("<td>" + song.m_duration + "</td>");
            String path="music/"+song.m_name+"."+song.m_format;
            m_writer.println("<td><audio controls src=\""+path+"\"/></td>");
            m_writer.println("</tr>");
        }

        m_writer.println("</table>");
        m_writer.println("</html>");
        m_writer.println("</body>");

    }

    public void printSong(String name,String genre,String author,
                          String format,String duration) throws IOException { //выводим атрибуты каждой песни
        m_writer.println("<html>");
        m_writer.println("<body>");
        m_writer.println("<table style=margin-left:auto;margin-right:auto>");
        m_writer.println("<tr>");
        m_writer.println("<th>Name</th>");
        m_writer.println("<th>Genre</th>");
        m_writer.println("<th>Author</th>");
        m_writer.println("<th>Format</th>");
        m_writer.println("<th>Duration</th>");
        m_writer.println("<th>Player</th>");
        m_writer.println("</tr>");
        if(name!=null)
            for(int i=0;i<songs.size();i++){
            m_writer.println("<tr>");
            Song song=songs.get(i);
            if(song.m_name.equals(name)){
                m_writer.println("<td>" + song.m_name + "</td>");
                m_writer.println("<td>" + song.m_genre + "</td>");
                m_writer.println("<td>" + song.m_author + "</td>");
                m_writer.println("<td>" + song.m_format + "</td>");
                m_writer.println("<td>" + song.m_duration + "</td>");
                String path="music/"+song.m_name+"."+song.m_format;
                m_writer.println("<td><audio controls src=\""+path+"\"/></td>");
                m_writer.println("</tr>");
            }

        }
        if(genre!=null)
            for(int i=0;i<songs.size();i++){
                m_writer.println("<tr>");
                Song song=songs.get(i);
                if(song.m_genre.equals(genre)) {
                    m_writer.println("<td>" + song.m_name + "</td>");
                    m_writer.println("<td>" + song.m_genre + "</td>");
                    m_writer.println("<td>" + song.m_author + "</td>");
                    m_writer.println("<td>" + song.m_format + "</td>");
                    m_writer.println("<td>" + song.m_duration + "</td>");
                    String path = "music/" + song.m_name + "." + song.m_format;
                    m_writer.println("<td><audio controls src=\"" + path + "\"/></td>");
                    m_writer.println("</tr>");
                }
            }
        if(author!=null)
            for(int i=0;i<songs.size();i++){
                m_writer.println("<tr>");
                Song song=songs.get(i);
                if(song.m_author.equals(author)) {
                    m_writer.println("<td>" + song.m_name + "</td>");
                    m_writer.println("<td>" + song.m_genre + "</td>");
                    m_writer.println("<td>" + song.m_author + "</td>");
                    m_writer.println("<td>" + song.m_format + "</td>");
                    m_writer.println("<td>" + song.m_duration + "</td>");
                    String path = "music/" + song.m_name + "." + song.m_format;
                    m_writer.println("<td><audio controls src=\"" + path + "\"/></td>");
                    m_writer.println("</tr>");
                }
            }
        if(format!=null)
            for(int i=0;i<songs.size();i++){
                m_writer.println("<tr>");
                Song song=songs.get(i);
                if(song.m_format.equals(format)) {
                    m_writer.println("<td>" + song.m_name + "</td>");
                    m_writer.println("<td>" + song.m_genre + "</td>");
                    m_writer.println("<td>" + song.m_author + "</td>");
                    m_writer.println("<td>" + song.m_format + "</td>");
                    m_writer.println("<td>" + song.m_duration + "</td>");
                    String path = "music/" + song.m_name + "." + song.m_format;
                    m_writer.println("<td><audio controls src=\"" + path + "\"/></td>");
                    m_writer.println("</tr>");
                }
            }

        if(duration!=null)
            for(int i=0;i<songs.size();i++){
                m_writer.println("<tr>");
                Song song=songs.get(i);
                if(song.m_duration.equals(duration)) {
                    m_writer.println("<td>" + song.m_name + "</td>");
                    m_writer.println("<td>" + song.m_genre + "</td>");
                    m_writer.println("<td>" + song.m_author + "</td>");
                    m_writer.println("<td>" + song.m_format + "</td>");
                    m_writer.println("<td>" + song.m_duration + "</td>");
                    String path = "music/" + song.m_name + "." + song.m_format;
                    m_writer.println("<td><audio controls src=\"" + path + "\"/></td>");
                    m_writer.println("</tr>");
                }
            }


        m_writer.println("</table>");
        m_writer.println("</html>");
        m_writer.println("</body>");

    }
    public static void addSong(String name,String genre,
                               String author,String format,String duration) {
        Song song=new Song();
        song.m_name=name;
        song.m_genre=genre;
        song.m_author=author;
        song.m_format=format;
        song.m_duration=duration;
        songs.add(song);

    }
    public static void delSongByName(String name) throws NullPointerException {
        for(Song i :songs) if(i.m_name.equals(name)) songs.remove(i);
        
    }

    @Override
    public void init(ServletConfig sc) {
        songs = new ArrayList<>();
        xml = "file:///C:/Program Files/apache-tomcat-10.1.1/webapps/OOP_Lab3_war/xml/info.xml";
        readXML();
    }
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        res.setContentType("text/html");
        res.setCharacterEncoding("utf-8");
        m_writer=res.getWriter();
        printSong();
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        m_writer=res.getWriter();
        String name = req.getParameter("name");
        String genre = req.getParameter("genre");
        String author = req.getParameter("author");
        String format = req.getParameter("format");
        String duration = req.getParameter("duration");
        if(genre==null&&author==null&&format==null&&duration==null){
            name = req.getParameter("name");
            delSongByName(name);
            req.removeAttribute("name");
        }
        else {
            addSong(name,genre,author,format,duration);
            req.removeAttribute("name");
            req.removeAttribute("genre");
            req.removeAttribute("author");
            req.removeAttribute("format");
            req.removeAttribute("duration");
        }
        String name1= req.getParameter("name1");
        String genre1 =req.getParameter("genre1");
        String author1 =req.getParameter("author1");
        String format1 =req.getParameter("format1");
        String duration1= req.getParameter("duration1");

       if(name1!=null) printSong(name1,genre1,author1,format1,duration1);

    }
}
