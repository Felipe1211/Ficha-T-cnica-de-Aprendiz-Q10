using ListaApp.Models;
using System;
using System.Collections.Generic;


namespace ListaApp.Services
{
    public class TareaService
    {
        private List<Tarea> tareas = new List<Tarea>();

        /// Agrega una nueva tarea a la lista.
        public void AgregarTarea(Tarea tarea)
        {
            tareas.Add(tarea); /// Añade la tarea a la lista
        }

        /// Lista todas las tareas registradas.
        public void ListarTareas()
        {
            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas en la lista.");
                return;
            }
            /// Recorre y muestra todas las tareas con su índice.
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i]}");
            }
        }

        public void MarcarComoCompletada(int index)
        {
            if (index < 0 || index >= tareas.Count)
            {
                Console.WriteLine("Índice de tarea no válido.");
                return;
            }

            tareas[index].Completada = true;
        }
        /// Elimina una tarea de la lista basándose en su índice.
        public void EliminarTarea(int index)
        {
            if (index < 0 || index >= tareas.Count)
            {
                Console.WriteLine("Índice de tarea no válido.");
                return;
            }

            tareas.RemoveAt(index); /// Elimina la tarea en el índice especificado.
        }
    }
}
