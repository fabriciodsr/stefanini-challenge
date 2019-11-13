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
    public class ClassificationsController : Controller
    {
        readonly protected IAppClassification _classificationApp;


        public ClassificationsController(
            IAppClassification classificationApp)
        {
            _classificationApp = classificationApp;
        }

        public IActionResult Index()
        {
            var classificationsDTO = _classificationApp.SelectAll();
            return View(classificationsDTO);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificationDTO = _classificationApp.SelectById(id.Value);
            if (classificationDTO == null)
            {
                return NotFound();
            }

            return View(classificationDTO);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Id")] ClassificationDTO classificationDTO)
        {
            if (ModelState.IsValid)
            {
                _classificationApp.Insert(classificationDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(classificationDTO);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificationDTO = _classificationApp.SelectById(id.Value);
            if (classificationDTO == null)
            {
                return NotFound();
            }
            return View(classificationDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Id")] ClassificationDTO classificationDTO)
        {
            if (id != classificationDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _classificationApp.Update(classificationDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(classificationDTO);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificationDTO = _classificationApp.SelectById(id.Value);
            if (classificationDTO == null)
            {
                return NotFound();
            }

            return View(classificationDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _classificationApp.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
