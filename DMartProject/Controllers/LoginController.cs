using Microsoft.AspNetCore.Mvc;
using ShopFarmProject.Data;
using ShopFarmProject.Models;

namespace ShopFarmProject.Controllers
{
    public class LoginController : Controller
    {

        private readonly ApplicationDbContext db;
        public LoginController(ApplicationDbContext db)
        {
            this.db = db;
        }
      
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            var emp = db.Employees.FirstOrDefault(e => e.Email == model.Email && e.Password == model.Password);
            var cus = db.Customers.FirstOrDefault(c => c.Email == model.Email && c.Password == model.Password);
            if (emp != null)
            {
                return RedirectToAction("Index", "Product");
            }
            else if(cus!=null)
            {
                return RedirectToAction("IndexCus", "Product");
            }
            else
            {
                ViewBag.ErrorMsg = "Something went wrong";
                return View();
            }
        }
    }
}
