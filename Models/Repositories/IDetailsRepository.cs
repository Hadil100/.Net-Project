namespace MyNewProject.Models.Repositories
{
	public interface IDetailsRepository
	{
		IList<DetailsCommand> GetAll();
		DetailsCommand GetById(int id);
		void Add(DetailsCommand c);
		void Edit(DetailsCommand c);
		void Delete(DetailsCommand c);
		DetailsCommand GetByCommandId(int CommandId);

    }
}
