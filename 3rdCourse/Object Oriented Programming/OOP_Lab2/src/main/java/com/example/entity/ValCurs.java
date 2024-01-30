package com.example.entity;

import jakarta.xml.bind.annotation.*;
import jakarta.xml.bind.annotation.XmlRootElement;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

@XmlRootElement(name = "ValCurs")
public class ValCurs implements Serializable
{
    @XmlElement(name = "Valute")
    private final List<Valute> m_list_valutes = new ArrayList<>();

    public ValCurs() {}

    public List<Valute> getListValutes() { return m_list_valutes; }
}


