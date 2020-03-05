using ConsoleTEstFilters.Entity;
using DoroboShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoroboShop.Controllers
{
    public class FilterValueController : Controller
    {
        // GET: FilterValue
        private ApplicationDbContext _context;

        public FilterValueController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            List<FilterValueViewModel> Filters = _context.dbFilterValue.Select(e => new FilterValueViewModel
            {
                Name = e.Name

            }).ToList();

            return View(Filters);
        }
        [HttpGet]
        public ActionResult Create()
        {

            List<Category> list = _context.dbCategories.ToList();
            List<FilterName> listname = _context.dbFilterName.ToList();

            List<SelectListItem> selectedesCategori = new List<SelectListItem>();

            List<SelectListItem> selectedFname = new List<SelectListItem>();
            foreach (var item in listname)
            {
                selectedFname.Add(new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            }
            foreach (var item in list)
            {
              
                selectedesCategori.Add(new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Name

                });
            }

            FilterValueViewModel model = new FilterValueViewModel();
            model.Categories = selectedesCategori;
            model.FiltersNames = selectedFname;

            return View(model);
       
        }


        [HttpPost]
        public ActionResult Create(FilterValueViewModel model)
        {

            if (ModelState.IsValid)
            {
                //_context.dbFilterValue.Add(new FilterValue
                //{
                //    Name = model.Name
                //});

                FilterValue categoryValue = new FilterValue()
                {
                    Name = model.Name
                };
                _context.dbFilterValue.Add(categoryValue);
                _context.SaveChanges();

                _context.dbFilterNameGroups.Add(new FilterNameGroups
                {
                      FilterNameId = model.Id,
                      FilterValueId= categoryValue.Id,
                      CategoryId = model.CategoryId
                });
                _context.SaveChanges();

                return RedirectToAction("Index", "FilterValue");
            }
            else { return View(model); }

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            _context.dbFilterValue.Remove(_context.dbFilterValue.FirstOrDefault(t => t.Id == id));
            _context.SaveChanges();


            return RedirectToAction("Index", "FilterValue");

        }

    }
}