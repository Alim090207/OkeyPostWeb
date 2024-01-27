using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okey.Application.UseCases.Orders.Commands
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime UpdatedAt { get; set; }

        public int ProductId { get; set; }
    }
}
