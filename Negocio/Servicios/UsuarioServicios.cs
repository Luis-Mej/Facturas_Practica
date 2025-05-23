﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;
using Dtos.UsuariosDTOS;
using Encryptar.Encriptador;
using JWT.JwtServicios;
using Microsoft.EntityFrameworkCore;
using Entidades.Context;
using Entidades.Models;
using Extensiones;

namespace Negocio.Servicios
{
    public class UsuarioServicios
    {
        private readonly PracticaContext _context;

        public UsuarioServicios(PracticaContext context)
        {  
            _context = context;
        }

        public async Task<ResponseBase<List<UsuariosDT>>> GetUsuarioDTO()
        {
            var listaUsuarios = await _context.Usuarios.Where(x=> x.Estado == "A").Select(x => new UsuariosDT()
            {
                CodigoUsuario = x.CodigoUsuario,
                Nombre = x.Nombre
            }).ToListAsync();

            return new ResponseBase<List<UsuariosDT>>(200, listaUsuarios);
        }

        public async Task<ResponseBase<UsuarioDTOs>> PostUsuarioDTO(UsuarioDTOs usuarioDTOs)
        {
            var usuarioExiste = await _context.Usuarios.FirstOrDefaultAsync(x => x.Nombre == usuarioDTOs.Nombre);
            if (usuarioExiste != null)
            {
                return new ResponseBase<UsuarioDTOs>(400, "Usuario ya existente.");
            }

            using var ts = await _context.Database.BeginTransactionAsync();
            {

                var usuarioregistro = new Usuario(usuarioDTOs.Nombre, usuarioDTOs.Nombre.GenerarNombreUsuario(), Encriptador.Encriptar(usuarioDTOs.Contrasenia), "A");

                _context.Usuarios.Add(usuarioregistro);

                try
                {
                    await _context.SaveChangesAsync();
                    await ts.CommitAsync();
                }
                catch (Exception)
                {
                    await ts.RollbackAsync();
                    return new ResponseBase<UsuarioDTOs>(500, "Error al registrar el usuario");
                }
            }
            return new ResponseBase<UsuarioDTOs>(200, "Usuario registrado.");
        }

        public async Task<ResponseBase<UsuarioDTOs>> PutUsuario(UsuarioDTOs usuarioDTOs)
        {
            var usuarioExiste = await _context.Usuarios.FindAsync(usuarioDTOs.Id);
            if (usuarioExiste == null || usuarioExiste.Estado != "A" || usuarioExiste.IdUsuario == 0)
            {
                return new ResponseBase<UsuarioDTOs>(400, "El usuario no existe");
            }

            using var ts = await _context.Database.BeginTransactionAsync();
            {
                try
                {
                    usuarioExiste.IdUsuario = usuarioDTOs.Id;
                    usuarioExiste.Nombre = usuarioDTOs.Nombre;
                    usuarioExiste.CodigoUsuario = usuarioDTOs.Nombre.GenerarNombreUsuario();
                    usuarioExiste.Contrasenia = (Encriptador.Encriptar(usuarioDTOs.Contrasenia));

                    await _context.SaveChangesAsync();
                    await ts.CommitAsync();

                    return new ResponseBase<UsuarioDTOs>(200, "Usuario actualizado");
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuarioDTOs.Id))
                    {
                        return new ResponseBase<UsuarioDTOs>(400, "El usuario no coincide con el id");
                    }
                    else
                    {
                        await ts.RollbackAsync();
                        throw;
                    }
                }
            }
        }

        public async Task<ResponseBase<UsuarioDTOs>> DeleteUsuarioDTO(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null || usuario.Estado != "A")
            {
                return new ResponseBase<UsuarioDTOs>(400, "El usuario no existe");
            }
            using var ts = await _context.Database.BeginTransactionAsync();
            {
                usuario.Estado = "I";
                await _context.SaveChangesAsync();
                await ts.CommitAsync();
            }
            return new ResponseBase<UsuarioDTOs>(200, "Usuario eliminado");
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
