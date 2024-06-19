using System;
using System.Collections.Generic;

namespace cafeteriaSena.Models;

public partial class TProveedore
{
    public int Id { get; set; }

    public int? Nit { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Contacto { get; set; }

    public virtual ICollection<TProductoxProveedore> TProductoxProveedores { get; set; } = new List<TProductoxProveedore>();
}
