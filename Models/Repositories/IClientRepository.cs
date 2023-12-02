namespace MyNewProject.Models.Repositories
{
    public interface IClientRepository
    {
        IList<Client> GetAll();
        Client GetById(int id);
        void Add(Client cl);
        void Edit(Client cl);
        void Delete(Client cl);
    }
    
}
