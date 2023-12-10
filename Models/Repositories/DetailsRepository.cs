namespace MyNewProject.Models.Repositories
{
	public class DetailsRepository : IDetailsRepository
	{
		readonly AppDbContext context;
		public DetailsRepository(AppDbContext context)
		{
			this.context = context;
		}
		public IList<DetailsCommand> GetAll()
		{
			return context.DetailsCommands.OrderBy(c => c.Id).ToList();
		}
		public  DetailsCommand GetById(int id)
		{
			return context.DetailsCommands.Find(id);
		}
		public void Add( DetailsCommand c)
		{
			
			
			context.DetailsCommands.Add(c);

			context.SaveChanges();
		}
		public void Edit( DetailsCommand c)
		{
			 DetailsCommand c1 = context.DetailsCommands.Find(c.CommandId);
			if (c1 != null)
			{
				// c1.CartItems = c.CartItems;
				c1.CommandId = c.CommandId;
				c1.ProductId = c.ProductId;
				c1.Quantity = c1.Quantity;
				context.SaveChanges();
			}
		}
		public void Delete( DetailsCommand c)
		{
			 DetailsCommand com = context.DetailsCommands.Find(c.CommandId);
			if (com != null)
			{
				context.DetailsCommands.Remove(com);
				context.SaveChanges();
			}
		}

        public DetailsCommand GetByCommandId(int CommandId)
        {
            return context.DetailsCommands.FirstOrDefault(dc => dc.CommandId == CommandId);
        }

    }
}
