package classes.task4;

import jakarta.persistence.*;

@MappedSuperclass
public abstract class User
{
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @Column(name = "Id")
    private int id;

    @Basic
    @Column(name = "login")
    private String login;

    @Basic
    @Column(name = "password")
    private String password;



    public String getPassword() { return password; }

    public void setPassword(String password) { this.password = password; }

    public int getId() { return id; }

    public void setId(int id) { this.id = id; }

    public String getLogin() { return login; }

    public void setLogin(String login) { this.login = login; }
}
