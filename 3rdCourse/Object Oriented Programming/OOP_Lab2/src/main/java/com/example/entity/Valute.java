package com.example.entity;

import jakarta.xml.bind.annotation.XmlElement;
import jakarta.xml.bind.annotation.XmlRootElement;
import jakarta.xml.bind.JAXBException;
import java.io.Serializable;

@XmlRootElement(name = "Valute")
public class Valute implements Serializable
{
    @XmlElement(name = "Name")
    private String m_name;

    @XmlElement(name = "Value")
    private String m_value;

    public Valute() {}

    public String getName() { return m_name; }
    public String getValue() { return m_value; }
}


