using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Okey.Application.Absreactions;
using Okey.Application.UseCases.Products.Commands;

namespace Okey.Application.UseCases.Products.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IOkeyDbContext _context;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IOkeyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _context.products
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (product is null)
                    throw new ArgumentNullException(nameof(product));


                _mapper.Map(request, product);

                product.UpdatedAt = DateTime.UtcNow;

                _context.products.Update(product);

                var result = await _context
                    .SaveChangesAsync(cancellationToken);

                return result;
            }
            catch
            {
                return 0;
            }
        }
    }
}
