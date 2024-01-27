using MediatR;
using Microsoft.EntityFrameworkCore;
using Okey.Application.Absreactions;
using Okey.Application.UseCases.Orders.Queries;
using Okey.Domain.Entities.Orders;

namespace Okey.Application.UseCases.Orders.Handlers
{
    public class GetAllOrderCommandHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<Order>>
    {
        private readonly IOkeyDbContext _context;

        public GetAllOrderCommandHandler(IOkeyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            List<Order> result = await _context.order.ToListAsync(cancellationToken);
            if (result == null)
                throw new Exception();
            return result;
        }
    }
}
