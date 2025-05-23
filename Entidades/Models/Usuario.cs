﻿using System;
using System.Collections.Generic;

namespace Entidades.Models;

public partial class Usuario
{
    public Usuario(string nombre, string codigoUsuario, string contrasenia ,string estado)
    {
        Nombre = nombre;
        CodigoUsuario = codigoUsuario;
        Contrasenia = contrasenia;
        Estado = estado;
    }

    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string CodigoUsuario { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<CabFact> CabFacts { get; set; } = new List<CabFact>();
}
