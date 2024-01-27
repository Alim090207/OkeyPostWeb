using MediatR;
using Microsoft.EntityFrameworkCore;
using Okey.Application.Absreactions;
using Okey.Application.UseCases.Products.Commands;

namespace Okey.Application.UseCases.Products.Handlers;

public class ProductDeleteCommandHandler : IRequestHandler<DeleteProductCommand, int>
{
    private readonly IOkeyDbContext _context;

    public ProductDeleteCommandHandler(IOkeyDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return 0;

        var products = await _context.products
            .FirstOrDefaultAsync(x => x.Id == request.Id,
            cancellationToken);

        if (products is null)
            return 0;

        _context.products.Remove(products);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result;
    }
}

