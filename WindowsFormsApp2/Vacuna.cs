using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacunaNamespace
{
    public class Vacuna
    {
        public Vacuna(int perroID, string vacunaNombre, DateTime fecha, decimal precio)
        {
            ID = perroID;  // Asignamos perroID a la propiedad ID
            Nombre = vacunaNombre;  // Asignamos vacunaNombre a la propiedad Nombre
            Fecha = fecha;  // Asignamos fecha a la propiedad Fecha
            Precio = precio;  // Asignamos el precio
            Estado = (fecha == DateTime.MinValue) ? "Agendada" : "Suministrada";  // Asignamos el estado según la fecha
        }

        public int ID { get; set; }  // Propiedad pública para el ID del perro
        public string Nombre { get; set; }  // Propiedad pública para el nombre de la vacuna
        public DateTime Fecha { get; set; }  // Propiedad pública para la fecha
        public decimal Precio { get; set; }  // Propiedad para el precio de la vacuna
        public string Estado { get; set; }  // Propiedad para el estado de la vacuna (Suministrada o Agendada)
    }
}
