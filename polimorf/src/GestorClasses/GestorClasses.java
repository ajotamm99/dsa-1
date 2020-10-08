package GestorClasses;

import GestorClasses.figuras.Circulo;
import GestorClasses.figuras.Rectangulo;
import GestorClasses.figuras.Figura;
import GestorClasses.figuras.Cuadrado;

import java.util.Arrays;
import java.util.Comparator;

public class GestorClasses {

    public static void sort (Figura[] v){
        Arrays.sort(v, (o1, o2) -> (int)(o1.area()-o2.area()));
    }
    public static double suma (Figura[] v){
        double ret=0;
        for (Figura f: v){
            System.out.println(f);
            ret+=f.area();
        }
        return ret;
    }

    public static void main(String[] args){
        Figura[] v = new Figura[3];
        v[0]=new Cuadrado(2);
        v[1]=new Rectangulo(2,1);
        v[2]=new Circulo(5);

        double r = GestorClasses.suma(v);

        System.out.println(r);
        System.out.println(Arrays.asList(v));

        GestorClasses.sort(v);
        System.out.println(Arrays.asList(v));
    }
}
