package classes.task3;

import jakarta.persistence.*;

import java.util.Set;

@Entity
@Table(name = "Singers", schema = "dbo", catalog = "Music")
public class Singer
{
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @Column(name = "id")
    private int id;

    @Basic
    @Column(name = "first_name")
    private String first_name;

    @Basic
    @Column(name = "second_name")
    private String second_name;


    @OneToMany
    @JoinColumn(name = "Singer", nullable = true)
    private Set<Song> songs;


    public Singer(String first_name, String second_name)
    {
        this.first_name = first_name;
        this.second_name = second_name;
    }

    public Singer() {}

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getFirstName() {
        return first_name;
    }

    public void setFirstName(String firstName) {
        this.first_name = firstName;
    }

    public String getSecondName() {
        return second_name;
    }

    public void setSecondName(String secondName) {
        this.second_name = secondName;
    }

    public Set<Song> getSongs() { return songs; }

    public void setSongs(Set<Song> songs) { this.songs = songs; }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;//если равны
        if (o == null || getClass() != o.getClass()) return false;//если o null или разные классы

        Singer singer = (Singer) o;

        if (id != singer.id) return false;
        //если имя или фамилия не совпадают с текущим певцом то false
        if (first_name != null ? !first_name.equals(singer.first_name) : singer.first_name != null) return false;
        if (second_name != null ? !second_name.equals(singer.second_name) : singer.second_name != null) return false;

        return true;
    }

}
