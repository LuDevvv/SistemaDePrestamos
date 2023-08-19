using System;
using System.Collections.Generic;

namespace PracticaFinal.Models;

public partial class CuotaPrestamo
{
    public int CodCuota { get; set; }

    public DateTime FechaPlanificada { get; set; }

    public int Monto { get; set; }

    public DateTime? FechaRealizada { get; set; }

    public string? CodComprobante { get; set; }

    public int IdPrestamo { get; set; }

    public int TipoTransaccion { get; set; }

    public virtual Prestamo IdPrestamoNavigation { get; set; } = null!;

    public virtual TipoPago TipoTransaccionNavigation { get; set; } = null!;
}
