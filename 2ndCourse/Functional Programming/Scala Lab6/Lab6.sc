
var m:Int =(-1)
var x: Int=0
def Search1(word:String, str: String):Int= {
 m=str.indexOf(word,m+1)
 m+=word.length-1
 m
}

Search1("Great","Great Britain capital of Great Great London is Great ")
Search1("Great","Great Britain capital of Great Great London is Great ")
Search1("Great","Great Britain capital of Great Great London is Great ")
Search1("Great","Great Britain capital of Great Great London is Great ")