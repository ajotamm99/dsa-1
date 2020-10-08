package GestorClasses.figuras;

public class Rectangulo extends Figura {
    private double l1;
    private double l2;

    public Rectangulo(double l1, double l2){
        this.l1=l1;
        this.l2=l2;

    }

    public double area(){
        return this.l1 *this.l2;

    }

    public double getL1() {
        return l1;
    }

    public double getL2() {
        return l2;
    }

    @Override
    public String toString(){
        return "Rectangulo l1:" + this.l1+ "l2:"+ this.l2+ "area:"+this.area();

    }
}
