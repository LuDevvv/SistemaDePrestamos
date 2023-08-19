using System;
using System.Collections.Generic;

namespace PracticaFinal.Models;

public partial class Prestamo
{
    public int Idprestamo { get; set; }

    public decimal Monto { get; set; }

    public DateTime FechaAprobacion { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFinal { get; set; }

    public decimal Interes { get; set; }

    public string IdCliente { get; set; } = null!;

    public virtual ICollection<CuotaPrestamo> CuotaPrestamos { get; } = new List<CuotaPrestamo>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<PrestamoGarantium> PrestamoGarantia { get; } = new List<PrestamoGarantium>();
}
