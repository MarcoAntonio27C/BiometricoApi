using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BiometricoApi.Entities
{
    public class Asistencia
    {
        public Guid Id { get; set; }
        public DateTime FechaHora { get; set; }

        [ForeignKey("EmpleadoId")]
      //  public Empleado Empleado { get; set; }
        public Guid EmpleadoId { get; set; }

    }
}
