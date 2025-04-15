using System;
using System.Collections.Generic;

namespace Entidades.Models;

public partial class DetFact
{
    public DetFact(int idFactura, int idProducto, int? cantidad)
    {
        IdFactura = idFactura;
        IdProducto = idProducto;
        Cantidad = cantidad;
    }

    public int IdDetFact { get; set; }

    public int IdFactura { get; set; }

    public int IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public virtual CabFact IdFacturaNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
