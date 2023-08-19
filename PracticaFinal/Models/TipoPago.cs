using System;
using System.Collections.Generic;

namespace PracticaFinal.Models;

public partial class TipoPago
{
    public int IdTipo { get; set; }

    public string TipoPago1 { get; set; } = null!;

    public virtual ICollection<CuotaInversion> CuotaInversions { get; } = new List<CuotaInversion>();

    public virtual ICollection<CuotaPrestamo> CuotaPrestamos { get; } = new List<CuotaPrestamo>();
}
