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

        public ActionResult Delete(int id)
        {
            var model = cdal.GetProductById(id);
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
                int result = cdal.DeleteProduct(id);
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


