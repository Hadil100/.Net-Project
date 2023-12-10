using Microsoft.EntityFrameworkCore;

namespace MyNewProject.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;
        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Product Add(Product P)
        {
            context.Products.Add(P);
            context.SaveChanges();
            return P;
        }
        public Product Delete(int Id)
        {
            Product P = context.Products.Find(Id);
            if (P != null)
            {
                context.Products.Remove(P);
                context.SaveChanges();
            }
            return P;
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        public Product Get(int Id)

        {
            return context.Products.Find(Id);
        }
        public Product Update(Product P)
        {
            var Product =
            context.Products.Attach(P);
            Product.State = EntityState.Modified;
            context.SaveChanges();
            return P;
        }

        public IList<Product> GetProductsByCategoryID(int? CategoryId)
        {
            return context.Products.Where(prod =>
            prod.Id.Equals(CategoryId))
            .OrderBy(prod => prod.Designation)
            .Include(prod => prod.Category).ToList();

        }
        public IList<Product> FindByName(string name)
        {
            return context.Products.Where(prod =>
            prod.Designation.Contains(name)).Include(prod =>
            prod.Category).ToList();

        }
    }
}

