﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UsuariosDTOS
{
    public class UsuarioLoginDTO
    {
        public UsuarioLoginDTO()
        {
        }
        public UsuarioLoginDTO(string nombre, string contrasenia, int idUsuario = 0)
        {
            Nombre = nombre;
            Contrasenia = contrasenia;
            IdUsuario = idUsuario;
        }

        public string Nombre { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
    }
}
