using Microsoft.AspNetCore.Mvc;
using ShopFarmProject.Data;
using ShopFarmProject.Models;


namespace ShopFarmProject.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db;
        ProductDAL dal;
        ShoppingCartDAL cdal;
        
        public ShoppingCartController(ApplicationDbContext db)
        {

            this.db = db;
            cdal = new ShoppingCartDAL(this.db);
        }
        public ActionResult Index()
        {
            var model = cdal.GetProducts();
            return View(model);
        }
    }
}


