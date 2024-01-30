package com.example.lab2;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import org.w3c.dom.Document;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.InputSource;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import java.io.*;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;


class MetalInfo {
	String buy;
	String sell;
	String date;
	MetalInfo(String buy, String sell, String date) {
		this.buy = buy;
		this.sell = sell;
		this.date = date;
	}
}

@WebServlet("/task4")
public class Task4 extends HttpServlet {
	public static String data_1;
	public static String data_2;

	public String getURLContent(String p_sURL) {
		URL oURL;
		URLConnection oConnection;
		BufferedReader oReader;
		String sLine;
		StringBuilder sbResponse;
		String sResponse = null;

		try
		{
			oURL = new URL(p_sURL);
			oConnection = oURL.openConnection();
			oReader = new BufferedReader(new InputStreamReader(oConnection.getInputStream()));
			sbResponse = new StringBuilder();

			while((sLine = oReader.readLine()) != null)
			{
				sbResponse.append(sLine);
			}

			sResponse = sbResponse.toString();
		}
		catch(Exception e)
		{
			e.printStackTrace();
		}

		return sResponse;
	}

	public static Document loadXMLFromString(String xml) throws Exception {
		DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
		DocumentBuilder builder = factory.newDocumentBuilder();
		InputSource is = new InputSource(new StringReader(xml));
		return builder.parse(is);
	}

	public void writeList(PrintWriter writer, ArrayList<MetalInfo> list, String title) {
		writer.println(
				"<div class=\"list\">\n" +
						"    <div class=\"head\"><hr><br>" + title + "</div>"
		);
		for(MetalInfo mif : list) {
			writer.println(
					"      <div class=\"info\">\n" +
							"        <div>Дата: " + mif.date + "</div>\n" +
							"        <div>Покупка: " + mif.buy + "руб</div>\n" +
							"        <div>Продажа: " + mif.sell + "руб</div>\n<br>" +
							"      </div>"
			);
		}
		writer.println("</div>");
	}

	@Override
	public void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		resp.setContentType("text/html");
		resp.setCharacterEncoding("utf-8");

		data_1 = req.getParameter("data1");
		data_2 = req.getParameter("data2");

		PrintWriter writer = resp.getWriter();

		String content = getURLContent(
				"http://www.cbr.ru/scripts/xml_metall.asp?date_req1=" + data_1 + "&date_req2=" + data_2
		);


		Document doc = null;
		try {
			doc = loadXMLFromString(content);
		} catch (Exception e) {
			throw new RuntimeException(e);
		}
		if(doc == null) return;

		doc.getDocumentElement().normalize();
		NodeList records = doc.getElementsByTagName("Record");
		ArrayList<MetalInfo> gold = new ArrayList<>();
		ArrayList<MetalInfo> silver = new ArrayList<>();
		ArrayList<MetalInfo> platinum = new ArrayList<>();
		ArrayList<MetalInfo> palladium = new ArrayList<>();

		for(int i = 0; i < records.getLength(); i++) {
			Node record = records.item(i);
			String code = record.getAttributes().getNamedItem("Code").getNodeValue();
			String buy = record.getFirstChild().getFirstChild().getNodeValue();
			String sell = record.getLastChild().getFirstChild().getNodeValue();
			String date = record.getAttributes().getNamedItem("Date").getNodeValue();
			MetalInfo mif = new MetalInfo(buy, sell, date);

			switch(code) {
				case "1":
					gold.add(mif);
					break;
				case "2":
					silver.add(mif);
					break;
				case "3":
					platinum.add(mif);
					break;
				case "4":
					palladium.add(mif);
					break;
			}
		}

		writeList(writer, gold, "Золото");
		writeList(writer, silver, "Серебро");
		writeList(writer, platinum, "Платина");
		writeList(writer, palladium, "Палладий");

	}
}