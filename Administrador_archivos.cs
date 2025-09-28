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

            if (!File.Exists(Ruta_usuarios)) {
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
    }
}
