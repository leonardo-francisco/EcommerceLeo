using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EcommerceLeo.Domain.Entities;
using EcommerceLeo.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcommerceLeo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProdutoController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository, IHostingEnvironment environment)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            hostingEnvironment = environment;
        }
        public void PreencheDropDown()
        {          
            ViewBag.Categoria = new SelectList(_categoriaRepository.GetAllCategoria(), "idCategoria", "nmCategoria");

        }

        public IActionResult Index()
        {
            var prd = _produtoRepository.GetAllProduto();
            return View(prd);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PreencheDropDown();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produto pr, IFormFile image)
        {
            PreencheDropDown();

            if (image != null)
            {
                var name = Path.GetFileName(image.FileName);
                var path = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var uniquepath = Path.Combine(path, name);
                image.CopyTo(new FileStream(uniquepath, FileMode.Create));
                pr.urlFoto = "~/img/" + image.FileName;
            }
            _produtoRepository.InsertProduto(pr.nmProduto, pr.idCateProd, pr.precoProduto, pr.urlFoto);

            return View(pr);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PreencheDropDown();

            var prd = _produtoRepository.GetProdutoById(id);

            return View(prd);
        }

        [HttpPost]
        public IActionResult Edit(int id, Produto pd)
        {
            var prd = _produtoRepository.UpdateProduto(id, pd.nmProduto, pd.idCateProd, pd.precoProduto);

            return View(prd);
        }

        [HttpDelete]
        public void DeleteProduto(int id)
        {
            _produtoRepository.DeleteProduto(id);
        }
    }
}