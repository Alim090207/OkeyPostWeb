using MediatR;
using Okey.Domain.DTOs.OrdersDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okey.Application.UseCases.Orders.Commands
{
    public class CreateOrderCommand : CreateOrderDTO, IRequest<int>
    {
    }
}
