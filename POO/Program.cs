using System;
using System.Collections.Generic;
using System;
using static POO.CuentaBancaria;
using Microsoft.VisualBasic.FileIO;

namespace POO
{
    public class Persona
    {
        // Atributos
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public const int MAYORIA_DE_EDAD = 18;

        // Constructor
        public Persona(string nombre, string apellido, int edad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }

        // Método para presentarse
        public void Presentarse()
        {
            Console.WriteLine("Hola, soy " + Nombre + " " + Apellido);
            Console.ReadLine();
        }
        public bool EsMayorDeEdad()
        {
            return Edad >= MAYORIA_DE_EDAD;
        }
    }
    public class Casa
    {
        // Atributos
        public int Capacidad { get; set; }
        public string ColorExterior { get; set; }
        public List<Persona> Habitantes { get; set; }
        public Direccion Direccion { get; set; }

        // Constructor
        public Casa(int capacidad, string colorExterior, Direccion direccion)
        {
            Capacidad = capacidad;
            ColorExterior = colorExterior;
            Habitantes = new List<Persona>();
            Direccion = direccion;
        }
        public void DescribirCasa()
        {
            Console.WriteLine("La casa tiene una capacidad para " + Capacidad + " personas y es de color " + ColorExterior + ". Se ubica en la calle " + Direccion.Calle + Direccion.Altura + ", " + Direccion.Ciudad + ", " + Direccion.Barrio + ".");
            Console.ReadLine();
        }
        public void PresentarHabitantes()
        {
            foreach (var habitante in Habitantes)
            {
                habitante.Presentarse();
            }
        }
        public void AgregarHabitante(Persona persona)
        {
            if (Habitantes.Count < Capacidad)
            {
                Habitantes.Add(persona);
            }
            else
            {
                Console.WriteLine("No se puede agregar más habitantes, la casa está llena.");
            }
        }
        public void PresentarMayoresDeEdad()
        {
            foreach (var habitante in Habitantes)
            {
                if (habitante.EsMayorDeEdad())
                {
                    habitante.Presentarse();
                }
            }
        }
    }
    public class Direccion
    {
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }

        // Constructor
        public Direccion(string calle, int altura, string ciudad, string barrio)
        {
            Calle = calle;
            Altura = altura;
            Ciudad = ciudad;
            Barrio = barrio;
        }

        // Método para obtener el código postal
        public int ObtenerCodigoPostal()
        {
            return Altura * Calle.Length;
        }
    }
    public class CuentaBancaria
    {
        public Persona Titular { get; set; }
        public decimal Saldo { get; set; }

        public CuentaBancaria(Persona titular)
        {
            Titular = titular;
            Saldo = 100000;
        }
        public void Depositar(decimal monto)
        {
            if (monto > 0)
            {
                Saldo += monto;
                Console.WriteLine("Se depositó " + monto + " en la cuenta de " + Titular.Nombre + " " + Titular.Apellido + ". Saldo actual: " + Saldo + ".");
            }
            else
            {
                Console.WriteLine("El monto tiene que ser positivo.");
            }
        }

        public void Retirar(decimal monto)
        {
            if (monto > 0 && Saldo >= monto)
            {
                Saldo -= monto;
                Console.WriteLine("Se retiró " + monto + " de la cuenta de " + Titular.Nombre + " " + Titular.Apellido + ". Saldo actual: " + Saldo);
            }
            else if (monto <= 0)
            {
                Console.WriteLine("El monto a retirar debe ser positivo.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para realizar el retiro.");
            }
        }
        public decimal ObtenerSaldo()
        {
            return Saldo;
        }
    }
    public class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int CantidadDisponible { get; set; }

        public Producto(string nombre, decimal precio, int cantidadDisponible)
        {
            Nombre = nombre;
            Precio = precio;
            CantidadDisponible = cantidadDisponible;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Producto: {Nombre}");
            Console.WriteLine($"Precio: {Precio:C}");
            Console.WriteLine($"Cantidad disponible: {CantidadDisponible}");
        }
        public void AjustarPrecio(decimal nuevoPrecio)
        {
        if (nuevoPrecio >= 0)
        {
            Precio = nuevoPrecio;
            Console.WriteLine($"El precio de {Nombre} ha sido ajustado a {Precio:C}");
        }
        else
        {
            Console.WriteLine("El precio no puede ser negativo.");
        }
    }

    public void AjustarCantidadDisponible(int nuevaCantidad)
    {
        if (nuevaCantidad >= 0)
        {
            CantidadDisponible = nuevaCantidad;
            Console.WriteLine("La cantidad disponible de " + Nombre + " ha sido ajustada a " + CantidadDisponible);
        }
        else
        {
            Console.WriteLine("La cantidad disponible no puede ser negativa.");
        }
    }
    public class CarritoDeCompras
    {
        private List<Producto> productos;

        public CarritoDeCompras()
        {
            productos = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
            Console.WriteLine(producto.Nombre + " ha sido agregado al carrito.");
        }

        public void EliminarProducto(Producto producto)
        {
            if (productos.Remove(producto))
            {
                Console.WriteLine(producto.Nombre + " ha sido eliminado del carrito.");
            }
            else
            {
                Console.WriteLine(producto.Nombre + " no se encuentra en el carrito.");
            }
        }

        public void MostrarCarrito()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            Console.WriteLine("Contenido del carrito:");
            foreach (var producto in productos)
            {
                producto.MostrarInformacion();
                Console.WriteLine();
            }
        }
        public void VaciarCarrito()
        {
            productos.Clear();
            Console.WriteLine("El carrito ha sido vaciado.");
        }
        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var producto in productos)
            {
               total += producto.Precio;
            }
            return total;
        }

        public void MostrarProductos()
        {
            Console.WriteLine("Productos en el carrito:");
            foreach (var producto in productos)
            {
               producto.MostrarInformacion();
            }
        }
    }
        class Empleado : Persona
        {
            public string Puesto { get; }
            public decimal Salario { get; set; }

            public Empleado(string nombre, string apellido, int edad, string puesto, decimal salario)
                : base(nombre, apellido, edad)
            {
                Puesto = puesto;
                Salario = salario;
            }

            public void AumentarSalario(decimal porcentaje)
            {
                if (porcentaje < 0)
                {
                    Console.WriteLine("El porcentaje no puede ser negativo.");
                    return;
                }

                decimal aumento = Salario * (porcentaje / 100);
                Salario += aumento;

                Console.WriteLine("Salario actualizado: " + Salario);
            }

            public void MostrarInformacion()
            {
                Console.WriteLine("Empleado: " + Nombre + " " + Apellido + ", Edad:" + Edad + ", Puesto: " + Puesto + ", Salario: " + Salario);
            }
        }
        class Estudiante : Persona
        {
            public string Carrera { get; }
            public decimal Promedio { get; private set; }

            public Estudiante(string nombre, string apellido, int edad, string carrera, decimal promedio)
                : base(nombre, apellido, edad)
            {
                Carrera = carrera;
                Promedio = promedio;
            }

            public void ActualizarPromedio(decimal nuevoPromedio)
            {
                if (nuevoPromedio < 0 || nuevoPromedio > 10)
                {
                    Console.WriteLine("El promedio debe estar entre 0 y 10.");
                    return;
                }

                Promedio = nuevoPromedio;
                Console.WriteLine("Promedio actualizado: " + Promedio);
            }

            public void MostrarInformacion()
            {
                Console.WriteLine("Estudiante: " + Nombre + " " + Apellido + ", Edad: " + Edad + ", Carrera: " + Carrera + ", Promedio: " + Promedio);
            }
        }
        class Libro
        {
            public string Titulo { get; }
            public string Autor { get; }
            public bool EstaPrestado { get; private set; }

            public Libro(string titulo, string autor)
            {
                Titulo = titulo;
                Autor = autor;
                EstaPrestado = false;
            }

            public void Prestar()
            {
                EstaPrestado = true;
            }

            public void Devolver()
            {
                EstaPrestado = false;
            }
        }

        class Socio : Persona
        {
            public Socio(string nombre, string apellido, int edad)
                : base(nombre, apellido, edad)
            {
            }
        }
        class Biblioteca
        {
            private List<Libro> libros;
            private List<Socio> socios;

            public Biblioteca()
            {
                libros = new List<Libro>();
                socios = new List<Socio>();
            }

            public void AgregarLibro(Libro libro)
            {
                libros.Add(libro);
                Console.WriteLine("Libro '" + libro.Titulo + "' agregado a la biblioteca.");
            }

            public void PrestarLibro(int indice, Socio socio)
            {
                if (indice < 0 || indice >= libros.Count)
                {
                    Console.WriteLine("Índice de libro no válido.");
                    return;
                }

                Libro libro = libros[indice];

                if (libro.EstaPrestado)
                {
                    Console.WriteLine("El libro '" + libro.Titulo + "' ya está prestado.");
                    return;
                }

                libro.Prestar();
                Console.WriteLine("El libro '" + libro.Titulo + "' ha sido prestado a " + socio.Nombre + " " + socio.Apellido);
            }

            public void DevolverLibro(int indice, Socio socio)
            {
                if (indice < 0 || indice >= libros.Count)
                {
                    Console.WriteLine("Índice de libro no válido.");
                    return;
                }

                Libro libro = libros[indice];

                if (!libro.EstaPrestado)
                {
                    Console.WriteLine("El libro '" + libro.Titulo + "' no está prestado.");
                    return;
                }

                libro.Devolver();
                Console.WriteLine("El libro '" + libro.Titulo + "' ha sido devuelto por " + socio.Nombre + " " + socio.Apellido);
            }

            public void MostrarLibros()
            {
                Console.WriteLine("Libros en la biblioteca:");
                foreach (var libro in libros)
                {
                    Console.WriteLine("- " + libro.Titulo + " por " + libro.Autor);
                }
            }
        }

        class Program
    {
        static void Main(string[] args)
        {
            Persona persona1 = new Persona("Agustin", "Fernandez", 10);
            Persona persona2 = new Persona("Ana", "Fernandez", 15);
            Persona persona3 = new Persona("Luis", "Fernandez", 18);

            Direccion direccion = new Direccion("Humahuaca", 3123, "CABA", "Almagro");

            Casa miCasa = new Casa(3, "azul", direccion);

            CuentaBancaria cuenta = new CuentaBancaria(persona3);

            Producto producto1 = new Producto("Monitor", 1500, 10);
            Producto producto2 = new Producto("Mouse", 25, 50);
            Producto producto3 = new Producto("Teclado", 75, 20);

            CarritoDeCompras carrito = new CarritoDeCompras();
            List<Producto> todosLosProductos = new List<Producto> { producto1, producto2, producto3 };

            Empleado empleado = new Empleado("Lucas", "Gimenez", 30, "Desarrollador", 50000m);

            Estudiante estudiante = new Estudiante("Santiago", "Lopez", 20, "Ingeniería de Sistemas", 8.5m);

            Biblioteca biblioteca = new Biblioteca();

            Libro libro1 = new Libro("1984", "George Orwell");
            Libro libro2 = new Libro("El Principito", "Antoine de Saint-Exupéry");

            Socio socio1 = new Socio("Juan", "Pérez", 30);

            while (true)
            {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Ver informacion de la casa");
            Console.WriteLine("2. Ver saldo");
            Console.WriteLine("3. Carrito y productos");
            Console.WriteLine("4. Empleados");
            Console.WriteLine("5. Alumnos");
            Console.WriteLine("6. Biblioteca");
            Console.WriteLine("7. Salir");

            string opcion = Console.ReadLine();

                if(opcion=="1")
                {
                    miCasa.AgregarHabitante(persona1);
                    miCasa.AgregarHabitante(persona2);
                    miCasa.AgregarHabitante(persona3);
            
                    miCasa.DescribirCasa();
                    Console.WriteLine("Código Postal:" + direccion.ObtenerCodigoPostal());
                    Console.ReadLine();

                    Console.WriteLine("Integrantes de la casa:");
                    miCasa.PresentarHabitantes();

                    Console.WriteLine("Integrantes de la casa mayores de edad:");
                    miCasa.PresentarMayoresDeEdad();
                }
                else if(opcion == "2"){
                    while (true)
                    {
                        Console.WriteLine("Seleccione una opción:");
                        Console.WriteLine("1. Ver saldo actual");
                        Console.WriteLine("2. Depositar dinero");
                        Console.WriteLine("3. Retirar dinero");
                        Console.WriteLine("4. Salir");

                        string option = Console.ReadLine();

                        if (option == "4")
                        {
                            break;
                        }
                        else if (option == "1")
                        {
                                Console.WriteLine("Saldo actual: " + cuenta.ObtenerSaldo());
                            }
                            else if (option == "3")
                        {
                            Console.WriteLine("Ingrese el monto a retirar: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal montoARetirar))
                            {
                                cuenta.Retirar(montoARetirar);
                            }
                            else
                            {
                                Console.WriteLine("Monto inválido. Por favor, ingrese un número válido.");
                                Console.ReadLine();
                            }
                        }
                        else if (option == "2")
                        {
                            Console.WriteLine("Ingrese el monto a depositar: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal montoADepositar))
                            {
                                cuenta.Depositar(montoADepositar);
                            }
                            else
                            {
                                Console.WriteLine("Monto inválido. Por favor, ingrese un número válido.");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                            Console.ReadLine();
                        }
                    }
                }
                else if (opcion == "3")
                {
                        while (true)
                        {
                            Console.WriteLine("Selecciona una opción: ");
                            Console.WriteLine("1. Agregar producto al carrito");
                            Console.WriteLine("2. Eliminar producto del carrito");
                            Console.WriteLine("3. Mostrar productos en el carrito");
                            Console.WriteLine("4. Calcular total del carrito");
                            Console.WriteLine("5. Vaciar carrito");
                            Console.WriteLine("6. Salir");
                            
                            string option = Console.ReadLine();
                            if (option == "1")
                            {
                                Console.WriteLine("Selecciona un producto para agregar:");
                                for (int i = 0; i < todosLosProductos.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {todosLosProductos[i].Nombre}");
                                }
                                int agregarOpcion = int.Parse(Console.ReadLine()) - 1;
                                if (agregarOpcion >= 0 && agregarOpcion < todosLosProductos.Count)
                                {
                                    carrito.AgregarProducto(todosLosProductos[agregarOpcion]);
                                }
                                else
                                {
                                    Console.WriteLine("Opción no válida.");
                                }
                            }
                            else if (option == "2")
                            {
                                Console.WriteLine("Selecciona un producto para eliminar:");
                                carrito.MostrarProductos();
                                if (todosLosProductos.Count == 0)
                                {
                                    break; // Si el carrito está vacío, no se puede eliminar nada
                                }
                                int eliminarOpcion = int.Parse(Console.ReadLine()) - 1;
                                if (eliminarOpcion >= 0 && eliminarOpcion < todosLosProductos.Count)
                                {
                                    carrito.EliminarProducto(todosLosProductos[eliminarOpcion]);
                                }
                                else
                                 {
                                    Console.WriteLine("Opción no válida.");
                                 }
                            }
                            else if (option == "3")
                            {
                                carrito.MostrarProductos();
                            }
                            else if (option == "4")
                            {
                                Console.WriteLine("Total del carrito: " + carrito.CalcularTotal());
                            }
                            else if (option == "5")
                            {
                                carrito.VaciarCarrito();
                            }
                            else if (option == "6")
                            {
                                break;
                            }
                        }
                }
                    else if (opcion == "4")
                    {
                        while (true)
                        {
                            Console.WriteLine("1. Ver informacion del empleado ");
                            Console.WriteLine("2. Aumentar el porcentaje del salario del empleado ");
                            Console.WriteLine("3. Salir ");
                            string option = Console.ReadLine();
                            if (option == "1")
                            {
                                empleado.MostrarInformacion();
                            }
                            else if (option == "2")
                            {
                                Console.WriteLine("Ingrese el porcentaje de aumento del salario: ");
                                string input = Console.ReadLine();

                                if (decimal.TryParse(input, out decimal porcentaje))
                                {
                                    empleado.AumentarSalario(porcentaje);
                                }
                                else
                                {
                                    Console.WriteLine("Por favor, ingrese un número válido.");
                                }
                                empleado.MostrarInformacion();
                            }
                            else if (option == "3")
                            {
                                break;
                            }

                        }
                    }
                    else if (opcion == "5")
                    {
                        while (true)
                        {
                            Console.WriteLine("1. Ver informacion del alumno ");
                            Console.WriteLine("2. Actualizar el promedio del alumno ");
                            Console.WriteLine("3. Salir ");
                            string option = Console.ReadLine();
                            if (option == "1")
                            {
                                estudiante.MostrarInformacion();
                            }
                            else if (option == "2")
                            {
                                Console.WriteLine("Ingrese el nuevo promedio del estudiante: ");
                                string input = Console.ReadLine();

                                if (decimal.TryParse(input, out decimal nuevoPromedio))
                                {
                                    estudiante.ActualizarPromedio(nuevoPromedio);
                                }
                                else
                                {
                                    Console.WriteLine("Por favor, ingrese un número válido.");
                                }

                                // Mostrar la información actualizada
                                estudiante.MostrarInformacion();
                            }
                            else if (option == "3")
                            {
                                break;
                            }

                        }
                    }
                    else if (opcion == "6")
                    {
                        while (true)
                        {
                            Console.WriteLine("1. Libros ");
                            Console.WriteLine("2. Agregar un libro ");
                            Console.WriteLine("3. Prestar libro ");
                            Console.WriteLine("4. Devolver libro ");
                            Console.WriteLine("5. Salir ");
                            string option = Console.ReadLine();
                            if (option == "1")
                            {
                                biblioteca.MostrarLibros();
                            }
                            else if (option == "2")
                            {
                                Console.WriteLine("Ingresa el título del libro: ");
                                string titulo = Console.ReadLine();

                                Console.WriteLine("Ingresa el autor del libro: ");
                                string autor = Console.ReadLine();

                                Libro nuevoLibro = new Libro(titulo, autor);
                                biblioteca.AgregarLibro(nuevoLibro);
                            }
                            else if (option == "3")
                            {
                                Console.Write("Ingresa el número del libro a prestar: ");
                                if (int.TryParse(Console.ReadLine(), out int indiceLibroPrestar))
                                {
                                    biblioteca.PrestarLibro(indiceLibroPrestar - 1, socio1);
                                }
                                else
                                {
                                    Console.WriteLine("Entrada no válida.");
                                }
                                biblioteca.MostrarLibros();
                            }
                            else if (option == "4")
                            {
                                Console.Write("Ingresa el número del libro a devolver: ");
                                if (int.TryParse(Console.ReadLine(), out int indiceLibroDevolver))
                                {
                                    biblioteca.DevolverLibro(indiceLibroDevolver - 1, socio1);
                                }
                                else
                                {
                                    Console.WriteLine("Entrada no válida.");
                                }
                                biblioteca.MostrarLibros();
                            }
                            else if (option == "5")
                            {
                                break;
                            }
                        }
                    }
                    else if (opcion == "7")
                    {
                        break;
                    }
                }
            }
        }
    }
}
