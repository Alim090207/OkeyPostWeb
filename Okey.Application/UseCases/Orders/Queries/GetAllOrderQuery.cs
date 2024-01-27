using MediatR;
using Okey.Domain.Entities.Orders;

namespace Okey.Application.UseCases.Orders.Queries
{
    public class GetAllOrderQuery : IRequest<IEnumerable<Order>>
    {
    }
}
