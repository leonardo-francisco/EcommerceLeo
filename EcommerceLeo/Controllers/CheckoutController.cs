using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceLeo.Domain.Entities;
using EcommerceLeo.Web.Utils;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceLeo.Web.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Checkout()
        {
            List<Produto> produtos = HttpContext.Session.Get<List<Produto>>("produtos");
            IEnumerable<Produto> xy = produtos;

            return View(xy);
        }
    }
}