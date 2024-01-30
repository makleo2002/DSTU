import java.util.Scanner
import scala.collection.mutable.Set
import scala.collection.mutable.{ListBuffer, Stack}
import scala.util.Random
trait Word[String] {
  def Search(word:String,str:String):String
}
trait Word1[Unit] {
  def Search1(word:String,str:String):Unit
}
trait Word2[Int] {
  def Search2(word:String,str:String):Int
}

class StrWord extends Word[String] with Word1[Unit] with Word2[Int] {
  override def Search(word:String,str:String):String={
   val array = str.toCharArray
    var str1:String=""
    var i:Int=0
    var b:Boolean=false
    for(n<-array){
      if(n!=' ' &&i!=array.length-1) {
        str1=str1+n
        if(word==str1&&i==array.length-1) b=true
      }
      else if(i==array.length-1) str1=str1+n
      else if(n==' ') {
        if(word==str1) b=true
       println(str1)
        str1=""
      }
      i+=1
    }
  if(b) "Word finded"
  else "Word isnt finded"
  }
  override def Search1(word:String,str:String):Unit={
    if(str.contains(word)) println("Word is finded")
    else println("Word is not finded")
  }
  override def Search2(word:String,str:String):Int={
    str.indexOf(word)
  }
}
val s = Stack[Int]()
trait push {
  def push(i:Int):Unit= {
    s.push(i)
  }
}
trait push2{
  def push2(i:Int,f:Int):Unit={
    s.push(i)
    s.push(f)
  }
}
trait pop {
  def pop():Unit= {
    s.pop()
  }
}
trait show {
  def show():Unit= {
    println(s)
  }
}
class stack extends push with pop with show{
  override def push(i: Int): Unit = super.push(i)
  override def pop(): Unit = super.pop()
  override def show(): Unit = super.show()
}
trait difference{
  def d(list: ListBuffer[Int], list1: ListBuffer[Int]): Unit = {
 /*   var list2=List[Int]()
   for(i<-list) {
     for(j<-list1){
       if(i==j) list2=i+:list2
     }
   }
    println("Difference: "+list2)
  */
    val result=list.diff(list1)
    val set=Set[Int]();
    for(i<-result){
      set.add(i)
    }
    print("Difference: "+set)
  }
}
trait composition {
  def c(list: ListBuffer[Int], list1: ListBuffer[Int]):Unit= {
  //  val result = for(value1 <- list; value2 <- list1; if value1 == value2) yield value1
   val result= list.intersect(list1)
    val set=Set[Int]();
    for(i<-result){
      set.add(i)
    }
    print("Composition: "+set)
  }
}
trait association {
  def a(list: ListBuffer[Int], list1: ListBuffer[Int]):Unit = {
    val result =list++list1
    val set=Set[Int]();
    for(i<-result){
      set.add(i)
    }
    print("Association: "+set)
  }
}
class sets extends association with composition with difference{
  var list=ListBuffer[Int]()
  def CreateSet(): Unit ={
    for(i<-1 to 10) {
     val R= Random.between(1, 20)
   list=R+:list
    }
    println(list)
  }
  override def a(list: ListBuffer[Int], list1: ListBuffer[Int]): Unit = super.a(list, list1)

  override def c(list: ListBuffer[Int], list1: ListBuffer[Int]): Unit = super.c(list, list1)
}
trait fibo2{
  val data=new Scanner(System.in)
 def check: Unit ={
   for(i<-1 to 6){
     val i=data.nextInt()
    if(i%2==0) print(i)
   }
 }
}

class fibo extends fibo2{
  override def check: Unit = super.check
}
val word:String="the"
val str:String="London is the capital of Great Britain"
var strword = new StrWord()
strword.Search(word,str)
strword.Search1(word,str)
strword.Search2(word,str)
var stack=new stack()
stack.push(10)
stack.push(15)
stack.push(30)
stack.show()
stack.pop()
var set1=new sets()
set1.CreateSet()
var set2=new sets()
set2.CreateSet()
set1.a(set1.list,set2.list)
set1.c(set1.list,set2.list)
set1.d(set1.list,set2.list)
var fibo=new fibo()
fibo.check
