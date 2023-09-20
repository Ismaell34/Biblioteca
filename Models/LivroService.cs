using System.Linq;
using System.Collections.Generic;



namespace Biblioteca.Models
{
    public class LivroService
    {
        private readonly BibliotecaContext _context;

        public LivroService(BibliotecaContext context)
        {
            _context = context;
        }

        public void Inserir(Livro l)
        {
            
            {
                _context.Livros.Add(l);
                _context.SaveChanges();
            }
        }

        public void Atualizar(Livro l)
        {
            
            {
                Livro livro = _context.Livros.Find(l.Id);
                livro.Autor = l.Autor;
                livro.Titulo = l.Titulo;

                _context.SaveChanges();
            }
        }

        public ICollection<Livro> ListarTodos(FiltrosLivros filtro = null)
        {
            
            {
                IQueryable<Livro> query;
                
                if(filtro != null)
                {
                    //definindo dinamicamente a filtragem
                    switch(filtro.TipoFiltro)
                    {
                        case "Autor":
                            query = _context.Livros.Where(l => l.Autor.Contains(filtro.Filtro));
                        break;

                        case "Titulo":
                            query = _context.Livros.Where(l => l.Titulo.Contains(filtro.Filtro));
                        break;

                        default:
                            query = _context.Livros;
                        break;
                    }
                }
                else
                {
                    // caso filtro não tenha sido informado
                    query = _context.Livros;
                }
                
                //ordenação padrão
                return query.OrderBy(l => l.Titulo).ToList();
            }
        }

        public ICollection<Livro> ListarDisponiveis()
        {
            
            {
                //busca os livros onde o id não está entre os ids de livro em empréstimo
                // utiliza uma subconsulta
                return
                    _context.Livros
                    .Where(l =>  !(_context.Emprestimos.Where(e => e.Devolvido == false).Select(e => e.LivroId).Contains(l.Id)) )
                    .ToList();
            }
        }

        public Livro ObterPorId(int id)
        {
            
            {
                return _context.Livros.Find(id);
            }
        }
    }
}