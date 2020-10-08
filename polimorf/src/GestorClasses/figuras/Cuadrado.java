package GestorClasses.figuras;

public class Cuadrado extends Rectangulo {


    public Cuadrado (int r){
        super(r,r);
    }
    @Override
    public String toString() {
        return "Cuadrado l:" + this.getL1() + "area:" +this.area();
    }


}
