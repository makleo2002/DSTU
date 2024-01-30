package classes.task3;
import jakarta.persistence.*;


@Entity
@Table(name = "Songs", schema = "dbo", catalog = "Music")
public class Song
{
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Id
    @Column(name = "Id")
    private int id;

    @Basic
    @Column(name = "Name")
    private String name;

    @ManyToOne
    @JoinColumn(name = "Id_Singer", nullable = true)
    private Singer singer;


    public Song() {}

    public Song(String name, Singer singer)
    {
        this.name = name;
        this.singer = singer;
    }

    public int getId() { return id; }

    public void setId(int id) { this.id = id; }

    public String getName() { return name; }

    public void setName(String name) { this.name = name; }

    public Singer getSinger() { return singer; }

    public void setSinger(Singer singer) { this.singer = singer; }
}
