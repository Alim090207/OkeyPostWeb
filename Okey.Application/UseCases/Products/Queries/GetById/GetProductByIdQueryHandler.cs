using MediatR;
using Microsoft.EntityFrameworkCore;
using Okey.Application.Absreactions;
using Okey.Domain.Entities.Products;

namespace Okey.Application.UseCases.Products.Queries.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IOkeyDbContext _context;

        public GetProductByIdQueryHandler(IOkeyDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.products
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            return result ?? throw new Exception("Product not found!");
        }
    }

}
