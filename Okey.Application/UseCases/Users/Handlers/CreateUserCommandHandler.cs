using MediatR;
using Okey.Application.Absreactions;
using Okey.Application.UseCases.Users.Commands;
using Okey.Domain.Entities.Users;

namespace Okey.Application.UseCases.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IOkeyDbContext _context;
        public CreateUserCommandHandler(IOkeyDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // AmbulanceInfo? ambulanceInfo = await _context.amulanceInfo.FirstOrDefaultAsync(cancellationToken);

            User info = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                UserName = request.UserName,
                Password = request.Password,
                Role = request.Role,
            };

            await _context.user.AddAsync(info, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
