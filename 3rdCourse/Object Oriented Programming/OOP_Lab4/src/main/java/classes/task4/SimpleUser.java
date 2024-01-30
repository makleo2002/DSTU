package classes.task4;
import jakarta.persistence.Entity;
import jakarta.persistence.Table;


@Entity
@Table(name = "SimpleUsers", schema = "dbo", catalog = "Music")
public class SimpleUser extends User
{

}
