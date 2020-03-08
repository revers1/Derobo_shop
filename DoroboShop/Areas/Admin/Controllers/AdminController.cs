using DoroboShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoroboShop.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly UserManager<IdentityUser> _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());


 
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var list = _context.Users.ToList();


            return View(list);
        }

        public ActionResult BanUser(string id)
        {
            _userManager.SetLockoutEnabled(id, true);
            _userManager.SetLockoutEndDate(id, DateTime.MaxValue);
            return RedirectToAction("Index");
        }

        public ActionResult UnbanUser(string id)
        {
            _userManager.SetLockoutEnabled(id, false);
            _userManager.SetLockoutEndDate(id, new DateTime(2017, 2, 3));
            return RedirectToAction("Index");
        }

    }
}