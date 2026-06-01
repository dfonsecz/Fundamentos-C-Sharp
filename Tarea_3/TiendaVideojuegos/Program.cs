using System;

class Videojuego {

    private string nombre;
    private string genero;
    private double precio;
    private string plataforma;
    private double porcentaje_descuento;

    public Videojuego() {
            nombre = "";
            genero = "";
            precio = 0;
            plataforma = "";
            porcentaje_descuento = 0;
        }

    public void PonerNombre(string nombre) {
        this.nombre = nombre;
    }

    public void PonerGenero(string genero) {
        this.genero = genero;
    }

    public void PonerPrecio(double precio) {
        this.precio = precio;
    }

    public void PonerPlataforma(string plataforma) {
        this.plataforma = plataforma;
    }

    public void AplicarDescuento(double porcentaje_descuento) {
        this.porcentaje_descuento = porcentaje_descuento;
    }

    public void MostrarInformacion() {
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Género: " + genero);
            Console.WriteLine("Precio: " + precio);
            Console.WriteLine("Plataforma: " + plataforma);
            Console.WriteLine("");
            if (porcentaje_descuento > 0) {
                Console.WriteLine($"Este artículo cuenta con un {porcentaje_descuento}% de descuento. Precio final: {(precio * (100 - porcentaje_descuento) / 100):F2}");
                Console.WriteLine("");
            }
        }

};

class Program {
    static void Main() {
        Console.WriteLine("===== VIDEOJUEGO 1 =====");
        Videojuego juego1 = new Videojuego();
        juego1.PonerNombre("Minecraft");
        juego1.PonerGenero("Sandbox");
        juego1.PonerPrecio(29.99);
        juego1.PonerPlataforma("PC");
        juego1.AplicarDescuento(20.5);
        juego1.MostrarInformacion();

        Console.WriteLine("===== VIDEOJUEGO 2 =====");
        Videojuego juego2 = new Videojuego();
        juego2.PonerNombre("Pokemon Pokopia");
        juego2.PonerGenero("Sandbox");
        juego2.PonerPrecio(69.99);
        juego2.PonerPlataforma("Nintendo Switch");
        juego2.MostrarInformacion();
    }
};