using System;
using System.Collections.Generic;

namespace PracticaFinal.Models;

public partial class Cliente
{
    public string Cedula { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? Telefono { get; set; }

    public virtual ICollection<Cuentum> Cuenta { get; } = new List<Cuentum>();

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}
