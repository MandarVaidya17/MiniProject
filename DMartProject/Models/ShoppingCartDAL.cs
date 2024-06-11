using ShopFarmProject.Data;
using System.Linq;

namespace ShopFarmProject.Models
{
    public class ShoppingCartDAL
    {
        private ApplicationDbContext db;
        Login login;
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
        public ShoppingCart GetProductById(int id)
        {
            var model = db.ShoppingCarts.Where(x => x.Id == id).SingleOrDefault();
            return model;
        }
        public int AddProduct(ShoppingCart cart, int id)
        {
            int result = 0;
            var model = db.Products.Where(x => x.Id == id).SingleOrDefault();
            int cid = db.Customers.Select(x => x.Id).First();
            //int Custid = (from customer in db.Customers
            //          where customer.Email == login.Email
            //          select customer.Id).Single();

            var addproduct = new ShoppingCart
            {
              
                Name=model.Name,
                Price=model.Price,
                CustomerId=cid,//customer id not get yet...this model get product id in cart
                Image=model.Image


            };
            db.ShoppingCarts.Add(addproduct);
            result=db.SaveChanges();
            return result;
        }
        public int DeleteProduct(int id)
        {
            int result = 0;
            var model = db.ShoppingCarts.Where(x => x.Id == id).SingleOrDefault();
            if (model != null)
            {
                // remove from dbSet
                db.ShoppingCarts.Remove(model);
                result = db.SaveChanges();
            }
            return result;
        }

        public int GetCustomerId()
        {
            
            var id=db.Customers.Select(x=> x.Id).SingleOrDefault();
            return id;
        }
    }
}
