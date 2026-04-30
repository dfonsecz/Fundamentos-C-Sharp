using System;

class Program {
    static int cantidadPositivos = 0;
    static int cantidadNegativos = 0;
    static int cantidadCeros = 0;

    // Método para obtener un número entero como entrada
    static int obtenerNumero() {
        int numero;
        
        while (!int.TryParse(Console.ReadLine(), out numero)) {
            Console.Write("Entrada inválida. Ingrese un número entero: ");
        }

        return numero;
    }

    // Método para clasificar números como positivos, negativos o ceros e incrementar contador respectivo
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
        // Solicitar entrada
        Console.Write("¿Cuántos números desea ingresar? ");
        int cantidadNumeros = obtenerNumero();

        for (int i = 0; i < cantidadNumeros; i++) {
            Console.Write("Ingrese el número " + (i + 1) + ": ");
            int numero = obtenerNumero();
            clasificarNumero(numero);
        }

        // Imprimir resultados
        Console.WriteLine("\nResultados:");
        Console.WriteLine("Números positivos: " + cantidadPositivos);
        Console.WriteLine("Números negativos: " + cantidadNegativos);
        Console.WriteLine("Cantidad de ceros: " + cantidadCeros);
    }
}