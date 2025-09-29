using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlTypes;

namespace Cajero_automatico
{
    internal class Administrador_archivos
    {
        //creamos una ruta relativa al archivo
        private static string Ruta_usuarios = "usuarios.txt";

        //Guarda el usuario nuevo
        public static void Guardar_usuario(Usuario usuario)
        {
            using (StreamWriter sw = new StreamWriter(Ruta_usuarios, true))
            {
                sw.WriteLine($"{usuario.Nombre};{usuario.Documento};{usuario.Clave};{usuario.Saldo}");
            }
        }
        //Carga los usuarios desde el archivo .txt
        public static List<Usuario> Cargar_usuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            if (!File.Exists(Ruta_usuarios))
            {
                return usuarios;
            }

            string[] lineas = File.ReadAllLines(Ruta_usuarios);

            foreach (string linea in lineas)
            {
                string[] partes = linea.Split(';');
                if (partes.Length == 4)
                {
                    string nombre = partes[0];
                    string documento = partes[1];
                    string clave = partes[2];
                    decimal saldo = decimal.Parse(partes[3]);

                    usuarios.Add(new Usuario(nombre, documento, clave, saldo));
                }
            }
            return usuarios;
        }

        public static void Actualizar_usuario(Usuario Usuario_actualizado)
        {
            //cargamos los usuarios 
            List<Usuario> usuarios = Cargar_usuarios();

            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].Documento == Usuario_actualizado.Documento)
                {
                    usuarios[i] = Usuario_actualizado;
                    break;
                }
            }

            //reescribimos todo el arcivo txt

            using (StreamWriter sw = new StreamWriter(Ruta_usuarios, false))
            {
                foreach (var Usuario_reescrito in usuarios)
                { 
                    sw.WriteLine($"{Usuario_reescrito.Nombre};{Usuario_reescrito.Documento};{Usuario_reescrito.Clave};{Usuario_reescrito.Saldo}");
                }
            }
        }
    }
}
