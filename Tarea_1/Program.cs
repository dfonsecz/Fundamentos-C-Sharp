using System;

class Program {
    //int cantidadNumeros;
    //int contador;

    static int obtenerNumero() {
        int numero = int.Parse(Console.ReadLine());
        return numero;
    }
    
    static void Main() {
        Console.WriteLine("¿Cuántos números desea ingresar? ");
        int cantidadNumeros = obtenerNumero();
    }
}