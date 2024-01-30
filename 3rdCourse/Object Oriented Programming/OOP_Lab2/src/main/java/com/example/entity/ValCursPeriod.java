package com.example.entity;

import jakarta.xml.bind.annotation.XmlAttribute;
import jakarta.xml.bind.annotation.XmlElement;
import jakarta.xml.bind.annotation.XmlRootElement;

import java.util.ArrayList;
import java.util.List;

//the name of the class may differ with the name of the root element
@XmlRootElement(name = "ValCurs")
public class ValCursPeriod
{
    @XmlElement(name = "Record")
    private final List<ValutePeriod> m_list_valutes = new ArrayList<>();

    public ValCursPeriod() {}

    public List<ValutePeriod> getListValutes() { return m_list_valutes; }
}


