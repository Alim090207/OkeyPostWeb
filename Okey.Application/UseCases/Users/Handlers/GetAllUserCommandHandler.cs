using MediatR;
using Microsoft.EntityFrameworkCore;
using Okey.Application.Absreactions;
using Okey.Application.UseCases.Users.Queries;
using Okey.Domain.Entities.Users;

namespace Okey.Application.UseCases.Users.Handlers
{
    public class GetAllUserCommandHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly IOkeyDbContext _context;

        public GetAllUserCommandHandler(IOkeyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> result = await _context.user.ToListAsync(cancellationToken);
            if (result == null)
                throw new Exception();
            return result;
        }
    }
}
