using System;
using System.Collections.Generic;

namespace PracticaFinal.Models;

public partial class Inversione
{
    public int IdInversion { get; set; }

    public decimal Monto { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFinal { get; set; }

    public decimal Interes { get; set; }

    public int IdCuenta { get; set; }

    public virtual ICollection<CuotaInversion> CuotaInversions { get; } = new List<CuotaInversion>();

    public virtual Cuentum IdCuentaNavigation { get; set; } = null!;

    public virtual ICollection<InversionGarantium> InversionGarantia { get; } = new List<InversionGarantium>();
}
