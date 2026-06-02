using System;

class Viaje
{
    private string nombre_cliente;
    private string nombre_conductor;
    private float distancia_viaje;
    private float precio_viaje;

    public Viaje() {
        nombre_cliente = "";
        nombre_conductor = "";
        distancia_viaje = 0;
        precio_viaje = 0;
    }

    public void PonerNombreCliente(string nombre_cliente) {
        this.nombre_cliente = nombre_cliente;
    }

    public void PonerNombreConductor(string nombre_conductor) {
        this.nombre_conductor = nombre_conductor;
    }

    public void PonerDistanciaViaje(float distancia_viaje) {
        this.distancia_viaje = distancia_viaje;
    }

    public void ActualizarInformacionViaje(string nombre_cliente, string nombre_conductor, float distancia_viaje) {
        PonerNombreCliente(nombre_cliente);
        PonerNombreConductor(nombre_conductor);
        PonerDistanciaViaje(distancia_viaje);
    }

    public void MostrarInformacion() {
        Console.WriteLine();
        Console.WriteLine("Cliente: " + nombre_cliente);
        Console.WriteLine("Conductor: " + nombre_conductor);
        Console.WriteLine("Distancia: " + distancia_viaje + " km");
        if (precio_viaje > 0) {
            Console.WriteLine("Precio: ₡" + precio_viaje);
        } else {
            Console.WriteLine("Precio: No se ha calculado el precio del viaje.");
        }
    }

    public void CalcularPrecio() {
        precio_viaje = distancia_viaje * 700f;
    }
}

class Program {

    static void PrintMenu() {
        Console.WriteLine("===== MINI UBER =====");
        Console.WriteLine("1. Registrar Viaje");
        Console.WriteLine("2. Mostrar información del viaje");
        Console.WriteLine("3. Calcular precio");
        Console.WriteLine("4. Salir");
    }

    static Viaje RegistrarViaje() {
        Console.Write("Ingrese el nombre del cliente: ");
        string nombre_cliente = Console.ReadLine() ?? "";

        Console.Write("Ingrese el nombre del conductor: ");
        string nombre_conductor = Console.ReadLine() ?? "";

        Console.Write("Ingrese la distancia del viaje (en km): ");
        float distancia_viaje = float.Parse(Console.ReadLine() ?? "0");

        Viaje viaje = new Viaje();
        viaje.ActualizarInformacionViaje(nombre_cliente, nombre_conductor, distancia_viaje);

        Console.WriteLine("Viaje registrado correctamente.");
        return viaje;
    }

    static void MostrarInformacionViaje(Viaje viaje) {
        if (viaje != null) {
            viaje.MostrarInformacion();
        } else {
            Console.WriteLine("No se ha registrado este viaje aún.");
        }
    }

    static void Main() {
        // Ejemplo mínimo: registrar un viaje y mostrar su información
        Viaje viaje = RegistrarViaje();
        MostrarInformacionViaje(viaje);
    }
}
