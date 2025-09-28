using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cajero_automatico
{
    internal class Program
    {
        static List<Usuario> usuarios = new List<Usuario>();

        static void Main(string[] args)
        {
            //carga los posibles usuarios ya creados
            usuarios = Administrador_archivos.Cargar_usuarios();

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
                        Iniciar_sesion();
                        break;

                    case "2":
                        Registrar_usuario();
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
        static void Registrar_usuario()
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

            //guarda el usuario nuevo en el .txt al momento de ser creado
            Administrador_archivos.Guardar_usuario(nuevo);

            Console.WriteLine("\nUsuario registrado con éxito.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void Iniciar_sesion()
        {
            Console.Clear();
            Console.WriteLine("=== Inicio de Sesion ===");

            Usuario encontrado = null;

            while (encontrado == null)
            {
                Console.Write("Documento: ");
                string documento = Console.ReadLine();

                Console.Write("Clave: ");
                string clave = Console.ReadLine();


                foreach (var usuario in usuarios)
                {
                    if (usuario.Documento == documento && usuario.Clave == clave)
                    {
                        encontrado = usuario;
                        break;
                    }
                }

                if (encontrado == null)
                {
                    Console.Clear();
                    Console.WriteLine($"\n Credenciales incorrectas!");
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }


            }

            Console.Clear();
            Console.WriteLine($"\n Bienvenido, {encontrado.Nombre}!");
            Console.WriteLine($"\n Saldo actual, {encontrado.Saldo:C}!");
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

    }
}
