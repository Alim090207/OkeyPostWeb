using AutoMapper;
using Okey.Application.UseCases.Orders.Commands;
using Okey.Domain.DTOs.OrdersDTO;
using Okey.Domain.Entities.Orders;

namespace Okey.Application.Mappers
{
    public class OrdersMapper : Profile
    {
        public OrdersMapper()
        { 
            CreateMap<Order, CreateOrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();

            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();

            CreateMap<CreateOrderDTO, CreateOrderCommand>().ReverseMap();
            CreateMap<UpdateOrderDTO, UpdateOrderCommand>().ReverseMap();
        }
    }
}
