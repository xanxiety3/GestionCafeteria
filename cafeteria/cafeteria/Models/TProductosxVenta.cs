using System;
using System.Collections.Generic;

namespace cafeteria.Models;

public partial class TProductosxVenta
{
    public int Id { get; set; }

    public int? IdVenta { get; set; }

    public int? IdProductos { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precioxcantidad { get; set; }

    public virtual TProducto? IdProductosNavigation { get; set; }

    public virtual TVenta? IdVentaNavigation { get; set; }
}
