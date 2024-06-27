using System;
using System.Collections.Generic;

namespace cafeteria.Models;

public partial class TTrabajadore
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? IdTipoDoc { get; set; }

    public int? NumDocumento { get; set; }

    public string? Direccion { get; set; }

    public int? Telefono { get; set; }

    public int? IdGenero { get; set; }

    public int? Estado { get; set; }

    public string? Usuario { get; set; }

    public string? Contrasenia { get; set; }

    public int? IdRol { get; set; }

    public virtual TGenero? IdGeneroNavigation { get; set; }

    public virtual TRole? IdRolNavigation { get; set; }

    public virtual TTiposDoc? IdTipoDocNavigation { get; set; }

    public virtual ICollection<TVenta> TVenta { get; set; } = new List<TVenta>();
}
