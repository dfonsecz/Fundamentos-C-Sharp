using System;

class Program {
    static int cantidadPositivos = 0;
    static int cantidadNegativos = 0;
    static int cantidadCeros = 0;

    static int obtenerNumero() {
        int numero = int.Parse(Console.ReadLine());
        return numero;
    }

    static void clasificarNumero(int numero) {
        if (numero > 0) {
            cantidadPositivos++;
        }
        else if (numero < 0) {
            cantidadNegativos++;
        }
        else {
            cantidadCeros++;
        }
    }
    
    static void Main() {
        Console.WriteLine("¿Cuántos números desea ingresar? ");
        int cantidadNumeros = obtenerNumero();

        for (int i = 0; i < cantidadNumeros; i++) {
            Console.WriteLine("Ingrese el número " + (i + 1) + ": ");
            int numero = obtenerNumero();
            clasificarNumero(numero);
        }

        Console.WriteLine("Resultados:");
        Console.WriteLine("Números positivos: " + cantidadPositivos);
        Console.WriteLine("Números negativos: " + cantidadNegativos);
        Console.WriteLine("Cantidad de ceros: " + cantidadCeros);
    }
}