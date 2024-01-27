using MediatR;
using Microsoft.EntityFrameworkCore;
using Okey.Application.Absreactions;
using Okey.Application.UseCases.Users.Commands;
using Okey.Domain.Entities.Users;

namespace Okey.Application.UseCases.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IOkeyDbContext _context;

        public UpdateUserCommandHandler(IOkeyDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _context.user.FirstOrDefaultAsync(x => x.UserId == request.Id, cancellationToken);
            if (user == null)
                throw new Exception();

            user.UserId = request.Id;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.Address = request.Address;

            _context.user.Update(user);
            int result = await _context.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
