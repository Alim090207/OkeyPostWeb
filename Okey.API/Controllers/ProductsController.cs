using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Okey.Application.UseCases.Products.Commands;
using Okey.Application.UseCases.Products.Queries.GetAll;
using Okey.Application.UseCases.Products.Queries.GetById;
using Okey.Domain.DTOs.ProductsDTO;

namespace Okey.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        return Ok(await _mediator.Send(new GetAllProductQuery()));
    }

    [HttpGet("{Id}")]
    public async ValueTask<IActionResult> GetByIdAsync(int Id)
    {
        var result = await _mediator
            .Send(new GetProductByIdQuery { Id = Id });

        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm] CreateProductDTO dto)
    {
        var product = _mapper.Map<CreateProductCommand>(dto);

        var result = await _mediator.Send(product);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(int Id, UpdateProductDTO dto)
    {
        var product = _mapper.Map<UpdateProductCommand>(dto);
        product.Id = Id;
        var result = await _mediator.Send(product);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(int Id)
    {
        var result = await _mediator
            .Send(new DeleteProductCommand() { Id = Id });

        return Ok(result);
    }
}
