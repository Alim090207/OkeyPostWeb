using MediatR;

namespace Okey.Application.UseCases.Users.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        //public CreateUserDTO dto { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
      
    }
}
