package GestorClasses.figuras;

public abstract class Figura implements Comparable<Figura>{

    public abstract double area();

    @Override
    public int compareTo(Figura o) {
        return (int)(o.area()-this.area());
    }


}
