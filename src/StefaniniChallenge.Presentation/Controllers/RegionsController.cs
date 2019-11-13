using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StefaniniChallenge.Application.DTO;
using StefaniniChallenge.Application.Interfaces;
using StefaniniChallenge.Data.Context;
using StefaniniChallenge.Domain.Entities;

namespace StefaniniChallenge.Presentation.Controllers
{
    [Authorize]
    public class RegionsController : Controller
    {
        readonly protected IAppRegion _regionApp;


        public RegionsController(
            IAppRegion regionApp)
        {
            _regionApp = regionApp;
        }

        public IActionResult Index()
        {
            var regionsDTO = _regionApp.SelectAll();
            return View(regionsDTO);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regionDTO = _regionApp.SelectById(id.Value);
            if (regionDTO == null)
            {
                return NotFound();
            }

            return View(regionDTO);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Id")] RegionDTO regionDTO)
        {
            if (ModelState.IsValid)
            {
                _regionApp.Insert(regionDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(regionDTO);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regionDTO = _regionApp.SelectById(id.Value);
            if (regionDTO == null)
            {
                return NotFound();
            }
            return View(regionDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Id")] RegionDTO regionDTO)
        {
            if (id != regionDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _regionApp.Update(regionDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(regionDTO);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regionDTO = _regionApp.SelectById(id.Value);
            if (regionDTO == null)
            {
                return NotFound();
            }

            return View(regionDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _regionApp.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
