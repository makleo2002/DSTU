//выясните, является ли список палиндромом
//  scala> isPalindrome(List(1, 2, 3, 2, 1))
//res0: Boolean = true
val x:List[Int]=List(1, 2, 3, 2, 1)
var y:List[Int]=List(1, 2, 3, 2, 1)
var i:Int=x.size-1
var m:Int=0
var list=List[Int]()
var list1=List[Int]()
def LoopIsPal(x:List[Int]):Boolean= {
  for (i <- x) {
    list =i +: list
  }
  if (list == x) {
    true
  }
  else false

}
def RecIsPal(y: List[Int]): Boolean = {
  list1=list1.::(y.head)
  if (y.isEmpty) throw new Exception("Empty list")
  else if (y.tail.isEmpty) {
    if (list1 == x) {
      true
    }
    else false
  }
  else RecIsPal(y.tail)
  }

RecIsPal(y)
LoopIsPal(x)
