using ChatServerApp.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando servidor en el puerto: {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);
            if (servidor.Iniciar())
            {
                while (true)
                {
                    //esperar a que se conecte un cliente
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Esperando conexion de Cliente");
                    if (servidor.ObtenerCliente())
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Cliente conectado");
                        Console.WriteLine("S: zZZzz");
                        servidor.Escribir("Wakeup Neo");
                        string mensaje = servidor.Leer();
                        Console.WriteLine("el cliente me dijo {0}", mensaje);
                        servidor.CerrarConexion();
                    }
                }
            }else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al iniciar el servidor");
                Console.ReadKey();
            }
        }
    }
}

//TODO APLICACION DEL CLIENTE