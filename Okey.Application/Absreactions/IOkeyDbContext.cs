using Microsoft.EntityFrameworkCore;
using Okey.Domain.Entities.Orders;
using Okey.Domain.Entities.Products;
using Okey.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okey.Application.Absreactions
{
    public interface IOkeyDbContext
    {
        public DbSet<User> user { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<Product> products { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
