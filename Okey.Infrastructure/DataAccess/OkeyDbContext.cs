using Microsoft.EntityFrameworkCore;
using Okey.Application.Absreactions;
using Okey.Domain.Entities.Orders;
using Okey.Domain.Entities.Products;
using Okey.Domain.Entities.Users;

namespace Okey.Infrastructure.DataAccess
{
    public class OkeyDbContext : DbContext, IOkeyDbContext
    {
        public OkeyDbContext(DbContextOptions<OkeyDbContext> options)
            : base(options)
        {
            /* var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
             try
             {
                 if (databaseCreator is null)
                 {
                     throw new Exception("Database Not Foundd!");
                 }

                 if (!databaseCreator.CanConnect())
                     databaseCreator.CreateAsync();

                 if (!databaseCreator.HasTables())
                     databaseCreator.CreateTablesAsync();

             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }*/

        }


        public DbSet<User> user { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(x => x.Products)
                .WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.User).WithMany(x => x.Products).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
