using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EcommerceLeo.Models;
using EcommerceLeo.Domain.Repositories.Interfaces;
using EcommerceLeo.Domain.Entities;
using Microsoft.AspNetCore.Http;
using EcommerceLeo.Web.Utils;

namespace EcommerceLeo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProdutoRepository _produtoRepository;

        public HomeController(ILogger<HomeController> logger, IProdutoRepository produtoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
        }

        public IActionResult Index()
        {
            var prd = _produtoRepository.GetAllProduto();
            return View(prd);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
