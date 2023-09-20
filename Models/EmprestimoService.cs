using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models
{
    public class EmprestimoService 
    {

        private readonly BibliotecaContext _context;

        public EmprestimoService(DbContextOptions<BibliotecaContext> options)
        {
            _context = new BibliotecaContext(options);
        }
        public void Inserir(Emprestimo e)
        {
            
            {
                _context.Emprestimos.Add(e);
                _context.SaveChanges();
            }
        }

        public void Atualizar(Emprestimo e)
        {
            
            {
                Emprestimo emprestimo = _context.Emprestimos.Find(e.Id);
                emprestimo.NomeUsuario = e.NomeUsuario;
                emprestimo.Telefone = e.Telefone;
                emprestimo.LivroId = e.LivroId;
                emprestimo.DataEmprestimo = e.DataEmprestimo;
                emprestimo.DataDevolucao = e.DataDevolucao;

                _context.SaveChanges();
            }
        }

        public ICollection<Emprestimo> ListarTodos(FiltrosEmprestimos filtro)
        {
           
            {
                return _context.Emprestimos.Include(e => e.Livro).ToList();
            }
        }

        public Emprestimo ObterPorId(int id)
        {
            
            {
                return _context.Emprestimos.Find(id);
            }
        }
    }
}