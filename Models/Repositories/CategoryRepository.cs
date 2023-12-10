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
            // Vérifiez si une catégorie avec le même nom existe déjà
            var existingCategory = context.Categories.FirstOrDefault(c => c.CategoryName == cat.CategoryName);

            if (existingCategory == null)
            {
                // Aucune catégorie avec le même nom n'existe, vous pouvez l'ajouter
                context.Categories.Add(cat);
                context.SaveChanges();
            }
            else
            {
                // Une catégorie avec le même nom existe déjà, vous pouvez gérer cela selon vos besoins
                // Par exemple, déclencher une exception, mettre à jour la catégorie existante, etc.
                // Dans cet exemple, nous lançons une exception, mais vous pouvez adapter cela à vos besoins.
                throw new InvalidOperationException("Une catégorie avec le même nom existe déjà.");
            }
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

        public Category GetByName(string name)
        {
            return context.Categories.Find(name);
        }

    }
}
