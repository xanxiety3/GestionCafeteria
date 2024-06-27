using System;
using System.Collections.Generic;

namespace cafeteria.Models;

public partial class TProducto
{
    public int Id { get; set; }

    public string? Referencia { get; set; }

    public string? Nombre { get; set; }

    public int? Precio { get; set; }

    public int? Cantidad { get; set; }

    public string? Descripcion { get; set; }

    public int? IdEstado { get; set; }

    public int? IdCategoria { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public virtual TCategoria? IdCategoriaNavigation { get; set; }

    public virtual TEstadoProducto? IdEstadoNavigation { get; set; }

    public virtual ICollection<TProductosxVenta> TProductosxVenta { get; set; } = new List<TProductosxVenta>();

    public virtual ICollection<TProductoxProveedore> TProductoxProveedores { get; set; } = new List<TProductoxProveedore>();
}
