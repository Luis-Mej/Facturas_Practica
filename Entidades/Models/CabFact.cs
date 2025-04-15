using System;
using System.Collections.Generic;

namespace Entidades.Models;

public partial class CabFact
{
    public CabFact(string nombreCliente, string identificacion, string? telefono, string? email, DateTime? fechaCreacion, decimal subTotal, decimal? iva, decimal? total)
    {
        NombreCliente = nombreCliente;
        Identificacion = identificacion;
        Telefono = telefono;
        Email = email;
        FechaCreacion = fechaCreacion;
        SubTotal = subTotal;
        Iva = iva;
        Total = total;
    }

    public int IdFactura { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public decimal SubTotal { get; set; }

    public decimal? Iva { get; set; }

    public decimal? Total { get; set; }

    public int? IdUsuario { get; set; }

    public virtual ICollection<DetFact> DetFacts { get; set; } = new List<DetFact>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
