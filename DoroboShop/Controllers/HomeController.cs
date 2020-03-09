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


        public ActionResult Index(string txtProductName )
        {
            GroupViewModel model = new GroupViewModel();
            List<CategoryViewModelcs> listCategories = _context.dbCategories.Where(t => t.ParentId == null).Select(t => new CategoryViewModelcs
            {
                Id = t.Id,
                Name = t.Name,
                ParentId = t.ParentId
            }).ToList();

            string linkString = Url.Content(Constants.ProductImagePath);
            List<ProductViewModel> listProducts = new List<ProductViewModel>();

            if (txtProductName == null)
            {
                listProducts = _context.dbProduct.Select(t => new ProductViewModel
                {
                    Id = t.Id,
                    ProductName = t.Name,
                    Photo = linkString + t.Photo,
                    Price = t.Price,
                    Size = t.Size,
                    Sale = t.Sale,
                    Quantity = t.Quantity,
                    Color = t.Color,
                    Brand = t.Brand,
                    Country = t.Country,
                    Season = t.Season,
                    Description = t.Description,
                    DataCreate = t.DataCreate,
                    CategoryId = t.CategoryId
                }).ToList();
            }
            else
            {

                listProducts = _context.dbProduct.Where(t => t.Name.Contains(txtProductName)).Select(t => new ProductViewModel
                {
                    Id = t.Id,
                    ProductName = t.Name,
                    Photo = linkString + t.Photo,
                    Price = t.Price,
                    Size = t.Size,
                    Sale = t.Sale,
                    Quantity = t.Quantity,
                    Color = t.Color,
                    Brand = t.Brand,
                    Country = t.Country,
                    Season = t.Season,
                    Description = t.Description,
                    DataCreate = t.DataCreate,
                    CategoryId = t.CategoryId
                }).ToList();
            }
           

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