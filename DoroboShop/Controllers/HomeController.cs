using DoroboShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoroboShop.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            GroupViewModel model = new GroupViewModel();

            List<CategoryViewModelcs> listCategories = _context.dbCategories.Where(t => t.ParentId == null).Select(t => new CategoryViewModelcs { 
                Id = t.Id,
                Name = t.Name,
                ParentId = t.ParentId
            }).ToList();

            List<ProductViewModel> listProducts = _context.dbProduct.Select(t=>new ProductViewModel
            {
                Name = t.Name,
                Price= t.Price,
                Photo =t.Photo
            }).ToList();

            model.Categories = listCategories;
            model.Products = listProducts;

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}