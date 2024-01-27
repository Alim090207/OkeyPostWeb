using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Okey.Application.UseCases.Users.Commands;
using Okey.Application.UseCases.Users.Queries;
using Okey.Domain.Entities.Users;

namespace Wood.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
[EnableCors("AllowSpecificOrigin")]
public class UsersforBackController : ControllerBase
{

    private readonly IMediator _mediator;

    public UsersforBackController(IMediator mediator)
    {
        _mediator = mediator;

    }
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(CreateUserCommand users)
    {
        int result = await _mediator.Send(users);
        return Ok(result);
    }
    [HttpGet]

    public async ValueTask<IActionResult> GetAllAsync()
    {
        IEnumerable<User> classes = await _mediator.Send(new GetAllUsersQuery());

        return Ok(classes);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateUserCommand user)
    {
        int result = await _mediator.Send(user);
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(int classId)
    {
        DeleteUserCommand @class = new DeleteUserCommand()
        {
            Id = classId
        };

        int result = await _mediator.Send(@class);

        return Ok(result);
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(int Id)
    {
        GetUserByIdQuery doctor = new GetUserByIdQuery()
        {
            Id = Id,
        };

        User result = await _mediator.Send(doctor);

        return Ok(result);
    }
}

