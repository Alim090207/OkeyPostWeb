using MediatR;
using Okey.Domain.DTOs.UsersDTO;

namespace Okey.Application.UseCases.Users.Commands
{
    public class UpdateUserCommand : CreateUserDTO, IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
