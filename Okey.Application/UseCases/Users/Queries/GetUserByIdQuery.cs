using MediatR;
using Okey.Domain.Entities.Users;

namespace Okey.Application.UseCases.Users.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
