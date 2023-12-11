namespace MyNewProject.Models.Repositories
{
    public interface ICommandRepository
    {
        IList<Command> GetAll();
        IEnumerable<Command> GetCommandsByUserId(string userId);
        Command GetById(int id);
        void Add(Command c);
        void Edit(Command c);
        void Delete(Command c);
    }
    
}
