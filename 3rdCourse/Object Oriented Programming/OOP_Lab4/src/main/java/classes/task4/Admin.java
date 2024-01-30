package classes.task4;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;


@Entity
@Table(name = "Admins", schema = "dbo", catalog = "Music")
public class Admin extends User
{

}
