using MediatR;
using Okey.Application.Absreactions;
using Okey.Application.UseCases.Orders.Commands;
using Okey.Domain.Entities.Orders;

namespace Okey.Application.UseCases.Orders.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOkeyDbContext _context;
        public CreateOrderCommandHandler(IOkeyDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // AmbulanceInfo? ambulanceInfo = await _context.amulanceInfo.FirstOrDefaultAsync(cancellationToken);

            Order info = new Order()
            {
                ProductId = request.ProductId,
                UserId = request.UserId,
            };
            await _context.order.AddAsync(info, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
