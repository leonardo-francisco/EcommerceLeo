using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceLeo.Domain.Entities;
using EcommerceLeo.Web.Utils;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceLeo.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Index()
        {
            List<Produto> produtos = HttpContext.Session.Get<List<Produto>>("produtos");
            IEnumerable<Produto> xy = produtos;
            ViewBag.Prod = xy;
            return View(xy);
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult Delete(int id)
        {
            List<Produto> produtos = HttpContext.Session.Get<List<Produto>>("produtos");
            var produto = produtos.FirstOrDefault(c => c.idProduto == id);
            if (produto != null)
            {
                produtos.Remove(produto);
                HttpContext.Session.Set("produtos",produtos);
                Index();
            }       

            return RedirectToAction(nameof(Index));
        }
    }
}