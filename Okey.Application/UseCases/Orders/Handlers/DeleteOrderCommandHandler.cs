using MediatR;
using Microsoft.EntityFrameworkCore;
using Okey.Application.Absreactions;
using Okey.Application.UseCases.Orders.Commands;
using Okey.Domain.Entities.Orders;

namespace Okey.Application.UseCases.Orders.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, int>
    {
        private readonly IOkeyDbContext _context;
        public DeleteOrderCommandHandler(IOkeyDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            Order? @class = await _context.order.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            // if (@class == null)
            //  throw new Exception();

            _context.order.Remove(@class);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
