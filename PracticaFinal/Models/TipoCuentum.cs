using System;
using System.Collections.Generic;

namespace PracticaFinal.Models;

public partial class TipoCuentum
{
    public int IdTipo { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Cuentum> Cuenta { get; } = new List<Cuentum>();
}
