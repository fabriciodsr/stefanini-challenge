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
    public class GendersController : Controller
    {
        readonly protected IAppGender _genderApp;


        public GendersController(
            IAppGender genderApp)
        {
            _genderApp = genderApp;
        }

        public IActionResult Index()
        {
            var gendersDTO = _genderApp.SelectAll();
            return View(gendersDTO);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderDTO = _genderApp.SelectById(id.Value);
            if (genderDTO == null)
            {
                return NotFound();
            }

            return View(genderDTO);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Id")] GenderDTO genderDTO)
        {
            if (ModelState.IsValid)
            {
                _genderApp.Insert(genderDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(genderDTO);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderDTO = _genderApp.SelectById(id.Value);
            if (genderDTO == null)
            {
                return NotFound();
            }
            return View(genderDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Id")] GenderDTO genderDTO)
        {
            if (id != genderDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _genderApp.Update(genderDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(genderDTO);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderDTO = _genderApp.SelectById(id.Value);
            if (genderDTO == null)
            {
                return NotFound();
            }

            return View(genderDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _genderApp.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
