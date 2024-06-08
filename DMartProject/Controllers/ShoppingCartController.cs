using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopFarmProject.Data;
using ShopFarmProject.Models;

namespace ShopFarmProject.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db;
        ShoppingCartDAL dal;
        
        public ShoppingCartController(ApplicationDbContext db)
        {
            this.db = db;   
            dal=new ShoppingCartDAL(this.db);
            
        }
        // GET: ShoppingCartController
        public ActionResult Index()
        {
            var model = dal.GetProducts();
            return View(model);
        }

        // GET: ShoppingCartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShoppingCartController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: ShoppingCartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShoppingCart sc,int id)
        {
            try
            {
                int result = dal.AddProduct(sc,id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: ShoppingCartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShoppingCartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingCartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShoppingCartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
