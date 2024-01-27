using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Okey.Application.Absreactions;
using Okey.Application.UseCases.Orders.Commands;

namespace Okey.Application.UseCases.Orders.Handlers
{

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IOkeyDbContext _context;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOkeyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _context.order
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (categories is null)
                    throw new ArgumentNullException(nameof(categories));

                _mapper.Map(request, categories);

                categories.UpdatedAt = DateTime.UtcNow;

                _context.order.Update(categories);

                var result = await _context
                    .SaveChangesAsync(cancellationToken);

                return result > 0;
            }
            catch
            {
                return false;
            }
        }
    }

}
