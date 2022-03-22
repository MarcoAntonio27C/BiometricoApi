using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiometricoApi.Entities
{
    public class Empleado
    {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; }
        public byte[] Huella { get; set; }

    }
}
