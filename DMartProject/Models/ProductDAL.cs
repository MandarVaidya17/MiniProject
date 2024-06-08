using ShopFarmProject.Data;

namespace ShopFarmProject.Models
{
    public class ProductDAL
    {
        private ApplicationDbContext db;

        public ProductDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Product> GetProducts()
        {
            var model=(from product in db.Products
                       select product).ToList();
            return model;
        }

        public Product GetProductById(int id)
        {
            var model = db.Products.Where(x => x.Id == id).SingleOrDefault();
            return model;
        }
        public int AddProduct(Product product)
        {
            int result = 0;
            db.Products.Add(product);
            db.SaveChanges();
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
        public int DeleteProduct(int id)
        {
            int result = 0;
            var model = db.Products.Where(x => x.Id == id).SingleOrDefault();
            if (model != null)
            {
                // remove from dbSet
                db.Products.Remove(model);
                result = db.SaveChanges();
            }
            return result;
        }

    }
}
