﻿using ConsoleTEstFilters.Entity;
using DoroboShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoroboShop.Controllers
{
    public class FilterNameController : Controller
    {
        // GET: FilterName
        private ApplicationDbContext _context;

        public FilterNameController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<FilterNameViewModel> Filters = _context.dbFilterName.Select(e => new FilterNameViewModel
            {
                Name = e.Name
              
            }).ToList();

            return View(Filters);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(FilterNameViewModel model)
        {

            if (ModelState.IsValid)
            {
                _context.dbFilterName.Add(new FilterName
                {
                    Name = model.Name            
                });
                _context.SaveChanges();

                return RedirectToAction("Index", "FilterName");
            }
            else { return View(model); }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id)
        {

            _context.dbFilterName.Remove(_context.dbFilterName.FirstOrDefault(t => t.Id == id));
            _context.SaveChanges();


            return RedirectToAction("Index", "FilterName");

        }

    }
}