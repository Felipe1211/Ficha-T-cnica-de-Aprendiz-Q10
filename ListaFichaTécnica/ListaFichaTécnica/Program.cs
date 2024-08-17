using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaApp.Services;
using ListaApp.Models;
using System.Threading;

namespace ListaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TareaService tareaService = new TareaService();
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("===============================================");
                Console.WriteLine("===============================================");
                Console.WriteLine("===-----------------------------------------===");
                Console.WriteLine("===-----------------------------------------===");
                Console.WriteLine("===-------------Lista de Tareas-------------===");
                Console.WriteLine("===-----------------------------------------===");
                Console.WriteLine("===---1.Agregar tarea-----------------------===");
                Console.WriteLine("===---2.Listar tareas-----------------------===");
                Console.WriteLine("===---3.Marcar tarea como completada--------===");
                Console.WriteLine("===---4.Eliminar tarea----------------------===");
                Console.WriteLine("===---5.Salir-------------------------------===");
                Console.WriteLine("===-----------------------------------------===");
                Console.WriteLine("===-----------------------------------------===");
                Console.WriteLine("===============================================");
                Console.WriteLine("===============================================");
                Console.Write("Selecciona una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AgregarTarea(tareaService);
                        break;
                    case "2":
                        tareaService.ListarTareas();
                        Console.ReadKey();
                        break;
                    case "3":
                        MarcarTareaComoCompletada(tareaService);
                        break;
                    case "4":
                        EliminarTarea(tareaService);
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void AgregarTarea(TareaService tareaService)
        {
            Console.Write("Descripción de la tarea: ");
            string descripcion = Console.ReadLine();
            Console.Write("Fecha límite (yyyy-mm-dd): ");
            DateTime? fechaLimite = null;
            if (DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                fechaLimite = fecha;
            }

            Tarea tarea = new Tarea(descripcion, fechaLimite);
            tareaService.AgregarTarea(tarea);
        }

        private static void MarcarTareaComoCompletada(TareaService tareaService)
        {
            tareaService.ListarTareas();
            Console.Write("Digita el número de la tarea para marcarla como completada: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                tareaService.MarcarComoCompletada(index - 1);
            }
            else
            {
                Console.WriteLine("Entrada no válida.");
            }
        }

        private static void EliminarTarea(TareaService tareaService)
        {
            tareaService.ListarTareas();
            Console.Write("Digita el número de la tarea que deseas eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                tareaService.EliminarTarea(index - 1);
            }
            else
            {
                Console.WriteLine("Entrada no válida.");
            }
        }
    }
}

