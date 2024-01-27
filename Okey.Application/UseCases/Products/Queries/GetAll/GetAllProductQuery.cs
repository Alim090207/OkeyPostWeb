
using MediatR;
using Okey.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okey.Application.UseCases.Products.Queries.GetAll
{
    public class GetAllProductQuery : IRequest<IEnumerable<Product>>
    {
    }
}
