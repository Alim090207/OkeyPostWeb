using AutoMapper;
using Okey.Application.UseCases.Products.Commands;
using Okey.Domain.DTOs.ProductsDTO;
using Okey.Domain.Entities.Products;

namespace Okey.Application.Mappers
{
    public class ProductsMapper : Profile
    {
        public ProductsMapper()
        {
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();

            CreateMap<CreateProductDTO, CreateProductCommand>().ReverseMap();
            CreateMap<UpdateProductDTO, UpdateProductCommand>().ReverseMap();
        }
    }
}
