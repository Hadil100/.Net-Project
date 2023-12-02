using MyNewProject.Models;

namespace MyNewProject.Models.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Add(Category cat);
        void Edit(Category cat);
        void Delete(Category cat);
    }
}
