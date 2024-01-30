//реализовать метод Ньютона для уравнения x^3+18x-83=0
def f(x:Double):Double= {
  return  x*x*x +18*x- 83;//функция
}

def df(x:Double):Double= {
  return 3*x*x+18//производная
}
def LoopNewton():Double= {
 val eps:Double=0.001
  var x:Double=(-10)
var dx:Double=0
var n:Double=0
  while(n<=100){
    dx=f(x)/df(x)
    x=x-dx
    if(dx.abs<eps) 0
    n+=1
  }
  x
}
def RecNewton(x:Double,dx:Double=0, n:Double=0, eps:Double=0.001): Double = {
  if (n <= 100) {
    var dx:Double = f(x) / df(x)
    if (dx.abs >= eps) {

      RecNewton(x=x - dx, n=n + 1)
    }
    else x
  }
  x
}

LoopNewton
RecNewton(x=3.0)

