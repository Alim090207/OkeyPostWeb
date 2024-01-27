using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okey.Application.UseCases.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {

        public string? Description { get; set; }
        public string? ProductName { get; set; }
        public int Price { get; set; }
        public int UserId { get; set; }
    }
}
