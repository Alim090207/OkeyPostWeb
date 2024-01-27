using AutoMapper;
using MediatR;
using Okey.Application.Absreactions;
using Okey.Application.UseCases.Products.Commands;
using Okey.Domain.Entities.Products;

namespace Okey.Application.UseCases.Products.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IOkeyDbContext _context;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IOkeyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<Product>(request);

                entity.CreatedAt = DateTime.UtcNow;
               

                await _context.products.AddAsync(entity, cancellationToken);

                var result = await _context.SaveChangesAsync(cancellationToken);

                return result;
            }
            catch
            {
                return 0;
            }
        }
    }
}
