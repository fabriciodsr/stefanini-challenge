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
    public class CitiesController : Controller
    {
        readonly protected IAppCity _cityApp;
        readonly protected IAppRegion _regionApp;

        public CitiesController(
            IAppCity cityApp,
            IAppRegion regionApp)
        {
            _cityApp = cityApp;
            _regionApp = regionApp;
        }

        public IActionResult Index()
        {
            var citiesDTO = _cityApp.SelectAll();
            return View(citiesDTO);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityDTO = _cityApp.SelectById(id.Value);
            if (cityDTO == null)
            {
                return NotFound();
            }

            return View(cityDTO);
        }

        public IActionResult Create()
        {
            ViewData["RegionId"] = new SelectList(_regionApp.SelectAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,RegionId,Id")] CityDTO cityDTO)
        {
            if (ModelState.IsValid)
            {
                _cityApp.Insert(cityDTO);
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionId"] = new SelectList(_regionApp.SelectAll(), "Id", "Name", cityDTO.RegionId);
            return View(cityDTO);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityDTO = _cityApp.SelectById(id.Value);
            if (cityDTO == null)
            {
                return NotFound();
            }
            ViewData["RegionId"] = new SelectList(_regionApp.SelectAll(), "Id", "Name", cityDTO.RegionId);
            return View(cityDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,RegionId,Id")] CityDTO cityDTO)
        {
            if (id != cityDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _cityApp.Update(cityDTO);
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionId"] = new SelectList(_regionApp.SelectAll(), "Id", "Name", cityDTO.RegionId);
            return View(cityDTO);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityDTO = _cityApp.SelectById(id.Value);
            if (cityDTO == null)
            {
                return NotFound();
            }

            return View(cityDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _cityApp.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
