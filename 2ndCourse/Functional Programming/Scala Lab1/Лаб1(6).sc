//определить является ли заданное число простым
//scala> 7.isPrime
//res0: Boolean = true
def LoopIsPrime(x:Int):Boolean={
  var b:Boolean=true
  if (x== 1||x==0)  b=false
  for (i <- 2 to x/2) {
    if (x % i == 0) b=false
  }
  b
}
def RecIsPrime(x:Int,i:Int=2):Boolean={
  var b:Boolean=true
  if (x== 1||x==0)  b=false
  if(i<=x/2){
    if (x % i == 0) b=false
    RecIsPrime(x,i+1)
  }
  b
}

LoopIsPrime(4)
RecIsPrime(6)



