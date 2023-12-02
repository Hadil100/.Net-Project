using System.ComponentModel.DataAnnotations;

namespace MyNewProject.Models.Repositories
{
    public class ClientRepository : IClientRepository
    {
        readonly AppDbContext context;
        public ClientRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Client> GetAll()
        {
            return context.Clients.OrderBy(p => p.ClientFirstName).ToList();
        }
        public Client GetById(int id)
        {
            return context.Clients.Find(id);
        }
        public void Add(Client cl)
        {
            context.Clients.Add(cl);
            context.SaveChanges();
        }
        public void Edit(Client cl)
        {
            Client cl1 = context.Clients.Find(cl.ClientId);
            if (cl1 != null)
            {
                cl1.ClientFirstName = cl.ClientFirstName;
                cl1.ClientSecondName = cl.ClientSecondName;
                cl1.EmailAdress =  cl.EmailAdress;
                cl1.TelNumber = cl.TelNumber;
               
        context.SaveChanges();
            }
        }
        public void Delete(Client cl)
        {
            Client cl1 = context.Clients.Find(cl.ClientFirstName);
            if (cl1 != null)
            {
                context.Clients.Remove(cl1);
                context.SaveChanges();
            }
        }
       
    }
}
