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
    public class CupomController : Controller
    {
        private readonly ICupomRepository _cupomRepository;

        public CupomController(ICupomRepository cupomRepository)
        {
            _cupomRepository = cupomRepository;
        }
        public IActionResult Index()
        {
            var cup = _cupomRepository.GetAllCupom();
            return View(cup);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cupom cupom)
        {
            try
            {
                var cup = _cupomRepository.CreateCupom(cupom.TipoCupom, cupom.CodigoCupom, cupom.ValorDesconto);
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
            var cup = _cupomRepository.SearchCupomId(id);
            ViewBag.Edit = cup;
            return PartialView("_Edit",cup);
        }

        [HttpPost]
        public IActionResult Edit(int id, Cupom cupom)
        {
            var cup = _cupomRepository.EditCupom(cupom.IdCupom,cupom.TipoCupom,cupom.CodigoCupom,cupom.ValorDesconto);
            return PartialView("_Edit",cup);
        }

        [HttpDelete]
        public void DeleteCupom(int id)
        {
            _cupomRepository.DeleteCupom(id);
        }
    }
}