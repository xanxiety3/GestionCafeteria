using System;
using System.Collections.Generic;

namespace cafeteriaSena.Models;

public partial class TVenta
{
    public int Id { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? TotalPagado { get; set; }

    public int? IdTrabajador { get; set; }

    public virtual TTrabajadore? IdTrabajadorNavigation { get; set; }

    public virtual ICollection<TProductosxVenta> TProductosxVenta { get; set; } = new List<TProductosxVenta>();
}
