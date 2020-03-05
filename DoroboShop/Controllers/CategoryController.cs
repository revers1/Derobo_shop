using ConsoleTEstFilters.Entity;
using DoroboShop.Models;
using DoroboShop.ModelsCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoroboShop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }


    
        public ActionResult GetProductsByCategory(int id)
        {
            List<ProductViewModel> list = _context.dbProduct.Where(t => t.CategoryId == id).Select(t => new ProductViewModel
            {
                Brand = t.Brand,
                CategoryId = t.CategoryId,
                Name = t.Name,
                Price = t.Price,
                Photo = t.Photo,
                Id = t.Id
            }).ToList();

            return View(list);
        }


        public ActionResult Index()
        {
            List<CategoryViewModelcs> Categories = _context.dbCategories.Select(e => new CategoryViewModelcs
            {
                Name = e.Name,
                ParentId=e.ParentId

            }).ToList();

            return View(Categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Category> list = _context.dbCategories.ToList();
            List<SelectListItem> selected = new List<SelectListItem>();
            foreach (var item in list)
            {
                selected.Add(new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text=item.Name
             
                });
            }
            CreateCategoryViewModel cat = new CreateCategoryViewModel();
            cat.Categories = selected;

            return View(cat);
        }


        [HttpPost]
        public ActionResult Create(CategoryViewModelcs model)
        {

            if (ModelState.IsValid)
            {
                _context.dbCategories.Add(new Category
                {
                    Name = model.Name,
                    ParentId = model.ParentId
                });
                _context.SaveChanges();

                return RedirectToAction("Index", "Category");
            }
            else { return View(model); }

        }
        
        public ActionResult Delete(int id)
        {

            _context.dbCategories.Remove(_context.dbCategories.FirstOrDefault(t => t.Id == id));
            _context.SaveChanges();


            return RedirectToAction("Index", "Category");

        }



    }
}