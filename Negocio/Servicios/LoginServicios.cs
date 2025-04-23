using Dtos.UsuariosDTOS;
using Dtos;
using Encryptar.Encriptador;
using Entidades.Context;
using JWT.JwtServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Negocio.Servicios
{
    public class LoginServicios
    {
        private readonly PracticaContext _context;
        private readonly ITokenServicio _tokenServicio;

        public LoginServicios(PracticaContext context, ITokenServicio tokenServicio)
        {
            _context = context;
            _tokenServicio = tokenServicio;
        }

        public async Task<ResponseBase<string>> Login(UsuarioLoginDTO loginDto)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(x => x.CodigoUsuario == loginDto.Nombre);

            if (usuario == null || usuario.Contrasenia != Encriptador.Encriptar(loginDto.Contrasenia))
            {
                return new ResponseBase<string>(400, "Credenciales incorrectas");
            }

            var usuarioDto = new UsuariosDT(usuario.IdUsuario, usuario.Nombre, usuario.Contrasenia);
            string token = _tokenServicio.CrearToken(usuarioDto);
            return new ResponseBase<string>(200, "Login exitoso", token);
        }
    }
}
