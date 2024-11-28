using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacunaNamespace
{
    public class Vacuna
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } // "Suministrada" o "Agendada"
    }

}
