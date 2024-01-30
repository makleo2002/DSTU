import scala.collection.mutable.ListBuffer

import scala.util.Random
// извлекает заданное количество случайно выбранных элементов из списка
//scala> randomSelect(3, List('a, 'b, 'c, 'd, 'f, 'g, 'h))
//res0: List[Symbol] = List('e, 'd, 'a)
var x:List[Symbol]=List('a, 'b, 'c, 'd, 'f, 'g, 'h)
def LoopRand(c:Int,list1:ListBuffer[Symbol],y:List[Symbol]):List[Symbol]= {
  var n: Int = 0
  if (c <= 0 || y.isEmpty ) print(x)
  else while(n<c) {
    val R = Random.between(1,y.size)
    list1.addOne(y(R))
    n+=1
  }
  list1.toList
}
def RecRand(c:Int,y:List[Symbol],list2:ListBuffer[Symbol],n:Int=0):List[Symbol]={

  val R = Random.between(1,y.size)
  if (c <= 0 || y.isEmpty ) x
  if(n<c) RecRand(c,y,list2.addOne(y(R)),n+1)
  else list2.toList
}
LoopRand(3,ListBuffer(),x)
RecRand(3,x,ListBuffer())



