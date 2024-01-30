//найти последний элемент списка
  //scala> last(List(1, 1, 2, 3, 5, 8))
//res0: Int = 8
  var x: List[Int]=List(1,1,2,3,5,8)
var i:Int=0


def RecLast(x: List[Int]): Int = {
  if (x.isEmpty) throw new Exception("Empty list")
  else if (x.tail.isEmpty) x.head
  else RecLast(x.tail)
}
def LoopLast():Unit= {
  while (i <= x.size + 2) {
    x = x.tail
    i += 1
  }
  println("res0: Int = " + x.head)
}

RecLast(x)
LoopLast