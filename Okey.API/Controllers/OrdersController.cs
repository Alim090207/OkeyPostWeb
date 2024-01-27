using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Okey.Domain.DTOs.OrdersDTO;
using Okey.Application.UseCases.Orders.Commands;
using Okey.Application.UseCases.Orders.Queries;
using Microsoft.AspNetCore.Authorization;

namespace Okey.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class OkeyOrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public OkeyOrdersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        return Ok(await _mediator.Send(new GetAllOrderQuery()));
    }

    [HttpGet("{Id}")]
    [Authorize]
    public async ValueTask<IActionResult> GetByIdAsync(int Id)
    {
        var result = await _mediator
            .Send(new GetOrderByIdQuery { Id = Id });

        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(CreateOrderDTO dto)
    {
        var category = _mapper.Map<CreateOrderCommand>(dto);

        var result = await _mediator.Send(category);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(int Id, UpdateOrderDTO dto)
    {
        var category = _mapper.Map<CreateOrderDTO>(dto);
        category.Id = Id;
        var result = await _mediator.Send(category);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    [Authorize]
    public async Task<IActionResult> DeleteAsync(int Id)
    {
        var result = await _mediator
            .Send(new DeleteOrderCommand() { Id = Id });

        return Ok(result);
    }
}

