using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList; 

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        private readonly LivroService _livroService;

        public LivroController(LivroService livroService)
        {
            _livroService = livroService;
        }

        public IActionResult Cadastro()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Livro l)
        {
            if (l.Id == 0)
            {
                _livroService.Inserir(l);
            }
            else
            {
                _livroService.Atualizar(l);
            }

            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem(string tipoFiltro, string filtro, int? page)
        {
            Autenticacao.CheckLogin(this);
            FiltrosLivros objFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosLivros();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }

            var livros = _livroService.ListarTodos(objFiltro);

            int pageSize = 10; 
            int pageNumber = (page ?? 1); 

            IPagedList<Livro> pagedListLivros = livros.ToPagedList(pageNumber, pageSize);

            return View(pagedListLivros);
        }

        public IActionResult Edicao(int id)
        {
            Autenticacao.CheckLogin(this);
            Livro l = _livroService.ObterPorId(id);
            return View(l);
        }
    }
}