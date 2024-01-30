//удалите K-й элемент из списка
 // scala> removeAt(1, List('a, 'b, 'c, 'd))
//res0: (List[Symbol], Symbol) = (List('a, 'c, 'd),'b)
import scala.collection.mutable.ListBuffer
 val x: List[Any]=List(1, List('a, 'b, 'c, 'd))
  val y:List[Symbol]=List('a, 'b, 'c, 'd)
def LoopRemoveAt(k:Int):List[Any]= {
 var y:List[Symbol]=List('a, 'b, 'c, 'd)
 var list=List[Any]()
 var blist=List[Symbol]()
 var f:Symbol=Symbol(1.toString)
 var n:Int=0
 for (i <-x) {
if (i==y) {
 for(m<-y){
  n+=1
  if (n==k){f=m}
  if (n!=k) blist = blist.:+(m)
 }
}

 }
 list=list.::(f)
 list=list.::(blist)
 list
}
def RecRemoveAt(x: List[Symbol],list2:ListBuffer[Symbol]=ListBuffer[Symbol](),c:Int=0,k:Int): ListBuffer[Symbol] = {
 if(c<x.size){
  if(k-1==c){
   RecRemoveAt(x,list2,c+1,k)
  }
  else {
   RecRemoveAt(x,list2+=x(c),c+1,k)
  }
 }
 else {
  list2
 }
}
LoopRemoveAt(3)
RecRemoveAt(y,ListBuffer(),0,2)