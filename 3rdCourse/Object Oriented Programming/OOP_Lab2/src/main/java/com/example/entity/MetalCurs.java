package com.example.entity;
import jakarta.xml.bind.annotation.XmlRootElement;
import jakarta.xml.bind.annotation.XmlElement;
import java.util.ArrayList;
import java.util.List;
@XmlRootElement(name = "Metall")
public class MetalCurs
{
    @XmlElement(name = "Record")
    private final List<PreciousMetal> m_list_metals = new ArrayList<>();


    public MetalCurs() {}

    public List<PreciousMetal> getListMetals() { return m_list_metals; }
}


