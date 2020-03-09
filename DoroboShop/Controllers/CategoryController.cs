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

            //string image;
            //    //= Server.MapPath(Constants.ProductImagePath) +
            //    //filename;

            List<ProductViewModel> list = _context.dbProduct.Where(t => t.CategoryId == id).Select(t => new ProductViewModel
            {
                Brand = t.Brand,
                CategoryId = t.CategoryId,
                ProductName = t.Name,
                Price = t.Price,
                Photo = t.Photo,              
                Id = t.Id
            }).ToList();

            return View(list);
        }

        public ActionResult Delete(int id)
        {
           
            var category = _context.dbCategories.Where(e => e.ParentId == id).ToList();
            if (category == null)
            {
                _context.dbCategories.Remove(_context.dbCategories.FirstOrDefault(t => t.Id == id));
            }
            else {
               
            }
            _context.SaveChanges();





            return RedirectToAction("Index", "Category");

        }
        public ActionResult Index()
        {
            List<CategoryViewModelcs> Categories = _context.dbCategories.Select(e => new CategoryViewModelcs
            {
                Name = e.Name,
                ParentId=e.ParentId,
                Id = e.Id

            }).ToList();

            return View(Categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Category> list = _context.dbCategories.ToList();
            List<SelectListItem> selected = new List<SelectListItem>();
            selected.Add(new SelectListItem()
            {
                Value = "Base",
                Text = "Base category"
            });
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
        public ActionResult Create(CreateCategoryViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (model.ParentId == "Base")
                {
                    _context.dbCategories.Add(new Category
                    {
                        Name = model.Name,
                    });
                }
                else
                {
                    _context.dbCategories.Add(new Category
                    {
                        Name = model.Name,
                        ParentId = int.Parse(model.ParentId)
                    });
                }
                _context.SaveChanges();

                return RedirectToAction("Index", "Category");
            }
            else { return View(model); }

        }
        
       



    }
}