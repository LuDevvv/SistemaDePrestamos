using System;
using System.Collections.Generic;

namespace PracticaFinal.Models;

public partial class CuotaInversion
{
    public int CodCuota { get; set; }

    public DateTime FechaPlanificada { get; set; }

    public int Monto { get; set; }

    public DateTime? FechaRealizada { get; set; }

    public string? CodComprobante { get; set; }

    public int IdInversion { get; set; }

    public int TipoTransaccion { get; set; }

    public virtual Inversione IdInversionNavigation { get; set; } = null!;

    public virtual TipoPago TipoTransaccionNavigation { get; set; } = null!;
}
