using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceLeo.Domain.Entities;
using EcommerceLeo.Domain.Repositories.Interfaces;
using EcommerceLeo.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EcommerceLeo.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View(new Usuario());
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usu)
        {
            try
            {
                _usuarioRepository.InsereUsuario(usu.nmUsuario, usu.emailUsuario, usu.telUsuario, usu.celUsuario, usu.cpfUsuario, usu.endUsuario,
                                            usu.complUsuario, usu.cepUsuario, usu.cidadeUsuario, usu.ufUsuario, usu.loginUsuario, usu.senhaUsuario);

                if (ModelState.IsValid)
                {
                    TempData["UserMessage"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction(nameof(Cadastro));
                }
                return View();
            }
            catch (Exception ex)
            {
                var message = $"Generic Error: {ex.Message}";
                ViewBag.B = message;
                return View();
            }
           
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(Conta conta)
        {
            if (ModelState.IsValid)
            {
                
                    var usuLogado = _usuarioRepository.Login(conta.Login, conta.Senha);

                    if (usuLogado != null)
                    {
                        if (usuLogado.emailUsuario == conta.Login)
                        {

                            HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuLogado));

                            return RedirectToAction("VerificaPerfil", "Perfil");
                        }
                        else
                        {

                            TempData["Mensagem"] = "Atenção: Cadastro não ativado!!!";
                        }
                    }
                    else
                    {

                        TempData["Mensagem"] = "Usuário e/ou senha inválidos";
                    }
                
                


            }

            return View();
        }
    }
}