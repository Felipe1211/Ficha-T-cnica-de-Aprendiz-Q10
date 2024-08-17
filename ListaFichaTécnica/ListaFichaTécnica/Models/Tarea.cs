using System;

namespace ListaApp.Models
{
    public class Tarea
    {
        public string Descripcion { get; set; }
        public DateTime? FechaLimite { get; set; }
        public bool Completada { get; set; }

        public Tarea(string descripcion, DateTime? fechaLimite = null)
        {
            Descripcion = descripcion;
            FechaLimite = fechaLimite;
            Completada = false; /// Por defecto, una tarea recién creada no está completada.
        }
        /// Representa la tarea en formato de cadena.
        public override string ToString()
        {
            return $"{Descripcion} - {(FechaLimite.HasValue ? FechaLimite.Value.ToShortDateString() : "Sin fecha límite")} - {(Completada ? "Completada" : "Pendiente")}";
        }
    }
}