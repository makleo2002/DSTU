import scala.util.Random
class Transport{
 var name:String=""
  var space:String=""
  def this(name: String) = {
    this()
    this.name = "Default Transport"
  }
 def say(): Unit ={
   print("This is Transport")
 }
  def printinfo(): Unit ={
    println(name)
    println(space)
  }
  def printid():Unit={
   val a:Long=0
    val b:Long=99999999
   println("Serial number: "+"#"+Random.between(a,b))
  }
}

class Car extends Transport {
  var brand:String=""
  var model:String=""
  var color:String=""
  var price:Int=0
  def this(name:String) = {
    this()
    this.name = "Default Car"
    this.brand="Toyota"
    this.model="Land Cruiser 300"
    this.color="black"
    this.price=7278000
  }
  override def say(): Unit ={
    print("This is Car")
  }
  override def printinfo(): Unit ={
    println("Name: "+name)
    println("Space: "+space)
    println("Brand: "+ brand)
    println("Model: "+ model)
    println("Color: "+ color)
    println("Price: "+ price+" Rubles")

  }

}

class Train extends Transport {
  var train_type:String=""
  var model:String=""
  var color:String=""
  var capacity:Int=0
  var length:Double=0
  var max_speed:Int=0
  def this(name:String) = {
    this()
    this.name = "Default Train"
    this.train_type="electric train"
    this.model="Lastochka"
    this.color="Red"
    this.capacity=822
    this.length=126.5
    this.max_speed=160
  }
  override def say(): Unit ={
    print("This is Train")
  }
  override def printinfo(): Unit ={
    println("Name: "+name)
    println("Space: "+space)
    println("Train type: "+ train_type)
    println("Model: "+ model)
    println("Color: "+ color)
    println("Capacity: "+ capacity+" people")
    println("Lenght: "+ length+" m")
    println("Max speed: "+ max_speed+" km/h")
    println("Capacity: "+ capacity+" people")
  }

}

class Airplane extends Transport{
  var brand:String=""
  var model:String=""
  var capacity:Int=0
  var weight:Int=0
  var length:Double=0
  var max_speed:Int=0
  var flight_range:Int=0
  def this(name:String) = {
    this()
    this.name = "Default Airplane"
    this.brand="Boeing"
    this.model="Boeing 777-200"
    this.capacity=400
    this.length=48.5
    this.max_speed=913
   this.flight_range=9695
  }
  override def say(): Unit ={
    print("This is Airplane")
  }
  override def printinfo(): Unit ={
    println("Name: "+name)
    println("Space: "+space)
    println("Brand: "+ brand)
    println("Model: "+ model)
    println("Capacity: "+ capacity+" people")
    println("Lenght: "+ length+" m")
    println("Max speed: "+ max_speed+" km/h")
    println("Flight_range: "+ flight_range+" people")
  }
}


class Rocket extends Transport {
  var length:Int=53
  var weight:Int=702
  var diameter:Double=7.4
  var height: Double =10001
  def Height(height: Double): Unit ={
    if(height>10000) print("Мы взлетаем")
  }
  def this(name:String) = {
    this()
    this.name = "Default Rocket"
  }
  override def say(): Unit ={
    print("This is Rocket")
  }
  override def printinfo(): Unit ={
    println("Name: "+name)
    println("Space: "+space)
    println("Length: "+length+ "m")
    println("Weight: "+weight+" t")
    println("Diameter: "+diameter+" m")
  }
}

class Cargo{
 var weight:Int=0
   var name:String=""
  var space:String=""
  def this(name:String) = {
    this()
    this.name = "Default Cargo"
    this.weight=10
  }
  def say(): Unit ={
    print("This is Cargo")
  }
  def printname(): Unit ={
    print(name)
  }
  def printinfo():Unit={
    println("Name: "+name)
    println("Weight: "+weight+" kg")
  }
  def printid():Unit={
    val a:Long=0
    val b:Long=9999999
    println("id: "+Random.between(a,b))
  }


}
class Passenger {
 var name:String=""
  var surname:String=""
  var age:Int=0
  def this(name:String) = {
    this()
    this.name = "Ivan"
    this.surname = "Petrov"
    this.age  =25
  }
  def say(): Unit ={
    print("This is Passanger")
  }
  def printname(): Unit ={
    print(name)
  }
  def printinfo(): Unit ={
    println(name)
    println(surname)
    println(age)
  }

}
object Passenger {
  def addpass1(a: Transport, p: Passenger): Unit = {
    a.space = p.name + p.surname
  }
  def addpass2(a: Car, p: Passenger): Unit = {
    a.space = p.name + p.surname
  }
  def addpass3(a: Train, p: Passenger): Unit = {
    a.space = p.name + p.surname
  }
  def addpass4(a: Airplane, p: Passenger): Unit = {
    a.space = p.name + p.surname
  }
  def addpass5(a: Rocket, p: Passenger): Unit = {
    a.space = p.name + p.surname
  }
}

class Child extends Passenger{
  def this(name:String) = {
    this()
    this.name = "Alexey"
    this.surname="Nikolaev"
    this.age=5
  }
  override def say(): Unit ={
    print("This is Child")
  }
}

val t1 =new Transport("")
t1.say()
t1.printinfo()
t1.printid()
val t2 =new Car("")
t2.say()
t2.printinfo()
t2.printid()
val t3 =new Train("")
t3.say()
t3.printinfo()
t3.printid()
val t4 =new Airplane("")
t4.say()
t4.printinfo()
t4.printid()
val t5 =new Rocket("")
t5.say()
t5.printinfo()
t5.printid()
t5.Height(10001)
val t6 =new Cargo("")
t6.say()
t6.printinfo()
t6.printid()
val t7 =new Passenger("")
t7.say()
t7.printinfo()
Passenger.addpass1(t1,t7)
t1.printinfo()
Passenger.addpass2(t2,t7)
t2.printinfo()
Passenger.addpass3(t3,t7)
t3.printinfo()
Passenger.addpass4(t4,t7)
t4.printinfo()
Passenger.addpass5(t5,t7)
t5.printinfo()
val t8 =new Child("")
t8.say()
t8.printinfo()