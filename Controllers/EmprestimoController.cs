using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using X.PagedList; 

namespace Biblioteca.Controllers
{
    
    public class EmprestimoController : Controller
    {
        private readonly LivroService _livroService; 
        private readonly EmprestimoService _emprestimoService; 

        public EmprestimoController(LivroService livroService, EmprestimoService emprestimoService) 
        {
            _livroService = livroService;
            _emprestimoService = emprestimoService;
        }
        public IActionResult Cadastro()
        {
            CadEmprestimoViewModel cadModel = new CadEmprestimoViewModel();
            cadModel.Livros = _livroService.ListarTodos(); 
            return View(cadModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CadEmprestimoViewModel viewModel)
        {
            if(viewModel.Emprestimo.Id == 0)
            {
                _emprestimoService.Inserir(viewModel.Emprestimo);
            }
            else
            {
                _emprestimoService.Atualizar(viewModel.Emprestimo);
            }
            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem(string tipoFiltro, string filtro, int? page)
        {
            Autenticacao.CheckLogin(this);
            FiltrosEmprestimos objFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosEmprestimos();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }

            var emprestimos = _emprestimoService.ListarTodos(objFiltro);

            int pageSize = 10; 
            int pageNumber = (page ?? 1); 

            var model = new StaticPagedList<Emprestimo>(emprestimos, pageNumber, pageSize, emprestimos.Count);

            return View(model);
        }

        public IActionResult Edicao(int id)
        {
            Emprestimo e = _emprestimoService.ObterPorId(id);

            CadEmprestimoViewModel cadModel = new CadEmprestimoViewModel();
            cadModel.Livros = _livroService.ListarTodos();
            cadModel.Emprestimo = e;
            
            return View(cadModel);
        }
    }
}