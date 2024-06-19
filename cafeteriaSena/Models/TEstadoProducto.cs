using System;
using System.Collections.Generic;

namespace cafeteriaSena.Models;

public partial class TEstadoProducto
{
    public int Id { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<TProducto> TProductos { get; set; } = new List<TProducto>();
}
