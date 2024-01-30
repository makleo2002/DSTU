package com.company;

class Complex{
    private double x;
    private double y;

    Complex(double x, double y){
        this.x=x;
        this.y=y;
    }
    Complex(){}
    Complex(double x){this.x=x;}
    void Real(){
        System.out.println(x);
    }
    void Imaginary(){
        System.out.println("i*"+y);
    }
    void AlgForm() {
        System.out.println("Алгебраическая форма: ");
        System.out.println(x+"+i*"+y);
    }
    void TrigForm() {
        System.out.println("Тригонометрическая форма: ");
        double r=Math.sqrt(x*x+y*y);
        double FI = Math.atan(y/x);
        System.out.printf("%.2f *(cos(%.2f)+ isin(%.2f))",r,FI,FI);
        System.out.println();
    }
    static boolean Compare(Complex z1, Complex z2){
        return z1.x == z2.x && z1.y == z2.y;
    }
    static Complex Sum(Complex z1, Complex z2){
        Complex z3 = new Complex();
        z3.x=z1.x+ z2.x;
        z3.y=z1.y+ z2.y;
        //z3.alg_form();
        return z3;
    }
    static Complex Diff(Complex z1, Complex z2){
        Complex z3 = new Complex();
        z3.x=z1.x- z2.x;
        z3.y=z1.y- z2.y;
        //z3.alg_form();
        return z3;
    }
    static Complex Mult(Complex z1, Complex z2){
        Complex z3 = new Complex();
        z3.x=z1.x* z2.x-z1.y* z2.y;
        z3.y=z1.y* z2.x+z1.x*z2.y;
        //z3.alg_form();
        return z3;
    }
    static Complex Div(Complex z1, Complex z2){
        Complex z3 = new Complex();
        z3.x=(z1.x*z2.x+z1.y*z2.y)/(z2.x*z2.x+z2.y*z2.y);
        z3.y=(z1.y*z2.x+z1.x*z2.y)/(z2.x*z2.x-z2.y*z2.y);
        //z3.alg_form();
        return z3;
        //  System.out.printf("%.2f + i * %.2f",(z1.x*z2.x+z1.y*z2.y)/(z2.x*z2.x+z2.y*z2.y),(z1.y*z2.x+z1.x*z2.y)/(z2.x*z2.x-z2.y*z2.y));
        //  System.out.println();
    }

    Complex conjugate(){y=-y; return new Complex(x,y);}
    static Complex exp(Complex z){
        return new Complex(Math.exp(z.x)*Math.cos(z.y),Math.exp(z.x)*Math.sin(z.y));
    }
    static Complex sin(Complex z){
        return new Complex(Math.sin(z.x) * Math.cosh(z.y), Math.cos(z.x) * Math.sinh(z.y));
    }
    static Complex cos(Complex z){
        return new Complex(Math.cos(z.x) * Math.cosh(z.y), -Math.sin(z.x) * Math.sinh(z.y));
    }
    public static Complex tan(Complex z){return Div(sin(z),cos(z));}
    public static Complex atan(Complex z){
        return Div(cos(z),sin(z));
    }
    public static Complex sh(Complex z) {return Div(Diff(exp(z),exp(z.conjugate())),new Complex(2,0));}
    public static Complex ch(Complex z){return Div(Sum(exp(z),exp(z.conjugate())),new Complex(2,0));}
    public static Complex th (Complex z) {return Div(sh(z),ch(z));}
    public static Complex cth (Complex z) {return Div(ch(z),sh(z));}
}