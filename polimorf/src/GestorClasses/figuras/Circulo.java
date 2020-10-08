package GestorClasses.figuras;

public class Circulo extends Figura{

    private double r;
    public Circulo(double r){
        this.r=r;
    }

    public double area(){
        return Math.PI * Math.pow (this.r, 2);

    }

    @Override
    public String toString(){
        return "Circulo r:" + this.r +"area:" +this.area();
    }
}
