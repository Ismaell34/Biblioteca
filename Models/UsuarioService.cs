using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        private readonly BibliotecaContext _context;

        public UsuarioService(DbContextOptions<BibliotecaContext> options)
        {
            _context = new BibliotecaContext(options);
        }

        public void Inserir(Usuario a)
        {
            _context.Usuarios.Add(a);
            _context.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public void Editar(Usuario a)
        {
            _context.Entry(a).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            var usuario = _context.Usuarios.Find(idUsuario);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

        public Usuario ObterPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario ValidarLogin(Usuario a)
        {
            return _context.Usuarios
                .Where(u => u.user == a.user && u.senha == a.senha)
                .FirstOrDefault();
        }
    }
}