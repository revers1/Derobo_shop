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

            var Products = _context.dbProduct.Where(t=>t.CategoryId == id).ToList();
            
           List<ProductViewModel> list = new List<ProductViewModel>();
            foreach (var item in Products)
            {
                var filename = Url.Content(Constants.ProductImagePath) + item.Photo;
                filename.Replace(@"\\", @"\");
                list.Add(new ProductViewModel
                { 
                    Brand = item.Brand,
                    CategoryId = item.CategoryId,
                    ProductName = item.Name,
                    Price = item.Price,
                    Photo = filename,
                    Id = item.Id
                });
            }

            return View(list);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {

            _context.dbCategories.Remove(_context.dbCategories.FirstOrDefault(t => t.Id == id));
            _context.SaveChanges();



            return RedirectToAction("Index", "Category");

        }

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
            selected.Add(new SelectListItem()
            {
                Value = "Base",
                Text = "Base category"
            });
            CreateCategoryViewModel cat = new CreateCategoryViewModel();
            cat.Categories = selected;

            return View(cat);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CreateCategoryViewModel model)
        {

            if (ModelState.IsValid)
            {
                _context.dbCategories.Add(new Category
                {
                    Name = model.Name,
                    ParentId = int.Parse(model.ParentId)
                });
                _context.SaveChanges();

                return RedirectToAction("Index", "Category");
            }
            else { return View(model); }

        }
        
       



    }
}