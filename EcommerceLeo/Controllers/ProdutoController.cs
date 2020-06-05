using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceLeo.Domain.Entities;
using EcommerceLeo.Domain.Repositories.Interfaces;
using EcommerceLeo.Web.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceLeo.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {         
            _produtoRepository = produtoRepository;
        }

        // GET: /<controller>/
        public IActionResult Detalhe(int id)
        {
            var produto = _produtoRepository.GetProdutoById(id);
            return View(produto);
        }

        [HttpPost]
        [ActionName("Detalhe")]
        public ActionResult AddToCart(int id)
        {
            List<Produto> produtos = new List<Produto>();

            var produto = _produtoRepository.GetProdutoById(id);

            produtos = HttpContext.Session.Get<List<Produto>>("produtos");
            if (produtos == null)
            {
                produtos = new List<Produto>();
            }

            int qtdeItensParaAdicionarNoCarrinho = 3;

            if(qtdeItensParaAdicionarNoCarrinho > 1) 
            {
                for (int i = 0; i < qtdeItensParaAdicionarNoCarrinho; i++)
                {
                    produtos.Add(produto);
                }
            }
            else
            {
                produtos.Add(produto);
            }
            
            HttpContext.Session.Set("produtos", produtos);

            return View(produto);

        }


    }
}
