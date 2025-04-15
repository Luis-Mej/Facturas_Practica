using System;
using System.Collections.Generic;

namespace Entidades.Models;

public partial class Producto
{
    public Producto(string nombre, decimal precio, int stock, string? estado)
    {
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
        Estado = estado;
    }

    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<DetFact> DetFacts { get; set; } = new List<DetFact>();
}
