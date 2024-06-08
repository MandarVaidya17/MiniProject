using ShopFarmProject.Data;

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
            var model = (from sc in db.ShoppingCarts
                         select sc).ToList();
            return model;
        }

        public int AddProduct(ShoppingCart sc,int id)
        {
            int result = 0;
            var pro = db.Products.ToList();
            var cart = pro.Select(product => new ShoppingCart
            {
                Name = product.Name,
                Price = product.Price,
                CustomerId = product.Id,
                Image = product.Image
            });

            db.ShoppingCarts.AddRange(cart);

                result = db.SaveChanges();

            return result;
        }

        public int EditProduct(Product product)
        {
            int result = 0;
            var model = db.Products.Where(x => x.Id == product.Id).SingleOrDefault();
            if (model != null)
            {
                model.Name = product.Name; // model will hold old data
                model.Price = product.Price;
                model.Image = product.Image;

                result = db.SaveChanges();

            }
            return result;

        }
    }
}
