namespace MyNewProject.Models.Repositories
{
    public interface IProductRepository
    {
        Product Get(int Id);
        IEnumerable<Product> GetAll();
        Product Add(Product product);
        Product Update(Product product);
        Product Delete(int Id);
        IList<Product> GetProductsBySchoolID(int? CategoryId);
        IList<Product> FindByName(string name);
    }
}
