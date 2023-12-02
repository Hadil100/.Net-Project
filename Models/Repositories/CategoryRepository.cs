using MyNewProject.Models;

namespace MyNewProject.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;
        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Category> GetAll()
        {
            return context.Categories;
        }
        public Category GetById(int id)
        {
            return context.Categories.Find(id);
        }
        public void Add(Category cat)
        {
            context.Categories.Add(cat);
            context.SaveChanges();
        }
        public void Edit(Category cat)
        {
            Category C1 = context.Categories.Find(cat.CategoryId);
            if (C1 != null)
            {
                C1.CategoryName = cat.CategoryName;
                C1.Products = cat.Products;
                context.SaveChanges();
            }
        }
        public void Delete(Category cat)
        {
            Category categ = context.Categories.Find(cat.CategoryId);
            if (categ != null)
            {
                context.Categories.Remove(categ);
                context.SaveChanges();
            }
        }
        public int ProductCount(int Id)
        {
            return context.Products.Where(s => s.Id ==
            Id).Count();
        }

    }
}
