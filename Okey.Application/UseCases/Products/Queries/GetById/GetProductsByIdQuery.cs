using MediatR;
using Okey.Domain.Entities.Products;

namespace Okey.Application.UseCases.Products.Queries.GetById
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }

}
