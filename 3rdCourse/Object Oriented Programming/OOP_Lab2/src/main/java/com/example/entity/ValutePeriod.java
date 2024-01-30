package com.example.entity;

import jakarta.xml.bind.annotation.XmlAttribute;
import jakarta.xml.bind.annotation.XmlElement;
import jakarta.xml.bind.annotation.XmlRootElement;
@XmlRootElement(name = "Record")
public class ValutePeriod
{
    @XmlAttribute(name = "Date")
    private String m_date;

    @XmlElement(name = "Value")
    private String m_value;


    public ValutePeriod() {}


    public String getDate() { return m_date; }

    public String getValue() { return m_value; }
}


