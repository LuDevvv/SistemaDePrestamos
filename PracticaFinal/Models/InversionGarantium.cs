using System;
using System.Collections.Generic;

namespace PracticaFinal.Models;

public partial class InversionGarantium
{
    public int IdGarantia { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public decimal Valor { get; set; }

    public string Ubicacion { get; set; } = null!;

    public int IdInversion { get; set; }

    public virtual Inversione IdInversionNavigation { get; set; } = null!;
}
