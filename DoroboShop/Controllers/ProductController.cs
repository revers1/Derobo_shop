using ConsoleTEstFilters.Entity;
using DoroboShop.Models;
using DoroboShop.ModelsCreate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoroboShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private ApplicationDbContext _context;

        public ProductController( )
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var Products = _context.dbProduct.ToList();


            List<ProductViewModel> list = new List<ProductViewModel>();

            foreach (var item in Products)
            {
                var filename = Url.Content(Constants.ProductImagePath) + item.Photo;
                list.Add(new ProductViewModel {
                    Id = item.Id,
                    Name = item.Name,
                    Photo = item.Photo,
                    Price = item.Price,
                    Size = item.Size,
                    Sale = item.Sale,
                    Quantity = item.Quantity,
                    Color = item.Color,
                    Brand = item.Brand,
                    Country = item.Country,
                    Season = item.Season,
                    Description = item.Description,
                    DataCreate = item.DataCreate,
                    CategoryId = item.CategoryId,
                    FilePath = filename
                });
            }
            return View(list);
        }


        

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var temp = _context.dbProduct.FirstOrDefault(t => t.Id == id);
            EditProductViewModel model = new EditProductViewModel()
            {
                Id = temp.Id,
                Name = temp.Name,
                Photo=temp.Photo,
                Price = temp.Price,
                Size = temp.Size,
                Sale = temp.Sale,
                Quantity = temp.Quantity,
                Color = temp.Color,
                Brand = temp.Brand,
                Country = temp.Country,
                Season = temp.Season,
                Description = temp.Description,
                DataCreate = temp.DataCreate,
                CategoryId = temp.CategoryId
            };

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {

            if (ModelState.IsValid)
            {
               var foundProduct = _context.dbProduct.First(t => t.Id == model.Id);
                    foundProduct.Id = model.Id;
                    foundProduct.Name = model.Name;
                    foundProduct.Photo = model.Photo;
                    foundProduct.Price = model.Price;
                    foundProduct.Size = model.Size;
                    foundProduct.Sale = model.Sale;
                    foundProduct.Quantity = model.Quantity;
                    foundProduct.Color = model.Color;
                    foundProduct.Brand = model.Brand;
                    foundProduct.Country = model.Country;
                    foundProduct.Season = model.Season;
                    foundProduct.Description = model.Description;
                    foundProduct.DataCreate = model.DataCreate;
                    foundProduct.CategoryId = model.CategoryId;
                _context.SaveChanges();


                return RedirectToAction("Index", "Product");
            }
            else { return View(model); }

        }


       
        public ActionResult Delete(int id)
        {

            _context.dbProduct.Remove(_context.dbProduct.FirstOrDefault(t => t.Id == id));
            _context.SaveChanges();


            return RedirectToAction("Index", "Product");

        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateProductViewModel model, HttpPostedFileBase someFile)
        {
            // do something with someFile

            string link = string.Empty;
            string filename = Guid.NewGuid().ToString() + ".jpg";
            string image = Server.MapPath(Constants.ProductImagePath) +
                filename;
            using (Bitmap bmp = new Bitmap(someFile.InputStream))
            {
                var saveImage = ImageWorker.CreateImage(bmp, 350, 350);
                if (saveImage != null)
                {
                    saveImage.Save(image, ImageFormat.Jpeg);

                    var pdImage = new Product
                    {
                        Name = model.Name,
                        Price = model.Price,
                        Photo = filename,
                        Size = model.Size,
                        Sale = model.Sale,
                        Quantity = model.Quantity,
                        Color = model.Color,
                        Brand = model.Brand,
                        Country = model.Country,
                        Season = model.Season,
                        Description = model.Description,
                        DataCreate = DateTime.Now,
                        CategoryId = model.CategoryId
                    };
                    _context.dbProduct.Add(pdImage);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Product");
                }
            }

            return View(model);
        }


    }
}