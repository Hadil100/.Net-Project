using Microsoft.AspNetCore.Http;

namespace MyNewProject.Models.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        readonly AppDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        public CommandRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public IEnumerable<Command> GetCommandsByUserId(string userId)
        {
            return context.Commands.Where(c => c.UserId == userId);
        }
        public IList<Command> GetAll()
        {
            return context.Commands.OrderBy(c => c.CommandId).ToList();
        }
        public Command GetById(int id)
        {
            return context.Commands.Find(id);
        }
        public void Add(Command c)
        {
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            Command command= context.Commands.Find(c.CommandId);
            if (command != null)
            {
                c.status = "Valide";
            }
            else
            {
                c.status = "Invalide";
                c.UserId = userName; 
                context.Commands.Add(c);
            }
            
            context.SaveChanges();
        }
        public void Edit(Command c)
        {
            Command c1 = context.Commands.Find(c.CommandId);
            if (c1 != null)
            {
                // c1.CartItems = c.CartItems;
                c1.UserId = c.UserId;
                c1.Total = c.Total;
                context.SaveChanges();
            }
        }
        public void Delete(Command c)
        {
            Command com = context.Commands.Find(c.CommandId);
            if (com != null)
            {
                context.Commands.Remove(com);
                context.SaveChanges();
            }
        }
       
    }
}
