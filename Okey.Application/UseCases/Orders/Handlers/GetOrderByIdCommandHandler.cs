using MediatR;
using Microsoft.EntityFrameworkCore;
using Okey.Application.Absreactions;
using Okey.Application.UseCases.Orders.Queries;
using Okey.Domain.Entities.Orders;

namespace Okey.Application.UseCases.Orders.Handlers
{
    public class GetOrderByIdCommandHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOkeyDbContext _context;

        public GetOrderByIdCommandHandler(IOkeyDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            Order ambulanceInfo = await _context.order.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return ambulanceInfo;
        }
    }
}
