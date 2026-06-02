using System;

class Viaje
{
    private string nombre_cliente;
    private string nombre_conductor;
    private float distancia_viaje;
    private float precio_viaje;
    private string tipo_vehiculo;
    private float tiempo_viaje;
    private float calificacion_conductor;
    private bool cobro_nocturno;

    public Viaje() {
        nombre_cliente = "";
        nombre_conductor = "";
        distancia_viaje = 0;
        precio_viaje = 0;
        tipo_vehiculo = "";
        tiempo_viaje = 0;
        calificacion_conductor = 0;
        cobro_nocturno = false;
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

    public void PonerTipoVehiculo() {
        Console.WriteLine("Seleccione el tipo de vehículo:");
        Console.WriteLine("1. Sedán/Hatchback");
        Console.WriteLine("2. SUV");
        Console.WriteLine("3. Moto");
        Console.Write("Ingrese alguna opción: ");
        string tipo = Console.ReadLine() ?? "";
        switch (tipo) {
            case "1":
                this.tipo_vehiculo = "Sedán/Hatchback";
                break;
            case "2":
                this.tipo_vehiculo = "SUV";
                break;
            case "3":
                this.tipo_vehiculo = "Moto";
                break;
            default:
                Console.WriteLine("Opción inválida. Se asignará el tipo de vehículo por defecto (Sedán/Hatchback).");
                this.tipo_vehiculo = "Sedán/Hatch";
                break;
        }
    }

    public void PonerTiempoViaje(float tiempo_viaje) {
        this.tiempo_viaje = tiempo_viaje;
    }

    public void PonerCalificacionConductor(float calificacion_conductor) {
        this.calificacion_conductor = calificacion_conductor;
    }

    public void PonerCobroNocturno(bool cobro_nocturno) {
        this.cobro_nocturno = cobro_nocturno;
    }

    public int ObtenerTrafico() {
        Random random = new Random();
        int velocidad_trafico = random.Next(10, 80);
        return velocidad_trafico;
    }

    public int ObtenerCalificacionAleatoria() {
        Random random = new Random();
        int calificacion_conductor = random.Next(7, 11);
        return calificacion_conductor;
    }

    public void ActualizarInformacionViaje(string nombre_cliente, string nombre_conductor, float distancia_viaje) {
        int velocidad_trafico = ObtenerTrafico();
        int calificacion_conductor = ObtenerCalificacionAleatoria();

        PonerNombreCliente(nombre_cliente);
        PonerNombreConductor(nombre_conductor);
        PonerDistanciaViaje(distancia_viaje);
        PonerTipoVehiculo();
        PonerTiempoViaje(distancia_viaje / velocidad_trafico);
        PonerCalificacionConductor(calificacion_conductor);
        if (DateTime.Now.Hour >= 22 || DateTime.Now.Hour < 6) {
            PonerCobroNocturno(true);
        } else {
            PonerCobroNocturno(false);
        }
    }

    public void MostrarInformacion() {
        Console.WriteLine();
        Console.WriteLine("===== INFORMACIÓN DEL VIAJE =====");
        Console.WriteLine("Cliente: " + nombre_cliente);
        Console.WriteLine("Conductor: " + nombre_conductor + " (Calificación: " + calificacion_conductor + "/10)");
        Console.WriteLine("Tipo de vehículo: " + tipo_vehiculo);
        Console.WriteLine("Distancia: " + distancia_viaje + " km");
        Console.WriteLine("Tiempo estimado: " + (tiempo_viaje * 60).ToString("F1") + " min");
        if (precio_viaje > 0) {
            float precio_final = precio_viaje;
            if (distancia_viaje > 10) {
                precio_final = precio_final * 0.95f;
            }
            if (cobro_nocturno) {
                precio_final = precio_final * 1.2f;
            }
            Console.WriteLine("Precio: ₡" + precio_final);
        } else {
            Console.WriteLine("Precio: No se ha calculado el precio del viaje.");
        }
        if (distancia_viaje > 10) {
            Console.Write("\nEste se trata de un viaje largo.");
            if (distancia_viaje > 10) {
                Console.Write(" Se aplica un 5% de descuento por ser un viaje largo.");
            }
            if (cobro_nocturno) {
                Console.Write(" Se aplica un 20% de recargo por ser un viaje nocturno.");
            }
        } else {
            Console.WriteLine("\nEste se trata de un viaje corto.");
        }
    }

    public void CalcularPrecio() {
        precio_viaje = distancia_viaje * 700f;
    }
}

class Program {

    static void ImprimirMenu() {
        Console.WriteLine("\n===== MINI UBER =====");
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

        Console.WriteLine("\nViaje registrado correctamente.");
        return viaje;
    }

    static void Main() {
        bool continuar = true;
        string opcion = "";
        Viaje viaje = null;

        while (continuar) {
            ImprimirMenu();

            // Manejo de opciones del menú
            Console.Write("\nSeleccione una opción: ");
            opcion = Console.ReadLine() ?? "";
            Console.WriteLine();

            switch (opcion) {
                case "1":
                    viaje = RegistrarViaje();
                    break;
                case "2":
                    if (viaje != null) {
                        viaje.MostrarInformacion();
                    } else {
                        Console.WriteLine("No se ha registrado ningún viaje aún.");
                    }
                    break;
                case "3":
                    if (viaje != null) {
                        viaje.CalcularPrecio();
                        Console.WriteLine("Precio calculado correctamente.");
                    } else {
                        Console.WriteLine("No se ha registrado ningún viaje aún.");
                    }
                    break;
                case "4":
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción del menú.");
                    break;
            }
        }
    }
}
