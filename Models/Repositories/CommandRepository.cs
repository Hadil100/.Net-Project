namespace MyNewProject.Models.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        readonly AppDbContext context;
        public CommandRepository(AppDbContext context)
        {
            this.context = context;
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
            context.Commands.Add(c);
            context.SaveChanges();
        }
        public void Edit(Command c)
        {
            Command c1 = context.Commands.Find(c.CommandId);
            if (c1 != null)
            {
                c1.ProductList = c.ProductList;
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
