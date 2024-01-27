using MediatR;
using Okey.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okey.Application.UseCases.Orders.Queries
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
