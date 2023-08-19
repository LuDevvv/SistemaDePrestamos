using System;
using System.Collections.Generic;

namespace PracticaFinal.Models;

public partial class Cuentum
{
    public int IdCuenta { get; set; }

    public string Banco { get; set; } = null!;

    public int Tipo { get; set; }

    public string IdCliente { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<Inversione> Inversiones { get; } = new List<Inversione>();

    public virtual TipoCuentum TipoNavigation { get; set; } = null!;
}
