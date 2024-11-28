using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacunaNamespace
{
    public class Vacuna
    {
        public Vacuna(int perroID, string vacunaNombre, DateTime fecha)
        {
            ID = perroID;  // Asignamos perroID a la propiedad ID
            Nombre = vacunaNombre;  // Asignamos vacunaNombre a la propiedad Nombre
            Fecha = fecha;  // Asignamos fecha a la propiedad Fecha
        }

        public int ID { get; set; }  // Propiedad pública para el ID del perro
        public string Nombre { get; set; }  // Propiedad pública para el nombre de la vacuna
        public DateTime Fecha { get; set; }  // Propiedad pública para la fecha
        public string Estado { get; set; }  // Propiedad para el estado de la vacuna (Suministrada o Agendada)
    }


}
