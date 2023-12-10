using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyNewProject.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<CartItem> ShoppingCardItems { get; set; }

        public DbSet<DetailsCommand> DetailsCommands { get; set; }

        public DbSet<Favorite> Favorites { get; set;}
    }
}
