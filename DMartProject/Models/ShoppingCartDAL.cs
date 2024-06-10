using ShopFarmProject.Data;
using System.Linq;

namespace ShopFarmProject.Models
{
    public class ShoppingCartDAL
    {
        private ApplicationDbContext db;
        public ShoppingCartDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<ShoppingCart> GetProducts()
        {
            var model = (from product in db.ShoppingCarts
                         select product).ToList();
            return model;
        }
        public int AddProduct(ShoppingCart cart,int id)
        {
            int result = 0;
            var model = db.Products.Where(x => x.Id == id).SingleOrDefault();
            var cid = db.Customers.Select(x => x.Id).SingleOrDefault();

            var targetData = new ShoppingCart
            {
              
                Name=model.Name,
                Price=model.Price,
                CustomerId=model.Id,//customer id not get yet...this model get product id in cart
                Image=model.Image


            };
            db.ShoppingCarts.Add(targetData);
            db.SaveChanges();
            return result;
        }

    }
}
