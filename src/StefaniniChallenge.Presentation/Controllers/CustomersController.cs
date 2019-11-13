using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StefaniniChallenge.Application.DTO;
using StefaniniChallenge.Application.Interfaces;
using StefaniniChallenge.Data.Context;
using StefaniniChallenge.Domain.Entities;
using StefaniniChallenge.Domain.Enums;

namespace StefaniniChallenge.Presentation.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        readonly protected IAppCustomer _customerApp;
        readonly protected IAppCity _cityApp;
        readonly protected IAppClassification _classificationApp;
        readonly protected IAppGender _genderApp;
        readonly protected IAppRegion _regionApp;
        readonly protected UserManager<IdentityUser> _userManager;

        public CustomersController(
            IAppCustomer customerApp, 
            IAppCity cityApp, 
            IAppClassification classificationApp, 
            IAppGender genderApp, 
            IAppRegion regionApp,
            UserManager<IdentityUser> userManager)
        {
            _customerApp = customerApp;
            _cityApp = cityApp;
            _classificationApp = classificationApp;
            _genderApp = genderApp;
            _regionApp = regionApp;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["CityId"] = new SelectList(_cityApp.SelectAll(), "Id", "Name");
            ViewData["ClassificationId"] = new SelectList(_classificationApp.SelectAll(), "Id", "Name");
            ViewData["GenderId"] = new SelectList(_genderApp.SelectAll(), "Id", "Name");
            ViewData["RegionId"] = new SelectList(_regionApp.SelectAll(), "Id", "Name");
            ViewData["Sellers"] = new SelectList(await _userManager.GetUsersInRoleAsync(Enum.GetName(typeof(Roles), Roles.Seller)), "Id", "UserName");

            var customerDTO = new CustomerDTO();
            customerDTO.Customers = _customerApp.SelectAll()
                .Where(x => !User.IsInRole(Enum.GetName(typeof(Roles), Roles.Seller)) || x.IdentityUserId.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier)));

            return View(customerDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("Name,Phone,GenderId,CityId,RegionId,LastPurchase,ClassificationId,IdentityUserId,Id")] CustomerDTO customerDTO)
        {
            if (customerDTO.CityId > 0)
            {
                var cityObj = _customerApp.SelectById(customerDTO.CityId);
                if (cityObj != null)
                {
                    customerDTO.RegionId = cityObj.RegionId;
                }
            }

            customerDTO.Customers = _customerApp.SelectAll().Where(x =>
               (String.IsNullOrEmpty(customerDTO.Name) || x.Name.ToUpper().Contains(customerDTO.Name.ToUpper())) &&
               (customerDTO.GenderId == 0 || x.GenderId.Equals(customerDTO.GenderId)) &&
               (customerDTO.CityId == 0 || x.CityId.Equals(customerDTO.CityId)) &&
               (customerDTO.RegionId == 0 || x.RegionId.Equals(customerDTO.RegionId)) &&
               ((customerDTO.LastPurchase == new DateTime() && customerDTO.Until == new DateTime()) ||
               (customerDTO.LastPurchase >= x.LastPurchase && customerDTO.Until <= x.LastPurchase) ||
               (customerDTO.LastPurchase == null && customerDTO.Until == null)) &&
               (customerDTO.ClassificationId == 0 || x.ClassificationId.Equals(customerDTO.ClassificationId)) &&
               (customerDTO.SellerId == 0 || x.IdentityUserId.Equals(customerDTO.SellerId))
            );

            ViewData["CityId"] = new SelectList(_cityApp.SelectAll(), "Id", "Name");
            ViewData["ClassificationId"] = new SelectList(_classificationApp.SelectAll(), "Id", "Name");
            ViewData["GenderId"] = new SelectList(_genderApp.SelectAll(), "Id", "Name");
            ViewData["RegionId"] = new SelectList(_regionApp.SelectAll(), "Id", "Name");
            ViewData["Sellers"] = new SelectList(await _userManager.GetUsersInRoleAsync(Enum.GetName(typeof(Roles), Roles.Seller)), "Id", "UserName");

            return View(customerDTO);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerDTO = _customerApp.SelectById(id.Value);

            if (customerDTO == null)
            {
                return NotFound();
            }

            return View(customerDTO);
        }

        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_cityApp.SelectAll(), "Id", "Name");
            ViewData["ClassificationId"] = new SelectList(_classificationApp.SelectAll(), "Id", "Name");
            ViewData["GenderId"] = new SelectList(_genderApp.SelectAll(), "Id", "Name");
            ViewData["RegionId"] = new SelectList(_regionApp.SelectAll(), "Id", "Name");
            ViewData["IdentityUserId"] = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Phone,GenderId,CityId,RegionId,LastPurchase,ClassificationId,IdentityUserId,Id")] CustomerDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                _customerApp.Insert(customerDTO);
                return RedirectToAction(nameof(Index));
            }

            ViewData["CityId"] = new SelectList(_cityApp.SelectAll(), "Id", "Name", customerDTO.CityId);
            ViewData["ClassificationId"] = new SelectList(_classificationApp.SelectAll(), "Id", "Name", customerDTO.ClassificationId);
            ViewData["GenderId"] = new SelectList(_genderApp.SelectAll(), "Id", "Name", customerDTO.GenderId);
            ViewData["RegionId"] = new SelectList(_regionApp.SelectAll(), "Id", "Name", customerDTO.RegionId);
            ViewData["IdentityUserId"] = customerDTO.IdentityUserId ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(customerDTO);
        }
    }
}
