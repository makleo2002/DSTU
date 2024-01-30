//найти количество элементов списка
//  scala> length(List(1, 1, 2, 3, 5, 8))
//res0: Int = 6
var x:List[Int]=List(1, 1, 2, 3, 5, 8)
var k:Int=0
var i:Int=0
var n:Int=0
def LoopLenght():Int= {
  for (i <- x) {
    k = k + 1
  }
  k
}
def RecLenght(x: List[Int]): Int = {
  n+=1
  if (x.isEmpty) throw new Exception("Empty list")
  else if (x.tail.isEmpty) n
  else RecLenght(x.tail)

}
RecLenght(x)
LoopLenght

