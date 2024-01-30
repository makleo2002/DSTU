package classes.task1;
import jakarta.xml.bind.annotation.XmlAttribute;
import jakarta.xml.bind.annotation.XmlElement;
import jakarta.xml.bind.annotation.XmlRootElement;


@XmlRootElement(name = "Config")
public class Configuration
{
    private String name_db;
    private String url1;

    private String url2;
    private String user;
    private String password;


    public Configuration() {}

    public String getNameDb() { return name_db; }

    @XmlAttribute(name = "name_db")
    public void setNameDb(String name_db) { this.name_db = name_db; }

    public String getUrl1() { return url1; }

    @XmlElement(name = "url1")
    public void setUrl1(String url1) { this.url1 = url1; }

    public String getUrl2() { return url2; }

    @XmlElement(name = "url2")
    public void setUrl2(String url2) { this.url2 = url2; }

    public String getUser() { return user; }

    @XmlElement(name ="user")
    public void setUser(String user) { this.user = user; }

    public String getPassword() { return password; }

    @XmlElement(name = "password")
    public void setPassword(String password) { this.password = password; }

}
