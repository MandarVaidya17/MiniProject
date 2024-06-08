using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopFarmProject.Data;
using ShopFarmProject.Models;

namespace ShopFarmProject.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db;
        ProductDAL dal;
        ShoppingCartDAL scdal;

        public ProductController(ApplicationDbContext db)
        {

            this.db = db;
            dal = new ProductDAL(this.db);
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var model = dal.GetProducts();
            return View(model);
        }

        public ActionResult IndexCus()
        {
            var model = dal.GetProducts();
            return View(model);
        }
        
        public ActionResult AddCart(ShoppingCart sc)
        {
            
            
                return RedirectToAction("Index", "ShoppingCart");
            
           
        }
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var model = dal.GetProductById(id);
            return View(model);
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                int result = dal.AddProduct(product);
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = dal.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                int result = dal.EditProduct(product);
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = dal.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = dal.DeleteProduct(id);
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
    }
}
