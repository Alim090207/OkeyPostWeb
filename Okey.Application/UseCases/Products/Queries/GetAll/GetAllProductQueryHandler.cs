using MediatR;
using Microsoft.EntityFrameworkCore;
using Okey.Application.Absreactions;
using Okey.Domain.Entities.Products;

namespace Okey.Application.UseCases.Products.Queries.GetAll
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private readonly IOkeyDbContext _context;

        public GetAllProductQueryHandler(IOkeyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await _context
                .products.Include(x => x.Orders)
                .ThenInclude(y => y.User)
                .ToListAsync(cancellationToken);
        }
    }

}
