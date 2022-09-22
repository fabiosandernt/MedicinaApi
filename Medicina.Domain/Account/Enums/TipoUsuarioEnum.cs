using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Domain.Enums
{
    public enum TipoUsuarioEnum: int
    {
        [Description("Administrador")]
        Administrador = 1,

        [Description("Clínica")]
        Clinica = 2,

        [Description("Cliente")]
        Cliente = 3,
    }
}
