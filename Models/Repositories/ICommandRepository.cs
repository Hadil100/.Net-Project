namespace MyNewProject.Models.Repositories
{
    public interface ICommandRepository
    {
        IList<Command> GetAll();
        Command GetById(int id);
        void Add(Command c);
        void Edit(Command c);
        void Delete(Command c);
    }
    
}
