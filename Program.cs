using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cajero_automatico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir) 
            { 
                Console.Clear();
                Console.WriteLine(" === CAJERO AUTOMATICO === ");
                Console.WriteLine("1. Iniciar sesión");
                Console.WriteLine("2. Registrar usuario");
                Console.WriteLine("3. Salir");
                Console.Write("3. Seleccione una opcion: ");

                string opcion = Console.ReadLine();

                switch (opcion) 
                {
                    case "1":
                        Console.WriteLine("\n[Opcion Iniciar sesión todavia no implementada]");
                        Console.ReadKey();
                        break;
                    
                    case "2":
                        RegistrarUsuario();
                        break;
                    case "3":
                        Console.WriteLine("\n[Saliendo del sistema]");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\n Opcion no válida.");
                        Console.ReadKey();
                        break;
                }
            }

        }
        static List<Usuario> usuarios = new List<Usuario>();

        static void RegistrarUsuario() 
        {
            Console.Clear();
            Console.WriteLine("=== Registro de Usuario ===");

            Console.Write("Nombre completo: ");
            string nombre = Console.ReadLine();

            Console.Write("Documento: ");
            string documento = Console.ReadLine();

            Console.Write("Clave: ");
            string clave = Console.ReadLine();

            Usuario nuevo = new Usuario(nombre, documento, clave);

            usuarios.Add(nuevo);

            Console.WriteLine("\nUsuario registrado con éxito.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
