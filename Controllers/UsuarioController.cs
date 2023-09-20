using System.Net.WebSockets;
using System.Net;
using System.ComponentModel;
using System;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Editar(int id)
        {
            var usuario = _usuarioService.ObterPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario a)
        {
            _usuarioService.Editar(a);
            return RedirectToAction("Listar");
        }

        public IActionResult Deletar(int id)
        {
            _usuarioService.Deletar(id);
            return RedirectToAction("Listar");
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario a)
        {
            int idUsuario = (int)HttpContext.Session.GetInt32("idUsuario");
            a.idUsuario = idUsuario;
            _usuarioService.Inserir(a);
            return RedirectToAction("Login");
        }

        public IActionResult Listar()
        {
            int? nivelUsuario = HttpContext.Session.GetInt32("nivelUsuario");
            
            if (nivelUsuario == 1)
            {
                var usuarios = _usuarioService.Listar();
                return View(usuarios);
            }
            else
            {
                return RedirectToAction("AcessoNegado");
            }
        }

        public IActionResult Login()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Login(Usuario a)
        {
            Usuario usuarioLogado = _usuarioService.ValidarLogin(a);

            if (usuarioLogado == null)
            {
                ViewBag.Mensagem = "Falha no Login";
                return View();
            }
            else
            {
                HttpContext.Session.SetInt32("idUsuario", usuarioLogado.idUsuario);
                HttpContext.Session.SetString("nomeUsuario", usuarioLogado.nome);
                HttpContext.Session.SetInt32("nivelUsuario", usuarioLogado.nivel);

                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}