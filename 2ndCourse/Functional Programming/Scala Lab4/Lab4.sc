import java.util.Scanner

var x: Double=1
var k: Int=0
var y:Double=0
case class fun(x:Double,y:Double)
x match {
  case x if x>=0&&x<=1 => y = x
  case x if x>1&&x<=2 => y = -x+2
  case x if x>2&&x<=3 => y = 2*x-4
  case _ => "Function is not defined in this point"
}
val x1:Double=(-2.2)
val y1:Double=(-3.3)
val function=new fun(x1,y1)
function match{
  case function if function.x>0&&function.y>0=>k=1
  case function if function.x>0&&function.y<0=>k=2
  case function if function.x<0&&function.y<0=>k=3
  case function if function.x<0&&function.y>0=>k=4
  case function if x==0&&y>0 => "Point between 1 and 4 quarter"
  case function if x==0&&y<0 => "Point between 2 and 3 quarter"
  case function if y==0&&x>0 => "Point between 1 and 2 quarter"
  case function if y==0&&x<0 => "Point between 3 and 4 quarter"
  case function if y==0&&x==0 => "Point between 1,2,3 and 4 quarter"
  case _ =>
}

def Case(x:Double): Double ={
  x match {
    case x if x>0 && x<90 => Math.sin(x)
    case x if x>90 && x<180 => Math.cos(x)
  }
}
print(Case(45))
print(k)