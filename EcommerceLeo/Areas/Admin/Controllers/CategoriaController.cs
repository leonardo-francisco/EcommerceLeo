using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceLeo.Domain.Entities;
using EcommerceLeo.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceLeo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public IActionResult Index()
        {
            var cg = _categoriaRepository.GetAllCategoria();
            return View(cg);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoriaProduto catg)
        {
            try
            {
                var cg = _categoriaRepository.InsertCategoria(catg.nmCategoria);
                ModelState.Clear();

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
        public IActionResult Edit(int id)
        {
            var cg = _categoriaRepository.GetCategoriaId(id);
            
            return PartialView("_Edit", cg);
        }

        [HttpPost]
        public IActionResult Edit(int id, CategoriaProduto ctg)
        {
            var cg = _categoriaRepository.UpdateCategoria(ctg.idCategoria, ctg.nmCategoria);
            return PartialView("_Edit", cg);
        }

        [HttpDelete]
        public void DeleteCategoria(int id)
        {
            _categoriaRepository.DeleteCategoria(id);
        }
    }
}