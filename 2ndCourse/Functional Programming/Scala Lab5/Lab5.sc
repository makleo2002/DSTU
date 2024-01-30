import scala.util.Random
trait role{
  val role:String
  var status:String
}
abstract class Account extends role
case class SomethingStrange() extends Account {
  val role = "??"
  var status=""
  def getstatus(): Unit ={
    status="??"
    println(status)
  }
}
case class User(name: String) extends Account {
  val role = "User"
  var status = ""
}

case class SuperUser(name: String,email: String) extends Account {
  override val role = "SuperUser"
  var status=""
  val R=Random.between(0,10)
  def getstatus(obj:User): Unit ={
    if(R>0&&R<5) obj.status="Normal"
    else obj.status="Banned"
    println(obj.status)
  }
  def getprint(s:String): Unit ={
    println(s)
  }
}

def matcherFunc(obj: Account):Unit= {
  obj match {
    case User(name) =>
      println("Name: " + name)
      println("Email: none")
      println("Role: " + obj.role)

    case SuperUser(name, email) =>
      println("Name: " + name)
      println("Email: " + email)
      println("Role: " + obj.role)

    case SomethingStrange() =>
      println("Name: ??")
      println("Email: ??")
      println("Role: ??")
  }
}

matcherFunc(User("Maxim"))
matcherFunc(SuperUser("Maxim","makleo2002@mail.ru"))
matcherFunc(SomethingStrange())
SuperUser("Maxim","makleo2002@mail.ru").getstatus(User("Maxim"))


  //class User extends Account{
//  var name: String = ""
//  var email:String=""
//  val role :String=""
//  def this(name:String){
//    this()
//    this.name=name
//  }
//}
//class SuperUser extends Account with role{
//  var name:String=""
//  var email:String=""
//  val role:String=""
//  def this(name:String,email:String){
//    this()
//    this.name=name
//    this.email=email
//  }
//}
//class SomethingStrange extends Account with role{
//  var name:String=""
//  var email:String=""
//  val role:String=""
//  def this(){
//    this()
//  }
//
//}